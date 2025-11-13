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
    public class ZonaCorporalDat : IZonaCorporalDat
    {
        private readonly string _connectionString;
        public ZonaCorporalDat(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
        public async Task<IEnumerable<ZonaCorporalGridDTO>> Obtener()
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Zona_Obtener", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItems(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<IEnumerable<ZonaCorporalGridDTO>> ObtenerListado()
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Zona_ObtenerListado", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItemsWithSubZones(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<IEnumerable<ZonaServicio>> ObtenerListadoZonaCorporalServicio()
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_ZonaServicio_ObtenerListado", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItemsWithZonaServicio(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<ZonaCorporalGridDTO>> ObtenerListadoByServicio(int idServicio)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Zona_ObtenerByServicio", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdServicio", idServicio);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadObtenerListadoByServicio(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<IEnumerable<ZonaCorporalGridDTO>> ObtenerByNombre(string descripcion)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Zona_ObtenerByLikeNombre", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("Nombre", descripcion);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItems(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<ZonaCorporalEnt> ObtenerById(int Id)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Zona_ObtenerById", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("Id", Id);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await Read(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<IEnumerable<ZonaCorporalDTO>> ObtenerByGenero(int Id)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Zona_ObtenerByGenero", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("Id", Id);
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

        public async Task<IEnumerable<ZonaCorporalDTO>> ObtenerByGeneroByServicio(int idGenero, int idServicio)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Zona_ObtenerByGeneroByServicio", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("IdGenero", idGenero);
                cmd.Parameters.AddWithValue("IdServicio", idServicio);
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
        public async Task<IEnumerable<ZonaCorporalDTO>> ObtenerByGeneroByPromocion(int Id, int IdPromocion)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Zona_ObtenerByGeneroByPromocion", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("Id", Id);
                cmd.Parameters.AddWithValue("IdPromocion", IdPromocion);
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


        public async Task<IEnumerable<ZonaCorporalDTO>> ObtenerByGeneroByPromocionByServicio(int Id, int IdPromocion, int idServicio)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Zona_ObtenerByGeneroByPromocionByServicio", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("Id", Id);
                cmd.Parameters.AddWithValue("IdPromocion", IdPromocion);
                cmd.Parameters.AddWithValue("IdServicio", idServicio);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadObtenerByGeneroByPromocionByServicio(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<ZonaCorporalDTO>> ObtenerZonasParaSubZonaByGenero(int IdZona)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Zona_ObtenerZonasParaSubZonaByGenero", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("IdZona", IdZona);
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

        public async Task<IEnumerable<ZonaCitaEnt>> ObtenerZonaByCita(int idcita)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Zona_Obtener_IdCita", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("idcita", idcita);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadZonaCitaList(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<IEnumerable<ZonaPromocionEnt>> ObtenerZonas_PromocionByIdZona(int Id)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Zona_Promocion_Obtener", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("Id", Id);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadPromocion(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<IEnumerable<ZonaPromocionEnt>> Obtener_PromocionesPorZonasCorporales(string idsZonas)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Zona_Promociones_ObtenerPorZonasCorporales", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("IdsZonasCorporales", idsZonas);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadPromocion(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Respuesta<ZonaCorporalDTO>> Insertar(ZonaCorporalDTO model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Zona_Insertar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("Descripcion", model.Descripcion);
                cmd.Parameters.AddWithValue("DescripcionLarga", model.DescripcionLarga);
                cmd.Parameters.AddWithValue("Duracion", model.Duracion);
                cmd.Parameters.AddWithValue("IdGenero", model.IdGenero);
                cmd.Parameters.AddWithValue("IdEstado", model.IdEstado);
                cmd.Parameters.AddWithValue("IdTipo", model.IdTipo);
                cmd.Parameters.AddWithValue("PrecioBase", model.PrecioBase);
                cmd.Parameters.AddWithValue("PrecioDescuento", model.PrecioDescuento);
                cmd.Parameters.AddWithValue("UsuarioRegistra", model.UsuarioRegistra);
                cmd.Parameters.AddWithValue("UrlWeb", model.UrlWeb);
                cmd.Parameters.AddWithValue("Imagen", model.Imagen);
                cmd.Parameters.AddWithValue("ZonasRel", model.ZonasRel);
                cmd.Parameters.AddWithValue("pIdServicio", model.IdServicio);
                cmd.Parameters.AddWithValue("pIdUnidadMedida", model.IdUnidadMedida);
                var reader = await cmd.ExecuteReaderAsync();
                Respuesta<ZonaCorporalDTO> obj = new Respuesta<ZonaCorporalDTO>
                {
                    Response = new ZonaCorporalDTO()
                };
                while (await reader.ReadAsync())
                {
                    obj.Exito = Convert.ToBoolean(reader["Exito"]);
                    obj.Mensaje = Convert.ToString(reader["Mensaje"]);
                    obj.ErrorNumero = Convert.ToInt32(reader["ErrorNumero"]);
                    obj.ErrorDetalle = reader["ErrorDetalle"].ToString();
                    if (obj.Exito)
                    {
                        obj.Response.Id = Convert.ToInt32(reader["Id"]);
                        obj.Response.Descripcion = Convert.ToString(reader["Descripcion"]);
                        obj.Response.DescripcionLarga = Convert.ToString(reader["DescripcionLarga"]);
                        obj.Response.Duracion = Convert.ToInt32(reader["Duracion"]);
                        obj.Response.IdGenero = Convert.ToInt32(reader["IdGenero"]);
                        obj.Response.IdEstado = Convert.ToInt32(reader["IdEstado"]);
                        obj.Response.IdTipo = Convert.ToInt32(reader["IdTipo"]);
                        obj.Response.PrecioBase = Convert.ToDecimal(reader["PrecioBase"]);
                        obj.Response.PrecioDescuento = Convert.ToDecimal(reader["PrecioDescuento"]);
                    }
                }


                conn.Close();

                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Respuesta<ZonaCorporalDTO>> Modificar(ZonaCorporalDTO model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Zona_Modificar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("IdZona", model.Id);
                cmd.Parameters.AddWithValue("Descripcion", model.Descripcion);
                cmd.Parameters.AddWithValue("DescripcionLarga", model.DescripcionLarga);
                cmd.Parameters.AddWithValue("Duracion", model.Duracion);
                cmd.Parameters.AddWithValue("IdGenero", model.IdGenero);
                cmd.Parameters.AddWithValue("IdEstado", model.IdEstado);
                cmd.Parameters.AddWithValue("IdTipo", model.IdTipo);
                cmd.Parameters.AddWithValue("PrecioBase", model.PrecioBase);
                cmd.Parameters.AddWithValue("PrecioDescuento", model.PrecioDescuento);
                cmd.Parameters.AddWithValue("UsuarioEdita", model.UsuarioEdita);
                cmd.Parameters.AddWithValue("UrlWeb", model.UrlWeb);
                cmd.Parameters.AddWithValue("Imagen", model.Imagen);
                cmd.Parameters.AddWithValue("ZonasRel", model.ZonasRel);
                cmd.Parameters.AddWithValue("pIdServicio", model.IdServicio);
                cmd.Parameters.AddWithValue("pIdUnidadMedida", model.IdUnidadMedida);
                var reader = await cmd.ExecuteReaderAsync();
                Respuesta<ZonaCorporalDTO> obj = new Respuesta<ZonaCorporalDTO>
                {
                    Response = new ZonaCorporalDTO()
                };
                while (await reader.ReadAsync())
                {
                    obj.Exito = Convert.ToBoolean(reader["Exito"]);
                    obj.Mensaje = Convert.ToString(reader["Mensaje"]);
                    obj.ErrorNumero = Convert.ToInt32(reader["ErrorNumero"]);
                    obj.ErrorDetalle = reader["ErrorDetalle"].ToString();
                    if (obj.Exito) 
                    {
                        obj.Response.Id = Convert.ToInt32(reader["Id"]);
                        obj.Response.Descripcion = Convert.ToString(reader["Descripcion"]);
                        obj.Response.DescripcionLarga = Convert.ToString(reader["DescripcionLarga"]);
                        obj.Response.Duracion = Convert.ToInt32(reader["Duracion"]);
                        obj.Response.IdGenero = Convert.ToInt32(reader["IdGenero"]);
                        obj.Response.IdTipo = Convert.ToInt32(reader["IdTipo"]);
                        obj.Response.IdEstado = Convert.ToInt32(reader["IdEstado"]);
                        obj.Response.PrecioBase = Convert.ToDecimal(reader["PrecioBase"]);
                    }
                }


                conn.Close();

                return obj;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Respuesta<ZonaCorporalDTO>> AsignarSubZonas(int id, int[] idZonas)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Zona_AsignarSubZonas", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pId", id);
                cmd.Parameters.AddWithValue("pZonas", JsonSerializer.Serialize(idZonas));
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadAsignarSubZonas(reader);

                conn.Close();
            
                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<ZonaCorporalDTO>> ObtenerSubZonasById(int id)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Zona_ListarSubZonasById", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pId", id);
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


        public async Task<List<ZonaCantidad>> ObtenerCantidad(DateTime fechaInicio, DateTime fechaFin, int idSede, int idGenero, int numeroSesion, int idTipo)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Zona_ListarCantidadAtendidas", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pFechaInicio", fechaInicio);
                cmd.Parameters.AddWithValue("pFechaFin", fechaFin);
                cmd.Parameters.AddWithValue("pIdSede", idSede);
                cmd.Parameters.AddWithValue("pIdGenero", idGenero);
                cmd.Parameters.AddWithValue("pIdTipo", idTipo);
                cmd.Parameters.AddWithValue("pNumeroSesion", numeroSesion);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadListCantidadAtendidas(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<List<ZonaCantidad>> ObtenerTop10Cantidad(DateTime fechaInicio, DateTime fechaFin, int idSede, int idGenero,  int numeroSesion, int idTipo)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Zona_ListarTop10Atendidas", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pFechaInicio", fechaInicio);
                cmd.Parameters.AddWithValue("pFechaFin", fechaFin);
                cmd.Parameters.AddWithValue("pIdSede", idSede);
                cmd.Parameters.AddWithValue("pIdGenero", idGenero);
                cmd.Parameters.AddWithValue("pIdTipo", idTipo);
                cmd.Parameters.AddWithValue("pNumeroSesion", numeroSesion);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadListTop10Atendidas(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        // Readers


        static async Task<ZonaCorporalEnt> Read(DbDataReader reader)
        {
            try
            {
                ZonaCorporalEnt obj = new ZonaCorporalEnt();
                while (await reader.ReadAsync())
                {
                    obj.Id = Convert.ToInt32(reader["Id"]);
                    obj.Descripcion = Convert.ToString(reader["Descripcion"]);
                    obj.DescripcionLarga = Convert.ToString(reader["DescripcionLarga"]);
                    obj.Duracion = Convert.ToInt32(reader["Duracion"]);
                    obj.IdEstado = Convert.ToInt32(reader["IdEstado"]);
                    obj.IdTipo = Convert.ToInt32(reader["IdTipo"]);
                    obj.PrecioBase = Convert.ToDecimal(reader["PrecioBase"]);
                    obj.PrecioDescuento = Convert.ToDecimal(reader["PrecioDescuento"]);
                    obj.IdGenero = reader["IdGenero"].ToString();
                    obj.UrlWeb = DBNull.Value == reader["UrlWeb"] ? null : reader["UrlWeb"].ToString();
                    obj.Imagen = DBNull.Value == reader["Imagen"] ? null : reader["Imagen"].ToString();
                    obj.ZonasRel = DBNull.Value == reader["ZonasRel"] ? null : reader["ZonasRel"].ToString();
                    obj.IdServicio = DBNull.Value == reader["IdServicio"] ? (int?)null : Convert.ToInt32(reader["IdServicio"]);
                    obj.Servicio = DBNull.Value == reader["Servicio"] ? null : Convert.ToString(reader["Servicio"]);
                    obj.IdUnidadMedida = DBNull.Value == reader["IdUnidadMedida"] ? (int?)null : Convert.ToInt32(reader["IdUnidadMedida"]);
                    obj.UnidadMedida = DBNull.Value == reader["UnidadMedida"] ? null : Convert.ToString(reader["UnidadMedida"]);
                }

                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        static async Task<IEnumerable<ZonaCorporalDTO>> ReadList(DbDataReader reader)
        {
            try
            {
                IList<ZonaCorporalDTO> lista = new List<ZonaCorporalDTO>();
                while (await reader.ReadAsync())
                {
                    ZonaCorporalDTO obj = new ZonaCorporalDTO
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Descripcion = Convert.ToString(reader["Descripcion"]),
                        Duracion = Convert.ToInt32(reader["Duracion"]),
                        Igv = Convert.ToDecimal(reader["Igv"]),
                        IdGenero = Convert.ToInt32(reader["IdGenero"]),
                        Genero = reader["Genero"].ToString()
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

        static async Task<IEnumerable<ZonaCorporalDTO>> ReadObtenerByGeneroByPromocionByServicio(DbDataReader reader)
        {
            try
            {
                IList<ZonaCorporalDTO> lista = new List<ZonaCorporalDTO>();
                while (await reader.ReadAsync())
                {
                    ZonaCorporalDTO obj = new ZonaCorporalDTO
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Descripcion = Convert.ToString(reader["Descripcion"]),
                        Duracion = Convert.ToInt32(reader["Duracion"]),
                        Igv = Convert.ToDecimal(reader["Igv"]),
                        IdGenero = Convert.ToInt32(reader["IdGenero"]),
                        Genero = reader["Genero"].ToString()
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

        static async Task<IEnumerable<ZonaCitaEnt>> ReadZonaCitaList(DbDataReader reader)
        {
            try
            {
                IList<ZonaCitaEnt> lista = new List<ZonaCitaEnt>();
                while (await reader.ReadAsync())
                {
                    ZonaCitaEnt obj = new ZonaCitaEnt
                    {
                        Descripcion = Convert.ToString(reader["Descripcion"]),
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

        static async Task<IEnumerable<ZonaPromocionEnt>> ReadPromocion(DbDataReader reader)
        {
            try
            {
                IList<ZonaPromocionEnt> lista = new List<ZonaPromocionEnt>();
                while (await reader.ReadAsync())
                {
                    ZonaPromocionEnt obj = new ZonaPromocionEnt
                    {
                        IdPromocion = Convert.ToInt32(reader["Idpromocion"]),
                        Promocion = reader["Promocion"].ToString(),
                        IdZona = (reader["IdZona"] != DBNull.Value) ? Convert.ToInt32(reader["IdZona"]) : 0
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
        static async Task<IEnumerable<ZonaCorporalGridDTO>> ReadItems(DbDataReader reader)
        {
            try
            {
                IList<ZonaCorporalGridDTO> lista = new List<ZonaCorporalGridDTO>();
                while (await reader.ReadAsync())
                {
                    ZonaCorporalGridDTO obj = new ZonaCorporalGridDTO
                    {
                        Id = reader.GetFieldValue<int>(0),
                        Descripcion = reader["Descripcion"].ToString(),
                        DescripcionLarga = reader["DescripcionLarga"].ToString(),
                        Duracion = Convert.ToInt32(reader["Duracion"]),
                        IdEstado = Convert.ToInt32(reader["IdEstado"]),
                        IdUnidadMedida = DBNull.Value == reader["IdUnidadMedida"] ? (int?)null : Convert.ToInt32(reader["IdUnidadMedida"]),
                        UnidadMedida = DBNull.Value == reader["UnidadMedida"] ? null : Convert.ToString(reader["UnidadMedida"]),
                        Genero = reader["Genero"].ToString(),
                        Sesion = 1,
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


        static async Task<Respuesta<ZonaCorporalDTO>> ReadAsignarSubZonas(DbDataReader reader)
        {
            try
            {
                Respuesta<ZonaCorporalDTO> response = new Respuesta<ZonaCorporalDTO>
                {
                    Response = new ZonaCorporalDTO()
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
                        response.Response.Descripcion = Convert.ToString(reader["Descripcion"]);
                        response.Response.SubZonas = new List<SubZonaCorporalDTO>();
                    }
                }

                if (response.Exito)
                {

                    // Leer listado de zonas
                    List<ZonaCorporalDTO> zonas = new List<ZonaCorporalDTO>();
                    if (reader.NextResult())
                    {
                        while (await reader.ReadAsync())
                        {
                            ZonaCorporalDTO zona = new ZonaCorporalDTO()
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Descripcion = reader["Descripcion"].ToString()
                            };
                            zonas.Add(zona);
                        }
                    }

                    // Leer listado de relacion zona con subzona
                    if (reader.NextResult())
                    {
                        while (await reader.ReadAsync())
                        {
                            var IdZona = Convert.ToInt32(reader["IdZona"]);
                            var IdSubZona = Convert.ToInt32(reader["IdSubZona"]);


                            //Asociar documento con perfiles
                            // Buscar Perfil
                            var SubZona = zonas.Find(p => p.Id == IdSubZona);

                            if (SubZona != null)
                            {
                                // Insertar perfil en la lista
                                response.Response.SubZonas.Add(
                                    new SubZonaCorporalDTO()
                                    {
                                        Id = SubZona.Id,
                                        Descripcion = SubZona.Descripcion
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


        static async Task<IEnumerable<ZonaCorporalGridDTO>> ReadItemsWithSubZones(DbDataReader reader)
        {
            try
            {
                List<ZonaCorporalGridDTO> lista = new List<ZonaCorporalGridDTO>();
                while (await reader.ReadAsync())
                {
                    ZonaCorporalGridDTO obj = new ZonaCorporalGridDTO
                    {
                        Id = reader.GetFieldValue<int>(0),
                        Descripcion = reader["Descripcion"].ToString(),
                        DescripcionLarga = reader["DescripcionLarga"].ToString(),
                        Duracion = Convert.ToInt32(reader["Duracion"]),
                        IdEstado = Convert.ToInt32(reader["IdEstado"]),
                        UsuarioRegistro = Convert.ToString(reader["UsuarioRegistro"]),
                        FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"]),
                        PrecioBase = Convert.ToDecimal(reader["PrecioBase"]),
                        PrecioDescuento = Convert.ToDecimal(reader["PrecioDescuento"]),
                        IdTipo = Convert.ToInt32(reader["IdTipo"]),
                        UrlWeb = DBNull.Value == reader["UrlWeb"] ? null : reader["UrlWeb"].ToString(),
                        Imagen = DBNull.Value == reader["Imagen"] ? null : reader["Imagen"].ToString(),
                        ZonasRel = DBNull.Value == reader["ZonasRel"] ? null : reader["ZonasRel"].ToString(),
                        Genero = reader["Genero"].ToString(),
                        Sesion = 1,
                        SubZonas = new List<SubZonaCorporalDTO>(),
                        ZonasRelArray = new List<SubZonaCorporalDTO>(),
                        IdServicio = DBNull.Value == reader["IdServicio"] ? (int?)null : Convert.ToInt32(reader["IdServicio"]),
                        Servicio = DBNull.Value == reader["Servicio"] ? null : Convert.ToString(reader["Servicio"]),
                        ServicioColor = DBNull.Value == reader["ServicioColor"] ? null : Convert.ToString(reader["ServicioColor"]),
                        IdUnidadMedida = DBNull.Value == reader["IdUnidadMedida"] ? (int?)null : Convert.ToInt32(reader["IdUnidadMedida"]),
                        UnidadMedida = DBNull.Value == reader["UnidadMedida"] ? null : Convert.ToString(reader["UnidadMedida"])
                    };
                    lista.Add(obj);
                }

                List<SubZonaRelacionDTO> relacion = new List<SubZonaRelacionDTO>();
                // Leer listado de relacion zona con subzona
                if (reader.NextResult())
                {
                    while (await reader.ReadAsync())
                    {
                        var IdZona = Convert.ToInt32(reader["IdZona"]);
                        var IdSubZona = Convert.ToInt32(reader["IdSubZona"]);

                        SubZonaRelacionDTO obj = new SubZonaRelacionDTO
                        {
                            Id = Convert.ToInt32(reader["IdZona"]),
                            IdZona = Convert.ToInt32(reader["IdZona"]),
                            IdSubZona = Convert.ToInt32(reader["IdSubZona"])
                        };
                        relacion.Add(obj);
                    }
                }

                // Recorrer lista de zonas
                foreach (ZonaCorporalGridDTO zona in lista)
                {
                    // Verificar si tienen relacion
                    var hasRelation = relacion.FindAll(p => p.IdZona == zona.Id);
                    if (hasRelation.Count > 0)
                    {

                        // recorrer la relacion
                        foreach (SubZonaRelacionDTO rel in hasRelation)
                        {

                            var OZona = lista.Find(z => z.Id == rel.IdSubZona);
                            if (OZona != null)
                            {
                                SubZonaCorporalDTO subZona = new SubZonaCorporalDTO
                                {
                                    Id = OZona.Id,
                                    Descripcion = OZona.Descripcion
                                };
                                zona.SubZonas.Add(subZona);
                            }
                        }

                    }

                    // Agregar las zonas relacionadas
                    List<string> ids = zona.ZonasRel != null ? new List<string>(zona.ZonasRel.Split(',')) : new List<string>();
                    foreach (ZonaCorporalGridDTO zonaRel in lista)
                    {
                        if( ids.Exists( i => i.Equals(zonaRel.Id.ToString())) )
                        {
                            zona.ZonasRelArray.Add(new SubZonaCorporalDTO()
                            {
                                Id = zonaRel.Id,
                                Descripcion = zonaRel.Descripcion
                            });
                        }
                    }

                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        static async Task<IEnumerable<ZonaServicio>> ReadItemsWithZonaServicio(DbDataReader reader)
        {
            try
            {
                List<ZonaServicio> lista = new List<ZonaServicio>();
                while (await reader.ReadAsync())
                {
                    ZonaServicio obj = new ZonaServicio
                    {
                        IdServicio = Convert.ToInt32(reader["IdServicio"].ToString()),
                        Servicio = reader["Servicio"].ToString(),
                        IdZona = Convert.ToInt32(reader["IdZona"].ToString()),  
                        Zona = reader["Zona"].ToString(),
                        IdGenero = Convert.ToInt32(reader["IdGenero"].ToString()),
                        Genero = reader["Genero"].ToString()
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

        static async Task<List<ZonaCantidad>> ReadListCantidadAtendidas(DbDataReader reader)
        {
            try
            {
                List<ZonaCantidad> collection = new List<ZonaCantidad>();
                while (await reader.ReadAsync())
                {
                    var obj = new ZonaCantidad();
                    obj.Id = Convert.ToInt32(reader["Id"]);
                    obj.Zona = reader["Zona"].ToString();
                    obj.Genero = reader["Genero"].ToString();
                    obj.Cantidad = Convert.ToInt32( reader["Cantidad"] );
                    collection.Add(obj);
                }

                return collection;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        static async Task<List<ZonaCantidad>> ReadListTop10Atendidas(DbDataReader reader)
        {
            try
            {
                List<ZonaCantidad> collection = new List<ZonaCantidad>();
                while (await reader.ReadAsync())
                {
                    var obj = new ZonaCantidad();
                    obj.Id = Convert.ToInt32(reader["Id"]);
                    obj.Zona = reader["Zona"].ToString();
                    obj.Genero = reader["Genero"].ToString();
                    obj.Cantidad = Convert.ToInt32(reader["Cantidad"]);
                    obj.Total = Convert.ToDecimal(reader["Total"]);
                    collection.Add(obj);
                }

                return collection;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static async Task<List<ZonaCorporalGridDTO>> ReadObtenerListadoByServicio(DbDataReader reader)
        {
            try
            {
                List<ZonaCorporalGridDTO> lista = new List<ZonaCorporalGridDTO>();
                while (await reader.ReadAsync())
                {
                    ZonaCorporalGridDTO obj = new ZonaCorporalGridDTO
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Descripcion = Convert.ToString(reader["Descripcion"]),
                        DescripcionLarga = Convert.ToString(reader["DescripcionLarga"]),
                        Duracion = Convert.ToInt32(reader["Duracion"]),
                        IdEstado = Convert.ToInt32(reader["IdEstado"]),
                        Genero = Convert.ToString(reader["Genero"]),
                        Sesion = 1,
                        IdServicio = DBNull.Value == reader["IdServicio"] ? (int?)null : Convert.ToInt32(reader["IdServicio"]),
                        Servicio = DBNull.Value == reader["Servicio"] ? null : Convert.ToString(reader["Servicio"]),
                        ServicioColor = DBNull.Value == reader["ServicioColor"] ? null : Convert.ToString(reader["ServicioColor"])
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

    }
}
