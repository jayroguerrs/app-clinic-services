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
	public class CitaMensajeDetalleDat : ICitaMensajeDetalleDat
	{
        private readonly string _connectionString;

        public CitaMensajeDetalleDat(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
        public async Task<IEnumerable<CitaMensajeDetalleEnt>> Obtener()
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Detalle_Obtener", conn)
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
        
        public async Task<CitaMensajeDetalleEnt> ObtenerById(int Id)
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

        public async Task<Respuesta<CitaMensajeDetalleEnt>> Insertar(CitaMensajeDetalleEnt model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Detalles_Insertar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                //cmd.Parameters.AddWithValue("IdSeguimientoCita", model.IdSeguimientoCita);
                cmd.Parameters.AddWithValue("Detalle", model.Detalle);
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
        public async Task<Respuesta<CitaMensajeDetalleEnt>> Modificar(CitaMensajeDetalleEnt model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Usuario_Modificar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("Nota", model.Detalle);
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

        public async Task<List<CitaMensajeDetalleDTO>> ListarByCita(int idCita)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_CitaMensajeDetalle_ListarByCita", conn)
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
        static async Task<IEnumerable<CitaMensajeDetalleEnt>> ReadItems(DbDataReader reader)
        {
            try
            {
                IList<CitaMensajeDetalleEnt> lista = new List<CitaMensajeDetalleEnt>();
                while (await reader.ReadAsync())
                {
                    CitaMensajeDetalleEnt obj = new CitaMensajeDetalleEnt
                    {
                        Id = reader.GetFieldValue<int>(0),
                        Detalle = reader["Detalle"].ToString(),
                        FechaRegistra = Convert.ToDateTime(reader["FechaRegistra"]),
                        IdUsuario = Convert.ToInt32(reader["IdUsuario"]),
                        IdCita = Convert.ToInt32(reader["IdCita"]),

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

        static async Task<CitaMensajeDetalleEnt> Read(DbDataReader reader)
        {
            try
            {
                CitaMensajeDetalleEnt obj = new CitaMensajeDetalleEnt();
                while (await reader.ReadAsync())
                {
                    obj.Id = Convert.ToInt32(reader["Id"]);
                    obj.Detalle = Convert.ToString(reader["Detalle"]);
                    obj.FechaRegistra = Convert.ToDateTime(reader["FechaRegistra"]);
                    obj.IdUsuario = Convert.ToInt32(reader["IdUsuario"]);
                    obj.IdCita = Convert.ToInt32(reader["IdCita"]);
                }



                return obj;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        static async Task<Respuesta<CitaMensajeDetalleEnt>> ReadItem(DbDataReader reader)
        {
            try
            {
                Respuesta<CitaMensajeDetalleEnt> obj = new Respuesta<CitaMensajeDetalleEnt>
                {
                    Response = new CitaMensajeDetalleEnt()
                };
                while (await reader.ReadAsync())
                {
                    obj.Exito = Convert.ToBoolean(reader["Exito"]);
                    obj.Mensaje = Convert.ToString(reader["Mensaje"]);
                    if (obj.Exito)
                    {
                        obj.Response.Id = Convert.ToInt32(reader["Id"]);
                        obj.Response.Detalle = Convert.ToString(reader["Detalle"]);
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

        static async Task<List<CitaMensajeDetalleDTO>> ReadListarByCita(DbDataReader reader)
        {
            try
            {
                List<CitaMensajeDetalleDTO> collection = new List<CitaMensajeDetalleDTO>();

                while (await reader.ReadAsync())
                {
                    CitaMensajeDetalleDTO obj = new CitaMensajeDetalleDTO();
                    obj.Id = Convert.ToInt32(reader["Id"]);
                    obj.IdCita = Convert.ToInt32(reader["IdCita"]);
                    obj.Texto = Convert.ToString(reader["Texto"]);
                    obj.Destacado = Convert.ToBoolean(reader["Destacado"]);
                    obj.FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"]);
                    obj.IdUsuarioRegistro = Convert.ToInt32(reader["IdUsuarioRegistro"]);
                    obj.UsuarioRegistro = Convert.ToString(reader["UsuarioRegistro"]);
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
