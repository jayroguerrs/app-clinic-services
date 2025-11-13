using DepilZone.Data.Interface;
using DepilZone.Entidad;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DepilZone.Data
{
    public class MaquinaDat : IMaquinaDat
    {
        private readonly string _connectionString;
        public MaquinaDat(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
        public async Task<IEnumerable<MaquinaEnt>> Obtener()
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Maquina_Obtener", conn)
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
        public async Task<IEnumerable<MaquinaEnt>> ObtenerByLikeNombre(string Nombre)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Maquina_ObtenerByLikeNombre", conn)
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
        //public async Task<IEnumerable<MaquinaSedeEnt>> ObtenerByIdSede(int IdSede)
        //{
        //using SqlConnection conn = GetConnection();
        //await conn.OpenAsync();
        //using SqlCommand cmd = new SqlCommand("SP_Maquina_ObtenerByIdSede", conn)
        //{
        //    CommandType = System.Data.CommandType.StoredProcedure
        //};
        //cmd.Parameters.AddWithValue("IdSede", IdSede);
        //var reader = await cmd.ExecuteReaderAsync();
        //return await ReadItemsMaquinaSede(reader);
        //}
        public async Task<MaquinaEnt> ObtenerById(int id)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Maquina_ObtenerById", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("Id", id);
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
        public async Task<Respuesta<MaquinaEnt>> Insertar(MaquinaEnt model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Maquina_Insertar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("Descripcion", model.Descripcion);
                cmd.Parameters.AddWithValue("Color", model.Color);
                cmd.Parameters.AddWithValue("UsuarioRegistra", model.UsuarioRegistra);
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
        public async Task<Respuesta<MaquinaEnt>> Modificar(MaquinaEnt model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Maquina_Modificar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("Id", model.Id);
                cmd.Parameters.AddWithValue("Descripcion", model.Descripcion);
                cmd.Parameters.AddWithValue("Color", model.Color);
                cmd.Parameters.AddWithValue("IdEstado", model.IdEstado);
                cmd.Parameters.AddWithValue("UsuarioEdita", model.UsuarioEdita);
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


        public async Task<List<MaquinaMinutosEnt>> ObtenerMinutos(DateTime fechaCita, int idSede)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Maquina_ObtenerMinutos", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pFechaCita", fechaCita);
                cmd.Parameters.AddWithValue("pIdSede", idSede);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadMaquinaMinutos(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        // READERS


        static async Task<List<MaquinaMinutosEnt>> ReadMaquinaMinutos(DbDataReader reader)
        {
            try
            {
                List<MaquinaMinutosEnt> collection = new List<MaquinaMinutosEnt>();
                while (await reader.ReadAsync())
                {
                    MaquinaMinutosEnt obj = new MaquinaMinutosEnt()
                    {
                        Citas = Convert.ToInt32(reader["Citas"]),
                        IdMaquina = Convert.ToInt32(reader["IdMaquina"]),
                        Sede = reader["Sede"].ToString(),
                        Minutos = Convert.ToInt32(reader["Minutos"]),
                        Porcentaje = Convert.ToInt32(reader["Porcentaje"])
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

        static async Task<MaquinaEnt> Read(DbDataReader reader)
        {
            try
            {
                MaquinaEnt obj = new MaquinaEnt();
                while (await reader.ReadAsync())
                {
                    obj.Id = Convert.ToInt32(reader["Id"]);
                    obj.Descripcion = reader["Descripcion"].ToString();
                    obj.Color = Convert.ToString(reader["Color"]);
                    obj.IdEstado = Convert.ToInt32(reader["IdEstado"]);
                }



                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        static async Task<Respuesta<MaquinaEnt>> ReadItem(DbDataReader reader)
        {
            try
            {
                Respuesta<MaquinaEnt> obj = new Respuesta<MaquinaEnt>
                {
                    Response = new MaquinaEnt()
                };
                while (await reader.ReadAsync())
                {
                    obj.Exito = Convert.ToBoolean(reader["Exito"]);
                    obj.Mensaje = Convert.ToString(reader["Mensaje"]);
                    obj.Response.Id = Convert.ToInt32(reader["Id"]);
                    obj.Response.Descripcion = Convert.ToString(reader["Descripcion"]);
                    obj.Response.IdEstado = Convert.ToInt32(reader["IdEstado"]);
                }


                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        static async Task<IEnumerable<MaquinaEnt>> ReadItems(DbDataReader reader)
        {
            try
            {
                IList<MaquinaEnt> lista = new List<MaquinaEnt>();
                while (await reader.ReadAsync())
                {
                    MaquinaEnt obj = new MaquinaEnt
                    {
                        Id = reader.GetFieldValue<int>(0),
                        Descripcion = reader["Descripcion"].ToString(),
                        Color = Convert.ToString(reader["Color"]),
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