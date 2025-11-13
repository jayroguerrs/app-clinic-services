using DepilZone.Data.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DepilZone.Data.Implement
{
    public class EvolucionCitaMensualDat : IEvolucionCitaMensualDat
    {
        private readonly string _connectionString;
        public EvolucionCitaMensualDat(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
        public async Task<Respuesta<EvolucionCitaMensualEnt>> Insertar(DateTime fecha)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_EvolucionCitaMensual_Insertar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pFecha", fecha);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItemInsertar(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<EvolucionCitaMensualDTO> Obtener(DateTime fecha, int idSede)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_EvolucionCitaMensual_Obtener", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pFecha", fecha);
                cmd.Parameters.AddWithValue("pIdSede", idSede);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItemObtener(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // READERS

        static async Task<Respuesta<EvolucionCitaMensualEnt>> ReadItemInsertar(DbDataReader reader)
        {
            try
            {
                Respuesta<EvolucionCitaMensualEnt> obj = new Respuesta<EvolucionCitaMensualEnt>
                {
                    Response = new EvolucionCitaMensualEnt()
                };
                while (await reader.ReadAsync())
                {
                    obj.Exito = Convert.ToBoolean(reader["Exito"]);
                    obj.Mensaje = Convert.ToString(reader["Mensaje"]);
                    if (obj.Exito)
                    {
                        obj.Response.Id = Convert.ToInt32(reader["Id"]);
                        obj.Response.FechaProceso = Convert.ToDateTime(reader["FechaProceso"].ToString());
                    }
                }


                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        static async Task<EvolucionCitaMensualDTO> ReadItemObtener(DbDataReader reader)
        {
            try
            {
                EvolucionCitaMensualDTO datos = new EvolucionCitaMensualDTO();

                //PRIMERA CABECERA DE TABLA
                datos.Dias = new List<DiasPorMesEvolucionDTO>();
                while (await reader.ReadAsync())
                {
                    datos.Dias.Add(new DiasPorMesEvolucionDTO
                    {
                        Dias = Convert.ToInt32(reader["Dias"]),
                        Nombre = reader["Nombre"].ToString(),
                        Mes = Convert.ToInt32(reader["Mes"]),
                    });
                }

                //FECHAS AL SIGUIENTE MES - CABECER DE COLUMNAS
                datos.FechasSiguienteMes = new List<DateTime>();
                if (reader.NextResult())
                {
                    while (await reader.ReadAsync())
                    {
                        datos.FechasSiguienteMes.Add(Convert.ToDateTime(reader["Fecha"]));
                    }
                }


                //CABECERA DE FILAS HASTA EL MES ANTERIOR
                datos.EvolucionCitaMensual = new List<EvolucionCitaMensualCabeceraDTO>();
                if (reader.NextResult())
                {
                    while (await reader.ReadAsync())
                    {
                        datos.EvolucionCitaMensual.Add(new EvolucionCitaMensualCabeceraDTO
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            FechaProceso = Convert.ToDateTime(reader["FechaProceso"].ToString()),
                            Dia = Convert.ToInt32(reader["Dia"]),
                            Mes = Convert.ToInt32(reader["Mes"]),
                        });
                    }
                }

                //DATOS HASTA EL MES ANTERIOR
                IList<EvolucionCitaMensualDetalleDTO> listaDetalle = new List<EvolucionCitaMensualDetalleDTO>();
                if (reader.NextResult())
                {
                    while (await reader.ReadAsync())
                    {
                        listaDetalle.Add(new EvolucionCitaMensualDetalleDTO()
                        {
                            //Id = Convert.ToInt32(reader["Id"]),
                            IdEvolucionCitaMensual = Convert.ToInt32(reader["IdEvolucionCitaMensual"]),
                            Fecha = Convert.ToDateTime(reader["Fecha"]),
                            Citas = Convert.ToInt32(reader["Citas"]),
                            Dia = Convert.ToInt32(reader["Dia"]),
                            Mes = Convert.ToInt32(reader["Mes"]),
                            Anio = Convert.ToInt32(reader["Anio"]),
                        });
                    }
                }

                for (int i = 0; i < datos.EvolucionCitaMensual.Count; i++)
                {
                    List<EvolucionCitaMensualDetalleDTO> detalles = listaDetalle.Where(x => x.IdEvolucionCitaMensual == datos.EvolucionCitaMensual[i].Id).ToList();
                    if (detalles.Count > 0)
                    {
                        datos.EvolucionCitaMensual[i].Detalles = detalles;
                    }
                }



                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

