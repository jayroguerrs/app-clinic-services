
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
	public class FacturaDatosClienteDat : IFacturaDatosClienteDat
	{
        private readonly string _connectionString;

        public FacturaDatosClienteDat(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
        public async Task<List<FacturaDatosClienteDTO>> ListarByCliente(int idUsuario, int idCliente)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_FacturacionCliente_Listar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdUsuario", idUsuario);
                cmd.Parameters.AddWithValue("pIdCliente", idCliente);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadListarByCliente(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        public async Task<List<FacturaDatosClienteDTO>> ListarByCliente2(int idUsuario,int idCliente)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_FacturacionCliente_ListarByCliente2", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdUsuario", idUsuario);
                cmd.Parameters.AddWithValue("pIdCliente", idCliente);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadListarByCliente2(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        public async Task<FacturaDatosClienteDTO> Buscar(int id, int idUsuario)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_FacturacionCliente_BuscarPorId", conn)
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
        public async Task<FacturaDatosClienteDTO> BuscarPredeterminado(int idCliente, int IdTipoComprobante, int idUsuario)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_FacturacionCliente_BuscarPredeterminado", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdCliente", idCliente);
                cmd.Parameters.AddWithValue("pIdUsuario", idUsuario);
                cmd.Parameters.AddWithValue("pIdTipoComprobante", IdTipoComprobante);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadBuscarPredeterminado(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        public async Task<bool> Registrar(FacturaDatosClienteDTO model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_FacturacionCliente_Insertar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                //cmd.Parameters.AddWithValue("pIdCliente", model.IdCliente);
                cmd.Parameters.AddWithValue("pIdTipoDocumento", model.IdTipoDocumento);
                cmd.Parameters.AddWithValue("pNumeroDocumento", model.NumeroDocumento);
                cmd.Parameters.AddWithValue("pDenominacion", model.Denominacion);
                cmd.Parameters.AddWithValue("pDireccion", model.Direccion);
                cmd.Parameters.AddWithValue("pIdUsuarioRegistro", model.IdUsuarioRegistro);
                cmd.Parameters.AddWithValue("pIdEstado", model.IdEstado);
                //cmd.Parameters.AddWithValue("pPredeterminado", model.Predeterminado);
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
        public async Task<bool> Modificar(int id, FacturaDatosClienteDTO model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_FacturacionCliente_Modificar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pId", id);
                //cmd.Parameters.AddWithValue("pIdCliente", model.IdCliente);
                cmd.Parameters.AddWithValue("pIdTipoDocumento", model.IdTipoDocumento);
                cmd.Parameters.AddWithValue("pNumeroDocumento", model.NumeroDocumento);
                cmd.Parameters.AddWithValue("pDenominacion", model.Denominacion);
                cmd.Parameters.AddWithValue("pDireccion", model.Direccion);
                cmd.Parameters.AddWithValue("pIdUsuarioRegistro", model.IdUsuarioRegistro);
                cmd.Parameters.AddWithValue("pIdEstado", model.IdEstado);
                //cmd.Parameters.AddWithValue("pPredeterminado", model.Predeterminado);
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

        public async Task<FacturaDatosClienteDTO> BuscarPorNumeroDocumento(string numeroDocumento, int idUsuario)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_FacturacionCliente_BuscarPorNumeroDocumento", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdUsuario", idUsuario);
                cmd.Parameters.AddWithValue("pNumeroDocumento", numeroDocumento);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadBuscarPorNumeroDocumento(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        // READERS

        static async Task<List<FacturaDatosClienteDTO>> ReadListarByCliente(DbDataReader reader)
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


                List<FacturaDatosClienteDTO> collection = new List<FacturaDatosClienteDTO>();
                if (reader.NextResult())
                {
                    while (await reader.ReadAsync())
                    {
                        FacturaDatosClienteDTO obj = new FacturaDatosClienteDTO();
                        obj.Id = Convert.ToInt32(reader["Id"]);
                        //obj.IdCliente = Convert.ToInt32(reader["IdCliente"]);
                        obj.IdTipoDocumento = Convert.ToInt32(reader["IdTipoDocumento"]);
                        obj.TipoDocumento = Convert.ToString(reader["TipoDocumento"]);
                        obj.TipoDocumentoValor = Convert.ToString(reader["TipoDocumentoValor"]);
                        obj.NumeroDocumento = Convert.ToString(reader["NumeroDocumento"]);
                        obj.Denominacion = Convert.ToString(reader["Denominacion"]);
                        obj.Direccion = Convert.ToString(reader["Direccion"]);
                        obj.IdEstado = Convert.ToInt32(reader["IdEstado"]);
                        //obj.Predeterminado = Convert.ToBoolean(reader["Predeterminado"]);
                        obj.Estado = Convert.ToString(reader["Estado"]);
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
        static async Task<List<FacturaDatosClienteDTO>> ReadListarByCliente2(DbDataReader reader)
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


                List<FacturaDatosClienteDTO> collection = new List<FacturaDatosClienteDTO>();
                if (reader.NextResult())
                {
                    while (await reader.ReadAsync())
                    {
                        FacturaDatosClienteDTO obj = new FacturaDatosClienteDTO();
                        obj.Id = Convert.ToInt32(reader["Id"]);
                        obj.IdCliente = Convert.ToInt32(reader["IdCliente"]);
                        obj.IdTipoDocumento = Convert.ToInt32(reader["IdTipoDocumento"]);
                        obj.TipoDocumento = Convert.ToString(reader["TipoDocumento"]);
                        obj.TipoDocumentoValor = Convert.ToString(reader["TipoDocumentoValor"]);
                        obj.NumeroDocumento = Convert.ToString(reader["NumeroDocumento"]);
                        obj.Denominacion = Convert.ToString(reader["Denominacion"]);
                        obj.Direccion = Convert.ToString(reader["Direccion"]);
                        obj.IdEstado = Convert.ToInt32(reader["IdEstado"]);
                        obj.Predeterminado = Convert.ToBoolean(reader["Predeterminado"]);
                        obj.Estado = Convert.ToString(reader["Estado"]);
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
        static async Task<FacturaDatosClienteDTO> ReadBuscar(DbDataReader reader)
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

                FacturaDatosClienteDTO data = new FacturaDatosClienteDTO();
                if (reader.NextResult())
                {
                    while (await reader.ReadAsync())
                    {
                        data.Id = Convert.ToInt32(reader["Id"]);
                        data.IdCliente = Convert.ToInt32(reader["IdCliente"]);
                        data.IdTipoDocumento = Convert.ToInt32(reader["IdTipoDocumento"]);
                        data.NumeroDocumento = Convert.ToString(reader["NumeroDocumento"]);
                        data.Denominacion = Convert.ToString(reader["Denominacion"]);
                        data.Direccion = Convert.ToString(reader["Direccion"]);
                        data.IdEstado = Convert.ToInt32(reader["IdEstado"]);
                        data.Estado = Convert.ToString(reader["Estado"]);
                        data.Predeterminado = Convert.ToBoolean(reader["Predeterminado"]);
                        data.IdUsuarioRegistro = Convert.ToInt32(reader["IdUsuarioRegistro"]);
                        data.IdUsuarioModifico = DBNull.Value != reader["IdUsuarioModifico"] ? Convert.ToInt32(reader["IdUsuarioModifico"]) : (int?)null;
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

        static async Task<FacturaDatosClienteDTO> ReadBuscarPredeterminado(DbDataReader reader)
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

                FacturaDatosClienteDTO data = new FacturaDatosClienteDTO();
                if (reader.NextResult())
                {
                    while (await reader.ReadAsync())
                    {
                        data.Id = Convert.ToInt32(reader["Id"]);
                        data.IdCliente = Convert.ToInt32(reader["IdCliente"]);
                        data.IdTipoDocumento = Convert.ToInt32(reader["IdTipoDocumento"]);
                        data.TipoDocumento = Convert.ToString(reader["TipoDocumento"]);
                        data.TipoDocumentoValor = Convert.ToString(reader["TipoDocumentoValor"]);
                        data.NumeroDocumento = Convert.ToString(reader["NumeroDocumento"]);
                        data.Denominacion = Convert.ToString(reader["Denominacion"]);
                        data.Direccion = Convert.ToString(reader["Direccion"]);
                        data.IdEstado = Convert.ToInt32(reader["IdEstado"]);
                        data.Estado = Convert.ToString(reader["Estado"]);
                        //data.Predeterminado = Convert.ToBoolean(reader["Predeterminado"]);
                        data.IdUsuarioRegistro = Convert.ToInt32(reader["IdUsuarioRegistro"]);
                        data.IdUsuarioModifico = DBNull.Value != reader["IdUsuarioModifico"] ? Convert.ToInt32(reader["IdUsuarioModifico"]) : (int?)null;
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



        static async Task<FacturaDatosClienteDTO> ReadBuscarPorNumeroDocumento(DbDataReader reader)
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

                FacturaDatosClienteDTO? data = null;
                if (reader.NextResult())
                {
                    while (await reader.ReadAsync())
                    {
                        data = new FacturaDatosClienteDTO();
                        data.Id = Convert.ToInt32(reader["Id"]);
                        data.IdTipoDocumento = Convert.ToInt32(reader["IdTipoDocumento"]);
                        data.NumeroDocumento = Convert.ToString(reader["NumeroDocumento"]);
                        data.TipoDocumento = Convert.ToString(reader["TipoDocumento"]);
                        data.TipoDocumentoValor = Convert.ToString(reader["TipoDocumentoValor"]);
                        data.Denominacion = Convert.ToString(reader["Denominacion"]);
                        data.Direccion = Convert.ToString(reader["Direccion"]);
                        data.IdEstado = Convert.ToInt32(reader["IdEstado"]);
                        data.Estado = Convert.ToString(reader["Estado"]);
                        //data.Predeterminado = Convert.ToBoolean(reader["Predeterminado"]);
                        data.IdUsuarioRegistro = Convert.ToInt32(reader["IdUsuarioRegistro"]);
                        data.IdUsuarioModifico = DBNull.Value != reader["IdUsuarioModifico"] ? Convert.ToInt32(reader["IdUsuarioModifico"]) : (int?)null;
                        data.FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"]);
                        data.FechaModifico = DBNull.Value != reader["FechaModifico"] ? Convert.ToDateTime(reader["FechaModifico"]) : (DateTime?)null;
                    }
                }

                if (data == null)
                {
                    mensaje = "No se encontraron datos registrados.";
                    throw new AlertException(mensaje);
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
