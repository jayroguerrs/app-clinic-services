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
	public class CitaMensajeNotaDat : ICitaMensajeNotaDat
    {
        private readonly string _connectionString;

        public CitaMensajeNotaDat(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
        public async Task<IEnumerable<CitaMensajeNotaEnt>> Obtener()
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Notas_Obtener", conn)
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

        public async Task<CitaMensajeNotaEnt> ObtenerById(int Id)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Usuario_ObtenerByIdUsuario", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("Id", Id);
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
        
        public async Task<Respuesta<CitaMensajeNotaEnt>> Insertar(CitaMensajeNotaEnt model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Notas_Insertar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                //cmd.Parameters.AddWithValue("IdSeguimientoCita", model.IdSeguimientoCita);
                cmd.Parameters.AddWithValue("Nota", model.Nota);
                cmd.Parameters.AddWithValue("FechaRegistra", model.FechaRegistra);
                cmd.Parameters.AddWithValue("IdUsuario", model.IdUsuario);
                cmd.Parameters.AddWithValue("IdCita", model.IdCita);
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
        public async Task<Respuesta<CitaMensajeNotaEnt>> Modificar(CitaMensajeNotaEnt model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Usuario_Modificar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("Nota", model.Nota);
                cmd.Parameters.AddWithValue("FechaRegistra", model.FechaRegistra);
                cmd.Parameters.AddWithValue("IdUsuario", model.IdUsuario);
                cmd.Parameters.AddWithValue("IdCita", model.IdCita);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItem(reader);

                conn.Close();

                return output;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public async Task<List<CitaMensajeNotaDTO>> ListarByCita(int idCita)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_CitaMensajeNota_ListarByCita", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdCita", idCita);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadListarByCita(reader);

                conn.Close();

                return output;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }


        // READERS
        static async Task<IEnumerable<CitaMensajeNotaEnt>> ReadItems(DbDataReader reader)
        {
            try
            {
                IList<CitaMensajeNotaEnt> lista = new List<CitaMensajeNotaEnt>();
                while (await reader.ReadAsync())
                {
                    CitaMensajeNotaEnt obj = new CitaMensajeNotaEnt
                    {
                        Id = reader.GetFieldValue<int>(0),
                        Nota = reader["Nota"].ToString(),
                        FechaRegistra = Convert.ToDateTime(reader["FechaRegistra"]),
                        IdUsuario = Convert.ToInt32(reader["IdUsuario"]),
                        IdCita = Convert.ToInt32(reader["IdCita"]),

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

        static async Task<CitaMensajeNotaEnt> Read(DbDataReader reader)
        {
            try
            {
                CitaMensajeNotaEnt obj = new CitaMensajeNotaEnt();
                while (await reader.ReadAsync())
                {
                    obj.Id = Convert.ToInt32(reader["Id"]);
                    obj.Nota = Convert.ToString(reader["Nota"]);
                    obj.FechaRegistra = Convert.ToDateTime(reader["FechaRegistra"]);
                    obj.IdUsuario = Convert.ToInt32(reader["IdUsuario"]);
                    obj.IdCita = Convert.ToInt32(reader["IdCita"]);
                }



                return obj;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        static async Task<Respuesta<CitaMensajeNotaEnt>> ReadItem(DbDataReader reader)
        {
            try
            {
                Respuesta<CitaMensajeNotaEnt> obj = new Respuesta<CitaMensajeNotaEnt>
                {
                    Response = new CitaMensajeNotaEnt()
                };
                while (await reader.ReadAsync())
                {
                    obj.Exito = Convert.ToBoolean(reader["Exito"]);
                    obj.Mensaje = Convert.ToString(reader["Mensaje"]);
                    if (obj.Exito)
                    {
                        obj.Response.Id = Convert.ToInt32(reader["Id"]);
                        obj.Response.Nota = Convert.ToString(reader["Nota"]);
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


        static async Task<List<CitaMensajeNotaDTO>> ReadListarByCita(DbDataReader reader)
        {
            try
            {
                List<CitaMensajeNotaDTO> collection = new List<CitaMensajeNotaDTO>();
                while (await reader.ReadAsync())
                {
                    CitaMensajeNotaDTO obj = new CitaMensajeNotaDTO();
                    obj.Id = Convert.ToInt32(reader["Id"]);
                    obj.IdCita = Convert.ToInt32(reader["IdCita"]);
                    obj.Texto = Convert.ToString(reader["Texto"]);
                    obj.Destacado = Convert.ToBoolean(reader["Destacado"]);
                    obj.FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"]);
                    obj.IdUsuarioRegistro = Convert.ToInt32(reader["IdUsuarioRegistro"]);
                    obj.UsuarioRegistro = Convert.ToString(reader["UsuarioRegistro"]);
                    obj.IdCliente = Convert.ToInt32(reader["IdCliente"]);
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
