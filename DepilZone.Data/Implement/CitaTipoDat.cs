using DepilZone.Data.Interface;
using DepilZone.Entidad;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DepilZone.Data

{
    public class CitaTipoDat : ICitaTipoDat
    {
        private readonly string _connectionString;

        public CitaTipoDat(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
        public async Task<IEnumerable<CitaTipoEnt>> Obtener()
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_TipoCita_Obtener", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItems(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        public async Task<CitaTipoEnt> ObtenerById(Int32 IdTipoCita)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_TipoCita_ObtenerByIdTipoCita", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("IdTipoCita", IdTipoCita);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await Read(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        public async Task<Respuesta<CitaTipoEnt>> Insertar(CitaTipoEnt model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_TipoCita_Insertar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pNombre", model.Nombre);
                cmd.Parameters.AddWithValue("pIdEstado", model.IdEstado);
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

        public async Task<IEnumerable<CitaTipoEnt>> ObtenerByLikeNombre(string Nombre)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_TipoCita_ObtenerByLikeNombre", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("Nombre", Nombre);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItems(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        public async Task<Respuesta<CitaTipoEnt>> Modificar(CitaTipoEnt model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_TipoCita_Modificar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdTipoCita", model.IdTipoCita);
                cmd.Parameters.AddWithValue("pNombre", model.Nombre);
                cmd.Parameters.AddWithValue("pIdEstado", model.IdEstado);
                cmd.Parameters.AddWithValue("pUsuarioEdita", model.UsuarioEdita);
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

        // READERS

        static async Task<CitaTipoEnt> Read(DbDataReader reader)
        {
            try
            {
                CitaTipoEnt obj = new CitaTipoEnt();
                while (await reader.ReadAsync())
                {
                    obj.IdTipoCita = Convert.ToInt32(reader["IdTipoCita"]);
                    obj.Nombre = Convert.ToString(reader["Nombre"]);
                    obj.IdEstado = Convert.ToInt32(reader["IdEstado"]);
                }



                return obj;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        static async Task<Respuesta<CitaTipoEnt>> ReadItem(DbDataReader reader)
        {
            try
            {
                Respuesta<CitaTipoEnt> obj = new Respuesta<CitaTipoEnt>
                {
                    Response = new CitaTipoEnt()
                };
                while (await reader.ReadAsync())
                {
                    obj.Exito = Convert.ToBoolean(reader["Exito"]);
                    obj.Mensaje = Convert.ToString(reader["Mensaje"]);
                    obj.Response.IdTipoCita = Convert.ToInt32(reader["IdTipoCita"]);
                    obj.Response.Nombre = Convert.ToString(reader["Nombre"]);
                    obj.Response.IdEstado = Convert.ToInt32(reader["IdEstado"]);
                }



                return obj;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        static async Task<IEnumerable<CitaTipoEnt>> ReadItems(DbDataReader reader)
        {
            try
            {
                IList<CitaTipoEnt> lista = new List<CitaTipoEnt>();
                while (await reader.ReadAsync())
                {
                    CitaTipoEnt obj = new CitaTipoEnt
                    {
                        IdTipoCita = Convert.ToInt32(reader["IdTipoCita"]),
                        Nombre = reader["Nombre"].ToString(),
                        IdEstado = Convert.ToInt32(reader["IdEstado"]),
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

    }
}
