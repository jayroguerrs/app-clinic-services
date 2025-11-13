
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
	public class ComprobanteSerieDat : IComprobanteSerieDat
	{
        private readonly string _connectionString;

        public ComprobanteSerieDat(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
        public async Task<List<ComprobanteSerieDTO>> Listar(int idUsuario)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_ComprobanteSerie_Listar", conn)
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

        public async Task<List<ComprobanteSerieDTO>> ListarBySedeTipoComprobante(int idUsuario, int idSede, int idTipoComprobante)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_ComprobanteSerie_ListarBySedeComprobante", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdUsuario", idUsuario);
                cmd.Parameters.AddWithValue("pIdSede", idSede);
                cmd.Parameters.AddWithValue("pIdTipoComprobante", idTipoComprobante);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadListarBySedeTipoComprobante(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        public async Task<List<ComprobanteSerieDTO>> ListarByTipoComprobante(int idUsuario, int idTipoComprobante)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_ComprobanteSerie_ListarByTipoComprobante", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdUsuario", idUsuario);
                cmd.Parameters.AddWithValue("pIdTipoComprobante", idTipoComprobante);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadListarByTipoComprobante(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        public async Task<List<ComprobanteSerieDTO>> Listar2(int idUsuario)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_ComprobanteSerie_Listar2", conn)
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
        public async Task<ComprobanteSerieDTO> Buscar(int id, int idUsuario)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_ComprobanteSerie_BuscarPorId", conn)
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
        public async Task<bool> Registrar(ComprobanteSerieDTO model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_ComprobanteSerie_Insertar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdSede", model.IdSede);
                cmd.Parameters.AddWithValue("pIdTipoComprobante", model.IdTipoComprobante);
                cmd.Parameters.AddWithValue("pSerie", model.Serie);
                cmd.Parameters.AddWithValue("pDescripcion", model.Descripcion);
                cmd.Parameters.AddWithValue("pIdUsuarioRegistro", model.IdUsuarioRegistro);
                cmd.Parameters.AddWithValue("pIdEstado", model.IdEstado);
                cmd.Parameters.AddWithValue("pNumeroActual", model.NumeroActual);

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
        public async Task<bool> Modificar(int id, ComprobanteSerieDTO model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_ComprobanteSerie_Modificar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pId", id);
                cmd.Parameters.AddWithValue("pIdSede", model.IdSede);
                cmd.Parameters.AddWithValue("pIdTipoComprobante", model.IdTipoComprobante);
                cmd.Parameters.AddWithValue("pSerie", model.Serie);
                cmd.Parameters.AddWithValue("pDescripcion", model.Descripcion);
                cmd.Parameters.AddWithValue("pIdUsuarioModifico", model.IdUsuarioModifico);
                cmd.Parameters.AddWithValue("pIdEstado", model.IdEstado);
                cmd.Parameters.AddWithValue("pNumeroActual", model.NumeroActual);
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



        public async Task<bool> ActualizarNumero(int id, int numeroActual, int idUsuarioRegistro)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_ComprobanteSerie_ActualizarNumero", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pId", id);
                cmd.Parameters.AddWithValue("pIdUsuarioRegistro", idUsuarioRegistro);
                cmd.Parameters.AddWithValue("pNumeroActual", numeroActual);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadActualizarNumero(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        public async Task<List<ComprobanteSerieDTO>> ListarToNotaCredito(int IdUsuario)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_ComprobanteSerie_ListarByNotaCredito", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdUsuario", IdUsuario);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadListarToNotaCredito(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        // READERS

        static async Task<List<ComprobanteSerieDTO>> ReadListar(DbDataReader reader)
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


                List<ComprobanteSerieDTO> collection = new List<ComprobanteSerieDTO>();
                if (reader.NextResult())
                {
                    while (await reader.ReadAsync())
                    {
                        ComprobanteSerieDTO obj = new ComprobanteSerieDTO();
                        obj.Id = Convert.ToInt32(reader["Id"]);
                        obj.IdSede = Convert.ToInt32(reader["IdSede"]);
                        obj.Sede = Convert.ToString(reader["Sede"]);
                        obj.IdTipoComprobante = Convert.ToInt32(reader["IdTipoComprobante"]);
                        obj.TipoComprobante = Convert.ToString(reader["TipoComprobante"]);
                        obj.Serie = Convert.ToString(reader["Serie"]);
                        obj.Descripcion = DBNull.Value != reader["Descripcion"] ? Convert.ToString(reader["Descripcion"]) : null;
                        obj.IdEstado = Convert.ToInt32(reader["IdEstado"]);
                        obj.Estado = Convert.ToString(reader["Estado"]);
                        obj.NumeroActual = Convert.ToInt32(reader["NumeroActual"]);
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
        static async Task<List<ComprobanteSerieDTO>> ReadListar2(DbDataReader reader)
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


                List<ComprobanteSerieDTO> collection = new List<ComprobanteSerieDTO>();
                if (reader.NextResult())
                {
                    while (await reader.ReadAsync())
                    {
                        ComprobanteSerieDTO obj = new ComprobanteSerieDTO();
                        obj.Id = Convert.ToInt32(reader["Id"]);
                        obj.IdSede = Convert.ToInt32(reader["IdSede"]);
                        obj.IdTipoComprobante = Convert.ToInt32(reader["IdTipoComprobante"]);
                        obj.Serie = Convert.ToString(reader["Serie"]);
                        obj.Descripcion = DBNull.Value != reader["Descripcion"] ? Convert.ToString(reader["Descripcion"]) : null;
                        obj.IdEstado = Convert.ToInt32(reader["IdEstado"]);
                        obj.NumeroActual = Convert.ToInt32(reader["NumeroActual"]);
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
        static async Task<List<ComprobanteSerieDTO>> ReadListarBySedeTipoComprobante(DbDataReader reader)
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


                List<ComprobanteSerieDTO> collection = new List<ComprobanteSerieDTO>();
                if (reader.NextResult())
                {
                    while (await reader.ReadAsync())
                    {
                        ComprobanteSerieDTO obj = new ComprobanteSerieDTO();
                        obj.Id = Convert.ToInt32(reader["Id"]);
                        obj.IdSede = Convert.ToInt32(reader["IdSede"]);
                        obj.IdTipoComprobante = Convert.ToInt32(reader["IdTipoComprobante"]);
                        obj.Serie = Convert.ToString(reader["Serie"]);
                        obj.Descripcion = DBNull.Value != reader["Descripcion"] ? Convert.ToString(reader["Descripcion"]) : null;
                        obj.IdEstado = Convert.ToInt32(reader["IdEstado"]);
                        obj.NumeroActual = Convert.ToInt32(reader["NumeroActual"]);
                        obj.NumeroComprobante = Convert.ToInt32(reader["NumeroComprobante"]);
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

        static async Task<List<ComprobanteSerieDTO>> ReadListarByTipoComprobante(DbDataReader reader)
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


                List<ComprobanteSerieDTO> collection = new List<ComprobanteSerieDTO>();
                if (reader.NextResult())
                {
                    while (await reader.ReadAsync())
                    {
                        ComprobanteSerieDTO obj = new ComprobanteSerieDTO();
                        obj.Id = Convert.ToInt32(reader["Id"]);
                        obj.IdSede = Convert.ToInt32(reader["IdSede"]);
                        obj.IdTipoComprobante = Convert.ToInt32(reader["IdTipoComprobante"]);
                        obj.Serie = Convert.ToString(reader["Serie"]);
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

        static async Task<List<ComprobanteSerieDTO>> ReadListarToNotaCredito(DbDataReader reader)
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


                List<ComprobanteSerieDTO> collection = new List<ComprobanteSerieDTO>();
                if (reader.NextResult())
                {
                    while (await reader.ReadAsync())
                    {
                        ComprobanteSerieDTO obj = new ComprobanteSerieDTO();
                        obj.Id = Convert.ToInt32(reader["Id"]);
                        obj.IdSede = Convert.ToInt32(reader["IdSede"]);
                        obj.IdTipoComprobante = Convert.ToInt32(reader["IdTipoComprobante"]);
                        obj.Serie = Convert.ToString(reader["Serie"]);
                        obj.NumeroActual = Convert.ToInt32(reader["Total"]);
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
        static async Task<ComprobanteSerieDTO> ReadBuscar(DbDataReader reader)
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

                ComprobanteSerieDTO data = new ComprobanteSerieDTO();
                if (reader.NextResult())
                {
                    while (await reader.ReadAsync())
                    {
                        data.Id = Convert.ToInt32(reader["Id"]);
                        data.IdSede = Convert.ToInt32(reader["IdSede"]);
                        data.Sede = Convert.ToString(reader["Sede"]);
                        data.IdTipoComprobante = Convert.ToInt32(reader["IdTipoComprobante"]);
                        data.TipoComprobante = Convert.ToString(reader["TipoComprobante"]);
                        data.Serie = Convert.ToString(reader["Serie"]);
                        data.Descripcion = DBNull.Value != reader["Descripcion"] ? Convert.ToString(reader["Descripcion"]) : null;
                        data.IdEstado = Convert.ToInt32(reader["IdEstado"]);
                        data.NumeroActual = Convert.ToInt32(reader["NumeroActual"]);
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

        static async Task<bool> ReadActualizarNumero(DbDataReader reader)
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
