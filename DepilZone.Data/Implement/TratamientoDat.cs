using DepilZone.Data.Interface;
using DepilZone.Entidad.DTO;
using DepilZone.Entidad.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DepilZone.Data.Implement
{
	public class TratamientoDat : ITratamientoDat
	{
        private readonly string _connectionString;
        public TratamientoDat(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
        public async Task<List<TratamientoDTO>> Listar()
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Tratamiento_Listar", conn)
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
        public async Task<List<TratamientoSDTO>> ListarToSelect()
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Tratamiento_ListarToSelect", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadListarToSelect(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        public async Task<List<TratamientoSDTO>> ListarByServicio(int idServicio)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Tratamiento_ListarByServicio", conn)
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
        public async Task<bool> Registrar(TratamientoDTO model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Tratamiento_Insertar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pNombre", model.Nombre);
                cmd.Parameters.AddWithValue("pIdServicio", model.IdServicio);
                cmd.Parameters.AddWithValue("pIdUsuarioRegistro", model.IdUsuarioRegistro);
                cmd.Parameters.AddWithValue("pIdEstado", model.IdEstado);
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
        public async Task<bool> Modificar(int id, TratamientoDTO model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Tratamiento_Modificar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pId", id);
                cmd.Parameters.AddWithValue("pNombre", model.Nombre);
                cmd.Parameters.AddWithValue("pIdServicio", model.IdServicio);
                cmd.Parameters.AddWithValue("pIdUsuarioModifico", model.IdUsuarioModifico);
                cmd.Parameters.AddWithValue("pIdEstado", model.IdEstado);
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

        static async Task<List<TratamientoDTO>> ReadListar(DbDataReader reader)
        {
            try
            {
                List<TratamientoDTO> collection = new List<TratamientoDTO>();
                while (await reader.ReadAsync())
                {
                    TratamientoDTO obj = new TratamientoDTO();
                    obj.Id = Convert.ToInt32(reader["Id"]);
                    obj.Nombre = Convert.ToString(reader["Nombre"]);
                    obj.IdEstado = Convert.ToInt32(reader["IdEstado"]);
                    obj.IdUsuarioRegistro = Convert.ToInt32(reader["IdUsuarioRegistro"]);
                    obj.IdUsuarioModifico = DBNull.Value != reader["IdUsuarioModifico"] ?  Convert.ToInt32(reader["IdUsuarioModifico"]) : (int?)null;
                    obj.UsuarioRegistro = Convert.ToString(reader["UsuarioRegistro"]);
                    obj.UsuarioModifico = DBNull.Value != reader["UsuarioModifico"] ? Convert.ToString(reader["UsuarioModifico"]) : null;
                    obj.FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"]);
                    obj.FechaModifico = DBNull.Value != reader["FechaModifico"] ? Convert.ToDateTime(reader["FechaModifico"]) : (DateTime?)null;
                    //obj.Estado = Convert.ToString(reader["Estado"]);
                    obj.IdServicio = Convert.ToInt32(reader["IdServicio"]);
                    obj.Servicio = Convert.ToString(reader["Servicio"]);
                    obj.ServicioColor = Convert.ToString(reader["ServicioColor"]);
                    collection.Add(obj);
                }

                return collection;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        static async Task<List<TratamientoSDTO>> ReadListarToSelect(DbDataReader reader)
        {
            try
            {
                List<TratamientoSDTO> collection = new List<TratamientoSDTO>();
                while (await reader.ReadAsync())
                {
                    TratamientoSDTO obj = new TratamientoSDTO();
                    obj.Id = Convert.ToInt32(reader["Id"]);
                    obj.Nombre = Convert.ToString(reader["Nombre"]);
                    obj.IdEstado = Convert.ToInt32(reader["IdEstado"]);
                    obj.IdServicio = Convert.ToInt32(reader["IdServicio"]);
                    collection.Add(obj);
                }

                return collection;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        static async Task<List<TratamientoSDTO>> ReadListarByServicio(DbDataReader reader)
        {
            try
            {
                List<TratamientoSDTO> collection = new List<TratamientoSDTO>();
                while (await reader.ReadAsync())
                {
                    TratamientoSDTO obj = new TratamientoSDTO();
                    obj.Id = Convert.ToInt32(reader["Id"]);
                    obj.Nombre = Convert.ToString(reader["Nombre"]);
                    obj.IdEstado = Convert.ToInt32(reader["IdEstado"]);
                    obj.IdServicio = Convert.ToInt32(reader["IdServicio"]);
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
