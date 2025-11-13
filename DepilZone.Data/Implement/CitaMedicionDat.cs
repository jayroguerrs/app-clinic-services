using DepilZone.Data.Interface;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DepilZone.Data.Implement
{
    public class CitaMedicionDat : ICitaMedicionDat
    {
        private readonly string _connectionString;

        public CitaMedicionDat(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
        public async Task Grabar(CitaMedicionDTO model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_CitaMedicion_Insertar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdCita", model.IdCita);
                cmd.Parameters.AddWithValue("pIdTipoMedicion", model.IdTipoMedicion);
                cmd.Parameters.AddWithValue("pIdAlternativa", model.IdAlternativaMedicion);
                cmd.Parameters.AddWithValue("pIdUsuarioRegistro", model.IdUsuarioRegistro);
                var reader = await cmd.ExecuteReaderAsync();

                await ReadGrabar(reader);

                conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public async Task<CitaMedicionDTO> ObtenerByIdCita(int idCita, int idTipoMedicion)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_CitaMedicion_ObtenerByCita", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdCita", idCita);
                cmd.Parameters.AddWithValue("pIdTipoMedicion", idTipoMedicion);
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

        public async Task<List<CitaMedicionDTO>> ObtenerReporteGeneral(CitaMedicion_ParametrosDTO model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_CitaEncuesta_ObtenerReporteGeneral", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdSede", model.IdSede);
                cmd.Parameters.AddWithValue("pFdesde", model.Fdesde);
                cmd.Parameters.AddWithValue("pFhasta", model.Fhasta);
                cmd.Parameters.AddWithValue("pIdTipoMedicion", model.IdTipoMedicion);
                cmd.Parameters.AddWithValue("pIdServicio", model.IdServicio);
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

        public async Task<CitasEncuestadasDTO> ObtenerCitasEncuestadas(DateTime Fdesde, DateTime Fhasta, int idSede)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_CitasEncuestadas", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pFechaDesde", Fdesde);
                cmd.Parameters.AddWithValue("pFechaHasta", Fhasta);
                cmd.Parameters.AddWithValue("pIdSede", idSede);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadCitasEncuestadas(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        // READERS

        static async Task<List<CitaMedicionDTO>> ReadItems(DbDataReader reader)
        {
            try
            {
                List<CitaMedicionDTO> collection = new List<CitaMedicionDTO>();
                while (await reader.ReadAsync())
                {
                    CitaMedicionDTO obj = new CitaMedicionDTO
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        IdCita = Convert.ToInt32(reader["IdCita"]),
                        IdTipoMedicion = Convert.ToInt32(reader["IdTipoMedicion"]),
                        IdAlternativaMedicion = Convert.ToInt32(reader["IdAlternativaMedicion"]),
                        FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"]),
                        IdUsuarioRegistro = Convert.ToInt32(reader["IdUsuarioRegistro"]),
                        UsuarioModifico = reader["UsuarioModifico"] == DBNull.Value ? null :reader["UsuarioModifico"].ToString(),
                        UsuarioRegistro = reader["UsuarioRegistro"].ToString(),
                        FechaModifico = reader["FechaModifico"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["FechaModifico"]),
                        IdUsuarioModifico = reader["IdUsuarioModifico"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["IdUsuarioModifico"]),
                    };
                    collection.Add(obj);
                }

                return collection;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static async Task<CitaMedicionDTO> ReadItem(DbDataReader reader)
        {
            try
            {
                CitaMedicionDTO output = null;
                while (await reader.ReadAsync())
                {
                    output = new CitaMedicionDTO
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        IdCita = Convert.ToInt32(reader["IdCita"]),
                        IdTipoMedicion = Convert.ToInt32(reader["IdTipoMedicion"]),
                        IdAlternativaMedicion = Convert.ToInt32(reader["IdAlternativaMedicion"]),
                        FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"]),
                        IdUsuarioRegistro = Convert.ToInt32(reader["IdUsuarioRegistro"]),
                        UsuarioModifico = reader["UsuarioModifico"] == DBNull.Value ? null : reader["UsuarioModifico"].ToString(),
                        UsuarioRegistro = reader["UsuarioRegistro"].ToString(),
                        FechaModifico = reader["FechaModifico"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["FechaModifico"]),
                        IdUsuarioModifico = reader["IdUsuarioModifico"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["IdUsuarioModifico"]),
                    };
                }

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static async Task<CitasEncuestadasDTO> ReadCitasEncuestadas(DbDataReader reader)
        {
            try
            {
                CitasEncuestadasDTO output = null;
                while (await reader.ReadAsync())
                {
                    output = new CitasEncuestadasDTO
                    {
                        TotalCitas = Convert.ToInt32(reader["CitasAtendidas"]),
                        TotalCitasPagadas = Convert.ToInt32(reader["CitasPagadas"]),
                        TotalSatisfaccion = Convert.ToInt32(reader["Satisfaccion"]),
                        TotalEfectividad = Convert.ToInt32(reader["Efectividad"])
                       
                    };
                }

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static async Task ReadGrabar(DbDataReader reader)
        {
            try
            {
                int Exito = 0;
                string Mensaje = "";

                while (await reader.ReadAsync())
                {
                    Exito = Convert.ToInt32(reader["Exito"]);
                    Mensaje = reader["Mensaje"].ToString();
                }

                if ( Exito == 0)
                {
                    throw new Exception(Mensaje);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static async Task<List<CitaMedicionDTO>> ReadReporteGeneral(DbDataReader reader)
        {
            try
            {
                List<CitaMedicionDTO> lista = new List<CitaMedicionDTO>();
                while (await reader.ReadAsync())
                {
                    CitaMedicionDTO obj = new CitaMedicionDTO
                    {
                        IdCita = Convert.ToInt32(reader["IdCita"]),
                        IdSede = Convert.ToInt32(reader["IdSede"]),
                        IdCliente = Convert.ToInt32(reader["IdCliente"]),
                        Cliente = reader["Cliente"].ToString(),
                        Genero = reader["Genero"].ToString(),
                        IdEstado = Convert.ToInt32(reader["IdEstado"]),
                        Estado = reader["Estado"].ToString(),
                        EstadoColor = reader["EstadoColor"].ToString(),
                        TipoMedicion = reader["TipoMedicion"].ToString(),
                        Alternativa = reader["Alternativa"].ToString(),
                        FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"]),
                        UsuarioRegistro = reader["UsuarioRegistro"].ToString(),
                        UsuarioAtendio = DBNull.Value == reader["UsuarioAtendio"] ? null :  reader["UsuarioAtendio"].ToString(),
                        IdServicio = Convert.ToInt32(reader["IdServicio"]),
                        Servicio = Convert.ToString(reader["Servicio"]),
                        ServicioColor = Convert.ToString(reader["ServicioColor"]),
                        SiguienteCita = DBNull.Value == reader["SiguienteCita"] ? (int?) null :  Convert.ToInt32(reader["SiguienteCita"]),
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
