using DepilZone.Data.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using DepilZone.Entidad.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
namespace DepilZone.Data
{
    public class DocumentoTipoDat : IDocumentoTipoDat
    {
        private readonly string _connectionString;

        public DocumentoTipoDat(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
        public async Task<IEnumerable<DocumentoTipoDTO>> ObtenerListado()
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_DocumentoTipo_Listar", conn)
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

        public async Task<bool> Insertar(DocumentoTipoDTO model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_DocumentoTipo_Insertar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pNombre", model.Nombre);
                cmd.Parameters.AddWithValue("pTitulo", model.Titulo);
                cmd.Parameters.AddWithValue("pIdServicio", model.IdServicio);
                cmd.Parameters.AddWithValue("pIdUsuarioRegistro", model.IdUsuarioRegistro);

                cmd.Parameters.AddWithValue("pBlPromocion", model.BlPromocion);
                cmd.Parameters.AddWithValue("pBlZona", model.BlZona);
                cmd.Parameters.AddWithValue("pBlPatologia", model.BlPatologia);
                cmd.Parameters.AddWithValue("pBlApoderado", model.BlApoderado);
                cmd.Parameters.AddWithValue("pBlMantenimiento", model.BlMantenimiento);
                cmd.Parameters.AddWithValue("pBlRetroceso", model.BlRetroceso);

                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadInsertar(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<DocumentoTipoEnt> ObtenerById(int id)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_DocumentoTipo_ObtenerById", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("Id", id);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadObtenerById(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Modificar(DocumentoTipoDTO model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_DocumentoTipo_Modificar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pId", model.Id);
                cmd.Parameters.AddWithValue("pNombre", model.Nombre);
                cmd.Parameters.AddWithValue("pTitulo", model.Titulo);
                cmd.Parameters.AddWithValue("pIdServicio", model.IdServicio);
                cmd.Parameters.AddWithValue("pIdUsuarioModifico", model.IdUsuarioModifico);

                cmd.Parameters.AddWithValue("pBlPromocion", model.BlPromocion);
                cmd.Parameters.AddWithValue("pBlZona", model.BlZona);
                cmd.Parameters.AddWithValue("pBlPatologia", model.BlPatologia);
                cmd.Parameters.AddWithValue("pBlApoderado", model.BlApoderado);
                cmd.Parameters.AddWithValue("pBlMantenimiento", model.BlMantenimiento);
                cmd.Parameters.AddWithValue("pBlRetroceso", model.BlRetroceso);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadModificar(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<DocumentoTipoPerfilDTO>> ObtenerPerfilesById( int id )
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
                var output = await ReadPerfiles(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Respuesta<DocumentoTipoEnt>> AsignarPerfiles(int id, int[] perfiles)
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
                var output = await ReadItem(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<DocumentoTipoEnt>> ListarByServicio(int idServicio)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_DocumentoTipo_ListarByServicio", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdServicio", idServicio);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadListarByServicio(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }





        // READERS
        static async Task<IEnumerable<DocumentoTipoDTO>> ReadItemsListado(DbDataReader reader)
        {
            try
            {

                // Leer listado de tipos de documento
                List<DocumentoTipoDTO> documentoTipos = new List<DocumentoTipoDTO>();
                while (await reader.ReadAsync())
                {
                    DocumentoTipoDTO documentoTipo = new DocumentoTipoDTO()
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Nombre = reader["Nombre"].ToString(),
                        Titulo = reader["Titulo"].ToString(),
                        IdServicio = DBNull.Value == reader["IdServicio"] ? (int?)null : Convert.ToInt32(reader["IdServicio"]),
                        Servicio = DBNull.Value == reader["Servicio"] ? null : Convert.ToString(reader["Servicio"]),
                        ServicioColor = DBNull.Value == reader["ServicioColor"] ? null : Convert.ToString(reader["ServicioColor"]),
                        IdUsuarioRegistro = DBNull.Value == reader["IdUsuarioRegistro"] ? (int?)null : Convert.ToInt32(reader["IdUsuarioRegistro"]),
                        UsuarioRegistro = DBNull.Value == reader["UsuarioRegistro"] ? null : Convert.ToString(reader["UsuarioRegistro"]),
                        FechaRegistro = DBNull.Value == reader["FechaRegistro"] ? (DateTime?)null : Convert.ToDateTime(reader["FechaRegistro"]),
                        IdUsuarioModifico = DBNull.Value == reader["IdUsuarioModifico"] ? (int?)null : Convert.ToInt32(reader["IdUsuarioModifico"]),
                        UsuarioModifico = DBNull.Value == reader["UsuarioModifico"] ? null : Convert.ToString(reader["UsuarioModifico"]),
                        FechaModifico = DBNull.Value == reader["FechaModifico"] ? (DateTime?)null : Convert.ToDateTime(reader["FechaModifico"]),

                        BlPromocion = Convert.ToBoolean(reader["BlPromocion"]),
                        BlZona = Convert.ToBoolean(reader["BlZona"]),
                        BlPatologia = Convert.ToBoolean(reader["BlPatologia"]),
                        BlApoderado = Convert.ToBoolean(reader["BlApoderado"]),
                        BlMantenimiento = Convert.ToBoolean(reader["BlMantenimiento"]),
                        BlRetroceso = Convert.ToBoolean(reader["BlRetroceso"]),



                        Perfiles = new List<DocumentoTipoPerfilDTO>(),
                        docStatus = Convert.ToInt32(reader["DOC_STATUS"]),
                    };
                    documentoTipos.Add(documentoTipo);
                }

                // Leer listado de perfiles
                List<PerfilDTO> perfiles = new List<PerfilDTO>();
                if (reader.NextResult())
                {
                    while (await reader.ReadAsync())
                    {
                        PerfilDTO perfil = new PerfilDTO()
                        {
                            IdPerfil = Convert.ToInt32(reader["Id"]),
                            Nombre = reader["Nombre"].ToString()
                        };
                        perfiles.Add(perfil);
                    }
                }

                // Leer listado de relacion documento con perfil
                if (reader.NextResult())
                {
                    while (await reader.ReadAsync())
                    {
                        var IdTipo = Convert.ToInt32(reader["IdTipo"]);
                        var IdPerfil = Convert.ToInt32(reader["IdPerfil"]);


                        //Asociar documento con perfiles

                        // Buscar Tipo
                        var Tipo = documentoTipos.Find(d => d.Id == IdTipo);
                        var index = documentoTipos.FindIndex(d => d.Id == IdTipo);

                        if (Tipo != null)
                        {
                            // Buscar Perfil
                            var Perfil = perfiles.Find(p => p.IdPerfil == IdPerfil);

                            if (Perfil != null)
                            {
                                // Insertar perfil en la lista
                                documentoTipos[index].Perfiles.Add(
                                    new DocumentoTipoPerfilDTO()
                                    {
                                        Id = Perfil.IdPerfil,
                                        Nombre = Perfil.Nombre
                                    }
                                );
                            }
                        }
                    }
                }



                return documentoTipos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        static async Task<Respuesta<DocumentoTipoEnt>> ReadItem(DbDataReader reader)
        {

            try
            {
                Respuesta<DocumentoTipoEnt> response = new Respuesta<DocumentoTipoEnt>
                {
                    Response = new DocumentoTipoEnt()
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
                        response.Response.Nombre = reader["Nombre"].ToString();
                        response.Response.Titulo = reader["Titulo"].ToString();
                        response.Response.Perfiles = new List<DocumentoTipoPerfilEnt>();
                    }
                }


                if (response.Exito)
                {

                    // Leer listado de perfiles
                    List<PerfilDTO> perfiles = new List<PerfilDTO>();
                    if (reader.NextResult())
                    {
                        while (await reader.ReadAsync())
                        {
                            PerfilDTO perfil = new PerfilDTO()
                            {
                                IdPerfil = Convert.ToInt32(reader["Id"]),
                                Nombre = reader["Nombre"].ToString()
                            };
                            perfiles.Add(perfil);
                        }
                    }

                    // Leer listado de relacion documento con perfil
                    if (reader.NextResult())
                    {
                        while (await reader.ReadAsync())
                        {
                            var IdTipo = Convert.ToInt32(reader["IdTipo"]);
                            var IdPerfil = Convert.ToInt32(reader["IdPerfil"]);


                            //Asociar documento con perfiles
                            // Buscar Perfil
                            var Perfil = perfiles.Find(p => p.IdPerfil == IdPerfil);

                            if (Perfil != null)
                            {
                                // Insertar perfil en la lista
                                response.Response.Perfiles.Add(
                                    new DocumentoTipoPerfilEnt()
                                    {
                                        Id = Perfil.IdPerfil,
                                        Nombre = Perfil.Nombre
                                    }
                                );
                            }
                        }
                    }

                }



                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        static async Task<bool> ReadInsertar(DbDataReader reader)
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

                    if (!Exito)
                    {
                        Mensaje = Convert.ToString(reader["Mensaje"]);
                        ErrorNumero = Convert.ToInt32(reader["ErrorNumero"]);
                        ErrorDetalle = reader["ErrorDetalle"].ToString();

                        throw new AlertException(Mensaje);
                    }
                }

                return Exito;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        static async Task<bool> ReadModificar(DbDataReader reader)
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

                    if (!Exito)
                    {
                        Mensaje = Convert.ToString(reader["Mensaje"]);
                        ErrorNumero = Convert.ToInt32(reader["ErrorNumero"]);
                        ErrorDetalle = reader["ErrorDetalle"].ToString();

                        throw new AlertException(Mensaje);
                    }
                }

                return Exito;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        static async Task<DocumentoTipoEnt> ReadObtenerById(DbDataReader reader)
        {

            try
            {
                bool Exito = false;
                string Mensaje = "";
                int ErrorNumero = 0;
                string ErrorDetalle = "";
                DocumentoTipoEnt model = new DocumentoTipoEnt();

                while (await reader.ReadAsync())
                {
                    Exito = Convert.ToBoolean(reader["Exito"]);

                    if (!Exito)
                    {
                        Mensaje = Convert.ToString(reader["Mensaje"]);
                        ErrorNumero = Convert.ToInt32(reader["ErrorNumero"]);
                        ErrorDetalle = reader["ErrorDetalle"].ToString();

                        throw new AlertException(Mensaje);
                    }

                    model.Id = Convert.ToInt32(reader["Id"]);
                    model.Nombre = Convert.ToString(reader["Nombre"]);
                    model.Titulo = Convert.ToString(reader["Titulo"]);
                    model.IdServicio = DBNull.Value == reader["IdServicio"] ? (int?)null : Convert.ToInt32(reader["IdServicio"]) ;

                    model.BlPromocion = Convert.ToBoolean(reader["BlPromocion"]);
                    model.BlZona = Convert.ToBoolean(reader["BlZona"]);
                    model.BlPatologia = Convert.ToBoolean(reader["BlPatologia"]);
                    model.BlApoderado = Convert.ToBoolean(reader["BlApoderado"]);
                    model.BlMantenimiento = Convert.ToBoolean(reader["BlMantenimiento"]);
                    model.BlRetroceso = Convert.ToBoolean(reader["BlRetroceso"]);
                }

                return model;
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

        static async Task<List<DocumentoTipoEnt>> ReadListarByServicio(DbDataReader reader)
        {
            try
            {
                List<DocumentoTipoEnt> collection = new List<DocumentoTipoEnt>();
                while (await reader.ReadAsync())
                {
                    DocumentoTipoEnt obj = new DocumentoTipoEnt
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Nombre = Convert.ToString(reader["Nombre"]),
                        Titulo = Convert.ToString(reader["Titulo"]),
                        IdServicio = Convert.ToInt32(reader["IdServicio"]),
                        Version = reader["Version"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["Version"]),

                        BlPromocion = Convert.ToBoolean(reader["BlPromocion"]),
                        BlZona = Convert.ToBoolean(reader["BlZona"]),
                        BlPatologia = Convert.ToBoolean(reader["BlPatologia"]),
                        BlApoderado = Convert.ToBoolean(reader["BlApoderado"]),
                        BlMantenimiento = Convert.ToBoolean(reader["BlMantenimiento"]),
                        BlRetroceso = Convert.ToBoolean(reader["BlRetroceso"])
                    };
                    collection.Add(obj);
                }



                return collection;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<GeneralResponse<bool>> UpdateAllDocumentStatus(DocumentStatusDTO[] docuemntIds)
        {
            try
            {
                foreach (var docuemnt in docuemntIds)
                {
                    await UpdateDocumentStatus(docuemnt.Id, docuemnt.Status);
                }

                // Si todo ha ido bien, retornamos un objeto con éxito
                return new GeneralResponse<bool> { Data = true, Message = "Documentos actualizados exitosamente", Status = 201 };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdateDocumentStatus(int documentId, int newStatus)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_UpdateDocumentStatus", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("IdDocument", documentId);
                cmd.Parameters.AddWithValue("NuevoEstado", newStatus);

                var reader = await cmd.ExecuteReaderAsync();
                //var output = await ReadItemsObtener(reader, numero);

                conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}