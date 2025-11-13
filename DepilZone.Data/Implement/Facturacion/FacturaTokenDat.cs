
using DepilZone.Data.Interface.Facturacion;
using DepilZone.Entidad.DTO.Facturacion;
using DepilZone.Entidad.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DepilZone.Data.Implement.Facturacion
{
	public class FacturaTokenDat : IFacturaTokenDat
	{
        private readonly string _connectionString;

        public FacturaTokenDat(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
        public async Task<List<FacturaTokenDTO>> Listar(int idUsuario)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_FacturacionToken_Listar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdUsuario", idUsuario);
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
        public async Task<FacturaTokenDTO> BuscarPorSede(int idUsuario, int idSede)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_FacturacionToken_BuscarPorSede", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdUsuario", idUsuario);
                cmd.Parameters.AddWithValue("pIdSede", idSede);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadBuscarPorSede(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        public async Task<FacturaTokenDTO> Buscar(int id, int idUsuario)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_FacturacionToken_BuscarPorId", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdUsuario", idUsuario);
                cmd.Parameters.AddWithValue("pId", id);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadBuscarPorSede(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        public async Task<bool> Registrar(FacturaTokenDTO model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_FacturacionToken_Insertar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pRuta", model.Ruta);
                cmd.Parameters.AddWithValue("pToken", model.Token);
                cmd.Parameters.AddWithValue("pIdSede", model.IdSede);
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
        public async Task<bool> Modificar(int id, FacturaTokenDTO model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_FacturacionToken_Modificar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pId", id);
                cmd.Parameters.AddWithValue("pRuta", model.Ruta);
                cmd.Parameters.AddWithValue("pToken", model.Token);
                cmd.Parameters.AddWithValue("pIdSede", model.IdSede);
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

        static async Task<List<FacturaTokenDTO>> ReadListar(DbDataReader reader)
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


                List<FacturaTokenDTO> collection = new List<FacturaTokenDTO>();
                if (reader.NextResult())
                {
                    while (await reader.ReadAsync())
                    {
                        FacturaTokenDTO obj = new FacturaTokenDTO();
                        obj.Id = Convert.ToInt32(reader["Id"]);
                        obj.Ruta = Convert.ToString(reader["Ruta"]);
                        obj.Token = Convert.ToString(reader["Token"]);
                        obj.IdEstado = Convert.ToInt32(reader["IdEstado"]);
                        obj.Estado = Convert.ToString(reader["Estado"]);
                        obj.IdSede = Convert.ToInt32(reader["IdSede"]);
                        obj.Sede = Convert.ToString(reader["Sede"]);
                        obj.IdUsuarioRegistro = Convert.ToInt32(reader["IdUsuarioRegistro"]);
                        obj.IdUsuarioModifico = DBNull.Value != reader["IdUsuarioModifico"] ? Convert.ToInt32(reader["IdUsuarioModifico"]) : (int?)null;
                        obj.UsuarioRegistro = Convert.ToString(reader["UsuarioRegistro"]);
                        obj.UsuarioModifico = DBNull.Value != reader["UsuarioModifico"] ? Convert.ToString(reader["UsuarioModifico"]) : null;
                        obj.FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"]);
                        obj.FechaModifico = DBNull.Value != reader["FechaModifico"] ? Convert.ToDateTime(reader["FechaModifico"]) : (DateTime?)null;
                        collection.Add(obj);
                    }
                }

                return collection;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        static async Task<FacturaTokenDTO> ReadBuscarPorSede(DbDataReader reader)
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

                FacturaTokenDTO data = new FacturaTokenDTO();
                if (reader.NextResult())
                {
                    while (await reader.ReadAsync())
                    {
                        data.Id = Convert.ToInt32(reader["Id"]);
                        data.Ruta = Convert.ToString(reader["Ruta"]);
                        data.Token = Convert.ToString(reader["Token"]);
                        data.IdEstado = Convert.ToInt32(reader["IdEstado"]);
                        data.Estado = Convert.ToString(reader["Estado"]);
                        data.IdSede = Convert.ToInt32(reader["IdSede"]);
                        data.Sede = Convert.ToString(reader["Sede"]);
                        data.IdUsuarioRegistro = Convert.ToInt32(reader["IdUsuarioRegistro"]);
                        data.IdUsuarioModifico = DBNull.Value != reader["IdUsuarioModifico"] ? Convert.ToInt32(reader["IdUsuarioModifico"]) : (int?)null;
                        data.UsuarioRegistro = Convert.ToString(reader["UsuarioRegistro"]);
                        data.UsuarioModifico = DBNull.Value != reader["UsuarioModifico"] ? Convert.ToString(reader["UsuarioModifico"]) : null;
                        data.FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"]);
                        data.FechaModifico = DBNull.Value != reader["FechaModifico"] ? Convert.ToDateTime(reader["FechaModifico"]) : (DateTime?)null;
                    }
                }

                return data;
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
