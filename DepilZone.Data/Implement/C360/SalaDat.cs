using DepilZone.Data.Interface.C360;
using DepilZone.Entidad.DTO.C360;
using DepilZone.Entidad.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text.Json;
using System.Threading.Tasks;

namespace DepilZone.Data.ImplementC360
{
	public class SalaDat : ISalaDat
	{
        private readonly string _connectionString;

        public SalaDat(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
        public async Task<List<SalaDTO>> Listar()
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("C360_SP_Sala_Listar", conn)
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
        public async Task<List<SalaDTO>> ListarByEstado(int idEstado)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("C360_SP_Sala_ListarByEstado", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdEstado", idEstado);
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
        public async Task<bool> Registrar(SalaDTO model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("C360_SP_Sala_Registrar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pNombre", model.Nombre);
                cmd.Parameters.AddWithValue("pIdSede", model.IdSede);
                cmd.Parameters.AddWithValue("pIdUsuarioRegistro", model.IdUsuarioRegistro);
                cmd.Parameters.AddWithValue("pIdServicios", JsonSerializer.Serialize(model.IdServicios));
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
        public async Task<bool> Modificar(int id, SalaDTO model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("C360_SP_Sala_Modificar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pId", id);
                cmd.Parameters.AddWithValue("pNombre", model.Nombre);
                cmd.Parameters.AddWithValue("pIdSede", model.IdSede);
                cmd.Parameters.AddWithValue("pIdUsuarioModifico", model.IdUsuarioModifico);
                cmd.Parameters.AddWithValue("pIdServicios", JsonSerializer.Serialize(model.IdServicios));
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

        static async Task<List<SalaDTO>> ReadListar(DbDataReader reader)
        {
            try
            {
                List<SalaDTO> collection = new List<SalaDTO>();
                while (await reader.ReadAsync())
                {
                    SalaDTO obj = new SalaDTO();
                    //var d = new List<int>(JsonSerializer.Deserialize<List<int>>(Convert.ToString(reader["IdServicios"])));
                    //var dd = Convert.ToString(reader["IdServicios"]);
                    obj.Id = Convert.ToInt32(reader["Id"]);
                    obj.Nombre = Convert.ToString(reader["Nombre"]);
                    obj.IdEstado = Convert.ToInt32(reader["IdEstado"]);
                    obj.IdSede = Convert.ToInt32(reader["IdSede"]);
                    obj.IdUsuarioRegistro = Convert.ToInt32(reader["IdUsuarioRegistro"]);
                    obj.IdUsuarioModifico = DBNull.Value != reader["IdUsuarioModifico"] ?  Convert.ToInt32(reader["IdUsuarioModifico"]) : (int?)null;
                    obj.UsuarioRegistro = Convert.ToString(reader["UsuarioRegistro"]);
                    obj.UsuarioModifico = DBNull.Value != reader["UsuarioModifico"] ? Convert.ToString(reader["UsuarioModifico"]) : null;
                    obj.FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"]);
                    obj.FechaModifico = DBNull.Value != reader["FechaModifico"] ? Convert.ToDateTime(reader["FechaModifico"]) : (DateTime?)null;
                    obj.Estado = Convert.ToString(reader["Estado"]);
                    obj.Sede = Convert.ToString(reader["Sede"]);
                    obj.IdServicios = new List<int>(JsonSerializer.Deserialize<List<int>>(Convert.ToString(reader["IdServicios"])));
                    obj.Servicios = new List<Servicios360DTO>(JsonSerializer.Deserialize<List<Servicios360DTO>>(Convert.ToString(reader["Servicios"])));
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
