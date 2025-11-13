
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
	public class FacturaTipoIgvDat : IFacturaTipoIgvDat
	{
        private readonly string _connectionString;

        public FacturaTipoIgvDat(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
        public async Task<List<FacturaTipoIgvDTO>> Listar(int idUsuario)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_FacturacionTipoIgv_Listar", conn)
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
        public async Task<List<FacturaTipoIgvDTO>> Listar2(int idUsuario)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_FacturacionTipoIgv_Listar2", conn)
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
        public async Task<FacturaTipoIgvDTO> Buscar(int id, int idUsuario)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_FacturacionTipoIgv_BuscarPorId", conn)
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
        public async Task<bool> Registrar(FacturaTipoIgvDTO model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_FacturacionTipoIgv_Insertar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pNombre", model.Nombre);
                cmd.Parameters.AddWithValue("pDescripcion", model.Descripcion);
                cmd.Parameters.AddWithValue("pValor", model.Valor);
                cmd.Parameters.AddWithValue("pIdUsuarioRegistro", model.IdUsuarioRegistro);
                cmd.Parameters.AddWithValue("pIdEstado", model.IdEstado);
                cmd.Parameters.AddWithValue("pAplicaIgv", model.AplicaIgv);
                cmd.Parameters.AddWithValue("pGratuita", model.Gratuita);
                cmd.Parameters.AddWithValue("pInafecta", model.Inafecta);
                cmd.Parameters.AddWithValue("pExonerada", model.Exonerada);
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
        public async Task<bool> Modificar(int id, FacturaTipoIgvDTO model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_FacturacionTipoIgv_Modificar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pId", id);
                cmd.Parameters.AddWithValue("pNombre", model.Nombre);
                cmd.Parameters.AddWithValue("pDescripcion", model.Descripcion);
                cmd.Parameters.AddWithValue("pValor", model.Valor);
                cmd.Parameters.AddWithValue("pIdUsuarioModifico", model.IdUsuarioModifico);
                cmd.Parameters.AddWithValue("pIdEstado", model.IdEstado);
                cmd.Parameters.AddWithValue("pAplicaIgv", model.AplicaIgv);
                cmd.Parameters.AddWithValue("pGratuita", model.Gratuita);
                cmd.Parameters.AddWithValue("pInafecta", model.Inafecta);
                cmd.Parameters.AddWithValue("pExonerada", model.Exonerada);
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

        static async Task<List<FacturaTipoIgvDTO>> ReadListar(DbDataReader reader)
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


                List<FacturaTipoIgvDTO> collection = new List<FacturaTipoIgvDTO>();
                if (reader.NextResult())
                {
                    while (await reader.ReadAsync())
                    {
                        FacturaTipoIgvDTO obj = new FacturaTipoIgvDTO();
                        obj.Id = Convert.ToInt32(reader["Id"]);
                        obj.Nombre = Convert.ToString(reader["Nombre"]);
                        obj.Descripcion = DBNull.Value != reader["Descripcion"] ? Convert.ToString(reader["Descripcion"]) : null;
                        obj.Valor = Convert.ToString(reader["Valor"]);
                        obj.IdEstado = Convert.ToInt32(reader["IdEstado"]);
                        obj.AplicaIgv = Convert.ToBoolean(reader["AplicaIgv"]);
                        obj.Gratuita = Convert.ToBoolean(reader["Gratuita"]);
                        obj.Inafecta = Convert.ToBoolean(reader["Inafecta"]);
                        obj.Exonerada = Convert.ToBoolean(reader["Exonerada"]);

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
        static async Task<List<FacturaTipoIgvDTO>> ReadListar2(DbDataReader reader)
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


                List<FacturaTipoIgvDTO> collection = new List<FacturaTipoIgvDTO>();
                if (reader.NextResult())
                {
                    while (await reader.ReadAsync())
                    {
                        FacturaTipoIgvDTO obj = new FacturaTipoIgvDTO();
                        obj.Id = Convert.ToInt32(reader["Id"]);
                        obj.Nombre = Convert.ToString(reader["Nombre"]);
                        obj.Descripcion = DBNull.Value != reader["Descripcion"] ? Convert.ToString(reader["Descripcion"]) : null;
                        obj.Valor = Convert.ToString(reader["Valor"]);
                        obj.IdEstado = Convert.ToInt32(reader["IdEstado"]);
                        obj.AplicaIgv = Convert.ToBoolean(reader["AplicaIgv"]);
                        obj.Gratuita = Convert.ToBoolean(reader["Gratuita"]);
                        obj.Inafecta = Convert.ToBoolean(reader["Inafecta"]);
                        obj.Exonerada = Convert.ToBoolean(reader["Exonerada"]);
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
        static async Task<FacturaTipoIgvDTO> ReadBuscar(DbDataReader reader)
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

                FacturaTipoIgvDTO data = new FacturaTipoIgvDTO();
                if (reader.NextResult())
                {
                    while (await reader.ReadAsync())
                    {
                        data.Id = Convert.ToInt32(reader["Id"]);
                        data.Nombre = Convert.ToString(reader["Nombre"]);
                        data.Descripcion = DBNull.Value != reader["Descripcion"] ? Convert.ToString(reader["Descripcion"]) : null;
                        data.Valor = Convert.ToString(reader["Valor"]);
                        data.IdEstado = Convert.ToInt32(reader["IdEstado"]);
                        data.AplicaIgv = Convert.ToBoolean(reader["AplicaIgv"]);
                        data.Gratuita = Convert.ToBoolean(reader["Gratuita"]);
                        data.Inafecta = Convert.ToBoolean(reader["Inafecta"]);
                        data.Exonerada = Convert.ToBoolean(reader["Exonerada"]);
                        data.Estado = Convert.ToString(reader["Estado"]);
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

    }
}
