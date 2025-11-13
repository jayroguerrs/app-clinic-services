using DepilZone.Data.Interface;
using DepilZone.Entidad;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Data.Implement
{
    public class SedeDat: ISedeDat
    {
        private readonly string _connectionString;
        public SedeDat(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
        public async Task<IEnumerable<SedeEnt>> Obtener()
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Sede_Obtener", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
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
        public async Task<IEnumerable<SedeEnt>> ObtenerByLikeNombre(string Nombre)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Sede_ObtenerByLikeNombre", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("Nombre", Nombre);
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
        public async Task<Respuesta<SedeEnt>> Insertar(SedeEnt model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Sede_Insertar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pNombre", model.Nombre);
                cmd.Parameters.AddWithValue("pEstado", model.Estado);
                cmd.Parameters.AddWithValue("pDireccion", model.Direccion);
                cmd.Parameters.AddWithValue("pIdUbicacion", model.IdUbicacion);
                cmd.Parameters.AddWithValue("pUsuarioRegistra", model.UsuarioRegistra);
                cmd.Parameters.AddWithValue("@pHorainico", model.HoraInicio);
                cmd.Parameters.AddWithValue("@pHorafin", model.HoraFin);
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

        public async Task<Respuesta<SedeEnt>> Modificar(SedeEnt model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Sede_Modificar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdSede", model.IdSede);
                cmd.Parameters.AddWithValue("pNombre", model.Nombre);
                cmd.Parameters.AddWithValue("pEstado", model.Estado);
                cmd.Parameters.AddWithValue("pDireccion", model.Direccion);
                cmd.Parameters.AddWithValue("pIdUbicacion", model.IdUbicacion);
                cmd.Parameters.AddWithValue("pUsuarioEdita", model.UsuarioEdita);
                cmd.Parameters.AddWithValue("@pHoraInicio", model.HoraInicio);
                cmd.Parameters.AddWithValue("@pHorafin", model.HoraFin);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItem(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
          
        }

        public async Task<SedeEnt> ObtenerById(Int32 IdSede)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Sede_ObtenerByIdSede", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("IdSede", IdSede);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await Read(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        // READERS


        static async Task<SedeEnt> Read(DbDataReader reader)
        {
            try
            {
                SedeEnt obj = new SedeEnt();
                while (await reader.ReadAsync())
                {
                    obj.IdSede = Convert.ToInt32(reader["IdSede"]);
                    obj.IdUbicacion = reader["IdUbicacion"].ToString();
                    obj.Nombre = reader["Nombre"].ToString();
                    obj.Estado = Convert.ToInt32(reader["Estado"]);
                    obj.Direccion = reader["Direccion"].ToString();
                    obj.HoraInicio = reader["HoraInicio"].ToString();
                    obj.HoraFin = reader["HoraFin"].ToString();
                }


                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        static async Task<IEnumerable<SedeEnt>> ReadItems(DbDataReader reader)
        {
            try
            {
                IList<SedeEnt> lista = new List<SedeEnt>();
                while (await reader.ReadAsync())
                {
                    SedeEnt obj = new SedeEnt
                    {
                        IdSede = Convert.ToInt32(reader["IdSede"]),
                        IdUbicacion = reader["IdUbicacion"].ToString(),
                        Nombre = reader["Nombre"].ToString(),
                        Estado = Convert.ToInt32(reader["Estado"]),
                        Direccion = reader["Direccion"].ToString(),
                    };
                    obj.Ubicacion.IdUbicacion = reader["IdUbicacion"].ToString();
                    obj.Ubicacion.Departamento = reader["Departamento"].ToString();
                    obj.Ubicacion.Ciudad = reader["Ciudad"].ToString();
                    obj.Ubicacion.Distrito = reader["Distrito"].ToString();
                    obj.HoraInicio = reader["HoraInicio"].ToString();
                    obj.HoraFin = reader["HoraFin"].ToString();

                    lista.Add(obj);
                }


                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static async Task<Respuesta<SedeEnt>> ReadItem(DbDataReader reader)
        {
            try
            {
                Respuesta<SedeEnt> obj = new Respuesta<SedeEnt>
                {
                    Response = new SedeEnt()
                };
                while (await reader.ReadAsync())
                {
                    obj.Exito = Convert.ToBoolean(reader["Exito"]);
                    obj.Mensaje = Convert.ToString(reader["Mensaje"]);
                    if (obj.Exito)
                    {
                        obj.Response.IdSede = Convert.ToInt32(reader["IdSede"]);
                        obj.Response.Nombre = Convert.ToString(reader["Nombre"]);
                        obj.Response.Estado = Convert.ToInt32(reader["Estado"]);
                        obj.Response.IdUbicacion = reader["IdUbicacion"].ToString();
                        obj.Response.HoraInicio = reader["HoraInicio"].ToString();
                        obj.Response.HoraFin = reader["HoraFin"].ToString();
                    }
                }


                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}