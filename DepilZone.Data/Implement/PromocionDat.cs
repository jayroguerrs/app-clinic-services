    using DepilZone.Data.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using DepilZone.Entidad.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text.Json;
using System.Threading.Tasks;

namespace DepilZone.Data.Implement
{
    public class PromocionDat: IPromocionDat
    {
        private readonly string _connectionString;
        public PromocionDat(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
        public async Task<IEnumerable<PromocionGrillaDTO>> Obtener(int activo)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Promocion_Obtener", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pActivo", activo);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadObtener(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<PromocionGrillaDTO>> ObtenerParaModulo(int activo)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Promocion_Obtener_Modulo", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pActivo", activo);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadObtenerParaModulo(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<PromocionGrillaDTO>> ObtenerParaModuloByServicio(int activo, int idServicio)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Promocion_Obtener_Modulo", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pActivo", activo);
                cmd.Parameters.AddWithValue("pIdServicio", idServicio);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadObtenerParaModuloByServicio(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<PromocionGrillaDTO>> ObtenerPorServicio(int activo, int idServicio)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Promocion_ObtenerPorServicio", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pActivo", activo);
                cmd.Parameters.AddWithValue("pIdServicio", idServicio);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadObtenerPorServicio(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<PromocionGrillaDTO>> ObtenerPorCategoria(int idCategoria, int activo)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Promocion_Obtener_Modulo", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdPromocionCategoria", idCategoria);
                cmd.Parameters.AddWithValue("pActivo", activo);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadObtenerParaModulo(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<PromocionDTO> ObtenerById(Int32 Id)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Promocion_ObtenerByIdPromocion", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("IdPromocion", Id);
                var reader = await cmd.ExecuteReaderAsync();
                PromocionDTO objModel = new PromocionDTO();
                while (await reader.ReadAsync())
                {
                    var obj = Mapear(reader);
                    objModel.IdPromocion = obj.IdPromocion;
                    objModel.Descripcion = obj.Descripcion;
                    objModel.RefPrecio = obj.RefPrecio;
                    objModel.Condicion = obj.Condicion;
                    objModel.FechaInicio = obj.FechaInicio;
                    objModel.FechaFin = obj.FechaFin;
                    objModel.Lu = obj.Lu;
                    objModel.Ma = obj.Ma;
                    objModel.Mi = obj.Mi;
                    objModel.Ju = obj.Ju;
                    objModel.Vi = obj.Vi;
                    objModel.Sa = obj.Sa;
                    objModel.Do = obj.Do;
                    objModel.ZonaUsar = obj.ZonaUsar;
                    objModel.IdPerfil = obj.IdPerfil;
                    objModel.Activo = obj.Activo;
                    objModel.IdServicio = obj.IdServicio;
                    objModel.Servicio = obj.Servicio;
                    objModel.ServicioColor = obj.ServicioColor;
                    objModel.Vigente = Convert.ToBoolean(obj.Vigente);
                }

                if (reader.NextResult())
                {
                    List<PromocionBloqueEnt> bloques = new List<PromocionBloqueEnt>();
                    while (await reader.ReadAsync())
                    {
                        PromocionBloqueEnt objPromocioBloque = MapearPromoBloque(reader);
                        bloques.Add(objPromocioBloque);
                    }
                    objModel.PromocionBloques = bloques;
                }

                conn.Close();

                return objModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<PromocionGrillaDTO>> ObtenerByLikeNombre(string Nombre)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Promocion_ObtenerByLikeNombre", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("Nombre", Nombre);
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


        public async Task<IEnumerable<PromocionVistaDetalleDTO>> ObtenerPromocionVistaDetalle(int idPromocion)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_PromocionVista_Obtener_Genero_Zona_Precio_Bloque", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdPromocion", idPromocion);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItemsDetalle(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<IEnumerable<PromocionVistaDatosPlantillaDTO>> ObtenerPromocionVistaPlantilla(int idPromocion)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_PromocionVista_Obtener_Plantillas", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdPromocion", idPromocion);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItemsPlantilla(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<PromocionVistaDatosCondicionadoDTO> ObtenerPromocionVistaCondicionado(int idPromocion)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_PromocionVista_ObtenerCondicionado", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdPromocion", idPromocion);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItemsCondicionado(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<Respuesta<PromocionEnt>> Insertar(PromocionEnt model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Promocion_Insertar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pDescripcion", model.Descripcion.ToUpper());
                cmd.Parameters.AddWithValue("pRefPrecio", (model.RefPrecio == 0) ? null : model.RefPrecio);
                cmd.Parameters.AddWithValue("pZonaUsar", model.ZonaUsar);
                cmd.Parameters.AddWithValue("pCondicion", model.Condicion);
                cmd.Parameters.AddWithValue("pFechaInicio", model.FechaInicio);
                cmd.Parameters.AddWithValue("pFechaFin", model.FechaFin);
                cmd.Parameters.AddWithValue("pLu", model.Lu);
                cmd.Parameters.AddWithValue("pMa", model.Ma);
                cmd.Parameters.AddWithValue("pMi", model.Mi);
                cmd.Parameters.AddWithValue("pJu", model.Ju);
                cmd.Parameters.AddWithValue("pVi", model.Vi);
                cmd.Parameters.AddWithValue("pSa", model.Sa);
                cmd.Parameters.AddWithValue("pDo", model.Do);
                cmd.Parameters.AddWithValue("pIdPerfil", (model.IdPerfil == 0) ? null : model.IdPerfil);
                cmd.Parameters.AddWithValue("pActivo", model.Activo);
                cmd.Parameters.AddWithValue("pUsuarioRegistra", model.UsuarioRegistra);
                cmd.Parameters.AddWithValue("pPromocionBloques", JsonSerializer.Serialize(model.PromocionBloques));
                cmd.Parameters.AddWithValue("pIdServicio", model.IdServicio);
                cmd.Parameters.AddWithValue("pVigente", model.Vigente);
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

        public async Task<Respuesta<PromocionEnt>> Modificar(PromocionEnt model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Promocion_Modificar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("IdPromocion", model.IdPromocion);
                cmd.Parameters.AddWithValue("pDescripcion", model.Descripcion);
                //cmd.Parameters.AddWithValue("pRefPrecio", (model.RefPrecio == 0) ? null : model.RefPrecio);
                //cmd.Parameters.AddWithValue("pZonaUsar", model.ZonaUsar);
                cmd.Parameters.AddWithValue("pCondicion", model.Condicion);
                cmd.Parameters.AddWithValue("pFechaInicio", model.FechaInicio);
                cmd.Parameters.AddWithValue("pFechaFin", model.FechaFin);
                cmd.Parameters.AddWithValue("pLu", model.Lu);
                cmd.Parameters.AddWithValue("pMa", model.Ma);
                cmd.Parameters.AddWithValue("pMi", model.Mi);
                cmd.Parameters.AddWithValue("pJu", model.Ju);
                cmd.Parameters.AddWithValue("pVi", model.Vi);
                cmd.Parameters.AddWithValue("pSa", model.Sa);
                cmd.Parameters.AddWithValue("pDo", model.Do);
                cmd.Parameters.AddWithValue("pIdPerfil", (model.IdPerfil == 0) ? null : model.IdPerfil);
                cmd.Parameters.AddWithValue("pActivo", model.Activo);
                cmd.Parameters.AddWithValue("pUsuarioEdita", model.UsuarioModifica);
                cmd.Parameters.AddWithValue("pIdPromocionCategoria", model.IdPromocionCategoria);
                //cmd.Parameters.AddWithValue("pPromocionBloques", JsonSerializer.Serialize(model.PromocionBloques));
                cmd.Parameters.AddWithValue("pIdServicio", model.IdServicio);
                cmd.Parameters.AddWithValue("pVigente", model.Vigente);
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


        public async Task<List<PromocionRanking>> ObtenerRanking(DateTime fechaInicio, DateTime fechaFin, int idSede, int idPromocion)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();

                using SqlCommand cmd = new SqlCommand("SP_Promocion_RankingAgendados", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pFechaInicio", fechaInicio);
                cmd.Parameters.AddWithValue("pFechaFin", fechaFin);
                cmd.Parameters.AddWithValue("pIdSede", idSede);
                cmd.Parameters.AddWithValue("pIdPromocion", idPromocion);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadObtenerRanking(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<PromocionRanking>> ObtenerRankingVenta(DateTime fechaInicio, DateTime fechaFin, int idSede, int idPromocion)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();

                using SqlCommand cmd = new SqlCommand("SP_Promocion_RankingVenta", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pFechaInicio", fechaInicio);
                cmd.Parameters.AddWithValue("pFechaFin", fechaFin);
                cmd.Parameters.AddWithValue("pIdSede", idSede);
                cmd.Parameters.AddWithValue("pIdPromocion", idPromocion);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadObtenerRanking(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<PromocionRanking>> ObtenerRankingAtendido(DateTime fechaInicio, DateTime fechaFin, int idSede, int idPromocion)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Promocion_RankingAtendido", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pFechaInicio", fechaInicio);
                cmd.Parameters.AddWithValue("pFechaFin", fechaFin);
                cmd.Parameters.AddWithValue("pIdSede", idSede);
                cmd.Parameters.AddWithValue("pIdPromocion", idPromocion);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadObtenerRanking(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public async Task<List<PromocionZonaRanking>> ObtenerTop10Zonas(DateTime fechaInicio, DateTime fechaFin, int idSede, int idTipoZona, int idPromocion)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Promocion_ListarTop10Zonas", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pFechaInicio", fechaInicio);
                cmd.Parameters.AddWithValue("pFechaFin", fechaFin);
                cmd.Parameters.AddWithValue("pIdSede", idSede);
                cmd.Parameters.AddWithValue("pIdTipo", idTipoZona);
                cmd.Parameters.AddWithValue("pIdPromocion", idPromocion);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadObtenerZonaRanking(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<PromocionZonaRanking>> ObtenerBottom10Zonas(DateTime fechaInicio, DateTime fechaFin, int idSede, int idTipoZona, int idPromocion)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Promocion_ListarBottom10Zonas", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pFechaInicio", fechaInicio);
                cmd.Parameters.AddWithValue("pFechaFin", fechaFin);
                cmd.Parameters.AddWithValue("pIdSede", idSede);
                cmd.Parameters.AddWithValue("pIdTipo", idTipoZona);
                cmd.Parameters.AddWithValue("pIdPromocion", idPromocion);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadObtenerZonaRanking(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<PromocionZonaRanking>> ObtenerZonasRanking(DateTime fechaInicio, DateTime fechaFin, int idSede, int idTipoZona, int idPromocion)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Promocion_ListarZonasRanking", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pFechaInicio", fechaInicio);
                cmd.Parameters.AddWithValue("pFechaFin", fechaFin);
                cmd.Parameters.AddWithValue("pIdSede", idSede);
                cmd.Parameters.AddWithValue("pIdTipo", idTipoZona);
                cmd.Parameters.AddWithValue("pIdPromocion", idPromocion);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadObtenerZonaRanking(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<bool> Clonar(int idPromocion, int idUsuario)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Promocion_Clonar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdPromocion", idPromocion);
                cmd.Parameters.AddWithValue("pIdUsuario", idUsuario);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadClonar(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        // READERS



        static async Task<List<PromocionRanking>> ReadObtenerRanking(DbDataReader reader)
        {
            try
            {
                List<PromocionRanking> collection = new List<PromocionRanking>();

                while (await reader.ReadAsync())
                {
                    var obj = new PromocionRanking();
                    //obj.IdPromocion = Convert.ToInt32(reader["IdPromocion"]);
                    obj.Promocion = reader["Promocion"].ToString();
                    obj.FechaCita = Convert.ToDateTime(reader["FechaCita"]);
                    //obj.NumZonas = Convert.ToInt32(reader["NumZonas"]);
                    obj.Total = Convert.ToDecimal(reader["Total"]);
                    obj.IdSede = Convert.ToInt32(reader["IdSede"]);
                    obj.Sede = reader["Sede"].ToString();
                    collection.Add( obj );
                }

                return collection;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static async Task<List<PromocionZonaRanking>> ReadObtenerZonaRanking(DbDataReader reader)
        {
            try
            {
                List<PromocionZonaRanking> collection = new List<PromocionZonaRanking>();

                while (await reader.ReadAsync())
                {
                    var obj = new PromocionZonaRanking();
                    obj.Total = Convert.ToDecimal(reader["Total"]);
                    obj.IdZona = Convert.ToInt32(reader["IdZona"]);
                    obj.Zona = reader["Zona"].ToString();
                    obj.Cantidad = Convert.ToInt32(reader["Cantidad"]);
                    collection.Add(obj);
                }

                return collection;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static async Task<Respuesta<PromocionEnt>> ReadItem(DbDataReader reader)
        {
            try
            {
                Respuesta<PromocionEnt> obj = new Respuesta<PromocionEnt>
                {
                    Response = new PromocionEnt()
                };
                while (await reader.ReadAsync())
                {
                    obj.Exito = Convert.ToBoolean(reader["Exito"]);
                    obj.Mensaje = Convert.ToString(reader["Mensaje"]);
                    obj.ErrorNumero = Convert.ToInt32(reader["ErrorNumero"]);
                    obj.ErrorDetalle = reader["ErrorDetalle"].ToString();
                    if (obj.Exito)
                    {
                        obj.Response = Mapear(reader);
                    }
                }


                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static async Task<IEnumerable<PromocionGrillaDTO>> ReadObtener(DbDataReader reader)
        {
            try
            {
                IList<PromocionGrillaDTO> lista = new List<PromocionGrillaDTO>();
                while (await reader.ReadAsync())
                {
                    PromocionGrillaDTO obj = new PromocionGrillaDTO
                    {
                        IdPromocion = Convert.ToInt32(reader["IdPromocion"]),
                        Descripcion = reader["Descripcion"].ToString(),
                        FechaInicio = Convert.ToDateTime(reader["FechaInicio"]).ToString("dd/MM/yyyy"),
                        FechaFin = Convert.ToDateTime(reader["FechaFin"]).ToString("dd/MM/yyyy"),
                        PerfilDes = reader["Acceso"].ToString(),
                        RefDescrip = reader["PromocionBase"].ToString(),
                        ZonaUsarDes = reader["ZonaUsarDesc"].ToString(),
                        Activo = Convert.ToInt32(reader["Activo"]),
                        UsuarioRegistra = reader["UsuarioRegistra"].ToString(),
                        FechaRegistra = Convert.ToDateTime(reader["FechaRegistra"]),
                        UsuarioModifica = (reader["UsuarioEdita"] as string) ?? null,
                        FechaModifica = (reader["FechaEdita"] as DateTime?) ?? null,
                        IdPromocionCategoria = (reader["IdPromocionCategoria"] as int?) ?? null,
                        PromocionCategoria = (reader["PromocionCategoria"] as string) ?? null,

                        IdServicio = DBNull.Value == reader["IdServicio"] ? (int?)null : Convert.ToInt32(reader["IdServicio"]),
                        Servicio = DBNull.Value == reader["Servicio"] ? null : Convert.ToString(reader["Servicio"]),
                        ServicioColor = DBNull.Value == reader["ServicioColor"] ? null : Convert.ToString(reader["ServicioColor"]),
                        Vigente = Convert.ToBoolean(reader["Vigente"]),
                        proStatus = Convert.ToInt32(reader["PRO_STATUS"])
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

        static async Task<IEnumerable<PromocionGrillaDTO>> ReadObtenerParaModulo(DbDataReader reader)
        {
            try
            {
                IList<PromocionGrillaDTO> lista = new List<PromocionGrillaDTO>();
                while (await reader.ReadAsync())
                {
                    PromocionGrillaDTO obj = new PromocionGrillaDTO
                    {
                        IdPromocion = Convert.ToInt32(reader["IdPromocion"]),
                        Descripcion = reader["Descripcion"].ToString(),
                        FechaInicio = Convert.ToDateTime(reader["FechaInicio"]).ToString("dd/MM/yyyy"),
                        FechaFin = Convert.ToDateTime(reader["FechaFin"]).ToString("dd/MM/yyyy"),
                        PerfilDes = reader["Acceso"].ToString(),
                        RefDescrip = reader["PromocionBase"].ToString(),
                        ZonaUsarDes = reader["ZonaUsarDesc"].ToString(),
                        Activo = Convert.ToInt32(reader["Activo"]),
                        UsuarioRegistra = reader["UsuarioRegistra"].ToString(),
                        FechaRegistra = Convert.ToDateTime(reader["FechaRegistra"]),
                        UsuarioModifica = (reader["UsuarioEdita"] as string) ?? null,
                        FechaModifica = (reader["FechaEdita"] as DateTime?) ?? null,
                        IdPromocionCategoria = (reader["IdPromocionCategoria"] as int?) ?? null,
                        PromocionCategoria = (reader["PromocionCategoria"] as string) ?? null,

                        IdServicio = DBNull.Value == reader["IdServicio"] ? (int?)null : Convert.ToInt32(reader["IdServicio"]),
                        Servicio = DBNull.Value == reader["Servicio"] ? null : Convert.ToString(reader["Servicio"]),
                        ServicioColor = DBNull.Value == reader["ServicioColor"] ? null : Convert.ToString(reader["ServicioColor"]),
                        Vigente = Convert.ToBoolean(reader["Vigente"]),
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

        static async Task<IEnumerable<PromocionGrillaDTO>> ReadObtenerParaModuloByServicio(DbDataReader reader)
        {
            try
            {
                IList<PromocionGrillaDTO> lista = new List<PromocionGrillaDTO>();
                while (await reader.ReadAsync())
                {
                    PromocionGrillaDTO obj = new PromocionGrillaDTO
                    {
                        IdPromocion = Convert.ToInt32(reader["IdPromocion"]),
                        Descripcion = reader["Descripcion"].ToString(),
                        FechaInicio = Convert.ToDateTime(reader["FechaInicio"]).ToString("dd/MM/yyyy"),
                        FechaFin = Convert.ToDateTime(reader["FechaFin"]).ToString("dd/MM/yyyy"),
                        PerfilDes = reader["Acceso"].ToString(),
                        RefDescrip = reader["PromocionBase"].ToString(),
                        ZonaUsarDes = reader["ZonaUsarDesc"].ToString(),
                        Activo = Convert.ToInt32(reader["Activo"]),
                        UsuarioRegistra = reader["UsuarioRegistra"].ToString(),
                        FechaRegistra = Convert.ToDateTime(reader["FechaRegistra"]),
                        UsuarioModifica = (reader["UsuarioEdita"] as string) ?? null,
                        FechaModifica = (reader["FechaEdita"] as DateTime?) ?? null,
                        IdPromocionCategoria = (reader["IdPromocionCategoria"] as int?) ?? null,
                        PromocionCategoria = (reader["PromocionCategoria"] as string) ?? null,

                        IdServicio = DBNull.Value == reader["IdServicio"] ? (int?)null : Convert.ToInt32(reader["IdServicio"]),
                        Servicio = DBNull.Value == reader["Servicio"] ? null : Convert.ToString(reader["Servicio"]),
                        ServicioColor = DBNull.Value == reader["ServicioColor"] ? null : Convert.ToString(reader["ServicioColor"]),
                        Vigente = Convert.ToBoolean(reader["Vigente"]),
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

        static async Task<IEnumerable<PromocionGrillaDTO>> ReadObtenerPorServicio(DbDataReader reader)
        {
            try
            {
                IList<PromocionGrillaDTO> lista = new List<PromocionGrillaDTO>();
                while (await reader.ReadAsync())
                {
                    PromocionGrillaDTO obj = new PromocionGrillaDTO
                    {
                        IdPromocion = Convert.ToInt32(reader["IdPromocion"]),
                        Descripcion = reader["Descripcion"].ToString(),
                        FechaInicio = Convert.ToDateTime(reader["FechaInicio"]).ToString("dd/MM/yyyy"),
                        FechaFin = Convert.ToDateTime(reader["FechaFin"]).ToString("dd/MM/yyyy"),
                        PerfilDes = reader["Acceso"].ToString(),
                        RefDescrip = reader["PromocionBase"].ToString(),
                        ZonaUsarDes = reader["ZonaUsarDesc"].ToString(),
                        Activo = Convert.ToInt32(reader["Activo"]),
                        UsuarioRegistra = reader["UsuarioRegistra"].ToString(),
                        FechaRegistra = Convert.ToDateTime(reader["FechaRegistra"]),
                        UsuarioModifica = (reader["UsuarioEdita"] as string) ?? null,
                        FechaModifica = (reader["FechaEdita"] as DateTime?) ?? null,
                        IdPromocionCategoria = (reader["IdPromocionCategoria"] as int?) ?? null,
                        PromocionCategoria = (reader["PromocionCategoria"] as string) ?? null,

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
        static async Task<IEnumerable<PromocionGrillaDTO>> ReadItems(DbDataReader reader)
        {
            try
            {
                IList<PromocionGrillaDTO> lista = new List<PromocionGrillaDTO>();
                while (await reader.ReadAsync())
                {
                    PromocionGrillaDTO obj = new PromocionGrillaDTO
                    {
                        IdPromocion = Convert.ToInt32(reader["IdPromocion"]),
                        Descripcion = reader["Descripcion"].ToString(),
                        FechaInicio = Convert.ToDateTime(reader["FechaInicio"]).ToString("dd/MM/yyyy"),
                        FechaFin = Convert.ToDateTime(reader["FechaFin"]).ToString("dd/MM/yyyy"),
                        PerfilDes = reader["Acceso"].ToString(),
                        RefDescrip = reader["PromocionBase"].ToString(),
                        ZonaUsarDes = reader["ZonaUsarDesc"].ToString(),
                        Activo = Convert.ToInt32(reader["Activo"]),
                        UsuarioRegistra = reader["UsuarioRegistra"].ToString(),
                        FechaRegistra = Convert.ToDateTime(reader["FechaRegistra"]),
                        UsuarioModifica = (reader["UsuarioEdita"] as string) ?? null,
                        FechaModifica = (reader["FechaEdita"] as DateTime?) ?? null,
                        IdPromocionCategoria = (reader["IdPromocionCategoria"] as int?) ?? null,
                        PromocionCategoria = (reader["PromocionCategoria"] as string) ?? null,
                        IdServicio = DBNull.Value == reader["IdServicio"] ? (int?)null : Convert.ToInt32(reader["IdServicio"]),
                        Servicio = DBNull.Value == reader["Servicio"] ? null : Convert.ToString(reader["Servicio"]),
                        ServicioColor = DBNull.Value == reader["ServicioColor"] ? null : Convert.ToString(reader["ServicioColor"]),

                        Vigente = Convert.ToBoolean(reader["Vigente"]),

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

        static async Task<IEnumerable<PromocionVistaDetalleDTO>> ReadItemsDetalle(DbDataReader reader)
        {
            try
            {
                IList<PromocionVistaDetalleDTO> lista = new List<PromocionVistaDetalleDTO>();

                while (await reader.ReadAsync())
                {
                    PromocionVistaDetalleDTO obj = new PromocionVistaDetalleDTO
                    {
                        ZonaCorporal = reader["ZonaCorporal"].ToString(),
                        PrecioBase = Convert.ToDecimal(reader["PrecioBase"].ToString()),
                        IdGenero = Convert.ToInt32(reader["IdGenero"].ToString()),
                        IdZona = Convert.ToInt32(reader["IdZona"].ToString()),
                        IdPromocionZona = Convert.ToInt32(reader["IdPromocionZona"].ToString()),
                    };

                    obj.PrecioBloques = new List<ColumnaPrecioBloque>();
                    for (int i = 5; i < reader.FieldCount; i++)
                    {
                        ColumnaPrecioBloque col = new ColumnaPrecioBloque()
                        {
                            ColumnaBloque = reader.GetName(i),
                            PrecioBloque = Convert.ToDecimal(reader[i].ToString())
                        };
                        obj.PrecioBloques.Add(col);
                    }

                    lista.Add(obj);
                }


                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        static async Task<IEnumerable<PromocionVistaDatosPlantillaDTO>> ReadItemsPlantilla(DbDataReader reader)
        {
            try
            {
                IList<PromocionVistaDatosPlantillaDTO> lista = new List<PromocionVistaDatosPlantillaDTO>();

                while (await reader.ReadAsync())
                {
                    PromocionVistaDatosPlantillaDTO obj = new PromocionVistaDatosPlantillaDTO
                    {
                        IdPromocionZona = Convert.ToInt32(reader["IdPromocionZona"].ToString()),
                        IdPromocionPrecio = Convert.ToInt32(reader["IdPromocionPrecio"].ToString()),
                        IdPromocionBloque = Convert.ToInt32(reader["IdPromocionBloque"].ToString()),
                        Precio = Convert.ToDecimal(reader["Precio"].ToString()),
                        Plantilla = reader["Plantilla"].ToString(),
                        DescripcionBloque = reader["DescripcionBloque"].ToString()
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
        static async Task<PromocionVistaDatosCondicionadoDTO> ReadItemsCondicionado(DbDataReader reader)
        {
            try
            {
                PromocionVistaDatosCondicionadoDTO obj = new PromocionVistaDatosCondicionadoDTO();
                while (await reader.ReadAsync())
                {
                    obj.IdPromocion = Convert.ToInt32(reader["IdPromocion"].ToString());
                    obj.Condicion = reader["Condicion"].ToString();
                    obj.Periodo = reader["Periodo"].ToString();
                    obj.Dias = reader["Dias"].ToString();
                    //obj.Dias = obj.Dias.Substring(0, obj.Dias.Length - 1);
                    obj.Dias = obj.Dias[0..^1];
                }


                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static PromocionEnt Mapear(DbDataReader reader)
        {
            try
            {
                var obj = new PromocionEnt
                {
                    IdPromocion = Convert.ToInt32(reader["IdPromocion"]),
                    Descripcion = reader["Descripcion"].ToString(),
                    RefPrecio = (reader["RefPrecio"] as int?) ?? null,
                    Condicion = reader["Condicion"].ToString(),

                    FechaInicio = (reader["FechaInicio"] as DateTime?) ?? DateTime.MinValue,
                    FechaFin = (reader["FechaFin"] as DateTime?) ?? DateTime.MinValue,
                    Lu = Convert.ToBoolean(reader["Lu"]),
                    Ma = Convert.ToBoolean(reader["Ma"]),
                    Mi = Convert.ToBoolean(reader["Mi"]),
                    Ju = Convert.ToBoolean(reader["Ju"]),
                    Vi = Convert.ToBoolean(reader["Vi"]),
                    Sa = Convert.ToBoolean(reader["Sa"]),
                    Do = Convert.ToBoolean(reader["Do"]),
                    ZonaUsar = Convert.ToInt32(reader["ZonaUsar"]),
                    IdPerfil = (reader["IdPerfil"] as int?) ?? null,
                    Activo = Convert.ToInt32(reader["Activo"]),
                    IdServicio = DBNull.Value == reader["IdServicio"] ? (int?)null : Convert.ToInt32(reader["IdServicio"]),
                    Servicio = DBNull.Value == reader["Servicio"] ? null : Convert.ToString(reader["Servicio"]),
                    ServicioColor = DBNull.Value == reader["ServicioColor"] ? null : Convert.ToString(reader["ServicioColor"])
                };

                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }   
        }


        static async Task<bool> ReadClonar(DbDataReader reader)
        {
            try
            {
                bool Exito = false;
                string MensajeError = "";
                string MensajeDetalle = "";
                while (await reader.ReadAsync())
                {
                    Exito = Convert.ToBoolean(reader["Exito"]);
                    if (!Exito)
                    {
                        MensajeError = Convert.ToString(reader["MensajeError"]);
                        MensajeDetalle = Convert.ToString(reader["MensajeDetalle"]);
                        throw new AlertException(MensajeError);
                    }
                }


                return Exito;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        static PromocionBloqueEnt MapearPromoBloque(DbDataReader reader)
        {
            try
            {
                var obj = new PromocionBloqueEnt
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    IdPromocion = Convert.ToInt32(reader["IdPromocion"]),
                    RangoIni = Convert.ToInt32(reader["RangoIni"].ToString()),
                    RangoFin = Convert.ToInt32(reader["RangoFin"].ToString()),
                    DescuentoPorcentaje = Convert.ToDecimal(reader["DescuentoPorcentaje"]),
                    DescuentoFijo = Convert.ToDecimal(reader["DescuentoFijo"]),
                    AumentFijo = Convert.ToDecimal(reader["AumentFijo"]),
                    UsuarioRegistra = reader["UsuarioRegistra"].ToString()
                };


                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<GeneralResponse<bool>> UpdateAllPromotionStatus(PromocionStatusDTO[] promotionIds)
        {
            try
            {
                foreach (var promotion in promotionIds)
                {
                    await UpdatePromotionStatus(promotion.Id, promotion.Status);
                }

                // Si todo ha ido bien, retornamos un objeto con éxito
                return new GeneralResponse<bool> { Data = true, Message = "Promociones actualizadas exitosamente", Status = 201 };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdatePromotionStatus(int promotionId, int newStatus)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_UpdatePromotionStatus", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("IdPromocion", promotionId);
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
