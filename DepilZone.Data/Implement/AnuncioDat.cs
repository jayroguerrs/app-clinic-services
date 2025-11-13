using DepilZone.Data.Interface;
using DepilZone.Entidad;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DepilZone.Data.Implement
{
    public class AnuncioDat : IAnuncioDat
    {
        private readonly string _connectionString;

        public AnuncioDat(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
        public async Task<Respuesta<AnuncioEnt>> Insertar(AnuncioEnt model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Anuncio_Insertar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pTitulo", model.Titulo);
                cmd.Parameters.AddWithValue("pInformacion", model.Informacion);
                cmd.Parameters.AddWithValue("pImagen", model.Imagen);
                cmd.Parameters.AddWithValue("pUsuarioRegistra", model.UsuarioRegistra);
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

        public async Task<Respuesta<AnuncioEnt>> Modificar(AnuncioEnt model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Anuncio_Modificar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pId", model.Id);
                cmd.Parameters.AddWithValue("pTitulo", model.Titulo);
                cmd.Parameters.AddWithValue("pInformacion", model.Informacion);
                cmd.Parameters.AddWithValue("pImagen", model.Imagen);
                cmd.Parameters.AddWithValue("pUsuarioEdita", model.UsuarioEdita);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItem(reader);

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        public async Task<IEnumerable<AnuncioEnt>> Obtener()
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Anuncio_Obtener", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItems(reader);

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        public async Task<AnuncioEnt> ObtenerById(int id)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Anuncio_ObtenerById", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("Id", id);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await Read(reader);

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }



        static async Task<Respuesta<AnuncioEnt>> ReadItem(DbDataReader reader)
        {
            try
            {
                Respuesta<AnuncioEnt> obj = new Respuesta<AnuncioEnt>
                {
                    Response = new AnuncioEnt()
                };
                while (await reader.ReadAsync())
                {
                    obj.Exito = Convert.ToBoolean(reader["Exito"]);
                    obj.Mensaje = Convert.ToString(reader["Mensaje"]);
                    if (obj.Exito)
                    {
                        obj.Response.Id = Convert.ToInt32(reader["Id"]);
                        obj.Response.Titulo = reader["Titulo"].ToString();
                        obj.Response.Informacion = reader["Informacion"].ToString();
                        obj.Response.Imagen = reader["Imagen"].ToString();
                    }
                }



                return obj;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        static async Task<IEnumerable<AnuncioEnt>> ReadItems(DbDataReader reader)
        {
            try
            {
                IList<AnuncioEnt> lista = new List<AnuncioEnt>();
                while (await reader.ReadAsync())
                {
                    AnuncioEnt obj = new AnuncioEnt
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Titulo = reader["Titulo"].ToString(),
                        Informacion = reader["Informacion"].ToString(),
                        Imagen = reader["Imagen"].ToString(),
                    };
                    lista.Add(obj);
                }



                return lista;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        static async Task<AnuncioEnt> Read(DbDataReader reader)
        {
            try
            {
                AnuncioEnt obj = new AnuncioEnt();
                while (await reader.ReadAsync())
                {
                    obj.Id = Convert.ToInt32(reader["Id"]);
                    obj.Titulo = reader["Titulo"].ToString();
                    obj.Informacion = reader["Informacion"].ToString();
                    obj.Imagen = reader["Imagen"].ToString();
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
