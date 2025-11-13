
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
	public class FacturaMonedaDat : IFacturaMonedaDat
	{
        private readonly string _connectionString;

        public FacturaMonedaDat(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
        public async Task<List<FacturaMonedaDTO>> Listar(int idUsuario)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_FacturacionTipoMoneda_Listar", conn)
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
        public async Task<List<FacturaMonedaDTO>> Listar2(int idUsuario)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_FacturacionTipoMoneda_Listar2", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdUsuario", idUsuario);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadListar2(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        public async Task<FacturaMonedaDTO> Buscar(int id, int idUsuario)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_FacturacionTipoMoneda_BuscarPorId", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdUsuario", idUsuario);
                cmd.Parameters.AddWithValue("pId", id);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadBuscar(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        public async Task<bool> Registrar(FacturaMonedaDTO model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_FacturacionTipoMoneda_Insertar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pSimbolo", model.Simbolo);
                cmd.Parameters.AddWithValue("pDescripcion", model.Descripcion);
                cmd.Parameters.AddWithValue("pValor", model.Valor);
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
        public async Task<bool> Modificar(int id, FacturaMonedaDTO model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_FacturacionTipoMoneda_Modificar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pId", id);
                cmd.Parameters.AddWithValue("pSimbolo", model.Simbolo);
                cmd.Parameters.AddWithValue("pDescripcion", model.Descripcion);
                cmd.Parameters.AddWithValue("pValor", model.Valor);
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

        static async Task<List<FacturaMonedaDTO>> ReadListar(DbDataReader reader)
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


                List<FacturaMonedaDTO> collection = new List<FacturaMonedaDTO>();
                if (reader.NextResult())
                {
                    while (await reader.ReadAsync())
                    {
                        FacturaMonedaDTO obj = new FacturaMonedaDTO();
                        obj.Id = Convert.ToInt32(reader["Id"]);
                        obj.Simbolo = Convert.ToString(reader["Simbolo"]);
                        obj.Descripcion = DBNull.Value != reader["Descripcion"] ? Convert.ToString(reader["Descripcion"]) : null;
                        obj.Valor = Convert.ToString(reader["Valor"]);
                        obj.IdEstado = Convert.ToInt32(reader["IdEstado"]);
                        obj.Estado = Convert.ToString(reader["Estado"]);
                        obj.IdUsuarioRegistro = DBNull.Value != reader["IdUsuarioRegistro"] ? Convert.ToInt32(reader["IdUsuarioRegistro"]) : (int?)null;
                        obj.IdUsuarioModifico = DBNull.Value != reader["IdUsuarioModifico"] ? Convert.ToInt32(reader["IdUsuarioModifico"]) : (int?)null;
                        obj.UsuarioRegistro = DBNull.Value != reader["UsuarioRegistro"] ? Convert.ToString(reader["UsuarioRegistro"]) : null;
                        obj.UsuarioModifico = DBNull.Value != reader["UsuarioModifico"] ? Convert.ToString(reader["UsuarioModifico"]) : null;
                        obj.FechaRegistro = DBNull.Value != reader["FechaRegistro"] ? Convert.ToDateTime(reader["FechaRegistro"]) : (DateTime?)null;
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
        static async Task<List<FacturaMonedaDTO>> ReadListar2(DbDataReader reader)
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


                List<FacturaMonedaDTO> collection = new List<FacturaMonedaDTO>();
                if (reader.NextResult())
                {
                    while (await reader.ReadAsync())
                    {
                        FacturaMonedaDTO obj = new FacturaMonedaDTO();
                        obj.Id = Convert.ToInt32(reader["Id"]);
                        obj.Simbolo = Convert.ToString(reader["Simbolo"]);
                        obj.Descripcion = DBNull.Value != reader["Descripcion"] ? Convert.ToString(reader["Descripcion"]) : null;
                        obj.Valor = Convert.ToString(reader["Valor"]);
                        //obj.IdEstado = Convert.ToInt32(reader["IdEstado"]);
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
        static async Task<FacturaMonedaDTO> ReadBuscar(DbDataReader reader)
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

                FacturaMonedaDTO data = new FacturaMonedaDTO();
                if (reader.NextResult())
                {
                    while (await reader.ReadAsync())
                    {
                        data.Id = Convert.ToInt32(reader["Id"]);
                        data.Simbolo = Convert.ToString(reader["Simbolo"]);
                        data.Descripcion = DBNull.Value != reader["Descripcion"] ? Convert.ToString(reader["Descripcion"]) : null;
                        data.Valor = Convert.ToString(reader["Valor"]);
                        data.IdEstado = Convert.ToInt32(reader["IdEstado"]);
                        data.Estado = Convert.ToString(reader["Estado"]);
                        data.IdUsuarioRegistro = DBNull.Value != reader["IdUsuarioRegistro"] ? Convert.ToInt32(reader["IdUsuarioRegistro"]) : (int?)null;
                        data.IdUsuarioModifico = DBNull.Value != reader["IdUsuarioModifico"] ? Convert.ToInt32(reader["IdUsuarioModifico"]) : (int?)null;
                        data.UsuarioRegistro = DBNull.Value != reader["UsuarioRegistro"] ? Convert.ToString(reader["UsuarioRegistro"]) : null;
                        data.UsuarioModifico = DBNull.Value != reader["UsuarioModifico"] ? Convert.ToString(reader["UsuarioModifico"]) : null;
                        data.FechaRegistro = DBNull.Value != reader["FechaRegistro"] ? Convert.ToDateTime(reader["FechaRegistro"]) : (DateTime?)null;
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

    }
}
