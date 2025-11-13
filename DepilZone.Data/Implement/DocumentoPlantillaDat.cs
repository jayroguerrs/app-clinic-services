using DepilZone.Data.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text.Json;
using System.Threading.Tasks;
namespace DepilZone.Data
{
    public class DocumentoPlantillaDat : IDocumentoPlantillaDat
    {
        private readonly string _connectionString;

        public DocumentoPlantillaDat(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
        public async Task<IEnumerable<DocumentoPlantillaDTO>> ObtenerListado()
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_DocumentoPlantilla_Listar", conn)
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

        public async Task<Respuesta<DocumentoPlantillaEnt>> Insertar(DocumentoPlantillaDTO model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_DocumentoPlantilla_Insertar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdTipoDocumento", model.IdDocumentoTipo);
                cmd.Parameters.AddWithValue("pPlantilla", model.Plantilla);
                cmd.Parameters.AddWithValue("pVersion", model.Version);
                cmd.Parameters.AddWithValue("pEstado", model.IdEstado);
                cmd.Parameters.AddWithValue("pUsuarioRegistra", model.UsuarioRegistra);
                cmd.Parameters.AddWithValue("pHtml", model.Html);
                cmd.Parameters.AddWithValue("pMargin", model.Margin);
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

        public async Task<Respuesta<DocumentoPlantillaEnt>> ObtenerById(int id)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_DocumentoPlantilla_ObtenerById", conn)
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

        public async Task<Respuesta<DocumentoPlantillaEnt>> Modificar(DocumentoPlantillaDTO model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_DocumentoPlantilla_Modificar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pId", model.Id);
                cmd.Parameters.AddWithValue("pIdTipoDocumento", model.IdDocumentoTipo);
                cmd.Parameters.AddWithValue("pPlantilla", model.Plantilla);
                cmd.Parameters.AddWithValue("pVersion", model.Version);
                cmd.Parameters.AddWithValue("pEstado", model.IdEstado);
                cmd.Parameters.AddWithValue("pUsuarioRegistra", model.UsuarioRegistra);
                cmd.Parameters.AddWithValue("pHtml", model.Html);
                cmd.Parameters.AddWithValue("pMargin", model.Margin);
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

        /*public async Task<IEnumerable<DocumentoTipoPerfilDTO>> ObtenerPerfilesById( int id )
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_DocumentoTipo_ListarPerfilesById", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pId", id);
                var reader = await cmd.ExecuteReaderAsync();
                return await ReadPerfiles(reader);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }*/

        /*public async Task<Respuesta<DocumentoTipoEnt>> AsignarPerfiles(int id, int[] perfiles)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_DocumentoTipo_AsignarPerfiles", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pId", id);
                cmd.Parameters.AddWithValue("pPerfiles", JsonSerializer.Serialize(perfiles));
                var reader = await cmd.ExecuteReaderAsync();
                return await ReadItem(reader);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }*/





        // READERS
        static async Task<IEnumerable<DocumentoPlantillaDTO>> ReadItemsListado(DbDataReader reader)
        {
            try
            {

                // Leer listado de tipos de documento
                List<DocumentoPlantillaDTO> documentoPlantillas = new List<DocumentoPlantillaDTO>();
                while (await reader.ReadAsync())
                {
                    DocumentoPlantillaDTO documentoPlantilla = new DocumentoPlantillaDTO()
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        IdDocumentoTipo = Convert.ToInt32(reader["IdDocumentoTipo"]),
                        Plantilla = reader["Plantilla"].ToString(),
                        Version = Convert.ToInt32(reader["Version"]),
                        IdEstado = Convert.ToInt32(reader["IdEstado"]),
                        FechaRegistra = Convert.ToDateTime(reader["FechaRegistra"]),
                        UsuarioRegistra = reader["UsuarioRegistra"].ToString(),
                        ImagenCabeceraDocumento = reader["ImagenCabeceraDocumento"].ToString(),
                        ImagenPieDocumento = reader["ImagenPieDocumento"].ToString(),
                        Html = reader["Html"].ToString(),
                        Margin = reader["Margin"].ToString(),
                        Documento = new DP_DocumentoDTO { 
                            Id = Convert.ToInt32(reader["IdDocumentoTipo"]),
                            Nombre = reader["DTNombre"].ToString(),
                        }
                    };
                    documentoPlantillas.Add(documentoPlantilla);
                }



                return documentoPlantillas;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        static async Task<Respuesta<DocumentoPlantillaEnt>> ReadItem(DbDataReader reader)
        {

            try
            {
                Respuesta<DocumentoPlantillaEnt> response = new Respuesta<DocumentoPlantillaEnt>
                {
                    Response = new DocumentoPlantillaEnt()
                };

                while (await reader.ReadAsync())
                {
                    response.Exito = Convert.ToBoolean(reader["Exito"]);
                    response.Mensaje = Convert.ToString(reader["Mensaje"]);
                    response.ErrorNumero = Convert.ToInt32(reader["ErrorNumero"]);
                    response.ErrorDetalle = reader["ErrorDetalle"].ToString();
                    response.Response.Id = Convert.ToInt32(reader["Id"]);
                    if (response.Exito)
                    {
                        response.Response.Id = Convert.ToInt32(reader["Id"]);
                        response.Response.IdDocumentoTipo = Convert.ToInt32(reader["IdDocumentoTipo"]);
                        response.Response.Plantilla = reader["Plantilla"].ToString();
                        response.Response.Version = Convert.ToInt32(reader["Version"]);
                        response.Response.IdEstado = Convert.ToInt32(reader["IdEstado"]);
                        response.Response.FechaRegistra = Convert.ToDateTime(reader["FechaRegistra"]);
                        response.Response.UsuarioRegistra = reader["UsuarioRegistra"].ToString();
                        response.Response.ImagenCabeceraDocumento = reader["ImagenCabeceraDocumento"].ToString();
                        response.Response.ImagenPieDocumento = reader["ImagenPieDocumento"].ToString();
                        response.Response.Html = reader["Html"].ToString();
                        response.Response.Margin = reader["Margin"].ToString();
                        response.Response.Documento = new DP_DocumentoEnt
                        {
                            Id = Convert.ToInt32(reader["IdDocumentoTipo"]),
                            Nombre = reader["DTNombre"].ToString(),
                        };
                    }
                }



                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        static async Task<IEnumerable<DocumentoTipoPerfilDTO>> ReadPerfiles(DbDataReader reader)
        {

            try
            {
                List<DocumentoTipoPerfilDTO> perfiles = new List<DocumentoTipoPerfilDTO>();

                while (await reader.ReadAsync())
                {
                    DocumentoTipoPerfilDTO perfil = new DocumentoTipoPerfilDTO()
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Nombre = reader["Nombre"].ToString(),
                    };
                    perfiles.Add(perfil);
                }



                return perfiles;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}