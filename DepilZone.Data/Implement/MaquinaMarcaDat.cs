using DepilZone.Data.Interface;
using DepilZone.Entidad.DTO;
using DepilZone.Entidad.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;

namespace DepilZone.Data.Implement
{
	public class MaquinaMarcaDat : IMaquinaMarcaDat
	{
        private readonly string _connectionString;
        public MaquinaMarcaDat(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
        public async Task<List<MaquinaMarcaSDTO>> Listar()
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_MaquinaMarca_Listar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadListar(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        public async Task<List<MaquinaMarcaSDTO>> ListarByServicio(int idServicio)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_MaquinaMarca_ListarByServicio", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdServicio", idServicio);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadListarByServicio(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        public async Task<List<MaquinaMarcaDTO>> Obtener()
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_MaquinaMarca_Obtener", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadObtener(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        public async Task<bool> Registrar(MaquinaMarcaDTO model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_MaquinaMarca_Insertar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pNombre", model.Nombre);
                cmd.Parameters.AddWithValue("pNombreCorto", model.NombreCorto);
                cmd.Parameters.AddWithValue("pIdUsuarioRegistro", model.IdUsuarioRegistro);
                cmd.Parameters.AddWithValue("pIdEstado", model.IdEstado);
                cmd.Parameters.AddWithValue("pIdServicios", JsonSerializer.Serialize(model.IdServicios));
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadRegistrar(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        public async Task<bool> Modificar(int id, MaquinaMarcaDTO model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_MaquinaMarca_Modificar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pId", id);
                cmd.Parameters.AddWithValue("pNombre", model.Nombre);
                cmd.Parameters.AddWithValue("pNombreCorto", model.NombreCorto);
                cmd.Parameters.AddWithValue("pIdUsuarioModifico", model.IdUsuarioModifico);
                cmd.Parameters.AddWithValue("pIdEstado", model.IdEstado);
                cmd.Parameters.AddWithValue("pIdServicios", JsonSerializer.Serialize(model.IdServicios));
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadModificar(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        // READERS

        static async Task<List<MaquinaMarcaDTO>> ReadObtener(DbDataReader reader)
        {
            try
            {
                List<MaquinaMarcaDTO> collection = new List<MaquinaMarcaDTO>();
                while (await reader.ReadAsync())
                {
                    MaquinaMarcaDTO obj = new MaquinaMarcaDTO();
                    obj.Id = Convert.ToInt32(reader["Id"]);
                    obj.Nombre = Convert.ToString(reader["Nombre"]);
                    obj.NombreCorto = Convert.ToString(reader["NombreCorto"]);
                    obj.IdEstado = Convert.ToInt32(reader["IdEstado"]);
                    obj.IdUsuarioRegistro = Convert.ToInt32(reader["IdUsuarioRegistro"]);
                    obj.IdUsuarioModifico = DBNull.Value != reader["IdUsuarioModifico"] ?  Convert.ToInt32(reader["IdUsuarioModifico"]) : (int?)null;
                    obj.UsuarioRegistro = Convert.ToString(reader["UsuarioRegistro"]);
                    obj.UsuarioModifico = DBNull.Value != reader["UsuarioModifico"] ? Convert.ToString(reader["UsuarioModifico"]) : null;
                    obj.FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"]);
                    obj.FechaModifico = DBNull.Value != reader["FechaModifico"] ? Convert.ToDateTime(reader["FechaModifico"]) : (DateTime?)null;
                    obj.Servicios = JsonSerializer.Deserialize<List<ServicioSDTO>>(Convert.ToString(reader["Servicios"]));
                    obj.IdServicios = JsonSerializer.Deserialize<List<int>>(Convert.ToString(reader["IdServicios"]));
                    collection.Add(obj);
                }

                return collection;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }


        static async Task<List<MaquinaMarcaSDTO>> ReadListar(DbDataReader reader)
        {
            try
            {
                List<MaquinaMarcaSDTO> collection = new List<MaquinaMarcaSDTO>();
                while (await reader.ReadAsync())
                {
                    MaquinaMarcaSDTO obj = new MaquinaMarcaSDTO();
                    obj.Id = Convert.ToInt32(reader["Id"]);
                    obj.Nombre = Convert.ToString(reader["Nombre"]);
                    obj.NombreCorto = Convert.ToString(reader["NombreCorto"]);
                    obj.IdEstado = Convert.ToInt32(reader["IdEstado"]);
                    collection.Add(obj);
                }

                return collection;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        static async Task<List<MaquinaMarcaSDTO>> ReadListarByServicio(DbDataReader reader)
        {
            try
            {
                List<MaquinaMarcaSDTO> collection = new List<MaquinaMarcaSDTO>();
                while (await reader.ReadAsync())
                {
                    MaquinaMarcaSDTO obj = new MaquinaMarcaSDTO();
                    obj.Id = Convert.ToInt32(reader["Id"]);
                    obj.Nombre = Convert.ToString(reader["Nombre"]);
                    obj.NombreCorto = Convert.ToString(reader["NombreCorto"]);
                    obj.IdEstado = Convert.ToInt32(reader["IdEstado"]);
                    collection.Add(obj);
                }

                return collection;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }


        static async Task<bool> ReadRegistrar(DbDataReader reader)
        {
            try
            {
                bool exito = true;
                string mensaje = "";
                string detalle = "";
                int codigoError = 0;
                while (await reader.ReadAsync())
                {
                    exito = Convert.ToBoolean(reader["Exito"]);
                    if (!exito)
                    {
                        mensaje = Convert.ToString(reader["Mensaje"]);
                        codigoError = Convert.ToInt32(reader["ErrorNumero"]);
                        detalle = Convert.ToString(reader["ErrorDetalle"]);
                        throw new AlertException(mensaje);
                    }
                }

                return exito;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        static async Task<bool> ReadModificar(DbDataReader reader)
        {
            try
            {
                bool exito = true;
                string mensaje = "";
                string detalle = "";
                int codigoError = 0;
                while (await reader.ReadAsync())
                {
                    exito = Convert.ToBoolean(reader["Exito"]);
                    if (!exito)
                    {
                        mensaje = Convert.ToString(reader["Mensaje"]);
                        codigoError = Convert.ToInt32(reader["ErrorNumero"]);
                        detalle = Convert.ToString(reader["ErrorDetalle"]);
                        throw new AlertException(mensaje);
                    }
                }

                return exito;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

    }
}
