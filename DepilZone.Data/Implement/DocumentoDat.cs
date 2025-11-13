using DepilZone.Data.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace DepilZone.Data
{
    public class DocumentoDat : IDocumentoDat
    {
        private readonly string _connectionString;

        public DocumentoDat(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
        public async Task<IEnumerable<DocumentoTipoEnt>> ObtenerTipoDocumento()
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Documento_ObtenerTipo", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItemsTipoDocumento(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<IEnumerable<DocumentoTipoEnt>> ObtenerTipoDocumentoByPerfil(int idPerfil)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Documento_ObtenerTipoByPerfil", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdPerfil", idPerfil);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItemsTipoDocumento(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public async Task<DocumentoPlantillaDTO> ObtenerPlantilla(int idDocumentoTipo)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Documento_ObtenerPlantilla", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdDocumentoTipo", idDocumentoTipo);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItemsObtenerPlantilla(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Respuesta<DocumentoDTO>> Insertar(DocumentoEnt model)
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
                cmd.Parameters.AddWithValue("pIntervaloMantenimiento", model.IntervaloMantenimiento);
                cmd.Parameters.AddWithValue("pConsultaMantenimientoEn", model.ConsultaMantenimientoEn);
                cmd.Parameters.AddWithValue("pDescripcionComentario", model.DescripcionComentario);
                cmd.Parameters.AddWithValue("pIdDoctora", model.IdDoctora);


                cmd.Parameters.AddWithValue("pIdEstado", 1);
                cmd.Parameters.AddWithValue("pObservacion", model.Observacion);
                cmd.Parameters.AddWithValue("pUsuarioRegistra", model.UsuarioRegistra);
                cmd.Parameters.AddWithValue("pDocumento", model.Documento);

                cmd.Parameters.AddWithValue("pDniApoderado", model.DniApoderado);
                cmd.Parameters.AddWithValue("pNombreApoderado", model.NombreApoderado);

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
        public async Task<IEnumerable<DocumentoDTO>> ObtenerListado()
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
                var output = await ReadItemsListado(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
       
        }

        public async Task<IEnumerable<DocumentoDTO>> ObtenerListadoByCliente( int idCliente )
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
                var output = await ReadItemsListadoByCliente(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }

        public async Task<Respuesta<DocumentoDTO>> AnularDocumento(int id)
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




        //Readers
        static async Task<IEnumerable<DocumentoTipoEnt>> ReadItemsTipoDocumento(DbDataReader reader)
        {
            try
            {
                IList<DocumentoTipoEnt> lista = new List<DocumentoTipoEnt>();
                while (await reader.ReadAsync())
                {
                    DocumentoTipoEnt obj = new DocumentoTipoEnt
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Nombre = reader["Nombre"].ToString(),
                        Titulo = reader["Titulo"].ToString(),
                        Version = reader["Version"] == DBNull.Value ? (int?)null : Convert.ToInt32( reader["Version"] )
                    };
                    lista.Add(obj);
                }



                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static async Task<DocumentoPlantillaDTO> ReadItemsObtenerPlantilla(DbDataReader reader)
        {
            try
            {
                DocumentoPlantillaDTO obj = new DocumentoPlantillaDTO();
                while (await reader.ReadAsync())
                {
                    obj.Id = Convert.ToInt32(reader["Id"]);
                    obj.IdDocumentoTipo = Convert.ToInt32(reader["IdDocumentoTipo"]);

                    // Leer las propiedades originales
                    string plantilla = reader["Plantilla"].ToString();
                    string html = reader["Html"].ToString();

                    // Aplicar los filtros con Regex
                    //plantilla = Regex.Replace(plantilla, @"""font"":""calibri,sans-serif"",", @"""background"":""white""");
                    plantilla = Regex.Replace(plantilla, @"""font"":""calibri,sans-serif"",", string.Empty);
                    plantilla = Regex.Replace(plantilla, @"""bold"":.*?,", string.Empty);
                    // Reemplazar "background":"transparent" por "background":"white"
                    plantilla = Regex.Replace(plantilla, @"""background"":""transparent""", @"""background"":""white""");
                    html = Regex.Replace(html, @"font-family:Calibri,sans-serif;", string.Empty);

                    // Asignar las propiedades filtradas
                    obj.Plantilla = plantilla;
                    obj.Html = html;

                    obj.Margin = reader["Margin"].ToString();
                    obj.Version = Convert.ToInt32(reader["Version"]);
                    obj.IdEstado = Convert.ToInt32(reader["IdEstado"]);
                    obj.ImagenCabeceraDocumento = reader["ImagenCabeceraDocumento"].ToString();
                    obj.ImagenPieDocumento = reader["ImagenPieDocumento"].ToString();
                }

                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static async Task<Respuesta<DocumentoDTO>> ReadItemInsertar(DbDataReader reader)
        {
            try
            {
                Respuesta<DocumentoDTO> obj = new Respuesta<DocumentoDTO>
                {
                    Response = new DocumentoDTO()
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
                        obj.Response.IdDocumentoTipo = Convert.ToInt32(reader["IdDocumentoTipo"]);
                        obj.Response.IdCliente = Convert.ToInt32(reader["IdCliente"]);
                        obj.Response.ClienteEmail = reader["ClienteEmail"].ToString();
                        obj.Response.EmailCC = reader["EmailCC"].ToString();
                        obj.Response.TituloDocumento = reader["TituloDocumento"].ToString();
                    }
                }



                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        static async Task<IEnumerable<DocumentoDTO>> ReadItemsListado(DbDataReader reader)
        {
            try
            {
                List<DocumentoDTO> listado = new List<DocumentoDTO>();
                while (await reader.ReadAsync())
                {
                    listado.Add(new DocumentoDTO()
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        IdCliente = Convert.ToInt32(reader["IdCliente"]),
                        IdDocumentoTipo = Convert.ToInt32(reader["IdDocumentoTipo"]),
                        IdPromocion = reader["IdPromocion"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["IdPromocion"]),
                        IdsZonas = reader["IdsZonas"].ToString(),
                        FechaRegistra = Convert.ToDateTime(reader["FechaRegistra"]),
                        UsuarioRegistra = reader["UsuarioRegistra"].ToString(),
                        Cliente = reader["Cliente"].ToString(),
                        Promocion = reader["Promocion"] == DBNull.Value ? null : reader["Promocion"].ToString(),
                        Documento = reader["Nombre"].ToString(),
                        //Pdf64 = reader["Pdf64"].ToString(),
                        IdEstado = Convert.ToInt32(reader["IdEstado"])
                    });
                }



                return listado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        static async Task<IEnumerable<DocumentoDTO>> ReadItemsListadoByCliente(DbDataReader reader)
        {
            try
            {
                List<DocumentoDTO> listado = new List<DocumentoDTO>();
                while (await reader.ReadAsync())
                {
                    listado.Add(new DocumentoDTO()
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        IdCliente = Convert.ToInt32(reader["IdCliente"]),
                        Documento = reader["Nombre"].ToString(),
                        TituloDocumento = reader["TituloDocumento"].ToString(),
                        IdPromocion = reader["IdPromocion"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["IdPromocion"]),
                        Promocion = reader["Promocion"] == DBNull.Value ? null : reader["Promocion"].ToString(),
                        IdsZonas = reader["IdsZonas"].ToString(),
                        FechaRegistra = Convert.ToDateTime(reader["FechaRegistra"]),
                        UsuarioRegistra = reader["UsuarioRegistro"].ToString(),
                        //Pdf64 = reader["Pdf64"].ToString(),
                        IdEstado = Convert.ToInt32(reader["IdEstado"]),
                        EmailEnviado = Convert.ToBoolean(reader["EmailEnviado"]),
                        DocumentoPromocion = reader["IdPromocion"] == DBNull.Value ? null : new DocumentoPromocionDTO() {
                            Id = reader["IdPromocion"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["IdPromocion"]),
                            Nombre = reader["Promocion"] == DBNull.Value ? null : reader["Promocion"].ToString(),
                        }
                    }); ;
                }



                return listado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static async Task<Respuesta<DocumentoDTO>> ReadItemAnular(DbDataReader reader)
        {
            try
            {
                Respuesta<DocumentoDTO> obj = new Respuesta<DocumentoDTO>
                {
                    Response = new DocumentoDTO()
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
                        obj.Response.Documento = reader["Nombre"].ToString();
                        obj.Response.IdPromocion = reader["IdPromocion"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["IdPromocion"]);
                        obj.Response.Promocion = reader["Promocion"].ToString();
                        obj.Response.IdsZonas = reader["IdsZonas"].ToString();
                        obj.Response.FechaRegistra = Convert.ToDateTime(reader["FechaRegistra"]);
                        //obj.Response.Pdf64 = reader["Pdf64"].ToString();
                        obj.Response.IdEstado = Convert.ToInt32(reader["IdEstado"]);
                        obj.Response.DocumentoPromocion = reader["IdPromocion"] == DBNull.Value ? null : new DocumentoPromocionDTO()
                        {
                            Id = Convert.ToInt32(reader["IdPromocion"]),
                            Nombre = reader["Promocion"].ToString()
                        };
                    }
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