using DepilZone.Data.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using DepilZone.Entidad.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DepilZone.Data.Implement
{
    public class EvolucionTratamientoDat : IEvolucionTratamientoDat
    {
        private readonly string _connectionString;
        public EvolucionTratamientoDat(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
        public async Task<EvolucionTratamientoDTO> GrabarHistoria(EvolucionTratamientoDTO model)
        {

            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();

                EvolucionTratamientoDTO evolucionTratamientoDTO = new EvolucionTratamientoDTO();
                evolucionTratamientoDTO.Id = model.Id;

                // Insertar o editar model clinica
                if (evolucionTratamientoDTO.Id > 0) {
                    using SqlCommand cmd = new SqlCommand("SP_EvolucionTratamiento_Modificar", conn)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    cmd.Parameters.AddWithValue("pId", model.Id);
                    cmd.Parameters.AddWithValue("pIdUsuarioModifico", model.IdUsuarioModifico);
                    var reader = await cmd.ExecuteReaderAsync();

                    evolucionTratamientoDTO = await ReadOnlyIdItem(reader);
                    evolucionTratamientoDTO.Zonas = new List<EvolucionTratamientoZonaDTO>();
                    reader.Close();
                }
                else {
                    using SqlCommand cmd = new SqlCommand("SP_EvolucionTratamiento_Insertar", conn)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    cmd.Parameters.AddWithValue("pIdCita", model.IdCita);
                    cmd.Parameters.AddWithValue("pIdUsuarioRegistro", model.IdUsuarioRegistro);
                    cmd.Parameters.AddWithValue("pIdUsuarioAtendio", model.IdUsuarioAtendio);
                    var reader = await cmd.ExecuteReaderAsync();
                    evolucionTratamientoDTO = await ReadOnlyIdItem(reader);
                    evolucionTratamientoDTO.Zonas = new List<EvolucionTratamientoZonaDTO>();
                    reader.Close();
                }



                List<EvolucionTratamientoZonaDTO> zonas = new List<EvolucionTratamientoZonaDTO>();
                // Grabar detalle de la model
                foreach (EvolucionTratamientoZonaDTO modelZona in model.Zonas)
                {
                    
                    List<EvolucionTratamientoDosisDTO> dosis = new List<EvolucionTratamientoDosisDTO>();

                    // Insertar o editar model clinica zona
                    if(modelZona.HasEdit)
                    {
                        EvolucionTratamientoZonaDTO modelZonaReader = null;
                        // Verificar si es un registro nuevo o se modificara
                        if (modelZona.Id > 0)
                        {
                            if(modelZona.IdEstado == 2)
                            {
                                using SqlCommand cmd = new SqlCommand("SP_EvolucionTratamientoZona_Eliminar", conn)
                                {
                                    CommandType = System.Data.CommandType.StoredProcedure
                                };
                                cmd.Parameters.AddWithValue("pId", modelZona.Id);
                                cmd.Parameters.AddWithValue("pIdCita", model.IdCita);
                                cmd.Parameters.AddWithValue("pIdUsuarioRegistro", modelZona.IdUsuarioRegistro);
                                cmd.Parameters.AddWithValue("pZona", modelZona.Zona);
                                cmd.Parameters.AddWithValue("pSesion", modelZona.Sesion);
                                var reader = await cmd.ExecuteReaderAsync();
                                int Exito = 0;
                                string Mensaje = "";
                                string Detalle = "";
                                while (await reader.ReadAsync())
                                {
                                    Exito = Convert.ToInt32(reader["Exito"].ToString());
                                    Mensaje = reader["Mensaje"].ToString();
                                    Detalle = reader["ErrorDetalle"].ToString();
                                }

                                if(Exito == 0)
                                {
                                    throw new AlertException(Mensaje + Detalle);
                                }
                            }
                            else
                            {
                                using SqlCommand cmd = new SqlCommand("SP_EvolucionTratamientoZona_Modificar", conn)
                                {
                                    CommandType = System.Data.CommandType.StoredProcedure
                                };
                                cmd.Parameters.AddWithValue("pId", modelZona.Id);
                                cmd.Parameters.AddWithValue("pIdEvolucionTratamiento", evolucionTratamientoDTO.Id);
                                cmd.Parameters.AddWithValue("pIdCitaDetalle", modelZona.IdCitaDetalle);
                                cmd.Parameters.AddWithValue("pSesion", modelZona.Sesion);
                                cmd.Parameters.AddWithValue("pPrototipoPiel", modelZona.FototipoPiel);
                                cmd.Parameters.AddWithValue("pIdEquipoLaser", modelZona.EquipoLaser.Id);
                                cmd.Parameters.AddWithValue("pEdema", modelZona.Edema);
                                cmd.Parameters.AddWithValue("pEritema", modelZona.Eritema);
                                cmd.Parameters.AddWithValue("pDolor", modelZona.Dolor);
                                cmd.Parameters.AddWithValue("pAgujas", modelZona.Agujas);
                                cmd.Parameters.AddWithValue("pQuemaduras", modelZona.Quemaduras);
                                cmd.Parameters.AddWithValue("pComentario", modelZona.Comentario);
                                cmd.Parameters.AddWithValue("pComentarioCliente", modelZona.ComentarioCliente);
                                cmd.Parameters.AddWithValue("pComentarioSesion", modelZona.ComentarioSesion);
                                cmd.Parameters.AddWithValue("pFoto1", modelZona.Foto1);
                                cmd.Parameters.AddWithValue("pFoto2", modelZona.Foto2);
                                cmd.Parameters.AddWithValue("pIdUsuarioRegistro", modelZona.IdUsuarioRegistro);
                                cmd.Parameters.AddWithValue("pIdEstado", modelZona.IdEstado);
                                var reader = await cmd.ExecuteReaderAsync();
                                modelZonaReader = await ReadOnlyHistoriaZonaIdItem(reader);

                                if (model.Zonas.Count > 1)
                                {
                                    reader.Close();
                                }
                            }
                        }
                        else
                        {
                            using SqlCommand cmd = new SqlCommand("SP_EvolucionTratamientoZona_Insertar", conn)
                            {
                                CommandType = System.Data.CommandType.StoredProcedure
                            };
                            cmd.Parameters.AddWithValue("pIdEvolucionTratamiento", evolucionTratamientoDTO.Id);
                            cmd.Parameters.AddWithValue("pIdCitaDetalle", modelZona.IdCitaDetalle);
                            cmd.Parameters.AddWithValue("pSesion", modelZona.Sesion);
                            cmd.Parameters.AddWithValue("pPrototipoPiel", modelZona.FototipoPiel);
                            cmd.Parameters.AddWithValue("pIdEquipoLaser", modelZona.EquipoLaser.Id);
                            cmd.Parameters.AddWithValue("pEdema", modelZona.Edema);
                            cmd.Parameters.AddWithValue("pEritema", modelZona.Eritema);
                            cmd.Parameters.AddWithValue("pDolor", modelZona.Dolor);
                            cmd.Parameters.AddWithValue("pAgujas", modelZona.Agujas);
                            cmd.Parameters.AddWithValue("pQuemaduras", modelZona.Quemaduras);
                            cmd.Parameters.AddWithValue("pComentario", modelZona.Comentario);
                            cmd.Parameters.AddWithValue("pComentarioCliente", modelZona.ComentarioCliente);
                            cmd.Parameters.AddWithValue("pComentarioSesion", modelZona.ComentarioSesion);
                            cmd.Parameters.AddWithValue("pFoto1", modelZona.Foto1);
                            cmd.Parameters.AddWithValue("pFoto2", modelZona.Foto2);
                            cmd.Parameters.AddWithValue("pIdUsuarioRegistro", modelZona.IdUsuarioRegistro);
                            var reader = await cmd.ExecuteReaderAsync();
                            modelZonaReader = await ReadOnlyHistoriaZonaIdItem(reader);

                            if (model.Zonas.Count > 1)
                            {
                                reader.Close();
                            }
                        }

                        if( modelZonaReader != null)
                        {
                            // Insertar zonas y dosis
                            modelZonaReader.Dosis = await InsertarDosis(modelZonaReader.Id, modelZona.Dosis);
                            evolucionTratamientoDTO.Zonas.Add(modelZonaReader);
                        }
                       
                    }

                }

                conn.Close();

                return evolucionTratamientoDTO;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public async Task<EvolucionTratamientoDTO> ObtenerByCita(int idCita)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();

                using SqlCommand cmd = new SqlCommand("SP_EvolucionTratamiento_ObtenerByCita", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdCita", idCita);
                var reader = await cmd.ExecuteReaderAsync();

                var output = await ReadEvolucionTratamiento(reader);
                conn.Close();

                if(output != null)
                {
                    foreach (var modelZona in output.Zonas)
                    {
                        // Agregar las dosis
                        List<EvolucionTratamientoDosisDTO> dosis = await ObtenerDosisByEvolucionTratamientoZona(modelZona.Id);
                        modelZona.Dosis = dosis;
                    }
                }

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<EvolucionTratamientoDTO> ObtenerById(int idHistoria)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();

                using SqlCommand cmd = new SqlCommand("SP_EvolucionTratamiento_ObtenerById", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pId", idHistoria);
                var reader = await cmd.ExecuteReaderAsync();

                var output = await ReadEvolucionTratamiento(reader);
                conn.Close();

                if (output != null)
                {
                    foreach (var modelZona in output.Zonas)
                    {
                        // Agregar las dosis
                        List<EvolucionTratamientoDosisDTO> dosis = await ObtenerDosisByEvolucionTratamientoZona(modelZona.Id);
                        modelZona.Dosis = dosis;
                    }
                }



                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<EvolucionTratamientoDTO>> ObtenerListadoByIdCliente(int idCliente)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();

                using SqlCommand cmd = new SqlCommand("SP_EvolucionTratamiento_ObtenerByIdCliente", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdCliente", idCliente);
                var reader = await cmd.ExecuteReaderAsync();

                var output = await ReadCollectionEvolucionTratamiento(reader);
                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /** Dosis Sub Zona **/
        public async Task<List<EvolucionTratamientoDosisDTO>> InsertarDosis(int idEvolucionTratamientoZona, List<EvolucionTratamientoDosisDTO> dosis)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();

                using SqlCommand cmd = new SqlCommand("SP_EvolucionTratamientoDosis_Insertar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdEvolucionTratamientoZona", idEvolucionTratamientoZona);
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

        public async Task<List<EvolucionTratamientoDosisDTO>> ObtenerDosisByEvolucionTratamientoZona(int idEvolucionTratamientoZona)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();

                using SqlCommand cmd = new SqlCommand("SP_EvolucionTratamientoDosis_ObtenerByEvolucionTratamientoZona", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdEvolucionTratamientoZona", idEvolucionTratamientoZona);
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

        /** Zona **/
        public async Task<ET_ZonaFotosDTO> ObtenerFotosById(int idEvolucionTratamiento)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();

                using SqlCommand cmd = new SqlCommand("SP_EvolucionTratamientoZona_ObtenerFotosById", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdEvolucionTratamientoZona", idEvolucionTratamiento);
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



        // READERS

        static async Task<EvolucionTratamientoDTO> ReadOnlyIdItem(SqlDataReader reader)
        {
            try
            {
                int Exito = 0;
                string Mensaje = "";
                EvolucionTratamientoDTO obj = new EvolucionTratamientoDTO();
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

        static async Task<EvolucionTratamientoZonaDTO> ReadOnlyHistoriaZonaIdItem(SqlDataReader reader)
        {
            try
            {
                int Exito = 0;
                string Mensaje = "";
                string ErrorDetalle = "";
                EvolucionTratamientoZonaDTO obj = new EvolucionTratamientoZonaDTO();
                while (await reader.ReadAsync())
                {
                    obj.Id = Convert.ToInt32(reader["Id"]);
                    Exito = Convert.ToInt32(reader["Exito"].ToString());
                    Mensaje = reader["Mensaje"].ToString();
                    ErrorDetalle = reader["ErrorDetalle"].ToString();
                }

                if (Exito == 1)
                {
                    return obj;
                }
                else
                {
                    throw new AlertException(Mensaje + " : " + ErrorDetalle);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        static async Task<ET_ZonaFotosDTO> ReadFotoHistoriaCLinicaZona(SqlDataReader reader)
        {
            try
            {
                ET_ZonaFotosDTO obj = new ET_ZonaFotosDTO();
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


        static async Task<EvolucionTratamientoDTO> ReadEvolucionTratamiento(SqlDataReader reader)
        {
            try
            {
                EvolucionTratamientoDTO obj = null;
                while (await reader.ReadAsync())
                {
                    obj = new EvolucionTratamientoDTO();
                    obj.Id = Convert.ToInt32(reader["Id"].ToString());
                    obj.IdCita = Convert.ToInt32(reader["IdCita"].ToString());

                    obj.Zonas = new List<EvolucionTratamientoZonaDTO>();

                    obj.FechaRegistro = reader["FechaRegistro"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["FechaRegistro"]);
                    obj.UsuarioRegistro = reader["UsuarioRegistro"] == DBNull.Value ? null : reader["UsuarioRegistro"].ToString();
                    obj.FechaModifico = reader["FechaModifico"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["FechaModifico"]);
                    obj.UsuarioModifico = reader["UsuarioModifico"] == DBNull.Value ? null : reader["UsuarioModifico"].ToString();
                    obj.UsuarioAtendio = reader["UsuarioAtendio"] == DBNull.Value ? null : reader["UsuarioAtendio"].ToString();
                    obj.IdUsuarioAtendio = Convert.ToInt32(reader["IdUsuarioAtendio"]);
                    obj.IdUsuarioRegistro = Convert.ToInt32(reader["IdUsuarioRegistro"]);

                    obj.IdEstado = Convert.ToInt32(reader["IdEstado"]);
                }

                if (reader.NextResult())
                {
                    while (await reader.ReadAsync())
                    {
                        EvolucionTratamientoZonaDTO modelZona = new EvolucionTratamientoZonaDTO()
                        {
                            Id = Convert.ToInt32(reader["Id"].ToString()),
                            IdEvolucionTratamiento = Convert.ToInt32(reader["IdEvolucionTratamiento"].ToString()),
                            IdCitaDetalle = Convert.ToInt32(reader["IdCitaDetalle"].ToString()),
                            Sesion = Convert.ToInt32(reader["Sesion"].ToString()),
                            PrototipoPiel = reader["PrototipoPiel"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["PrototipoPiel"].ToString()),
                            IdEquipoLaser = reader["IdEquipoLaser"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["IdEquipoLaser"].ToString()),
                            EquipoLaser = reader["IdEquipoLaser"] == DBNull.Value ? null : new ET_EquipoLaserDTO()
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
                        obj.Zonas.Add(modelZona);
                    }
                }

                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        static async Task<List<EvolucionTratamientoDTO>> ReadCollectionEvolucionTratamiento(SqlDataReader reader)
        {
            try
            {
                List<EvolucionTratamientoDTO> collection = new List<EvolucionTratamientoDTO>();
                while (await reader.ReadAsync())
                {
                    EvolucionTratamientoDTO model = new EvolucionTratamientoDTO()
                    {
                        Id = Convert.ToInt32(reader["Id"].ToString()),
                        IdCita = Convert.ToInt32(reader["IdCita"].ToString()),

                        Zonas = new List<EvolucionTratamientoZonaDTO>(),

                        FechaRegistro = reader["FechaRegistro"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["FechaRegistro"]),
                        UsuarioRegistro = reader["UsuarioRegistro"] == DBNull.Value ? null : reader["UsuarioRegistro"].ToString(),
                        FechaModifico = reader["FechaModifico"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["FechaModifico"]),
                        UsuarioModifico = reader["UsuarioModifico"] == DBNull.Value ? null : reader["UsuarioModifico"].ToString(),
                        UsuarioAtendio = reader["UsuarioAtendio"] == DBNull.Value ? null : reader["UsuarioAtendio"].ToString(),

                        IdEstado = Convert.ToInt32(reader["IdEstado"])
                    };
                    collection.Add( model );
                }

                return collection;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static async Task<List<EvolucionTratamientoDosisDTO>> ReadCollectionDosisSubzona(SqlDataReader reader)
        {
            try
            {
                List<EvolucionTratamientoDosisDTO> collection = new List<EvolucionTratamientoDosisDTO>();
                while (await reader.ReadAsync())
                {
                    EvolucionTratamientoDosisDTO obj = new EvolucionTratamientoDosisDTO();
                    obj.Id = Convert.ToInt32(reader["Id"].ToString());
                    obj.IdEvolucionTratamientoZona = Convert.ToInt32(reader["IdEvolucionTratamientoZona"].ToString());
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
    }
}
