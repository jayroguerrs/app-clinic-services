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
    public class IncidenciaDat : IIncidenciaDat
    {
        private readonly string _connectionString;
        public IncidenciaDat(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
        public async Task<Respuesta<IncidenciaEnt>> Insertar(IncidenciaEnt model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Incidencia_Insertar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdModuloSistema", model.IdModuloSistema);
                cmd.Parameters.AddWithValue("pDescripcion", model.Descripcion);
                cmd.Parameters.AddWithValue("pIdEstadoIncidencia", model.IdEstadoIncidencia);
                cmd.Parameters.AddWithValue("pIdUsuarioRegistra", model.IdUsuarioRegistra);
                cmd.Parameters.AddWithValue("pIdPrioridad", model.IdPrioridad);
                cmd.Parameters.AddWithValue("pFechaRegistra", model.FechaRegistra);
                cmd.Parameters.AddWithValue("pFechaPublica", model.FechaPublica);
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
        public async Task<Respuesta<IncidenciaEnt>> Modificar(IncidenciaEnt model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Incidencia_Modificar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdModuloSistema", model.IdModuloSistema);
                cmd.Parameters.AddWithValue("pDescripcion", model.Descripcion);
                cmd.Parameters.AddWithValue("pIdEstadoIncidencia", model.IdEstadoIncidencia);
                cmd.Parameters.AddWithValue("pIdUsuarioRegistra", model.IdUsuarioRegistra);
                cmd.Parameters.AddWithValue("pIdPrioridad", model.IdPrioridad);
                cmd.Parameters.AddWithValue("pFechaRegistra", model.FechaRegistra);
                cmd.Parameters.AddWithValue("pFechaPublica", model.FechaPublica);
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

        public  async Task<IncidenciaEnt> ObtenerById(int id)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Incidencia_ObtenerById", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdIncidencia", id);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItemObtenerById(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<IncidenciaListadoGrillaDTO>> ObtenerListado(int idEstado)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Incidencia_ObtenerListado", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdEstado", idEstado);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItemObtenerListado(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IncidenciaNivelAtencion> NivelAtencion()
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Incidencias_NivelAtencion", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadNivelAtencion(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        // READERS

        static async Task<Respuesta<IncidenciaEnt>> ReadItem(DbDataReader reader)
        {
            try
            {
                Respuesta<IncidenciaEnt> obj = new Respuesta<IncidenciaEnt>
                {
                    Response = new IncidenciaEnt()
                };
                while (await reader.ReadAsync())
                {
                    obj.Exito = Convert.ToBoolean(reader["Exito"]);
                    obj.Mensaje = Convert.ToString(reader["Mensaje"]);
                    if (obj.Exito)
                    {
                        obj.Response.Id = Convert.ToInt32(reader["Id"]);
                        obj.Response.IdModuloSistema = Convert.ToInt32(reader["IdModuloSistema"]);
                        obj.Response.Descripcion = reader["Descripcion"].ToString();
                        obj.Response.IdEstadoIncidencia = Convert.ToInt32(reader["IdEstadoIncidencia"]);
                        obj.Response.IdUsuarioRegistra = Convert.ToInt32(reader["IdUsuarioRegistra"]);
                        obj.Response.IdPrioridad = Convert.ToInt32(reader["IdPrioridad"]);
                        obj.Response.FechaRegistra = Convert.ToDateTime(reader["FechaRegistra"]);
                        obj.Response.FechaPublica = reader["FechaPublica"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["FechaPublica"]);
                    }
                }


                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static async Task<IncidenciaEnt> ReadItemObtenerById(DbDataReader reader)
        {
            try
            {
                IncidenciaEnt obj = new IncidenciaEnt();
                while (await reader.ReadAsync())
                {
                    obj.Id = Convert.ToInt32(reader["Id"]);
                    obj.IdModuloSistema = Convert.ToInt32(reader["IdModuloSistema"]);
                    obj.Descripcion = reader["Descripcion"].ToString();
                    obj.IdEstadoIncidencia = Convert.ToInt32(reader["IdEstadoIncidencia"]);
                    obj.IdUsuarioRegistra = Convert.ToInt32(reader["IdUsuarioRegistra"]);
                    obj.IdPrioridad = Convert.ToInt32(reader["IdPrioridad"]);
                    obj.FechaRegistra = Convert.ToDateTime(reader["FechaRegistra"]);
                    obj.FechaPublica = reader["FechaPublica"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["FechaPublica"]);
                }


                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static async Task<IEnumerable<IncidenciaListadoGrillaDTO>> ReadItemObtenerListado(DbDataReader reader)
        {
            try
            {
                IList<IncidenciaListadoGrillaDTO> lista = new List<IncidenciaListadoGrillaDTO>();
                while (await reader.ReadAsync())
                {
                    IncidenciaListadoGrillaDTO obj = new IncidenciaListadoGrillaDTO
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Descripcion = reader["Descripcion"].ToString(),
                        IdModuloSistema = Convert.ToInt32(reader["IdModuloSistema"]),
                        Modulo = reader["Modulo"].ToString(),
                        Prioridad = reader["Prioridad"].ToString(),
                        Usuario = reader["Usuario"].ToString(),
                        Estado = reader["Estado"].ToString(),
                        FechaPublica = reader["FechaPublica"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["FechaPublica"]),
                        FechaRegistra = Convert.ToDateTime(reader["FechaRegistra"])
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

        static async Task<IncidenciaNivelAtencion> ReadNivelAtencion(DbDataReader reader)
        {
            try
            {
                IncidenciaNivelAtencion obj = new IncidenciaNivelAtencion();
                while (await reader.ReadAsync())
                {
                    obj.NumeroCitas = Convert.ToInt32(reader["NumeroCitas"]);
                    obj.Total = Convert.ToDecimal(reader["Total"]);
                }

                return obj;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }


    }
}
