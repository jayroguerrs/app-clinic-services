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
    public class CitaEstadoMotivoDat : ICitaEstadoMotivoDat
    {
        private readonly string _connectionString;

        public CitaEstadoMotivoDat(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
        public async Task<List<CitaEstadoMotivoEnt>> Listar()
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_CitaEstadoMotivo_Listar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadCollection(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<CitaEstadoMotivoEnt> Grabar( CitaEstadoMotivoDTO model )
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_CitaEstadoMotivo_Insertar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdCita", model.IdCita);
                cmd.Parameters.AddWithValue("pIdMotivo", model.IdMotivo);
                cmd.Parameters.AddWithValue("pUsuarioRegistro", model.UsuarioRegistro);
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

        public async Task<List<CitaEstadoMotivoRespuestaEnt>> ObtenerReporteGeneral(CitaEstado_ParametrosDTO model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_CitaEstadoMotivo_ObtenerReporteGeneral", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdSede", model.IdSede);
                cmd.Parameters.AddWithValue("pFdesde", model.Fdesde);
                cmd.Parameters.AddWithValue("pFhasta", model.Fhasta);
                cmd.Parameters.AddWithValue("pIdCitaEstado", model.IdCitaEstado);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadReporteGeneral(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        // READERS

        static async Task<List<CitaEstadoMotivoEnt>> ReadCollection(DbDataReader reader)
        {
            try
            {
                List<CitaEstadoMotivoEnt> lista = new List<CitaEstadoMotivoEnt>();
                while (await reader.ReadAsync())
                {
                    CitaEstadoMotivoEnt obj = new CitaEstadoMotivoEnt
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        IdCita = Convert.ToInt32(reader["IdCita"]),
                        IdMotivo = Convert.ToInt32(reader["IdMotivo"]),
                        FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"]),
                        UsuarioRegistro = reader["UsuarioRegistro"].ToString(),
                        FechaModifico = reader["FechaModifico"] == DBNull.Value ? (DateTime?)null :Convert.ToDateTime(reader["FechaModifico"]),
                        UsuarioModifico = reader["UsuarioModifico"] == DBNull.Value ? null : reader["UsuarioModifico"].ToString(),
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

        static async Task<CitaEstadoMotivoEnt> ReadItem(DbDataReader reader)
        {
            try
            {
                CitaEstadoMotivoEnt obj = new CitaEstadoMotivoEnt();
                while (await reader.ReadAsync())
                {
                    obj.Id = Convert.ToInt32(reader["Id"]);
                    obj.IdCita = Convert.ToInt32(reader["IdCita"]);
                    obj.IdMotivo = Convert.ToInt32(reader["IdMotivo"]);
                    obj.FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"]);
                    obj.UsuarioRegistro = reader["UsuarioRegistro"].ToString();
                    obj.FechaModifico = reader["FechaModifico"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["FechaModifico"]);
                    obj.UsuarioModifico = reader["UsuarioModifico"] == DBNull.Value ? null : reader["UsuarioModifico"].ToString();
                }
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static async Task<List<CitaEstadoMotivoRespuestaEnt>> ReadReporteGeneral(DbDataReader reader)
        {
            try
            {
                List<CitaEstadoMotivoRespuestaEnt> lista = new List<CitaEstadoMotivoRespuestaEnt>();
                while (await reader.ReadAsync())
                {
                    CitaEstadoMotivoRespuestaEnt obj = new CitaEstadoMotivoRespuestaEnt
                    {
                        IdCita = Convert.ToInt32(reader["IdCita"]),
                        IdCliente = Convert.ToInt32(reader["IdCliente"]),
                        Cliente = reader["Cliente"].ToString(),
                        IdSede = Convert.ToInt32(reader["IdSede"]),
                        Genero = reader["Genero"].ToString(),
                        Estado = reader["Estado"].ToString(),
                        IdEstado = Convert.ToInt32(reader["IdEstado"]),
                        EstadoColor = reader["EstadoColor"].ToString(),
                        Motivo = reader["Motivo"].ToString(),
                        FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"]),
                        UsuarioRegistro = reader["UsuarioRegistro"].ToString()
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
