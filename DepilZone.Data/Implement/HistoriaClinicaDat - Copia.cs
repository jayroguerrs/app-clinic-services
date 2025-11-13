using DepilZone.Data.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DepilZone.Data.Implement
{
    /*public class HistoriaClinicasDat : IHistoriaClinicaDat
    {
        
        public async Task<HistoriaClinicaDTO> GrabarHistoria(HistoriaClinicaDTO historia)
        {

            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();

                HistoriaClinicaDTO historiaClinicaDTO = new HistoriaClinicaDTO();
                historiaClinicaDTO.Id = historia.Id;

                // Insertar o editar historia clinica
                if (historiaClinicaDTO.Id > 0) {
                    using SqlCommand cmd = new SqlCommand("SP_HistoriaClinica_Modificar", conn)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    cmd.Parameters.AddWithValue("pId", historia.Id);
                    cmd.Parameters.AddWithValue("pUsuarioRegistro", historia.UsuarioRegistro);
                    cmd.Parameters.AddWithValue("pIdUsuarioModifico", historia.IdUsuarioRegistro);
                    var reader = await cmd.ExecuteReaderAsync();
                    historiaClinicaDTO = await ReadOnlyIdItem(reader);
                    historiaClinicaDTO.Zonas = new List<HistoriaClinicaZonaDTO>();
                    reader.Close();
                }
                else {
                    using SqlCommand cmd = new SqlCommand("SP_HistoriaClinica_Insertar", conn)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    cmd.Parameters.AddWithValue("pIdCita", historia.IdCita);
                    cmd.Parameters.AddWithValue("pUsuarioRegistro", historia.UsuarioRegistro);
                    cmd.Parameters.AddWithValue("pIdUsuarioRegistro", historia.IdUsuarioRegistro);
                    var reader = await cmd.ExecuteReaderAsync();
                    historiaClinicaDTO = await ReadOnlyIdItem(reader);
                    historiaClinicaDTO.Zonas = new List<HistoriaClinicaZonaDTO>();
                    reader.Close();
                }



                List<HistoriaClinicaZonaDTO> zonas = new List<HistoriaClinicaZonaDTO>();
                // Grabar detalle de la historia
                foreach (HistoriaClinicaZonaDTO historiaZona in historia.Zonas)
                {
                    
                    List<HistoriaClinicaDosisDTO> dosis = new List<HistoriaClinicaDosisDTO>();

                    // Insertar o editar historia clinica zona
                    if(historiaZona.HasEdit)
                    {
                        HistoriaClinicaZonaDTO historiaZonaReader;
                        if (historiaZona.Id > 0)
                        {
                            using SqlCommand cmd = new SqlCommand("SP_HistoriaClinicaZona_Modificar", conn)
                            {
                                CommandType = System.Data.CommandType.StoredProcedure
                            };
                            cmd.Parameters.AddWithValue("pId", historiaZona.Id);
                            cmd.Parameters.AddWithValue("pIdHistoriaClinica", historiaClinicaDTO.Id);
                            cmd.Parameters.AddWithValue("pIdCitaDetalle", historiaZona.IdCitaDetalle);
                            cmd.Parameters.AddWithValue("pSesion", historiaZona.Sesion);
                            cmd.Parameters.AddWithValue("pPrototipoPiel", historiaZona.PrototipoPiel);
                            cmd.Parameters.AddWithValue("pIdEquipoLaser", historiaZona.EquipoLaser.Id);
                            cmd.Parameters.AddWithValue("pEdema", historiaZona.Edema);
                            cmd.Parameters.AddWithValue("pEritema", historiaZona.Eritema);
                            cmd.Parameters.AddWithValue("pDolor", historiaZona.Dolor);
                            cmd.Parameters.AddWithValue("pAgujas", historiaZona.Agujas);
                            cmd.Parameters.AddWithValue("pQuemaduras", historiaZona.Quemaduras);
                            cmd.Parameters.AddWithValue("pComentario", historiaZona.Comentario);
                            cmd.Parameters.AddWithValue("pComentarioCliente", historiaZona.ComentarioCliente);
                            cmd.Parameters.AddWithValue("pComentarioSesion", historiaZona.ComentarioSesion);
                            cmd.Parameters.AddWithValue("pFoto1", historiaZona.Foto1);
                            cmd.Parameters.AddWithValue("pFoto2", historiaZona.Foto2);
                            cmd.Parameters.AddWithValue("pUsuarioRegistro", historia.UsuarioRegistro);
                            cmd.Parameters.AddWithValue("pIdEstado", historiaZona.IdEstado);
                            var reader = await cmd.ExecuteReaderAsync();
                            historiaZonaReader = await ReadOnlyHistoriaZonaIdItem(reader);

                            if (historia.Zonas.Count > 1)
                            {
                                reader.Close();
                            }
                        }
                        else
                        {
                            using SqlCommand cmd = new SqlCommand("SP_HistoriaClinicaZona_Insertar", conn)
                            {
                                CommandType = System.Data.CommandType.StoredProcedure
                            };
                            cmd.Parameters.AddWithValue("pIdHistoriaClinica", historiaClinicaDTO.Id);
                            cmd.Parameters.AddWithValue("pIdCitaDetalle", historiaZona.IdCitaDetalle);
                            cmd.Parameters.AddWithValue("pSesion", historiaZona.Sesion);
                            cmd.Parameters.AddWithValue("pPrototipoPiel", historiaZona.PrototipoPiel);
                            cmd.Parameters.AddWithValue("pIdEquipoLaser", historiaZona.EquipoLaser.Id);
                            cmd.Parameters.AddWithValue("pEdema", historiaZona.Edema);
                            cmd.Parameters.AddWithValue("pEritema", historiaZona.Eritema);
                            cmd.Parameters.AddWithValue("pDolor", historiaZona.Dolor);
                            cmd.Parameters.AddWithValue("pAgujas", historiaZona.Agujas);
                            cmd.Parameters.AddWithValue("pQuemaduras", historiaZona.Quemaduras);
                            cmd.Parameters.AddWithValue("pComentario", historiaZona.Comentario);
                            cmd.Parameters.AddWithValue("pComentarioCliente", historiaZona.ComentarioCliente);
                            cmd.Parameters.AddWithValue("pComentarioSesion", historiaZona.ComentarioSesion);
                            cmd.Parameters.AddWithValue("pFoto1", historiaZona.Foto1);
                            cmd.Parameters.AddWithValue("pFoto2", historiaZona.Foto2);
                            cmd.Parameters.AddWithValue("pUsuarioRegistro", historia.UsuarioRegistro);
                            var reader = await cmd.ExecuteReaderAsync();
                            historiaZonaReader = await ReadOnlyHistoriaZonaIdItem(reader);

                            if (historia.Zonas.Count > 1)
                            {
                                reader.Close();
                            }
                        }
                        // Insertar zonas y dosis
                        historiaZonaReader.Dosis = await InsertarDosis(historiaZonaReader.Id, historiaZona.Dosis);
                        historiaClinicaDTO.Zonas.Add(historiaZonaReader);
                    }

                }

                conn.Close();

                return historiaClinicaDTO;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public async Task<HistoriaClinicaDTO> ObtenerByCita(int idCita)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();

                using SqlCommand cmd = new SqlCommand("SP_HistoriaClinica_ObtenerByCita", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdCita", idCita);
                var reader = await cmd.ExecuteReaderAsync();

                var output = await ReadHistoriaClinica(reader);
                conn.Close();

                if(output != null)
                {
                    foreach (var historiaZona in output.Zonas)
                    {
                        // Agregar las dosis
                        List<HistoriaClinicaDosisDTO> dosis = await ObtenerDosisByHistoriaClinicaZona(historiaZona.Id);
                        historiaZona.Dosis = dosis;
                    }
                }

                

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<HistoriaClinicaDTO> ObtenerById(int idHistoria)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();

                using SqlCommand cmd = new SqlCommand("SP_HistoriaClinica_ObtenerById", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pId", idHistoria);
                var reader = await cmd.ExecuteReaderAsync();

                var output = await ReadHistoriaClinica(reader);
                conn.Close();

                if (output != null)
                {
                    foreach (var historiaZona in output.Zonas)
                    {
                        // Agregar las dosis
                        List<HistoriaClinicaDosisDTO> dosis = await ObtenerDosisByHistoriaClinicaZona(historiaZona.Id);
                        historiaZona.Dosis = dosis;
                    }
                }



                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<HistoriaClinicaDTO>> ObtenerListadoByIdCliente(int idCliente)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();

                using SqlCommand cmd = new SqlCommand("SP_HistoriaClinica_ObtenerByIdCliente", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdCliente", idCliente);
                var reader = await cmd.ExecuteReaderAsync();

                var output = await ReadCollectionHistoriaClinica(reader);
                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


       
        public async Task<List<HistoriaClinicaDosisDTO>> InsertarDosis(int idHistoriaClinicaZona, List<HistoriaClinicaDosisDTO> dosis)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();

                using SqlCommand cmd = new SqlCommand("SP_DosisSubZona_Insertar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdHistoriaClinicaZona", idHistoriaClinicaZona);
                cmd.Parameters.AddWithValue("pDosis", JsonSerializer.Serialize(dosis));
                var reader = await cmd.ExecuteReaderAsync();

                var output = await ReadCollectionDosisSubzona(reader);
                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<HistoriaClinicaDosisDTO>> ObtenerDosisByHistoriaClinicaZona(int idHistoriaClinicaZona)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();

                using SqlCommand cmd = new SqlCommand("SP_DosisSubZona_ObtenerByHistoriaZona", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdHistoriaClinicaZona", idHistoriaClinicaZona);
                var reader = await cmd.ExecuteReaderAsync();

                var output = await ReadCollectionDosisSubzona(reader);
                conn.Close();


                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    
        public async Task<FotoHistorialClinicoDTO> ObtenerFotosById(int idHistoriaClinica)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();

                using SqlCommand cmd = new SqlCommand("SP_HistoriaClinicaZona_ObtenerFotosById", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdHistoriaClinicaZona", idHistoriaClinica);
                var reader = await cmd.ExecuteReaderAsync();

                var output = await ReadFotoHistoriaCLinicaZona(reader);
                conn.Close();


                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



       

        static async Task<HistoriaClinicaDTO> ReadOnlyIdItem(SqlDataReader reader)
        {
            try
            {
                int Exito = 0;
                string Mensaje = "";
                HistoriaClinicaDTO obj = new HistoriaClinicaDTO();
                while (await reader.ReadAsync())
                {
                    obj.Id = Convert.ToInt32(reader["Id"].ToString());
                    Exito = Convert.ToInt32(reader["Exito"].ToString());
                    Mensaje = reader["Mensaje"].ToString();
                }

                if (Exito == 1)
                {
                    return obj;
                }
                else {
                    throw new Exception(Mensaje);
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static async Task<HistoriaClinicaZonaDTO> ReadOnlyHistoriaZonaIdItem(SqlDataReader reader)
        {
            try
            {
                int Exito = 0;
                string Mensaje = "";
                HistoriaClinicaZonaDTO obj = new HistoriaClinicaZonaDTO();
                while (await reader.ReadAsync())
                {
                    obj.Id = Convert.ToInt32(reader["Id"].ToString());
                    Exito = Convert.ToInt32(reader["Exito"].ToString());
                    Mensaje = reader["Mensaje"].ToString();
                }

                if (Exito == 1)
                {
                    return obj;
                }
                else
                {
                    throw new Exception(Mensaje);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        static async Task<FotoHistorialClinicoDTO> ReadFotoHistoriaCLinicaZona(SqlDataReader reader)
        {
            try
            {
                FotoHistorialClinicoDTO obj = new FotoHistorialClinicoDTO();
                while (await reader.ReadAsync())
                {
                    obj.Foto1 = reader["Foto1"] == DBNull.Value ? null : reader["Foto1"].ToString();
                    obj.Foto2 = reader["Foto2"] == DBNull.Value ? null : reader["Foto2"].ToString();
                }

                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        static async Task<HistoriaClinicaDTO> ReadHistoriaClinica(SqlDataReader reader)
        {
            try
            {
                HistoriaClinicaDTO obj = null;
                while (await reader.ReadAsync())
                {
                    obj = new HistoriaClinicaDTO();
                    obj.Id = Convert.ToInt32(reader["Id"].ToString());
                    obj.IdCita = Convert.ToInt32(reader["IdCita"].ToString());

                    obj.Zonas = new List<HistoriaClinicaZonaDTO>();

                    obj.FechaRegistro = reader["FechaRegistro"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["FechaRegistro"]);
                    obj.UsuarioRegistro = reader["UsuarioRegistro"] == DBNull.Value ? null : reader["UsuarioRegistro"].ToString();
                    obj.FechaModifico = reader["FechaModifico"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["FechaModifico"]);
                    obj.UsuarioModifico = reader["UsuarioModifico"] == DBNull.Value ? null : reader["UsuarioModifico"].ToString();

                    obj.IdEstado = Convert.ToInt32(reader["IdEstado"]);
                }

                if (reader.NextResult())
                {
                    while (await reader.ReadAsync())
                    {
                        HistoriaClinicaZonaDTO historiaZona = new HistoriaClinicaZonaDTO()
                        {
                            Id = Convert.ToInt32(reader["Id"].ToString()),
                            IdHistoriaClinica = Convert.ToInt32(reader["IdHistoriaClinica"].ToString()),
                            IdCitaDetalle = Convert.ToInt32(reader["IdCitaDetalle"].ToString()),
                            Sesion = Convert.ToInt32(reader["Sesion"].ToString()),
                            PrototipoPiel = Convert.ToInt32(reader["PrototipoPiel"].ToString()),
                            IdEquipoLaser = Convert.ToInt32(reader["IdEquipoLaser"].ToString()),
                            EquipoLaser = new HT_EquipoLaserDTO()
                            {
                                Id = Convert.ToInt32(reader["IdEquipoLaser"].ToString()),
                                Nombre = reader["NombreEquipoLaser"].ToString()
                            },
                            Edema = Convert.ToInt32(reader["Edema"].ToString()),
                            Eritema = Convert.ToInt32(reader["Eritema"].ToString()),
                            Dolor = Convert.ToInt32(reader["Dolor"].ToString()),
                            Agujas = Convert.ToInt32(reader["Agujas"].ToString()),
                            Quemaduras = Convert.ToInt32(reader["Quemaduras"].ToString()),
                            Comentario = reader["Comentario"] == DBNull.Value ? null : reader["Comentario"].ToString(),
                            ComentarioCliente = reader["ComentarioCliente"] == DBNull.Value ? null : reader["ComentarioCliente"].ToString(),
                            ComentarioSesion = reader["ComentarioSesion"] == DBNull.Value ? null : reader["ComentarioSesion"].ToString(),

                            FechaRegistro = reader["FechaRegistro"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["FechaRegistro"]),
                            UsuarioRegistro = reader["UsuarioRegistro"] == DBNull.Value ? null : reader["UsuarioRegistro"].ToString(),
                            FechaModifico = reader["FechaModifico"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["FechaModifico"]),
                            UsuarioModifico = reader["UsuarioModifico"] == DBNull.Value ? null : reader["UsuarioModifico"].ToString(),
                            IdEstado = Convert.ToInt32(reader["IdEstado"].ToString()),
                            Zona = reader["Zona"].ToString(),

                            HasEdit = Convert.ToBoolean(reader["HasEdit"])
                        };
                        obj.Zonas.Add(historiaZona);
                    }
                }

                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        static async Task<List<HistoriaClinicaDTO>> ReadCollectionHistoriaClinica(SqlDataReader reader)
        {
            try
            {
                List<HistoriaClinicaDTO> collection = new List<HistoriaClinicaDTO>();
                while (await reader.ReadAsync())
                {
                    HistoriaClinicaDTO historia = new HistoriaClinicaDTO()
                    {
                        Id = Convert.ToInt32(reader["Id"].ToString()),
                        IdCita = Convert.ToInt32(reader["IdCita"].ToString()),

                        Zonas = new List<HistoriaClinicaZonaDTO>(),

                        FechaRegistro = reader["FechaRegistro"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["FechaRegistro"]),
                        UsuarioRegistro = reader["UsuarioRegistro"] == DBNull.Value ? null : reader["UsuarioRegistro"].ToString(),
                        FechaModifico = reader["FechaModifico"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["FechaModifico"]),
                        UsuarioModifico = reader["UsuarioModifico"] == DBNull.Value ? null : reader["UsuarioModifico"].ToString(),

                        IdEstado = Convert.ToInt32(reader["IdEstado"])
                    };
                    collection.Add( historia );
                }

                return collection;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static async Task<List<HistoriaClinicaDosisDTO>> ReadCollectionDosisSubzona(SqlDataReader reader)
        {
            try
            {
                List<HistoriaClinicaDosisDTO> collection = new List<HistoriaClinicaDosisDTO>();
                while (await reader.ReadAsync())
                {
                    HistoriaClinicaDosisDTO obj = new HistoriaClinicaDosisDTO();
                    obj.Id = Convert.ToInt32(reader["Id"].ToString());
                    obj.IdHistoriaClinicaZona = Convert.ToInt32(reader["IdHistoriaClinicaZona"].ToString());
                    obj.IdZona = Convert.ToInt32(reader["IdZona"].ToString());
                    obj.Zona = reader["Zona"].ToString();
                    obj.ValorJulios = reader["ValorJulios"].ToString();
                    obj.ValorContinuo = reader["ValorContinuo"].ToString();
                    obj.ValorStackMovil = reader["ValorStackMovil"].ToString();
                    obj.ValorStackFijo = reader["ValorStackFijo"].ToString();

                    collection.Add(obj);
                }


                return collection;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }*/
}
