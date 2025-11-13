using DepilZone.Data.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using DepilZone.Entidad.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace DepilZone.Data
{
    public class ClienteDocumentoDat : IClienteDocumentoDat
    {
        private readonly string _connectionString;

        public ClienteDocumentoDat(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
        public async Task<ClienteDocumentoDTO> AnularDocumento(int id, ClienteDocumentoDTO model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_ClienteDocumento_Anular", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pId", id);
                cmd.Parameters.AddWithValue("pMotivo", model.MotivoAnulacion);
                cmd.Parameters.AddWithValue("pIdUsuarioModifico", model.IdUsuarioModifico);
                cmd.Parameters.AddWithValue("pIdCliente", model.IdCliente);
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

        public async Task<ClienteDocumentoDTO> RestaurarDocumento(int id, ClienteDocumentoDTO model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_ClienteDocumento_Restaurar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pId", id);
                cmd.Parameters.AddWithValue("pIdUsuarioModifico", model.IdUsuarioModifico);
                cmd.Parameters.AddWithValue("pIdCliente", model.IdCliente);
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

        public async Task<ClienteDocumentoDTO> EnviarDocumentoPorCorreo(ClienteDocumentoDTO model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_ClienteDocumento_ObtenerDatosEmail", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdCliente", model.IdCliente);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadDatosEmail(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ClienteDocumentoDTO> ObtenerDocumentoById(int id)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_ClienteDocumento_ObtenerById", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pId", id);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItemInsertar(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<ClienteDocumentoDTO>> obtenerListado()
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_ClienteDocumento_ObtenerListado", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                var reader = await cmd.ExecuteReaderAsync();
                List<ClienteDocumentoDTO> output = await ReadObtenerListado(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ClienteDocumentoDTO> InsertarDocumento(ClienteDocumentoDTO model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_ClienteDocumento_Insertar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdCliente", model.IdCliente);
                cmd.Parameters.AddWithValue("pIdDocumentoTipo", model.IdDocumentoTipo);
                cmd.Parameters.AddWithValue("pIdPromocion", model.IdPromocion);
                cmd.Parameters.AddWithValue("pIdsZonas", model.IdsZonas);
                cmd.Parameters.AddWithValue("pIdPatologia", model.IdPatologia);

                cmd.Parameters.AddWithValue("pSesionesAdicionales", model.SesionesAdicionales);
                cmd.Parameters.AddWithValue("pNumeroSesionesRetroceder", model.NumeroSesionesRetroceder);
                cmd.Parameters.AddWithValue("pNumeroSesiones", model.NumeroSesiones);
                cmd.Parameters.AddWithValue("pIntervaloMantenimiento", model.IntervaloMantenimiento);
                cmd.Parameters.AddWithValue("pConsultaMantenimientoEn", model.ConsultaMantenimientoEn);
                cmd.Parameters.AddWithValue("pDescripcionComentario", model.DescripcionComentario);
                cmd.Parameters.AddWithValue("pIdDoctora", model.IdDoctora);

                cmd.Parameters.AddWithValue("pIdEstado", 1);
                cmd.Parameters.AddWithValue("pObservacion", model.Observacion);
                cmd.Parameters.AddWithValue("pIdUsuarioRegistro", model.IdUsuarioRegistro);
                //cmd.Parameters.AddWithValue("pDocumento", model.Documento);

                cmd.Parameters.AddWithValue("pDniApoderado", model.DniApoderado);
                cmd.Parameters.AddWithValue("pNombreApoderado", model.NombreApoderado);

                cmd.Parameters.AddWithValue("pVersion", model.Version);
                cmd.Parameters.AddWithValue("pFechaDocumento", model.FechaDocumento);
                cmd.Parameters.AddWithValue("pCondiciones", model.Condiciones);

                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItemInsertar(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<CD_Zonas>> obtenerZonas(string ids)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_ClienteDocumento_ObtenerZonas", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdsZonas", ids);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadListadoZonas(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> SeEnvioCorreo(int idDocumento)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_ClienteDocumento_SeEnvioCorreo", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pId", idDocumento);
                var reader = await cmd.ExecuteReaderAsync();

                bool output = false;
                string mensaje = "";

                while (await reader.ReadAsync())
                {
                    output = Convert.ToBoolean(reader["Exito"]);
                    mensaje = reader["Mensaje"].ToString();
                }

                conn.Close();

                if (!output)
                {
                    throw new AlertException(mensaje);
                }


                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<ClienteDocumentoDTO>> obtenerListadoByCliente(int idCliente)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_ClienteDocumento_ListarByCliente", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pId", idCliente);
                var reader = await cmd.ExecuteReaderAsync();
                List<ClienteDocumentoDTO> output = await ReadObtenerListadoByCliente(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<ClienteDocumentoDTO>> obtenerListadoByClientePorServicio(int idCliente, int idServicio)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_ClienteDocumento_ListarByClientePorServicio", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdCliente", idCliente);
                cmd.Parameters.AddWithValue("pIdServicio", idServicio);
                var reader = await cmd.ExecuteReaderAsync();
                List<ClienteDocumentoDTO> output = await ReadObtenerListadoByClienteByServicio(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<ClienteDocumentoDTO>> obtenerListadoByIdClienteByFecha(int idCLiente, DateTime fecha)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_ClienteDocumento_ListarByClienteByFecha", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pId", idCLiente);
                cmd.Parameters.AddWithValue("pFecha", fecha);
                var reader = await cmd.ExecuteReaderAsync();
                List<ClienteDocumentoDTO> output = await ReadObtenerListado(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<ClienteDocumentoDTO>> obtenerListadoByIdClienteByFechaPorServicio(int idCLiente, DateTime fecha, int idServicio)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_ClienteDocumento_ListarByClienteByFechaPorServicio", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pId", idCLiente);
                cmd.Parameters.AddWithValue("pFecha", fecha);
                cmd.Parameters.AddWithValue("pIdServicio", idServicio);
                var reader = await cmd.ExecuteReaderAsync();
                List<ClienteDocumentoDTO> output = await ReadObtenerListado(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }





        //Readers

        static async Task<ClienteDocumentoDTO> ReadItem(DbDataReader reader)
        {
            try
            {
                ClienteDocumentoDTO obj = new ClienteDocumentoDTO();

                while (await reader.ReadAsync())
                {
                    bool Exito = Convert.ToBoolean(reader["Exito"]);
                    string Mensaje = Convert.ToString(reader["Mensaje"]);

                    if (!Exito)
                    {
                        throw new SystemException(Mensaje);
                    }

                    obj.Id = Convert.ToInt32(reader["Id"]);
                    obj.IdCliente = Convert.ToInt32(reader["IdCliente"]);
                    //obj.Documento = reader["Nombre"].ToString();
                    obj.IdPromocion = reader["IdPromocion"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["IdPromocion"]);
                    obj.Promocion = reader["Promocion"] == DBNull.Value ? null : reader["Promocion"].ToString();
                    obj.IdsZonas = reader["IdsZonas"] == DBNull.Value ? null : reader["IdsZonas"].ToString();
                    obj.FechaRegistra = Convert.ToDateTime(reader["FechaRegistra"]);
                    obj.IdEstado = Convert.ToInt32(reader["IdEstado"]);
                    obj.DocumentoPromocion = reader["IdPromocion"] == DBNull.Value ? null : new ClienteDocumentoPromocionDTO()
                    {
                        Id = reader["IdPromocion"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["IdPromocion"]),
                        Nombre = reader["Promocion"] == DBNull.Value ? null : reader["Promocion"].ToString()
                    };
                    obj.ClienteEmail = reader["ClienteEmail"].ToString();
                    obj.EmailCC = reader["EmailCC"].ToString();
                }

                List<CD_Zonas> zonas = new List<CD_Zonas>();
                if (reader.NextResult())
                {
                    while (await reader.ReadAsync())
                    {
                        zonas.Add(new CD_Zonas()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Nombre = reader["Nombre"].ToString()
                        });
                    }
                }
                obj.Zonas = zonas;

                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        static async Task<ClienteDocumentoDTO> ReadItemAnular(DbDataReader reader)
        {
            try
            {

                bool Exito = false;
                string Mensaje = "";
                int ErrorNumero = 0;
                string ErrorDetalle = "";

                ClienteDocumentoDTO obj = new ClienteDocumentoDTO();

                while (await reader.ReadAsync())
                {
                    Exito = Convert.ToBoolean(reader["Exito"]);
                    Mensaje = Convert.ToString(reader["Mensaje"]);
                    ErrorNumero = Convert.ToInt32(reader["ErrorNumero"]);
                    ErrorDetalle = reader["ErrorDetalle"].ToString();

                    if (Exito)
                    {
                        obj.Id = Convert.ToInt32(reader["Id"]);
                        obj.IdCliente = Convert.ToInt32(reader["IdCliente"]);
                        obj.NombreDocumento = reader["NombreDocumento"].ToString();
                        obj.IdPromocion = reader["IdPromocion"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["IdPromocion"]);
                        obj.Promocion = reader["Promocion"] == DBNull.Value ? null : reader["Promocion"].ToString();
                        obj.IdsZonas = reader["IdZonas"] == DBNull.Value ? null : reader["IdZonas"].ToString();
                        obj.FechaRegistra = Convert.ToDateTime(reader["FechaRegistra"]);
                        obj.IdEstado = Convert.ToInt32(reader["IdEstado"]);
                        obj.DocumentoPromocion = reader["IdPromocion"] == DBNull.Value ? null : new ClienteDocumentoPromocionDTO()
                        {
                            Id = reader["IdPromocion"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["IdPromocion"]),
                            Nombre = reader["Promocion"] == DBNull.Value ? null : reader["Promocion"].ToString()
                        };

                        obj.EmailCC = reader["EmailCC"].ToString();
                        obj.ClienteEmail = reader["ClienteEmail"] == DBNull.Value ? "" : reader["ClienteEmail"].ToString();
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

        //UPDATE HERE
        static async Task<ClienteDocumentoDTO> ReadItemInsertar(DbDataReader reader)
        {
            try
            {
                ClienteDocumentoDTO obj = new ClienteDocumentoDTO();
                while (await reader.ReadAsync())
                {
                    bool Exito = Convert.ToBoolean(reader["Exito"]);
                    string Mensaje = Convert.ToString(reader["Mensaje"]);

                    if (!Exito)
                    {
                        throw new SystemException(Mensaje);
                    }

                    obj.Id = Convert.ToInt32(reader["Id"]);
                    obj.IdCliente = Convert.ToInt32(reader["IdCliente"]);
                    obj.IdDocumentoTipo = Convert.ToInt32(reader["IdDocumentoTipo"]);
                    obj.NombreDocumento = reader["NombreDocumento"].ToString();
                    obj.IdPromocion = reader["IdPromocion"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["IdPromocion"]);
                    obj.IdsZonas = reader["IdsZonas"] == DBNull.Value ? null : reader["IdsZonas"].ToString();
                    obj.IdPatologia = reader["IdPatologia"] == DBNull.Value ? null : reader["IdPatologia"].ToString();
                    obj.SesionesAdicionales = reader["SesionesAdicionales"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["SesionesAdicionales"]);
                    obj.NumeroSesionesRetroceder = reader["NumeroSesionesRetroceder"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["NumeroSesionesRetroceder"]);
                    obj.NumeroSesiones = reader["NumeroSesiones"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["NumeroSesiones"]);
                    obj.IntervaloMantenimiento = reader["IntervaloMantenimiento"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["IntervaloMantenimiento"]);
                    obj.ConsultaMantenimientoEn = reader["ConsultaMantenimientoEn"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["ConsultaMantenimientoEn"]);
                    obj.DescripcionComentario = reader["DescripcionComentario"] == DBNull.Value ? null : reader["DescripcionComentario"].ToString();
                    obj.IdDoctora = reader["IdDoctora"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["IdDoctora"]);
                    obj.IdEstado =  Convert.ToInt32(reader["IdEstado"]);
                    obj.Observacion = reader["Observacion"] == DBNull.Value ? null : reader["Observacion"].ToString();
                    obj.FechaRegistra = Convert.ToDateTime( reader["FechaRegistra"] );
                    obj.UsuarioRegistro = reader["UsuarioRegistro"].ToString();
                    obj.Condiciones = reader["Condiciones"] == DBNull.Value ? null : reader["Condiciones"].ToString();
                    obj.FechaNacimiento = reader["FechaNacimiento"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["FechaNacimiento"]);
                    obj.EmailEnviado = Convert.ToBoolean(reader["EmailEnviado"]);

                    obj.FechaModifico = reader["FechaModifico"] == DBNull.Value ? (DateTime?)null :  Convert.ToDateTime(reader["FechaModifico"]);
                    obj.UsuarioModifico = reader["UsuarioModifico"] == DBNull.Value ? null : reader["UsuarioModifico"].ToString();
                    obj.MotivoAnulacion = reader["MotivoAnulacion"] == DBNull.Value ? null : reader["MotivoAnulacion"].ToString();
                    obj.DniApoderado = reader["DniApoderado"] == DBNull.Value ? null : reader["DniApoderado"].ToString();
                    obj.NombreApoderado = reader["NombreApoderado"] == DBNull.Value ? null : reader["NombreApoderado"].ToString();

                    obj.NombreCliente = reader["NombreCLiente"].ToString();
                    obj.NombreDoctora = reader["NombreDoctora"] == DBNull.Value ? null : reader["NombreDoctora"].ToString();
                    obj.Direccion = reader["Direccion"] == DBNull.Value ? null : reader["Direccion"].ToString();
                    obj.Distrito = reader["Distrito"] == DBNull.Value ? null : reader["Distrito"].ToString();
                    obj.FechaDocumento = reader["FechaDocumento"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["FechaDocumento"]);
                    obj.TipoDocumentoIdentidad = reader["TipoDocumentoIdentidad"] == DBNull.Value ? null : reader["TipoDocumentoIdentidad"].ToString();
                    obj.DocumentoIdentidad = reader["DocumentoIdentidad"] == DBNull.Value ? null : reader["DocumentoIdentidad"].ToString();

                    // Filtrar y limpiar la propiedad Plantilla
                    string plantilla = reader["Plantilla"].ToString();
                    //plantilla = Regex.Replace(plantilla, @"""font"":""calibri,sans-serif"",", @"""background"":""white""");
                    plantilla = Regex.Replace(plantilla, @"""font"":""calibri,sans-serif"",", string.Empty);
                    plantilla = Regex.Replace(plantilla, @"""bold"":.*?,", string.Empty);
                    // Reemplazar "background":"transparent" por "background":"white"
                    plantilla = Regex.Replace(plantilla, @"""background"":""transparent""", @"""background"":""white""");
                    obj.Plantilla = plantilla;


                    obj.EmailCC = reader["EmailCC"].ToString();
                    obj.ClienteEmail = reader["ClienteEmail"] == DBNull.Value ? "" : reader["ClienteEmail"].ToString();

                    obj.Version = Convert.ToInt32( reader["Version"] );
                }

                List<CD_Zonas> zonas = new List<CD_Zonas>();
                if (reader.NextResult())
                {
                    while (await reader.ReadAsync())
                    {
                        zonas.Add(new CD_Zonas()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Nombre = reader["Nombre"].ToString()
                        });
                    }
                }
                obj.Zonas = zonas;


                List<CD_Patologias> patologias = new List<CD_Patologias>();
                if (reader.NextResult())
                {
                    while (await reader.ReadAsync())
                    {
                        patologias.Add(new CD_Patologias()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Nombre = reader["Nombre"].ToString()
                        });
                    }
                }
                obj.Patologias = patologias;

                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static async Task<List<ClienteDocumentoDTO>> ReadObtenerListado(DbDataReader reader)
        {
            try
            {
                List<ClienteDocumentoDTO> collection = new List<ClienteDocumentoDTO>();
                while (await reader.ReadAsync())
                {
                    ClienteDocumentoDTO obj = new ClienteDocumentoDTO();

                    obj.Id = Convert.ToInt32(reader["Id"]);
                    obj.IdCliente = Convert.ToInt32(reader["IdCliente"]);
                    obj.NombreDocumento = reader["NombreDocumento"].ToString();
                    obj.TituloDocumento = reader["TituloDocumento"].ToString();
                    obj.IdPromocion = reader["IdPromocion"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["IdPromocion"]);
                    obj.Promocion = reader["Promocion"] == DBNull.Value ? null : reader["Promocion"].ToString();
                    obj.IdsZonas = reader["IdZonas"] == DBNull.Value ? null : reader["IdZonas"].ToString();
                    obj.FechaRegistra = Convert.ToDateTime(reader["FechaRegistra"]);
                    obj.IdEstado = Convert.ToInt32(reader["IdEstado"]);
                    obj.EmailEnviado = Convert.ToBoolean(reader["EmailEnviado"]);
                    obj.UsuarioRegistro = reader["UsuarioRegistro"].ToString();
                    obj.EmailEnviado = Convert.ToBoolean(reader["EmailEnviado"]);
                    //obj.IdDocumentoTipo = Convert.ToInt32(reader["IdDocumentoTipo"]);
                    //obj.NombreDocumento = reader["NombreDocumento"].ToString();
                    //obj.IdPromocion = reader["IdPromocion"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["IdPromocion"]);
                    //obj.IdsZonas = reader["IdsZonas"] == DBNull.Value ? null : reader["IdsZonas"].ToString();
                    //obj.IdPatologia = reader["IdPatologia"] == DBNull.Value ? null : reader["IdPatologia"].ToString();
                    //obj.SesionesAdicionales = reader["SesionesAdicionales"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["SesionesAdicionales"]);
                    //obj.NumeroSesionesRetroceder = reader["NumeroSesionesRetroceder"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["NumeroSesionesRetroceder"]);
                    //obj.NumeroSesiones = reader["NumeroSesiones"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["NumeroSesiones"]);
                    //obj.IntervaloMantenimiento = reader["IntervaloMantenimiento"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["IntervaloMantenimiento"]);
                    //obj.ConsultaMantenimientoEn = reader["ConsultaMantenimientoEn"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["ConsultaMantenimientoEn"]);
                    //obj.DescripcionComentario = reader["DescripcionComentario"] == DBNull.Value ? null : reader["DescripcionComentario"].ToString();
                    //obj.Condiciones = reader["Condiciones"] == DBNull.Value ? null : reader["Condiciones"].ToString();
                    //obj.IdDoctora = reader["IdDoctora"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["IdDoctora"]);
                    //obj.IdEstado = Convert.ToInt32(reader["IdEstado"]);
                    //obj.Observacion = reader["Observacion"] == DBNull.Value ? null : reader["Observacion"].ToString();
                    //obj.FechaRegistra = Convert.ToDateTime(reader["FechaRegistra"]);
                    //obj.UsuarioRegistro = reader["UsuarioRegistro"].ToString();
                    //obj.FechaNacimiento = reader["FechaNacimiento"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["FechaNacimiento"]);
                    //obj.EmailEnviado = Convert.ToBoolean(reader["EmailEnviado"]);

                    //obj.FechaModifico = reader["FechaModifico"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["FechaModifico"]);
                    //obj.UsuarioModifico = reader["UsuarioModifico"] == DBNull.Value ? null : reader["UsuarioModifico"].ToString();
                    //obj.MotivoAnulacion = reader["MotivoAnulacion"] == DBNull.Value ? null : reader["MotivoAnulacion"].ToString();
                    //obj.DniApoderado = reader["DniApoderado"] == DBNull.Value ? null : reader["DniApoderado"].ToString();
                    //obj.NombreApoderado = reader["NombreApoderado"] == DBNull.Value ? null : reader["NombreApoderado"].ToString();

                    //obj.NombreCliente = reader["NombreCLiente"].ToString();
                    //obj.NombreDoctora = reader["NombreDoctora"] == DBNull.Value ? null : reader["NombreDoctora"].ToString();
                    //obj.Direccion = reader["Direccion"] == DBNull.Value ? null : reader["Direccion"].ToString();
                    //obj.Distrito = reader["Distrito"] == DBNull.Value ? null : reader["Distrito"].ToString();
                    //obj.FechaDocumento = reader["FechaDocumento"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["FechaDocumento"]);
                    //obj.TipoDocumentoIdentidad = reader["TipoDocumentoIdentidad"] == DBNull.Value ? null : reader["TipoDocumentoIdentidad"].ToString();
                    //obj.DocumentoIdentidad = reader["DocumentoIdentidad"] == DBNull.Value ? null : reader["DocumentoIdentidad"].ToString();

                    //obj.Promocion = reader["Promocion"] == DBNull.Value ? null : reader["Promocion"].ToString();

                    //obj.Version = Convert.ToInt32(reader["Version"]);                 

                    collection.Add(obj);
                }

                return collection;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static async Task<List<ClienteDocumentoDTO>> ReadObtenerListadoByCliente(DbDataReader reader)
        {
            try
            {
                List<ClienteDocumentoDTO> collection = new List<ClienteDocumentoDTO>();
                while (await reader.ReadAsync())
                {
                    ClienteDocumentoDTO obj = new ClienteDocumentoDTO();

                    obj.Id = Convert.ToInt32(reader["Id"]);
                    obj.IdCliente = Convert.ToInt32(reader["IdCliente"]);
                    obj.NombreDocumento = reader["NombreDocumento"].ToString();
                    obj.TituloDocumento = reader["TituloDocumento"].ToString();
                    obj.IdPromocion = reader["IdPromocion"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["IdPromocion"]);
                    obj.Promocion = reader["Promocion"] == DBNull.Value ? null : reader["Promocion"].ToString();
                    obj.IdsZonas = reader["IdZonas"] == DBNull.Value ? null : reader["IdZonas"].ToString();
                    obj.FechaRegistra = Convert.ToDateTime(reader["FechaRegistra"]);
                    obj.IdEstado = Convert.ToInt32(reader["IdEstado"]);
                    obj.EmailEnviado = Convert.ToBoolean(reader["EmailEnviado"]);
                    obj.UsuarioRegistro = reader["UsuarioRegistro"].ToString();
                    obj.EmailEnviado = Convert.ToBoolean(reader["EmailEnviado"]);
                    obj.ListaZonas = DBNull.Value == reader["Zonas"] ? null : reader["Zonas"].ToString();
                    //obj.NombreDocumento = reader["NombreDocumento"].ToString();
                    //obj.IdPromocion = reader["IdPromocion"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["IdPromocion"]);
                    //obj.IdsZonas = reader["IdsZonas"] == DBNull.Value ? null : reader["IdsZonas"].ToString();
                    //obj.IdPatologia = reader["IdPatologia"] == DBNull.Value ? null : reader["IdPatologia"].ToString();
                    //obj.SesionesAdicionales = reader["SesionesAdicionales"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["SesionesAdicionales"]);
                    //obj.NumeroSesionesRetroceder = reader["NumeroSesionesRetroceder"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["NumeroSesionesRetroceder"]);
                    //obj.NumeroSesiones = reader["NumeroSesiones"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["NumeroSesiones"]);
                    //obj.IntervaloMantenimiento = reader["IntervaloMantenimiento"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["IntervaloMantenimiento"]);
                    //obj.ConsultaMantenimientoEn = reader["ConsultaMantenimientoEn"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["ConsultaMantenimientoEn"]);
                    //obj.DescripcionComentario = reader["DescripcionComentario"] == DBNull.Value ? null : reader["DescripcionComentario"].ToString();
                    //obj.Condiciones = reader["Condiciones"] == DBNull.Value ? null : reader["Condiciones"].ToString();
                    //obj.IdDoctora = reader["IdDoctora"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["IdDoctora"]);
                    //obj.IdEstado = Convert.ToInt32(reader["IdEstado"]);
                    //obj.Observacion = reader["Observacion"] == DBNull.Value ? null : reader["Observacion"].ToString();
                    //obj.FechaRegistra = Convert.ToDateTime(reader["FechaRegistra"]);
                    //obj.UsuarioRegistro = reader["UsuarioRegistro"].ToString();
                    //obj.FechaNacimiento = reader["FechaNacimiento"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["FechaNacimiento"]);
                    //obj.EmailEnviado = Convert.ToBoolean(reader["EmailEnviado"]);

                    //obj.FechaModifico = reader["FechaModifico"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["FechaModifico"]);
                    //obj.UsuarioModifico = reader["UsuarioModifico"] == DBNull.Value ? null : reader["UsuarioModifico"].ToString();
                    //obj.MotivoAnulacion = reader["MotivoAnulacion"] == DBNull.Value ? null : reader["MotivoAnulacion"].ToString();
                    //obj.DniApoderado = reader["DniApoderado"] == DBNull.Value ? null : reader["DniApoderado"].ToString();
                    //obj.NombreApoderado = reader["NombreApoderado"] == DBNull.Value ? null : reader["NombreApoderado"].ToString();

                    //obj.NombreCliente = reader["NombreCLiente"].ToString();
                    //obj.NombreDoctora = reader["NombreDoctora"] == DBNull.Value ? null : reader["NombreDoctora"].ToString();
                    //obj.Direccion = reader["Direccion"] == DBNull.Value ? null : reader["Direccion"].ToString();
                    //obj.Distrito = reader["Distrito"] == DBNull.Value ? null : reader["Distrito"].ToString();
                    //obj.FechaDocumento = reader["FechaDocumento"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["FechaDocumento"]);
                    //obj.TipoDocumentoIdentidad = reader["TipoDocumentoIdentidad"] == DBNull.Value ? null : reader["TipoDocumentoIdentidad"].ToString();
                    //obj.DocumentoIdentidad = reader["DocumentoIdentidad"] == DBNull.Value ? null : reader["DocumentoIdentidad"].ToString();

                    //obj.Promocion = reader["Promocion"] == DBNull.Value ? null : reader["Promocion"].ToString();

                    //obj.Version = Convert.ToInt32(reader["Version"]);                 

                    collection.Add(obj);
                }

                return collection;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static async Task<List<ClienteDocumentoDTO>> ReadObtenerListadoByClienteByServicio(DbDataReader reader)
        {
            try
            {
                List<ClienteDocumentoDTO> collection = new List<ClienteDocumentoDTO>();
                while (await reader.ReadAsync())
                {
                    ClienteDocumentoDTO obj = new ClienteDocumentoDTO();

                    obj.Id = Convert.ToInt32(reader["Id"]);
                    obj.IdCliente = Convert.ToInt32(reader["IdCliente"]);
                    obj.NombreDocumento = reader["NombreDocumento"].ToString();
                    obj.TituloDocumento = reader["TituloDocumento"].ToString();
                    obj.IdPromocion = reader["IdPromocion"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["IdPromocion"]);
                    obj.Promocion = reader["Promocion"] == DBNull.Value ? null : reader["Promocion"].ToString();
                    obj.IdsZonas = reader["IdZonas"] == DBNull.Value ? null : reader["IdZonas"].ToString();
                    obj.FechaRegistra = Convert.ToDateTime(reader["FechaRegistra"]);
                    obj.IdEstado = Convert.ToInt32(reader["IdEstado"]);
                    obj.EmailEnviado = Convert.ToBoolean(reader["EmailEnviado"]);
                    obj.UsuarioRegistro = reader["UsuarioRegistro"].ToString();
                    obj.EmailEnviado = Convert.ToBoolean(reader["EmailEnviado"]);
                    obj.ListaZonas = DBNull.Value == reader["Zonas"] ? null : reader["Zonas"].ToString();
                    obj.Confirmado = DBNull.Value == reader["Confirmado"] ? 0 : Convert.ToInt32(reader["Confirmado"]);
                    obj.FechaConfirmo = reader["FechaConfirmo"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["FechaConfirmo"]);

                    //obj.NombreDocumento = reader["NombreDocumento"].ToString();
                    //obj.IdPromocion = reader["IdPromocion"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["IdPromocion"]);
                    //obj.IdsZonas = reader["IdsZonas"] == DBNull.Value ? null : reader["IdsZonas"].ToString();
                    //obj.IdPatologia = reader["IdPatologia"] == DBNull.Value ? null : reader["IdPatologia"].ToString();
                    //obj.SesionesAdicionales = reader["SesionesAdicionales"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["SesionesAdicionales"]);
                    //obj.NumeroSesionesRetroceder = reader["NumeroSesionesRetroceder"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["NumeroSesionesRetroceder"]);
                    //obj.NumeroSesiones = reader["NumeroSesiones"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["NumeroSesiones"]);
                    //obj.IntervaloMantenimiento = reader["IntervaloMantenimiento"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["IntervaloMantenimiento"]);
                    //obj.ConsultaMantenimientoEn = reader["ConsultaMantenimientoEn"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["ConsultaMantenimientoEn"]);
                    //obj.DescripcionComentario = reader["DescripcionComentario"] == DBNull.Value ? null : reader["DescripcionComentario"].ToString();
                    //obj.Condiciones = reader["Condiciones"] == DBNull.Value ? null : reader["Condiciones"].ToString();
                    //obj.IdDoctora = reader["IdDoctora"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["IdDoctora"]);
                    //obj.IdEstado = Convert.ToInt32(reader["IdEstado"]);
                    //obj.Observacion = reader["Observacion"] == DBNull.Value ? null : reader["Observacion"].ToString();
                    //obj.FechaRegistra = Convert.ToDateTime(reader["FechaRegistra"]);
                    //obj.UsuarioRegistro = reader["UsuarioRegistro"].ToString();
                    //obj.FechaNacimiento = reader["FechaNacimiento"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["FechaNacimiento"]);
                    //obj.EmailEnviado = Convert.ToBoolean(reader["EmailEnviado"]);

                    //obj.FechaModifico = reader["FechaModifico"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["FechaModifico"]);
                    //obj.UsuarioModifico = reader["UsuarioModifico"] == DBNull.Value ? null : reader["UsuarioModifico"].ToString();
                    //obj.MotivoAnulacion = reader["MotivoAnulacion"] == DBNull.Value ? null : reader["MotivoAnulacion"].ToString();
                    //obj.DniApoderado = reader["DniApoderado"] == DBNull.Value ? null : reader["DniApoderado"].ToString();
                    //obj.NombreApoderado = reader["NombreApoderado"] == DBNull.Value ? null : reader["NombreApoderado"].ToString();

                    //obj.NombreCliente = reader["NombreCLiente"].ToString();
                    //obj.NombreDoctora = reader["NombreDoctora"] == DBNull.Value ? null : reader["NombreDoctora"].ToString();
                    //obj.Direccion = reader["Direccion"] == DBNull.Value ? null : reader["Direccion"].ToString();
                    //obj.Distrito = reader["Distrito"] == DBNull.Value ? null : reader["Distrito"].ToString();
                    //obj.FechaDocumento = reader["FechaDocumento"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["FechaDocumento"]);
                    //obj.TipoDocumentoIdentidad = reader["TipoDocumentoIdentidad"] == DBNull.Value ? null : reader["TipoDocumentoIdentidad"].ToString();
                    //obj.DocumentoIdentidad = reader["DocumentoIdentidad"] == DBNull.Value ? null : reader["DocumentoIdentidad"].ToString();

                    //obj.Promocion = reader["Promocion"] == DBNull.Value ? null : reader["Promocion"].ToString();

                    //obj.Version = Convert.ToInt32(reader["Version"]);                 

                    collection.Add(obj);
                }

                return collection;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static async Task<List<CD_Zonas>> ReadListadoZonas(DbDataReader reader)
        {
            try
            {
                List<CD_Zonas> collection = new List<CD_Zonas>();
                while (await reader.ReadAsync())
                {
                    CD_Zonas obj = new CD_Zonas();

                    obj.Id = Convert.ToInt32(reader["Id"]);
                    obj.Nombre = reader["Nombre"].ToString();

                    collection.Add(obj);
                }

                return collection;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static async Task<ClienteDocumentoDTO> ReadDatosEmail(DbDataReader reader)
        {
            try
            {
                ClienteDocumentoDTO obj = new ClienteDocumentoDTO();
                while (await reader.ReadAsync())
                {
                    bool Exito = Convert.ToBoolean(reader["Exito"]);
                    string Mensaje = Convert.ToString(reader["Mensaje"]);

                    if (!Exito)
                    {
                        throw new SystemException(Mensaje);
                    }

                    obj.EmailCC = reader["EmailCC"].ToString();
                    obj.ClienteEmail = reader["ClienteEmail"] == DBNull.Value ? "" : reader["ClienteEmail"].ToString();
                }

                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}