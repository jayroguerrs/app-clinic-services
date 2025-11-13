using DepilZone.Data.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DepilZone.Data.Implement
{
	public class EgresoDat : IEgresoDat
	{
        private readonly string _connectionString;

        public EgresoDat(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
        public async Task<Respuesta<EgresoEnt>> Insertar(EgresoEnt model)
        {
            
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Egreso_Insertar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pMonto", model.Monto);
                cmd.Parameters.AddWithValue("pIdCaja", model.IdCaja);
                cmd.Parameters.AddWithValue("pFecha", model.FechaStr);
                cmd.Parameters.AddWithValue("pIdSede", model.IdSede);
                cmd.Parameters.AddWithValue("pConcepto", model.Concepto);
                cmd.Parameters.AddWithValue("pObservacion", model.Observacion);
                cmd.Parameters.AddWithValue("pBeneficiario", model.Beneficiario);
                cmd.Parameters.AddWithValue("pUsuarioRegistra", model.UsuarioRegistra);

                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItem(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
       
        public async Task<IEnumerable<EgresoDTO>> Obtener(DateTime fechaInicio, DateTime fechaTermino)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Egreso_Obtener", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pFechaInicio", fechaInicio);
                cmd.Parameters.AddWithValue("pFechaTermino", fechaTermino);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItems(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> AnularEgreso(EgresoEnt model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Egreso_Anular", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pId", model.Id);
                int egresosAnulados = await cmd.ExecuteNonQueryAsync();

                var output = egresosAnulados > 0 ? true : false;

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
        // READERS

        static async Task<Respuesta<EgresoEnt>> ReadItem(DbDataReader reader)
        {
            try
            {
                Respuesta<EgresoEnt> obj = new Respuesta<EgresoEnt>
                {
                    Response = new EgresoEnt()
                };
                while (await reader.ReadAsync())
                {
                    obj.Exito = Convert.ToBoolean(reader["Exito"]);
                    obj.Mensaje = Convert.ToString(reader["Mensaje"]);
                    obj.ErrorDetalle = Convert.ToString(reader["ErrorDetalle"]);
                    obj.ErrorNumero = Convert.ToInt32(reader["ErrorNumero"]);

                    if (obj.Exito)
                    {
                        obj.Response.Id = Convert.ToInt32(reader["Id"]);
                        obj.Response.Monto = Convert.ToDecimal(reader["Monto"]);
                        obj.Response.IdCaja = Convert.ToInt32(reader["IdCaja"]);
                        //obj.Response.Caja = Convert.ToString(reader["Caja"]);
                        obj.Response.Beneficiario = Convert.ToString(reader["Beneficiario"]);
                        obj.Response.IdSede = Convert.ToInt32(reader["IdSede"]);
                        //obj.Response.Sede = Convert.ToString(reader["Sede"]);
                        obj.Response.Observacion = Convert.ToString(reader["Observacion"]);
                    }
                }



                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static async Task<IEnumerable<EgresoDTO>> ReadItems(DbDataReader reader)
        {
            try
            {
                IList<EgresoDTO> lista = new List<EgresoDTO>();
                while (await reader.ReadAsync())
                {
                    EgresoDTO obj = new EgresoDTO
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        IdCaja = Convert.ToInt32(reader["IdCaja"]),
                        Caja = Convert.ToString(reader["Caja"]),
                        Fecha = Convert.ToDateTime(reader["Fecha"]),
                        ResponsableCaja = Convert.ToString(reader["ResponsableCaja"]),
                        Beneficiario = Convert.ToString(reader["Beneficiario"]),
                        Sede = Convert.ToString(reader["Sede"]),
                        Concepto = Convert.ToString(reader["Concepto"]),
                        Monto = Convert.ToDecimal(reader["Monto"]),
                        IdEstado = Convert.ToInt32(reader["IdEstado"])
                    };
                    lista.Add(obj);
                }



                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

