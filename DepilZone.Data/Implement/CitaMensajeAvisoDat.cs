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
    public class CitaMensajeAvisoDat : ICitaMensajeAvisoDat
	{
        private readonly string _connectionString;

        public CitaMensajeAvisoDat(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
        public async Task<IEnumerable<CitaMensajeAvisoEnt>> Obtener(int idCita)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_CitaMensajeAviso_Obtener", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdCita", idCita);

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

        //public async Task<CitaMensajeAvisoEnt> ObtenerById(int Id)
        //{
        //    using SqlConnection conn = GetConnection();
        //    await conn.OpenAsync();
        //    using SqlCommand cmd = new SqlCommand("SP_Usuario_ObtenerByIdUsuario", conn)
        //    {
        //        CommandType = System.Data.CommandType.StoredProcedure
        //    };
        //    cmd.Parameters.AddWithValue("Id", Id);
        //    var reader = await cmd.ExecuteReaderAsync();
        //    return await Read(reader);
        //}

        //static async Task<CitaMensajeAvisoEnt> Read(DbDataReader reader)
        //{
        //    CitaMensajeAvisoEnt obj = new CitaMensajeAvisoEnt();
        //    while (await reader.ReadAsync())
        //    {
        //        obj.Id = Convert.ToInt32(reader["IdAvisos"]);
        //        obj.Aviso = Convert.ToString(reader["Avisos"]);
        //        obj.FechaRegistra = Convert.ToDateTime(reader["FechaRegistra"]);
        //        obj.IdUsuario = Convert.ToInt32(reader["IdUsuarios"]);
        //        obj.IdCita = Convert.ToInt32(reader["IdCita"]);
        //    }
        //    return obj;
        //}
        public async Task<Respuesta<CitaMensajeAvisoEnt>> Insertar(CitaMensajeAvisoEnt model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_CitaMensajeAviso_Insertar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("Aviso", model.Aviso);
                cmd.Parameters.AddWithValue("FechaRegistra", model.FechaRegistra);
                cmd.Parameters.AddWithValue("IdUsuario", model.IdUsuario);
                cmd.Parameters.AddWithValue("IdCita", model.IdCita);
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
        public async Task<Respuesta<CitaMensajeAvisoEnt>> Modificar(CitaMensajeAvisoEnt model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Avisos_Modificar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("Aviso", model.Aviso);
                cmd.Parameters.AddWithValue("FechaRegistra", model.FechaRegistra);
                cmd.Parameters.AddWithValue("IdUsuario", model.IdUsuario);
                cmd.Parameters.AddWithValue("IdCita", model.IdCita);
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



        public async Task<List<CitaMensajeAvisoDTO>> ListarByCita(int idCita)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_CitaMensajeAviso_ListarByCita", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdCita", idCita);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadListarByCita(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        // READERS
        static async Task<IEnumerable<CitaMensajeAvisoEnt>> ReadItems(DbDataReader reader)
        {
            try
            {
                IList<CitaMensajeAvisoEnt> lista = new List<CitaMensajeAvisoEnt>();
                while (await reader.ReadAsync())
                {
                    CitaMensajeAvisoEnt obj = new CitaMensajeAvisoEnt
                    {
                        Id = reader.GetFieldValue<int>(0),
                        Aviso = reader["Aviso"].ToString(),
                        FechaRegistra = Convert.ToDateTime(reader["FechaRegistra"]),
                        IdUsuario = Convert.ToInt32(reader["IdUsuario"]),
                        IdCita = Convert.ToInt32(reader["IdCita"]),
                        UsuarioRegistro = Convert.ToString(reader["UsuarioRegistro"]),

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
        static async Task<Respuesta<CitaMensajeAvisoEnt>> ReadItem(DbDataReader reader)
        {
            try
            {
                Respuesta<CitaMensajeAvisoEnt> obj = new Respuesta<CitaMensajeAvisoEnt>
                {
                    Response = new CitaMensajeAvisoEnt()
                };
                while (await reader.ReadAsync())
                {
                    obj.Exito = Convert.ToBoolean(reader["Exito"]);
                    obj.Mensaje = Convert.ToString(reader["Mensaje"]);
                    if (obj.Exito)
                    {
                        obj.Response.Id = Convert.ToInt32(reader["Id"]);
                        obj.Response.Aviso = Convert.ToString(reader["Aviso"]);
                        obj.Response.FechaRegistra = Convert.ToDateTime(reader["FechaRegistra"]);
                        obj.Response.IdUsuario = Convert.ToInt32(reader["IdUsuario"]);
                        obj.Response.IdCita = Convert.ToInt32(reader["IdCita"]);
                    }
                }



                return obj;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }


        static async Task<List<CitaMensajeAvisoDTO>> ReadListarByCita(DbDataReader reader)
        {
            try
            {
                List<CitaMensajeAvisoDTO> collection = new List<CitaMensajeAvisoDTO>();
                while (await reader.ReadAsync())
                {
                    CitaMensajeAvisoDTO obj = new CitaMensajeAvisoDTO();
                    obj.Id = Convert.ToInt32(reader["Id"]);
                    obj.Texto = Convert.ToString(reader["Texto"]);
                    obj.Destacado = Convert.ToBoolean(reader["Destacado"]);
                    obj.FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"]);
                    obj.IdUsuarioRegistro = Convert.ToInt32(reader["IdUsuarioRegistro"]);
                    obj.UsuarioRegistro = Convert.ToString(reader["UsuarioRegistro"]);
                    obj.IdCita = Convert.ToInt32(reader["IdCita"]);
                    collection.Add(obj);
                }

                return collection;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
    }
}
