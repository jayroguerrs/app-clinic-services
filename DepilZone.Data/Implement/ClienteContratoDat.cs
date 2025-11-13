using DepilZone.Data.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using DepilZone.Entidad.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Threading.Tasks;
namespace DepilZone.Data
{
    public class ClienteContratoDat : IClienteContratoDat
    {
        private readonly string _connectionString;

        public ClienteContratoDat(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
        public async Task<Respuesta<ClienteContratoDTO>> GuardarContrato(ClienteContratoDTO model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_ClienteContrato_Insertar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdCliente", model.IdCliente);
                cmd.Parameters.AddWithValue("pIdDocumentos", model.IdDocumentos);
                cmd.Parameters.AddWithValue("pContrato", model.Contrato);
                cmd.Parameters.AddWithValue("pIdUsuarioRegistro", model.IdUsuarioRegistro);
                cmd.Parameters.AddWithValue("pIdPlantilla", model.IdPlantilla);
                cmd.Parameters.AddWithValue("pObservacion", model.Observacion);
                cmd.Parameters.AddWithValue("pIdServicio", model.IdServicio);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadGuardarContrato(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Respuesta<bool>> AnularContrato(int id, ClienteContratoDTO model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_ClienteContrato_Anular", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pId", model.Id);
                cmd.Parameters.AddWithValue("pIdUsuarioModifico", model.IdUsuarioRegistro);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItemAnular(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> EnviarContratoPorCorreo(ClienteContratoDTO model)
        {
            return true;
        }

        public async Task<Respuesta<ClienteContratoDTO>> ObtenerContratoById(int id)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_ClienteContrato_ObtenerById", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pId", id);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItem(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<ClienteContratoDTO>> ListarByIdCliente(int idCliente)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_ClienteContrato_ListarByIdCliente", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pId", idCliente);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadList(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<ClienteContratoDTO>> ListarByIdClientePorServicio(int idCliente, int idServicio)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_ClienteContrato_ListarByIdClientePorServicio", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdCliente", idCliente);
                cmd.Parameters.AddWithValue("pIdServicio", idServicio);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadListarByIdClientePorServicio(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ClienteContratoDTO> verContrato(int idContrato)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_ClienteContrato_ObtenerById", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pId", idContrato);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadContrato(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ClienteContratoDTO> DatosContrato(string idEncryptContrato)
        {
            try
            {
                int id = Convert.ToInt32(DBConn.DecryptString(idEncryptContrato));

                ClienteContratoDTO output = await verContrato(id);
                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> SeEnvioContrato(int idContrato)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_ClienteContrato_SeEnvioContrato", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pId", idContrato);
                var reader = await cmd.ExecuteReaderAsync();

                bool output = false;
                while (await reader.ReadAsync())
                {
                    output = Convert.ToBoolean(reader["Exito"]);
                }
                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ClienteContratoConfirmadoDTO> BuscarContratoConfirmado(string idContrato)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                int id = Convert.ToInt32(DBConn.DecryptString(idContrato));
                using SqlCommand cmd = new SqlCommand("SP_ClienteContrato_BuscarConfirmado", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pId", id);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadBuscarContratoConfirmado(reader);
                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> ConfirmarContrato(string idContrato, int idCliente)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                int id = Convert.ToInt32(DBConn.DecryptString(idContrato));
                using SqlCommand cmd = new SqlCommand("SP_ClienteContrato_Confirmar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pId", id);
                cmd.Parameters.AddWithValue("pIdCliente", idCliente);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadConfirmarContrato(reader);
                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        //Readers

        static async Task<Respuesta<ClienteContratoDTO>> ReadGuardarContrato(DbDataReader reader)
        {
            try
            {
                Respuesta<ClienteContratoDTO> obj = new Respuesta<ClienteContratoDTO>
                {
                    Response = new ClienteContratoDTO()
                };
                while (await reader.ReadAsync())
                {
                    obj.Exito = Convert.ToBoolean(reader["Exito"]);
                    obj.Mensaje = Convert.ToString(reader["Mensaje"]);
                    obj.ErrorNumero = Convert.ToInt32(reader["ErrorNumero"]);
                    obj.ErrorDetalle = reader["ErrorDetalle"].ToString();
                    obj.Response.Id = Convert.ToInt32(reader["Id"]);
                    if (obj.Exito)
                    {
                        obj.Response.Id = Convert.ToInt32(reader["Id"]);
                        obj.Response.IdCliente = Convert.ToInt32(reader["IdCliente"]);
                        obj.Response.IdDocumentos = reader["IdDocumentos"].ToString();
                        obj.Response.FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"]);
                        obj.Response.FechaModifico = reader["FechaModifico"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["FechaModifico"]);
                        obj.Response.UsuarioRegistro = reader["UsuarioRegistro"].ToString();
                        obj.Response.UsuarioModifico = reader["UsuarioModifico"] == DBNull.Value ? null : reader["Promocion"].ToString();
                        obj.Response.Contrato = reader["Contrato"].ToString();
                        obj.Response.IdEstado = Convert.ToInt32(reader["IdEstado"]);
                        obj.Response.Observacion = reader["IdEstado"].ToString();

                        obj.Response.TituloContrato = reader["TituloContrato"].ToString();
                        obj.Response.EmailCC = reader["EmailCC"].ToString();
                        obj.Response.ClienteEmail = reader["ClienteEmail"].ToString();
                    }
                }


                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        static async Task<Respuesta<ClienteContratoDTO>> ReadItem(DbDataReader reader)
        {
            try
            {
                Respuesta<ClienteContratoDTO> obj = new Respuesta<ClienteContratoDTO>
                {
                    Response = new ClienteContratoDTO()
                };
                while (await reader.ReadAsync())
                {
                    obj.Exito = Convert.ToBoolean(reader["Exito"]);
                    obj.Mensaje = Convert.ToString(reader["Mensaje"]);
                    obj.ErrorNumero = Convert.ToInt32(reader["ErrorNumero"]);
                    obj.ErrorDetalle = reader["ErrorDetalle"].ToString();
                    obj.Response.Id = Convert.ToInt32(reader["Id"]);
                    if (obj.Exito)
                    {
                        obj.Response.Id = Convert.ToInt32(reader["Id"]);
                        obj.Response.IdCliente = Convert.ToInt32(reader["IdCliente"]);
                        obj.Response.IdDocumentos = reader["IdDocumentos"].ToString();
                        obj.Response.FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"]);
                        obj.Response.FechaModifico = reader["FechaModifico"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["FechaModifico"]);
                        obj.Response.UsuarioRegistro = reader["UsuarioRegistro"].ToString();
                        obj.Response.UsuarioModifico = reader["UsuarioModifico"] == DBNull.Value ? null : reader["Promocion"].ToString();
                        obj.Response.Contrato = reader["Contrato"].ToString();
                        obj.Response.IdEstado = Convert.ToInt32(reader["IdEstado"]);
                        obj.Response.Observacion = reader["IdEstado"].ToString();

                        obj.Response.TituloContrato = reader["TituloContrato"].ToString();
                        obj.Response.EmailCC = reader["EmailCC"].ToString();
                        obj.Response.ClienteEmail = reader["ClienteEmail"].ToString();
                    }
                }


                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        static async Task<ClienteContratoDTO> ReadContrato(DbDataReader reader)
        {
            try
            {
                ClienteContratoDTO obj = new ClienteContratoDTO();
                bool Exito = false;
                while (await reader.ReadAsync())
                {
                   Exito = Convert.ToBoolean(reader["Exito"]);
                    var Mensaje = Convert.ToString(reader["Mensaje"]);

                    if (Exito)
                    {
                        obj.Id = Convert.ToInt32(reader["Id"]);
                        obj.NombreCliente = reader["NombreCliente"].ToString();
                        obj.TipoDocumentoIdentidad = reader["TipoDocumentoIdentidad"].ToString();
                        obj.DocumentoIdentidad = reader["DocumentoIdentidad"].ToString();
                        obj.FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"]);
                        obj.IdEstado = Convert.ToInt32(reader["IdEstado"]);
                        obj.Observacion = reader["Observacion"].ToString();
                    }
                    else
                    {
                        throw new SystemException(Mensaje);
                    }
                }

                if (Exito)
                {
                    if (reader.NextResult())
                    {
                        List<CC_DocumentoDTO> documentos = new List<CC_DocumentoDTO>();
                        while (await reader.ReadAsync())
                        {
                            documentos.Add(new CC_DocumentoDTO
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Nombre = reader["Nombre"].ToString(),
                                Zonas = DBNull.Value == reader["Zonas"] ? null : Convert.ToString(reader["Zonas"]),
                                Promocion = DBNull.Value == reader["Promocion"] ? null : Convert.ToString(reader["Promocion"]),
                            });
                        }
                        obj.Documentos = documentos;
                    }
                }

                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        static async Task<Respuesta<bool>> ReadItemAnular(DbDataReader reader)
        {
            try
            {
                Respuesta<bool> obj = new Respuesta<bool>{};
                while (await reader.ReadAsync())
                {
                    obj.Exito = Convert.ToBoolean(reader["Exito"]);
                    obj.Mensaje = Convert.ToString(reader["Mensaje"]);
                    obj.ErrorNumero = Convert.ToInt32(reader["ErrorNumero"]);
                    obj.ErrorDetalle = reader["ErrorDetalle"].ToString();
                    if (obj.Exito)
                    {
                        obj.Response = true;
                    }
                    else
                    {
                        throw new AlertException(obj.Mensaje + " : " + obj.ErrorDetalle );
                        obj.Response = false;
                    }
                }


                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        static async Task<List<ClienteContratoDTO>> ReadList(DbDataReader reader)
        {
            try
            {
                List<ClienteContratoDTO> collection = new List<ClienteContratoDTO>();
                while (await reader.ReadAsync())
                {
                    ClienteContratoDTO contrato = new ClienteContratoDTO
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        IdCliente = Convert.ToInt32(reader["IdCliente"]),
                        IdDocumentos = reader["IdDocumentos"].ToString(),
                        FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"]),
                        FechaModifico = reader["FechaModifico"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["FechaModifico"]),
                        UsuarioRegistro = reader["UsuarioRegistro"].ToString(),
                        UsuarioModifico = reader["UsuarioModifico"] == DBNull.Value ? null : reader["UsuarioModifico"].ToString(),
                        IdEstado = Convert.ToInt32(reader["IdEstado"]),
                        EmailEnviado = Convert.ToBoolean(reader["EmailEnviado"]),
                        ListaDocumentos = DBNull.Value == reader["Documentos"] ? null : Convert.ToString(reader["Documentos"]),
                    };
                    collection.Add(contrato);
                }


                return collection;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        static async Task<List<ClienteContratoDTO>> ReadListarByIdClientePorServicio(DbDataReader reader)
        {
            try
            {
                List<ClienteContratoDTO> collection = new List<ClienteContratoDTO>();
                while (await reader.ReadAsync())
                {
                    ClienteContratoDTO contrato = new ClienteContratoDTO
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        IdCliente = Convert.ToInt32(reader["IdCliente"]),
                        IdDocumentos = reader["IdDocumentos"].ToString(),
                        FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"]),
                        FechaModifico = reader["FechaModifico"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["FechaModifico"]),
                        UsuarioRegistro = reader["UsuarioRegistro"].ToString(),
                        UsuarioModifico = reader["UsuarioModifico"] == DBNull.Value ? null : reader["UsuarioModifico"].ToString(),
                        IdEstado = Convert.ToInt32(reader["IdEstado"]),
                        Confirmado = reader["Confirmado"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Confirmado"]),
                        FechaConfirmo = reader["FechaConfirmo"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["FechaConfirmo"]),
                        EmailEnviado = Convert.ToBoolean(reader["EmailEnviado"]),
                        ListaDocumentos = DBNull.Value == reader["Documentos"] ? null : Convert.ToString(reader["Documentos"]),
                    };
                    collection.Add(contrato);
                }


                return collection;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        static async Task<ClienteContratoConfirmadoDTO> ReadBuscarContratoConfirmado(DbDataReader reader)
        {
            try
            {
                ClienteContratoConfirmadoDTO obj = new ClienteContratoConfirmadoDTO();
                bool Exito = false;
                while (await reader.ReadAsync())
                {
                    Exito = Convert.ToBoolean(reader["Exito"]);
                    var Mensaje = Convert.ToString(reader["Mensaje"]);

                    if (Exito)
                    {
                        obj.Id = Convert.ToInt32(reader["Id"]);
                        obj.IdCliente = Convert.ToInt32(reader["IdCliente"]);
                        obj.FechaContrato = Convert.ToDateTime(reader["FechaContrato"]);
                        obj.FechaConfirmacion = DBNull.Value == reader["FechaConfirmacion"] ? (DateTime?)null : Convert.ToDateTime(reader["FechaConfirmacion"]);
                        obj.Correo = DBNull.Value == reader["Correo"] ? null : Convert.ToString(reader["Correo"]);
                        obj.Cliente = Convert.ToString(reader["Cliente"]);
                    }
                    else
                    {
                        throw new AlertException(Mensaje);
                    }
                }

                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        static async Task<bool> ReadConfirmarContrato(DbDataReader reader)
        {
            try
            {
                bool Exito = false;
                string Mensaje = "";
                int ErrorNumero = 0;
                string ErrorDetalle = "";

                while (await reader.ReadAsync())
                {
                    Exito = Convert.ToBoolean(reader["Exito"]);
                    Mensaje = Convert.ToString(reader["Mensaje"]);
                    ErrorNumero = Convert.ToInt32(reader["ErrorNumero"]);
                    ErrorDetalle = reader["ErrorDetalle"].ToString();
                    if (!Exito)
                    {
                        throw new AlertException(Mensaje);
                    }
                }


                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}