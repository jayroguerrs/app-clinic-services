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
	public class RolesDat : IRolesDat
	{
        private readonly string _connectionString;
        public RolesDat(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
        public async Task<Respuesta<RolesEnt>> Insertar(RolesEnt model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("Sp_Roles_Insertar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("IdMenu", model.IdMenu);
                cmd.Parameters.AddWithValue("IdUsuario", model.IdUsuario);
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
        public async Task<Respuesta<RolesEnt>> Modificar(RolesEnt model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("Sp_Roles_Modificar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("IdMenu", model.IdMenu);
                cmd.Parameters.AddWithValue("IdUsuario", model.IdUsuario);
                cmd.Parameters.AddWithValue("IdAcceso", model.IdAcceso);
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

        public async Task<IEnumerable<RolesMenuEnt>> ObtenerById(int IdUsuario, int idModulo)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Roles_Obtener_IdUsuario", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("IdUsuario", IdUsuario);
                cmd.Parameters.AddWithValue("idModulo", idModulo);
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

        public async Task<IEnumerable<RolesUsuarioEnt>> ObtenerRoles(int IdUsuario)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Roles_Obtener_Id_Usuario", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("IdUsuario", IdUsuario);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadUsuarioItems(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<RolesUsuarioEnt>> ObtenerRolesMenu(int IdUsuario, int IdModulo)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Roles_Obtener_Id_Roles", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("IdUsuario", IdUsuario);
                cmd.Parameters.AddWithValue("IdModulo", IdModulo);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadUsuariorolesItems(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        // READERS 


        static async Task<Respuesta<RolesEnt>> ReadItem(DbDataReader reader)
        {
            try
            {
                Respuesta<RolesEnt> obj = new Respuesta<RolesEnt>
                {
                    Response = new RolesEnt()
                };
                while (await reader.ReadAsync())
                {
                    obj.Exito = Convert.ToBoolean(reader["Exito"]);
                    obj.Mensaje = Convert.ToString(reader["Mensaje"]);
                    obj.Response.IdAcceso = Convert.ToInt32(reader["IdAcceso"]);
                    obj.Response.IdMenu = Convert.ToInt32(reader["IdMenu"]);
                    obj.Response.IdUsuario = Convert.ToInt32(reader["IdUsuario"]);
                }


                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       
        static async Task<IEnumerable<RolesMenuEnt>> ReadItems(DbDataReader reader)
        {
            try
            {
                IList<RolesMenuEnt> lista = new List<RolesMenuEnt>();
                while (await reader.ReadAsync())
                {
                    RolesMenuEnt obj = new RolesMenuEnt
                    {
                        IdMenu = Convert.ToInt32(reader["IdMenu"]),
                        Menu = Convert.ToString(reader["Menu"]),
                        idModulo = Convert.ToInt32(reader["idModulo"]),
                        checkbox = Convert.ToBoolean(reader["checkbox"]),
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
       
        static async Task<IEnumerable<RolesUsuarioEnt>> ReadUsuarioItems(DbDataReader reader)
        {
            try
            {
                IList<RolesUsuarioEnt> lista = new List<RolesUsuarioEnt>();
                while (await reader.ReadAsync())
                {
                    RolesUsuarioEnt obj = new RolesUsuarioEnt
                    {
                        IdModulo = Convert.ToInt32(reader["IdModulo"]),
                        id = Convert.ToString(reader["id"]),
                        title = Convert.ToString(reader["title"]),
                        type = Convert.ToString(reader["type"]),
                        url = Convert.ToString(reader["url"]),
                        icon = Convert.ToString(reader["icon"]),
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
       
        static async Task<IEnumerable<RolesUsuarioEnt>> ReadUsuariorolesItems(DbDataReader reader)
        {
            try
            {
                IList<RolesUsuarioEnt> lista = new List<RolesUsuarioEnt>();
                while (await reader.ReadAsync())
                {
                    RolesUsuarioEnt obj = new RolesUsuarioEnt
                    {
                        IdModulo = Convert.ToInt32(reader["IdModulo"]),
                        id = Convert.ToString(reader["id"]),
                        title = Convert.ToString(reader["title"]),
                        type = Convert.ToString(reader["type"]),
                        url = Convert.ToString(reader["url"]),
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
