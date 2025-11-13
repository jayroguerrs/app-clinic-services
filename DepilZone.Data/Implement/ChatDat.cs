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
    public class ChatDat : IChatDat
    {
        private readonly string _connectionString;

        public ChatDat(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
        public async Task<Respuesta<ChatEnt>> Insertar(ChatEnt model)
        {
            using SqlConnection conn = GetConnection();
            await conn.OpenAsync();
            using SqlCommand cmd = new SqlCommand("SP_Chat_Insertar", conn)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("pIdDeUsuario", model.IdDeUsuario);
            cmd.Parameters.AddWithValue("pIdParaUsuario", model.IdParaUsuario);
            cmd.Parameters.AddWithValue("pTexto", model.Texto);
            var reader = await cmd.ExecuteReaderAsync();
            return await ReadItem(reader);
        }

        public async Task<Respuesta<ChatEnt>> Modificar(ChatEnt model)
        {
            using SqlConnection conn = GetConnection();
            await conn.OpenAsync();
            using SqlCommand cmd = new SqlCommand("SP_Chat_Modificar", conn)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("pId", model.Id);
            cmd.Parameters.AddWithValue("pEstadoTexto", model.EstadoTexto);
            var reader = await cmd.ExecuteReaderAsync();
            return await ReadItem(reader);
        }

        public async Task<IEnumerable<ChatUsuarioListaDTO>> Obtener(int idUsuario)
        {
            using SqlConnection conn = GetConnection();
            await conn.OpenAsync();
            using SqlCommand cmd = new SqlCommand("SP_Chat_ObtenerUsuario", conn)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("pIdUsuario", idUsuario);
            var reader = await cmd.ExecuteReaderAsync();
            return await ReadItems(reader);
        }
        public async Task<IEnumerable<ChatEnt>> ObtenerMensajes(int idDeUsuario, int idParaUsuario)
        {
            using SqlConnection conn = GetConnection();
            await conn.OpenAsync();
            using SqlCommand cmd = new SqlCommand("SP_Chat_ObtenerMensajePorContacto", conn)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("pIdDeUsuario", idDeUsuario);
            cmd.Parameters.AddWithValue("pIdParaUsuario", idParaUsuario);
            var reader = await cmd.ExecuteReaderAsync();
            return await ReadItemChat(reader);
        }

        public async Task<bool> ActualizaUltimaConexion(int idUsuario)
        {
            using SqlConnection conn = GetConnection();
            await conn.OpenAsync();
            using SqlCommand cmd = new SqlCommand("SP_Chat_ActualizaUltimaConexion", conn)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("pIdUsuario", idUsuario);
            var reader = await cmd.ExecuteReaderAsync();
            return true;
        }

        public async Task<bool> ActualizarMensajeLeido(int idDeUsuario, int idParaUsuario)
        {
            using SqlConnection conn = GetConnection();
            await conn.OpenAsync();
            using SqlCommand cmd = new SqlCommand("SP_Chat_ActualizaMensajeLeido", conn)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("pIdDeUsuario", idDeUsuario);
            cmd.Parameters.AddWithValue("pIdParaUsuario", idParaUsuario);
            var reader = await cmd.ExecuteReaderAsync();
            return true;
        }




        static async Task<IEnumerable<ChatUsuarioListaDTO>> ReadItems(DbDataReader reader)
        {
            IList<ChatUsuarioListaDTO> lista = new List<ChatUsuarioListaDTO>();
            while (await reader.ReadAsync())
            {
                ChatUsuarioListaDTO obj = new ChatUsuarioListaDTO
                {
                    IdUsuario = Convert.ToInt32(reader["IdUsuario"]),
                    Usuario = reader["Nombre"].ToString(),
                    MensajeSinLeer = Convert.ToInt32(reader["MensajeSinLeer"].ToString()),
                    Foto = reader["Foto"].ToString(),
                    UltimaConexion = reader["UltimaConexion"].ToString(),
                    Estado = Convert.ToInt32(reader["Estado"].ToString())
                };
                lista.Add(obj);
            }
            return lista;
        }

        static async Task<IEnumerable<ChatEnt>> ReadItemChat(DbDataReader reader)
        {
            IList<ChatEnt> lista = new List<ChatEnt>();
            while (await reader.ReadAsync())
            {
                ChatEnt obj = new ChatEnt
                {
                    Id = Guid.Parse(reader["Id"].ToString()),
                    IdDeUsuario = Convert.ToInt32(reader["IdDeUsuario"]),
                    IdParaUsuario = Convert.ToInt32(reader["IdParaUsuario"]),
                    FechaHora = Convert.ToDateTime(reader["FechaHora"].ToString()),
                    Texto = reader["Texto"].ToString(),
                    EstadoTexto = Convert.ToInt32(reader["EstadoTexto"].ToString())
                };
                lista.Add(obj);
            }
            return lista;
        }

        static async Task<Respuesta<ChatEnt>> ReadItem(DbDataReader reader)
        {
            Respuesta<ChatEnt> obj = new Respuesta<ChatEnt>
            {
                Response = new ChatEnt()
            };
            while (await reader.ReadAsync())
            {
                obj.Exito = Convert.ToBoolean(reader["Exito"]);
                obj.Mensaje = Convert.ToString(reader["Mensaje"]);
                if (obj.Exito)
                {
                    obj.Response.Id = Guid.Parse(reader["Id"].ToString());
                    obj.Response.IdDeUsuario= Convert.ToInt32(reader["IdDeUsuario"]);
                    obj.Response.IdParaUsuario = Convert.ToInt32(reader["IdParaUsuario"]);
                    obj.Response.Texto = reader["Texto"].ToString();
                    obj.Response.FechaHora = Convert.ToDateTime(reader["FechaHora"]);
                }
            }
            return obj;
        }
    }
}
