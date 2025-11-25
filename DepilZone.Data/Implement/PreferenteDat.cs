using DepilZone.Data.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using DepilZone.Entidad.Exceptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text.Json;
using System.Threading.Tasks;

namespace DepilZone.Data.Implement
{
    public class PreferenteDat : IPreferenteDat
    {

        private readonly string _connectionString;

        public PreferenteDat(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public async Task<Respuesta<PreferenteEnt>> Asignar(PreferenteEnt model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Preferente_Asignar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("Id", model.Id);
                cmd.Parameters.AddWithValue("IdTeleoperador", model.IdTeleoperador);
                cmd.Parameters.AddWithValue("UsuarioEdita", model.UsuarioEdita);
                cmd.Parameters.AddWithValue("IdUsuarioRegistro", model.IdUsuarioRegistro);
                cmd.Parameters.AddWithValue("PreferenteObservacion", JsonSerializer.Serialize(model.PreferenteObservacion));
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

        public async Task<Respuesta<PreferenteEnt>> Atendido(PreferenteEnt model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Preferente_Atendido", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("Id", model.Id);
                cmd.Parameters.AddWithValue("IdEstadoPad", model.IdEstadoPadre);
                cmd.Parameters.AddWithValue("IdEstadoHij", model.IdEstadoAtencion);
                cmd.Parameters.AddWithValue("IdEstadoPro", model.Promocion);
                cmd.Parameters.AddWithValue("IdEstadoZon", model.IdAtencionOpcion);
                cmd.Parameters.AddWithValue("PreferenteComentario", model.Comentario);

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

        public async Task<Respuesta<PreferenteEnt>> Insertar(PreferenteEnt model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Preferente_Insertar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("Nombres", model.Nombres.ToUpper());
                cmd.Parameters.AddWithValue("Apellidos", model.Apellidos.ToUpper());
                cmd.Parameters.AddWithValue("Email", model.Email.ToUpper());
                cmd.Parameters.AddWithValue("Promocion", model.Promocion.ToUpper());
                cmd.Parameters.AddWithValue("IdUbicacion", model.IdUbicacion);
                cmd.Parameters.AddWithValue("Direccion", model.Direccion.ToUpper());
                cmd.Parameters.AddWithValue("IdTeleoperador", model.IdTeleoperador);
                cmd.Parameters.AddWithValue("IdComentario", model.IdComentario);
                cmd.Parameters.AddWithValue("IdMedioContacto", model.IdMedioContacto);
                cmd.Parameters.AddWithValue("IdMedioContactoCierre", model.IdMedioContactoCierre);

                cmd.Parameters.AddWithValue("IdEstado", model.IdEstado);
                cmd.Parameters.AddWithValue("OtroMedioContacto", model.OtroMedioContacto);
                cmd.Parameters.AddWithValue("UsuFacebook", model.UsuFacebook);
                cmd.Parameters.AddWithValue("UsuInstagram", model.UsuInstagram);
                cmd.Parameters.AddWithValue("UsuarioRegistra", model.UsuarioRegistra);
                cmd.Parameters.AddWithValue("EsCliente", model.EsCliente);
                cmd.Parameters.AddWithValue("IdCliente", model.IdCliente);
                cmd.Parameters.AddWithValue("PreferenteTelefono", JsonSerializer.Serialize(model.PreferenteTelefono));
                cmd.Parameters.AddWithValue("PreferenteZonaCorporal", JsonSerializer.Serialize(model.PreferenteZonaCorporal));
                cmd.Parameters.AddWithValue("PreferenteObservacion", JsonSerializer.Serialize(model.PreferenteObservacion));
                cmd.Parameters.AddWithValue("UtmSource", model.UtmSource);
                cmd.Parameters.AddWithValue("UtmMedium", model.UtmMedium);
                cmd.Parameters.AddWithValue("UtmCampaign", model.UtmCampaign);
                cmd.Parameters.AddWithValue("UtmId", model.UtmId);
                cmd.Parameters.AddWithValue("UtmTerm", model.UtmTerm);
                cmd.Parameters.AddWithValue("CodAtencion", model.CodAtencion);

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

        public async Task<Respuesta<PreferenteEnt>> Modificar(PreferenteEnt model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Preferente_Modificar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("Id", model.Id);
                cmd.Parameters.AddWithValue("Nombres", model.Nombres.ToUpper());
                cmd.Parameters.AddWithValue("Apellidos", model.Apellidos.ToUpper());
                cmd.Parameters.AddWithValue("Email", model.Email.ToUpper());
                cmd.Parameters.AddWithValue("Promocion", model.Promocion.ToUpper());
                cmd.Parameters.AddWithValue("IdUbicacion", model.IdUbicacion);
                cmd.Parameters.AddWithValue("Direccion", model.Direccion.ToUpper());
                cmd.Parameters.AddWithValue("IdTeleoperador", model.IdTeleoperador);
                cmd.Parameters.AddWithValue("IdComentario", model.IdComentario);
                cmd.Parameters.AddWithValue("IdMedioContacto", model.IdMedioContacto);

                cmd.Parameters.AddWithValue("IdMedioRecontacto", model.IdMedioRecontacto);

                cmd.Parameters.AddWithValue("IdMedioContactoCierre", model.IdMedioContactoCierre);

                cmd.Parameters.AddWithValue("IdEstado", model.IdEstado);
                cmd.Parameters.AddWithValue("OtroMedioContacto", model.OtroMedioContacto);
                cmd.Parameters.AddWithValue("UsuFacebook", model.UsuFacebook);
                cmd.Parameters.AddWithValue("UsuInstagram", model.UsuInstagram);
                cmd.Parameters.AddWithValue("UsuarioEdita", model.UsuarioEdita);
                cmd.Parameters.AddWithValue("EsCliente", model.EsCliente);
                cmd.Parameters.AddWithValue("IdCliente", model.IdCliente);
                cmd.Parameters.AddWithValue("PreferenteTelefono", JsonSerializer.Serialize(model.PreferenteTelefono));
                cmd.Parameters.AddWithValue("PreferenteZonaCorporal", JsonSerializer.Serialize(model.PreferenteZonaCorporal));
                cmd.Parameters.AddWithValue("PreferenteObservacion", JsonSerializer.Serialize(model.PreferenteObservacion));
                cmd.Parameters.AddWithValue("UtmSource", model.UtmSource);
                cmd.Parameters.AddWithValue("UtmMedium", model.UtmMedium);
                cmd.Parameters.AddWithValue("UtmCampaign", model.UtmCampaign);
                cmd.Parameters.AddWithValue("UtmId", model.UtmId);
                cmd.Parameters.AddWithValue("UtmTerm", model.UtmTerm);
                cmd.Parameters.AddWithValue("CodAtencion", model.CodAtencion);

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

        public async Task<IEnumerable<PreferenteGrillaDTO>> Obtener(DateTime? FechaDesde, DateTime? FechaHasta, int? IdEstado, int? IdUsuario, int? IdMedioContacto, int IdUsuarioSistema, int IdEstadoAtencion, int esCliente)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Preferente_Obtener", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure,
                    CommandTimeout = 30000
                };
                cmd.Parameters.AddWithValue("FechaDesde", FechaDesde);
                cmd.Parameters.AddWithValue("FechaHasta", FechaHasta);
                cmd.Parameters.AddWithValue("IdEstado", IdEstado);
                cmd.Parameters.AddWithValue("IdEstadoAtencion", IdEstadoAtencion);
                cmd.Parameters.AddWithValue("IdTeleOperador", IdUsuario);
                cmd.Parameters.AddWithValue("IdMedioContacto", IdMedioContacto);
                cmd.Parameters.AddWithValue("IdUsuarioSistema", IdUsuarioSistema);
                cmd.Parameters.AddWithValue("EsCliente", esCliente);
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

        public async Task<IEnumerable<PreferenteMobileGrillaDTO>> ObtenerMobilePreferentes()
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Preferentes_Mobile", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure,
                    CommandTimeout = 30000
                };
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadMobileItems(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<GeneralResponse<PreferenteMobileResponseDTO>> UpdateMobilePreferenteEstado(int IdCita, int EstadoId)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Preferentes_Mobile_Actualizar_Estado", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdCita", IdCita);
                cmd.Parameters.AddWithValue("pIdEstado", EstadoId);

                var reader = await cmd.ExecuteReaderAsync();
                var output = await UpdateEstadoResponse(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        public async Task<IEnumerable<PreferenteGrillaDTO>> ObtenerReportePreferente(DateTime? FechaDesde, DateTime? FechaHasta, int? IdEstado, int? IdUsuario, int? IdMedioContacto, int IdUsuarioSistema, int IdEstadoAtencion, int esCliente)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_PreferenteObtener_Exc", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure,
                    CommandTimeout = 30000
                };
                cmd.Parameters.AddWithValue("FechaDesde", FechaDesde);
                cmd.Parameters.AddWithValue("FechaHasta", FechaHasta);
                cmd.Parameters.AddWithValue("IdEstado", IdEstado);
                cmd.Parameters.AddWithValue("IdEstadoAtencion", IdEstadoAtencion);
                cmd.Parameters.AddWithValue("IdTeleOperador", IdUsuario);
                cmd.Parameters.AddWithValue("IdMedioContacto", IdMedioContacto);
                cmd.Parameters.AddWithValue("IdUsuarioSistema", IdUsuarioSistema);
                cmd.Parameters.AddWithValue("EsCliente", esCliente);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItemsReportePreferente(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<PreferenteGrillaDTO>> ObtenerConTelefono(DateTime? FechaDesde, DateTime? FechaHasta, int? IdEstado, int? IdUsuario, int? IdMedioContacto, int IdUsuarioSistema, int IdEstadoAtencion, int esCliente)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Preferente_ObtenerConTelefono", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("FechaDesde", FechaDesde);
                cmd.Parameters.AddWithValue("FechaHasta", FechaHasta);
                cmd.Parameters.AddWithValue("IdEstado", IdEstado);
                cmd.Parameters.AddWithValue("IdEstadoAtencion", IdEstadoAtencion);
                cmd.Parameters.AddWithValue("IdTeleOperador", IdUsuario);
                cmd.Parameters.AddWithValue("IdMedioContacto", IdMedioContacto);
                cmd.Parameters.AddWithValue("IdUsuarioSistema", IdUsuarioSistema);
                cmd.Parameters.AddWithValue("EsCliente", esCliente);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadObtenerConTelefono(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<PreferenteDTO> ObtenerById(int Id, int IdUsuarioSistema)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Preferente_ObtenerById", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("Id", Id);
                cmd.Parameters.AddWithValue("IdUsuarioSistema", IdUsuarioSistema);
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

        public async Task<int> RetornarSinAtender()
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Preferente_RetornarSinAtender", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                object scalar = await cmd.ExecuteScalarAsync();

                conn.Close();

                return Convert.ToInt32(scalar);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> ActualizaEstadoVisto(ListaIdsDTO idsPreferente)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Preferente_ActualizarEstadoVisto", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                string IdsString = string.Join(", ", idsPreferente.Ids);


                cmd.Parameters.AddWithValue("PreferenteIds", IdsString);

                object scalar = await cmd.ExecuteScalarAsync();

                conn.Close();

                return Convert.ToInt32(scalar);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> ImportarExcel(List<PreferenteImportarDTO> listado)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Preferente_ImportarExcel", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pPreferentes", JsonSerializer.Serialize(listado));
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadExportarExcel(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> AsignarLista(List<PreferenteAsignarListaDTO> listado)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Preferente_AsignarLista", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pPreferentes", JsonSerializer.Serialize(listado));
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadAsignarLista(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> ObtenerNumeroAsignados(int idUsuario, DateTime fecha)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Preferente_ObtenerNumeroAsignados", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdUsuario", idUsuario);
                cmd.Parameters.AddWithValue("pFecha", fecha);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadObtenerNumeroAsignados(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<PreferenteDTO>> ObtenerAsignadosDelDia()
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Preferente_ObtenerAsignadosDeldia", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadObtenerAsignadosDelDia(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<PreferenteDTO>> ObtenerRetornados()
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Preferente_ObtenerRetornadosSinAsignar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadObtenerRetornados(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> AtendiendoPreferente(int idPreferente, int termino)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Preferente_Atendiendo", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdPreferente", idPreferente);
                cmd.Parameters.AddWithValue("pTermino", termino);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadAtendiendoPreferente(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<bool> FormularioWeb(FormularioWebDTO model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Preferente_FormularioWeb", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pNombres", model.Nombres);
                cmd.Parameters.AddWithValue("pApellidos", model.Apellidos);
                cmd.Parameters.AddWithValue("pTelefono", model.Telefono);
                cmd.Parameters.AddWithValue("pDocumento", model.Documento);
                cmd.Parameters.AddWithValue("pObservacion", JsonSerializer.Serialize(model.Observacion));
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadFormularioWeb(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> FormularioWebLanding(FormularioWebLandingDTO model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Preferente_FormularioWebLanding", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pNombres", model.Nombres);
                cmd.Parameters.AddWithValue("pApellidos", model.Apellidos);
                cmd.Parameters.AddWithValue("pTelefono", model.Telefono);
                cmd.Parameters.AddWithValue("pDocumento", model.Documento);
                cmd.Parameters.AddWithValue("pCorreo", model.Correo);
                cmd.Parameters.AddWithValue("pObservacion", JsonSerializer.Serialize(model.Observacion));
                cmd.Parameters.AddWithValue("pUtmSource", model.UtmSource);
                cmd.Parameters.AddWithValue("pUtmMedium", model.UtmMedium);
                cmd.Parameters.AddWithValue("pUtmId", model.UtmId);
                cmd.Parameters.AddWithValue("pUtmCampaign", model.UtmCampaign);
                cmd.Parameters.AddWithValue("pUtmTerm", model.UtmTerm);
                cmd.Parameters.AddWithValue("pUtmContent", model.UtmContent);
                cmd.Parameters.AddWithValue("pTag", model.Tag);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadFormularioWeb(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<int> ObtenerPendientesActuales()
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Preferente_NumeroPendientes", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadObtenerPendientesActuales(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<List<PreferenteHistoriaDTO>> ObtenerHistoria(int idPreferente)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Preferente_ObtenerHistoria", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdPreferente", idPreferente);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadObtenerHistoria(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public async Task<bool> Reasignar(PreferenteReasignarDTO model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Preferente_Reasignar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("IdPreferente", model.IdPreferente);
                cmd.Parameters.AddWithValue("AsignadoA", model.AsignadoA);
                cmd.Parameters.AddWithValue("IdUsuario", model.IdUsuario);
                cmd.Parameters.AddWithValue("Observaciones", JsonSerializer.Serialize(model.Observaciones));
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadReasignar(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<PreferenteDTO> ObtenerByFacebookUser(string facebookUser)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Preferente_ObtenerByFacebookUser", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("UsuarioFacebook", facebookUser);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReaderObtenerByFacebookUser(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<PreferenteDTO> ObtenerByInstagramUser(string instagramUser)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Preferente_ObtenerByInstagramUser", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("UsuarioInstagram", instagramUser);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReaderObtenerByInstagramUser(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public async Task<List<PreferenteGrillaDTO>> Buscar(BuscarPreferenteDTO model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Preferente_Buscar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("dateType", model.DateTipo);
                cmd.Parameters.AddWithValue("fechaDesde", model.FechaDesde);
                cmd.Parameters.AddWithValue("fechaHasta", model.FechaHasta);
                cmd.Parameters.AddWithValue("tipo", model.Tipo);
                cmd.Parameters.AddWithValue("usuario", model.Usuario);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReaderBuscar(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        // READERS


        static async Task<bool> ReadReasignar(DbDataReader reader)
        {
            try
            {
                bool success = false;
                string mensaje = "";
                while (await reader.ReadAsync())
                {
                    success = Convert.ToBoolean(reader["Exito"]);
                    mensaje = reader["Mensaje"].ToString() + " " + reader["ErrorDetalle"].ToString();
                }

                if (!success)
                {
                    throw new SystemException(mensaje);
                }

                return success;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static async Task<bool> ReadExportarExcel(DbDataReader reader)
        {
            try
            {
                bool success = false;
                string mensaje = "";
                while (await reader.ReadAsync())
                {
                    success = Convert.ToBoolean(reader["Exito"]);
                    mensaje = reader["Mensaje"].ToString() + " " + reader["ErrorDetalle"].ToString();
                }

                if (!success)
                {
                    throw new SystemException(mensaje);
                }

                return success;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static async Task<string> ReadAsignarLista(DbDataReader reader)
        {
            try
            {
                bool success = false;
                string mensaje = "";
                string usuarios = "";
                while (await reader.ReadAsync())
                {
                    success = Convert.ToBoolean(reader["Exito"]);
                    mensaje = reader["Mensaje"].ToString() + " " + reader["ErrorDetalle"].ToString();
                    if (!success)
                    {
                        throw new SystemException(mensaje);
                    }

                    usuarios = reader["Usuarios"].ToString();
                }

                return usuarios;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static async Task<PreferenteDTO> Read(DbDataReader reader)
        {
            try
            {
                PreferenteDTO obj = new PreferenteDTO();
                while (await reader.ReadAsync())
                {
                    obj.Id = Convert.ToInt32(reader["Id"]);
                    obj.Nombres = Convert.ToString(reader["Nombres"]);
                    obj.Apellidos = Convert.ToString(reader["Apellidos"]);
                    obj.Email = Convert.ToString(reader["Email"]);
                    obj.Promocion = Convert.ToString(reader["Promocion"]);
                    obj.IdUbicacion = Convert.ToString(reader["IdUbicacion"]);
                    obj.Direccion = Convert.ToString(reader["Direccion"]);
                    obj.IdTeleoperador = reader["IdTeleoperador"] as int? ?? null;
                    obj.Teleoperador = reader["Teleoperador"] as string ?? null;
                    obj.EstadoAtencion = reader["EstadoAtencion"] as string ?? null;
                    obj.IdComentario = reader["IdComentario"] as int? ?? null;
                    obj.IdMedioContacto = Convert.ToInt32(reader["IdMedioContacto"]);
                    obj.IdMedioContactoCierre = reader["IdMedioContactoCierre"] != DBNull.Value ? Convert.ToInt32(reader["IdMedioContactoCierre"]) : null;
                    obj.IdMedioRecontacto = reader["IdMedioRecontacto"] != DBNull.Value ? Convert.ToInt32(reader["IdMedioRecontacto"]) : null;


                    obj.IdEstado = Convert.ToInt32(reader["IdEstado"]);
                    obj.OtroMedioContacto = Convert.ToString(reader["OtroMedioContacto"]);
                    obj.FechaAsignacion = reader["FechaAsignacion"] != DBNull.Value ? Convert.ToDateTime(reader["FechaAsignacion"]) : (DateTime?)null;
                    obj.UsuarioRegistra = Convert.ToString(reader["UsuarioRegistra"]);
                    obj.FechaRegistra = Convert.ToDateTime(reader["FechaRegistra"]);
                    obj.UsuarioEdita = reader["UsuarioEdita"] as string;
                    obj.FechaEdita = reader["FechaEdita"] as DateTime? ?? null;
                    obj.UsuFacebook = reader["UsuFacebook"] as string ?? null;
                    obj.UsuInstagram = reader["UsuInstagram"] as string ?? null;

                    obj.Distrito = reader["Distrito"] as string;
                    obj.Provincia = reader["Provincia"] as string;
                    obj.Departamento = reader["Departamento"] as string;

                    obj.PreferenteTelefono = reader["PreferenteTelefono"] != DBNull.Value ? JsonSerializer.Deserialize<List<PreferenteTelefonoEnt>>(reader["PreferenteTelefono"].ToString()) : null;
                    obj.PreferenteZonaCorporal = reader["PreferenteZonaCorporal"] != DBNull.Value ? JsonSerializer.Deserialize<List<PreferenteZonaCorporalEnt>>(reader["PreferenteZonaCorporal"].ToString()) : null;
                    obj.PreferenteObservacion = reader["PreferenteObservacion"] != DBNull.Value ? JsonSerializer.Deserialize<List<PreferenteObservacionDTO>>(reader["PreferenteObservacion"].ToString()) : null;

                    obj.EsCliente = Convert.ToInt32(reader["EsCliente"]);
                    obj.IdCliente = Convert.ToInt32(reader["IdCliente"]);
                    obj.Observacion = new List<string>(JsonSerializer.Deserialize<List<string>>(Convert.ToString(reader["Observacion"])));
                    //obj.Observacion = new List<string>(JsonSerializer.Deserialize<List<string>>(Convert.ToString(reader["Observacion"].ToString().Replace("\t", " "))));
                    //TRIM(REPLACE(Observacion, CHAR(9), ''))


                    obj.IdPreferenteAtencion = reader["IdPreferenteAtencion"] != DBNull.Value ? Convert.ToInt32(reader["IdPreferenteAtencion"]) : (int?)null;
                    obj.FechaPreferenteAtencion = reader["FechaPreferenteAtencion"] != DBNull.Value ? Convert.ToDateTime(reader["FechaPreferenteAtencion"]) : (DateTime?)null;
                    obj.EstadoPreferenteAtencion = reader["EstadoPreferenteAtencion"] != DBNull.Value ? Convert.ToString(reader["EstadoPreferenteAtencion"]) : (string?)null;

                    obj.UtmSource = reader["UtmSource"] as string ?? null;
                    obj.UtmMedium = reader["UtmMedium"] as string ?? null;
                    obj.UtmCampaign = reader["UtmCampaign"] as string ?? null;
                    obj.UtmId = reader["UtmId"] as string ?? null;
                    obj.UtmTerm = reader["UtmTerm"] as string ?? null;
                    obj.CodAtencion = reader["CodAtencion"] as string ?? null;
                }


                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static async Task<PreferenteDTO> ReaderObtenerByFacebookUser(DbDataReader reader)
        {
            try
            {
                PreferenteDTO obj = null;
                while (await reader.ReadAsync())
                {
                    obj = new PreferenteDTO();
                    obj.Nombres = Convert.ToString(reader["Nombres"]);
                    obj.Apellidos = Convert.ToString(reader["Apellidos"]);
                    obj.Email = Convert.ToString(reader["Email"]);

                    obj.PreferenteTelefono = reader["PreferenteTelefono"] != DBNull.Value ? JsonSerializer.Deserialize<List<PreferenteTelefonoEnt>>(reader["PreferenteTelefono"].ToString()) : null;

                    obj.EsCliente = DBNull.Value == reader["ClienteId"] ? 0 : 1;
                    obj.IdCliente = DBNull.Value == reader["ClienteId"] ? 0 : Convert.ToInt32(reader["ClienteId"]);
                    obj.ClienteNombre = DBNull.Value == reader["ClienteNombres"] ? null : Convert.ToString(reader["ClienteNombres"]);
                    obj.ClienteApellido = DBNull.Value == reader["ClienteApellidos"] ? null : Convert.ToString(reader["ClienteApellidos"]);
                    obj.ClienteCorreo = DBNull.Value == reader["ClienteCorreo"] ? null : Convert.ToString(reader["ClienteCorreo"]);
                    obj.ClienteTelefonoPais = DBNull.Value == reader["ClienteTelefonoPais"] ? null : Convert.ToString(reader["ClienteTelefonoPais"]);
                    obj.ClienteTelefono = DBNull.Value == reader["ClienteTelefono"] ? null : Convert.ToString(reader["ClienteTelefono"]);
                    obj.ClienteCorreo = DBNull.Value == reader["ClienteCorreo"] ? null : Convert.ToString(reader["ClienteCorreo"]);
                }

                if (obj == null)
                {
                    throw new AlertException("No se encontro preferente relacionado");
                }

                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static async Task<PreferenteDTO> ReaderObtenerByInstagramUser(DbDataReader reader)
        {
            try
            {
                PreferenteDTO obj = null;
                while (await reader.ReadAsync())
                {
                    obj = new PreferenteDTO();
                    obj.Nombres = Convert.ToString(reader["Nombres"]);
                    obj.Apellidos = Convert.ToString(reader["Apellidos"]);
                    obj.Email = Convert.ToString(reader["Email"]);

                    obj.PreferenteTelefono = reader["PreferenteTelefono"] != DBNull.Value ? JsonSerializer.Deserialize<List<PreferenteTelefonoEnt>>(reader["PreferenteTelefono"].ToString()) : null;

                    obj.EsCliente = DBNull.Value == reader["ClienteId"] ? 0 : 1;
                    obj.IdCliente = DBNull.Value == reader["ClienteId"] ? 0 : Convert.ToInt32(reader["ClienteId"]);
                    obj.ClienteNombre = DBNull.Value == reader["ClienteNombres"] ? null : Convert.ToString(reader["ClienteNombres"]);
                    obj.ClienteApellido = DBNull.Value == reader["ClienteApellidos"] ? null : Convert.ToString(reader["ClienteApellidos"]);
                    obj.ClienteCorreo = DBNull.Value == reader["ClienteCorreo"] ? null : Convert.ToString(reader["ClienteCorreo"]);
                    obj.ClienteTelefonoPais = DBNull.Value == reader["ClienteTelefonoPais"] ? null : Convert.ToString(reader["ClienteTelefonoPais"]);
                    obj.ClienteTelefono = DBNull.Value == reader["ClienteTelefono"] ? null : Convert.ToString(reader["ClienteTelefono"]);
                    obj.ClienteCorreo = DBNull.Value == reader["ClienteCorreo"] ? null : Convert.ToString(reader["ClienteCorreo"]);
                }

                if (obj == null)
                {
                    throw new AlertException("No se encontro preferente relacionado");
                }

                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static async Task<Respuesta<PreferenteEnt>> ReadItem(DbDataReader reader)
        {
            try
            {
                Respuesta<PreferenteEnt> obj = new Respuesta<PreferenteEnt>
                {
                    Response = new PreferenteEnt()
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
                        obj.Response.Nombres = Convert.ToString(reader["Nombres"]);
                        obj.Response.Apellidos = Convert.ToString(reader["Apellidos"]);
                        obj.Response.Email = Convert.ToString(reader["Email"]);
                        obj.Response.Promocion = Convert.ToString(reader["Promocion"]);
                        obj.Response.IdUbicacion = Convert.ToString(reader["IdUbicacion"]);
                        obj.Response.IdEstado = Convert.ToInt32(reader["IdEstado"]);
                        obj.Response.Direccion = Convert.ToString(reader["Direccion"]);
                        obj.Response.IdTeleoperador = reader["IdTeleoperador"] as int? ?? null;
                        obj.Response.IdComentario = reader["IdComentario"] as int? ?? null;
                        obj.Response.IdMedioContacto = Convert.ToInt32(reader["IdMedioContacto"]);
                        obj.Response.UsuFacebook = reader["UsuFacebook"] as string ?? null;
                        obj.Response.UsuInstagram = reader["UsuInstagram"] as string ?? null;
                        obj.Response.OtroMedioContacto = Convert.ToString(reader["OtroMedioContacto"]);
                        obj.Response.FechaAsignacion = reader["FechaAsignacion"] != DBNull.Value ? Convert.ToDateTime(reader["FechaAsignacion"]) : (DateTime?)null;
                        obj.Response.UsuarioRegistra = Convert.ToString(reader["UsuarioRegistra"]);
                        obj.Response.FechaRegistra = Convert.ToDateTime(reader["FechaRegistra"]);
                        obj.Response.PreferenteTelefono = reader["PreferenteTelefono"] != DBNull.Value ? JsonSerializer.Deserialize<List<PreferenteTelefonoEnt>>(reader["PreferenteTelefono"].ToString()) : null;
                        obj.Response.UtmSource = reader["UtmSource"] as string ?? null;
                        obj.Response.UtmMedium = reader["UtmMedium"] as string ?? null;
                        obj.Response.UtmCampaign = reader["UtmCampaign"] as string ?? null;
                        obj.Response.UtmId = reader["UtmId"] as string ?? null;
                        obj.Response.UtmTerm = reader["UtmTerm"] as string ?? null;
                        obj.Response.CodAtencion = reader["CodAtencion"] as string ?? null;
                    }
                }

                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static async Task<IEnumerable<PreferenteGrillaDTO>> ReadItemsReportePreferente(DbDataReader reader)
        {
            try
            {
                List<PreferenteObservacionDTO> observaciones = new List<PreferenteObservacionDTO>();

                List<PreferenteGrillaDTO> lista = new List<PreferenteGrillaDTO>();
                while (await reader.ReadAsync())
                {
                    PreferenteGrillaDTO obj = new PreferenteGrillaDTO();

                    obj.Id = Convert.ToInt32(reader["Id"]);
                    obj.X = "";
                    obj.Nombres = reader["Nombres"].ToString();
                    obj.Teleoperadora = reader["Teleoperador"].ToString();
                    obj.NombreTeleoperador = reader["NombreTeleoperador"].ToString();

                    obj.FechaRegistra = Convert.ToDateTime(reader["FechaRegistra"]);
                    obj.FechaAsignacion = reader["FechaAsignacion"] != DBNull.Value ? Convert.ToDateTime(reader["FechaAsignacion"]).ToString("dd-MM-yyyy hh:mm:ss tt") : null;
                    obj.Celular = reader["Celular"].ToString();
                    obj.Email = reader["Email"].ToString();
                    obj.Distrito = reader["Distrito"].ToString();
                    obj.ZonaCorporal = reader["ZonaCorporal"].ToString();
                    obj.MedioContacto = Convert.ToString(reader["MedioContacto"]);
                    obj.IdEstado = Convert.ToInt32(reader["IdEstado"]);
                    obj.EstadoAtencion = Convert.ToString(reader["EstadoAtencion"]);
                    obj.Promocion = reader["Promocion"].ToString();
                    obj.EsCliente = Convert.ToInt32(reader["EsCliente"]);
                    obj.IdCliente = Convert.ToInt32(reader["IdCliente"]);

                    obj.Observacion = new List<string>();

                    obj.UsuFacebook = reader["UsuFacebook"] != DBNull.Value ? Convert.ToString(reader["UsuFacebook"]) : null;
                    obj.UsuInstagram = reader["UsuInstagram"] != DBNull.Value ? Convert.ToString(reader["UsuInstagram"]) : null;

                    obj.UtmSource = reader["UtmSource"] != DBNull.Value ? Convert.ToString(reader["UtmSource"]) : null;
                    obj.UtmMedium = reader["UtmMedium"] != DBNull.Value ? Convert.ToString(reader["UtmMedium"]) : null;
                    obj.UtmCampaign = reader["UtmCampaign"] != DBNull.Value ? Convert.ToString(reader["UtmCampaign"]) : null;
                    obj.UtmId = reader["UtmId"] != DBNull.Value ? Convert.ToString(reader["UtmId"]) : null;
                    obj.UtmTerm = reader["UtmTerm"] != DBNull.Value ? Convert.ToString(reader["UtmTerm"]) : null;
                    obj.UtmCont = reader["UtmCont"] != DBNull.Value ? Convert.ToString(reader["UtmCont"]) : null;

                    obj.Comentario = DBNull.Value == reader["Comentario"] ? null : Convert.ToString(reader["Comentario"]);
                    obj.UsuarioRegistro = DBNull.Value == reader["UsuarioRegistro"] ? null : Convert.ToString(reader["UsuarioRegistro"]);

                    obj.Agendo = reader["Agendo"] != DBNull.Value ? Convert.ToDateTime(reader["Agendo"]) : (DateTime?)null;

                    lista.Add(obj);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static async Task<IEnumerable<PreferenteGrillaDTO>> ReadItems(DbDataReader reader)
        {
            try
            {

                List<PreferenteObservacionDTO> observaciones = new List<PreferenteObservacionDTO>();

                List<PreferenteGrillaDTO> lista = new List<PreferenteGrillaDTO>();
                while (await reader.ReadAsync())
                {
                    PreferenteGrillaDTO obj = new PreferenteGrillaDTO
                    {
                        Id = reader.GetFieldValue<int>(0),
                        X = "",
                        Nombres = reader["Nombres"].ToString(),
                        Teleoperadora = reader["Teleoperador"].ToString(),
                        NombreTeleoperador = reader["NombreTeleoperador"].ToString(),

                        FechaRegistra = Convert.ToDateTime(reader["FechaRegistra"]),
                        FechaAsignacion = reader["FechaAsignacion"] != DBNull.Value ? Convert.ToDateTime(reader["FechaAsignacion"]).ToString("dd-MM-yyyy hh:mm:ss tt") : null,
                        Celular = reader["Celular"].ToString(),
                        Email = reader["Email"].ToString(),
                        Distrito = reader["Distrito"].ToString(),
                        ZonaCorporal = reader["ZonaCorporal"].ToString(),
                        MedioContacto = Convert.ToString(reader["MedioContacto"]),

                        MedioRecontacto = reader["IdMedioRecontacto"] != DBNull.Value ? Convert.ToString(reader["IdMedioRecontacto"]) : null,


                        MedioContactoCierre = reader["MedioContactoCierre"] != DBNull.Value ? Convert.ToString(reader["MedioContactoCierre"]) : null,
                        IdEstado = Convert.ToInt32(reader["IdEstado"]),
                        EstadoAtencion = Convert.ToString(reader["EstadoAtencion"]),
                        EsCliente = Convert.ToInt32(reader["EsCliente"]),
                        IdCliente = Convert.ToInt32(reader["IdCliente"]),
                        //Observacion = new List<string>(JsonSerializer.Deserialize<List<string>>(Convert.ToString(reader["Observacion"]))),

                        Observacion = new List<string>(),

                        UsuFacebook = reader["UsuFacebook"] != DBNull.Value ? Convert.ToString(reader["UsuFacebook"]) : null,
                        UsuInstagram = reader["UsuInstagram"] != DBNull.Value ? Convert.ToString(reader["UsuInstagram"]) : null,


                        UtmSource = reader["UtmSource"] != DBNull.Value ? Convert.ToString(reader["UtmSource"]) : null,
                        UtmMedium = reader["UtmMedium"] != DBNull.Value ? Convert.ToString(reader["UtmMedium"]) : null,
                        UtmCampaign = reader["UtmCampaign"] != DBNull.Value ? Convert.ToString(reader["UtmCampaign"]) : null,
                        UtmId = reader["UtmId"] != DBNull.Value ? Convert.ToString(reader["UtmId"]) : null,
                        UtmTerm = reader["UtmTerm"] != DBNull.Value ? Convert.ToString(reader["UtmTerm"]) : null,
                        UtmCont = reader["UtmCont"] != DBNull.Value ? Convert.ToString(reader["UtmCont"]) : null,

                        Comentario = DBNull.Value == reader["Comentario"] ? null : Convert.ToString(reader["Comentario"]),
                        UsuarioRegistro = DBNull.Value == reader["UsuarioRegistro"] ? null : Convert.ToString(reader["UsuarioRegistro"]),

                        Agendo = reader["Agendo"] != DBNull.Value ? Convert.ToDateTime(reader["Agendo"]) : (DateTime?)null,


                        //AtencionCategoria = DBNull.Value == reader["AtencionCategoria"] ? null : Convert.ToString(reader["AtencionCategoria"]),
                        //AtencionOpcion = DBNull.Value == reader["AtencionOpcion"] ? null : Convert.ToString(reader["AtencionOpcion"])

                    };
                    lista.Add(obj);
                }


                if (reader.NextResult())
                {
                    while (await reader.ReadAsync())
                    {
                        observaciones.Add(
                            new PreferenteObservacionDTO()
                            {
                                IdPreferente = Convert.ToInt32(reader["IdPreferente"]),
                                Observacion = Convert.ToString(reader["Observacion"]),
                            }
                        );
                    }

                    foreach (var observacion in observaciones)
                    {
                        lista.Find(p => p.Id == observacion.IdPreferente).Observacion.Add(observacion.Observacion);
                    }
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static async Task<IEnumerable<PreferenteMobileGrillaDTO>> ReadMobileItems(DbDataReader reader)
        {
            try
            {

                List<PreferenteMobileGrillaDTO> lista = new List<PreferenteMobileGrillaDTO>();
                while (await reader.ReadAsync())
                {
                    PreferenteMobileGrillaDTO obj = new PreferenteMobileGrillaDTO
                    {
                        Nombre = reader["Nombres"].ToString() + " " + reader["Apellidos"].ToString(),
                        Celular1 = reader["Celular1"] == DBNull.Value ? "" : reader["Celular1"].ToString(),
                        Celular2 = reader["Celular2"] == DBNull.Value ? "" : reader["Celular2"].ToString(),
                        FechaCita = Convert.ToDateTime(reader["FechaSolicitud"]).ToString("dd-MM-yyyy"),
                        HoraInicio = Convert.ToDateTime(reader["HoraInicio"]).ToString("yyyy-MM-ddTHH:mm:ss.fff"),
                        Estado = reader["NombreEstado"].ToString(),
                        Dni = reader["Documento"] == DBNull.Value ? "" : reader["Documento"].ToString(),
                        PagoRealizado = false,
                        Servicio = reader["NombreServicio"].ToString(),
                        IdCita = Convert.ToInt32(reader["IdCita"]),
                        NombreTratamiento = reader["NombreTratamiento"].ToString()
                    }
                ;
                    lista.Add(obj);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static async Task<GeneralResponse<PreferenteMobileResponseDTO>> UpdateEstadoResponse(DbDataReader reader)
        {
            try
            {
                GeneralResponse<PreferenteMobileResponseDTO> generalRes = new GeneralResponse<PreferenteMobileResponseDTO>
                {
                    Data = new PreferenteMobileResponseDTO()
                };


                if (await reader.ReadAsync())
                {
                    generalRes.Message = "Pago actualizado exitosamente.";
                    generalRes.Status = 200;

                    generalRes.Data.IdCita = Convert.ToInt32(reader["IdCita"]);
                    generalRes.Data.EstadoId = Convert.ToInt32(reader["EstadoId"]);
                }

                return generalRes;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static async Task<IEnumerable<PreferenteGrillaDTO>> ReadObtenerConTelefono(DbDataReader reader)
        {
            try
            {
                IList<PreferenteGrillaDTO> lista = new List<PreferenteGrillaDTO>();
                while (await reader.ReadAsync())
                {
                    PreferenteGrillaDTO obj = new PreferenteGrillaDTO
                    {
                        Id = reader.GetFieldValue<int>(0),
                        X = "",
                        Nombres = reader["Nombres"].ToString(),
                        Teleoperadora = reader["Teleoperador"].ToString(),
                        NombreTeleoperador = reader["NombreTeleoperador"].ToString(),

                        FechaRegistra = Convert.ToDateTime(reader["FechaRegistra"]),
                        FechaAsignacion = reader["FechaAsignacion"] != DBNull.Value ? Convert.ToDateTime(reader["FechaAsignacion"]).ToString("dd-MM-yyyy hh:mm:ss tt") : null,
                        Celular = reader["Celular"].ToString(),
                        Email = reader["Email"].ToString(),
                        Distrito = reader["Distrito"].ToString(),
                        ZonaCorporal = reader["ZonaCorporal"].ToString(),
                        MedioContacto = Convert.ToString(reader["MedioContacto"]),
                        IdEstado = Convert.ToInt32(reader["IdEstado"]),
                        EstadoAtencion = Convert.ToString(reader["EstadoAtencion"]),
                        EsCliente = Convert.ToInt32(reader["EsCliente"]),
                        IdCliente = Convert.ToInt32(reader["IdCliente"]),
                        Observacion = new List<string>(JsonSerializer.Deserialize<List<string>>(Convert.ToString(reader["Observacion"]))),

                        UtmSource = reader["UtmSource"] != DBNull.Value ? Convert.ToString(reader["UtmSource"]) : null,
                        UtmMedium = reader["UtmMedium"] != DBNull.Value ? Convert.ToString(reader["UtmMedium"]) : null,
                        UtmCampaign = reader["UtmCampaign"] != DBNull.Value ? Convert.ToString(reader["UtmCampaign"]) : null,
                        UtmId = reader["UtmId"] != DBNull.Value ? Convert.ToString(reader["UtmId"]) : null,
                        UtmTerm = reader["UtmTerm"] != DBNull.Value ? Convert.ToString(reader["UtmTerm"]) : null,

                        Comentario = DBNull.Value == reader["Comentario"] ? null : Convert.ToString(reader["Comentario"]),
                        UsuarioRegistro = DBNull.Value == reader["UsuarioRegistro"] ? null : Convert.ToString(reader["UsuarioRegistro"]),

                        //AtencionCategoria = DBNull.Value == reader["AtencionCategoria"] ? null : Convert.ToString(reader["AtencionCategoria"]),
                        //AtencionOpcion = DBNull.Value == reader["AtencionOpcion"] ? null : Convert.ToString(reader["AtencionOpcion"])

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

        static async Task<int> ReadObtenerNumeroAsignados(DbDataReader reader)
        {
            try
            {
                int total = 0;

                while (await reader.ReadAsync())
                {
                    total = Convert.ToInt32(reader["Total"]);
                }

                return total;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        static async Task<List<PreferenteDTO>> ReadObtenerAsignadosDelDia(DbDataReader reader)
        {
            try
            {
                List<PreferenteDTO> lista = new List<PreferenteDTO>();
                while (await reader.ReadAsync())
                {
                    PreferenteDTO obj = new PreferenteDTO
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Nombres = Convert.ToString(reader["Nombres"]),
                        Apellidos = Convert.ToString(reader["Apellidos"]),
                        IdEstado = Convert.ToInt32(reader["IdEstado"]),
                        IdEstadoAtencion = Convert.ToInt32(reader["IdEstadoAtencion3"]),
                        Teleoperador = Convert.ToString(reader["Teleoperador"])
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

        static async Task<List<PreferenteDTO>> ReadObtenerRetornados(DbDataReader reader)
        {
            try
            {
                List<PreferenteDTO> lista = new List<PreferenteDTO>();
                while (await reader.ReadAsync())
                {
                    PreferenteDTO obj = new PreferenteDTO
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Nombres = Convert.ToString(reader["Nombres"]),
                        Apellidos = Convert.ToString(reader["Apellidos"]),
                        IdEstado = Convert.ToInt32(reader["IdEstado"]),
                        IdEstadoAtencion = Convert.ToInt32(reader["IdEstadoAtencion3"]),
                        Teleoperador = Convert.ToString(reader["Teleoperador"])
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

        static async Task<bool> ReadAtendiendoPreferente(DbDataReader reader)
        {
            try
            {
                bool success = false;
                string mensaje = "";
                while (await reader.ReadAsync())
                {
                    success = Convert.ToBoolean(reader["Exito"]);
                    mensaje = reader["Mensaje"].ToString() + " " + reader["ErrorDetalle"].ToString();
                    if (!success)
                    {
                        throw new SystemException(mensaje);
                    }

                }

                return success;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        static async Task<bool> ReadFormularioWeb(DbDataReader reader)
        {
            try
            {
                bool success = false;
                string mensaje = "";
                while (await reader.ReadAsync())
                {
                    success = Convert.ToBoolean(reader["Exito"]);
                    if (!success)
                    {
                        mensaje = reader["Mensaje"].ToString();
                        throw new SystemException(mensaje);
                    }
                }

                return success;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        static async Task<int> ReadObtenerPendientesActuales(DbDataReader reader)
        {
            try
            {
                int total = 0;
                while (await reader.ReadAsync())
                {
                    total = Convert.ToInt32(reader["Total"]);
                }

                return total;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        static async Task<List<PreferenteHistoriaDTO>> ReadObtenerHistoria(DbDataReader reader)
        {
            try
            {
                List<PreferenteHistoriaDTO> lista = new List<PreferenteHistoriaDTO>();
                while (await reader.ReadAsync())
                {
                    PreferenteHistoriaDTO obj = new PreferenteHistoriaDTO
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        IdPreferente = Convert.ToInt32(reader["IdPreferente"]),
                        AsignadoA = Convert.ToString(reader["AsignadoA"]),
                        AsignadoPor = Convert.ToString(reader["AsignadoPor"]),
                        FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"])
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

        static async Task<List<PreferenteGrillaDTO>> ReaderBuscar(DbDataReader reader)
        {
            try
            {

                List<PreferenteObservacionDTO> observaciones = new List<PreferenteObservacionDTO>();

                List<PreferenteGrillaDTO> lista = new List<PreferenteGrillaDTO>();
                while (await reader.ReadAsync())
                {
                    PreferenteGrillaDTO obj = new PreferenteGrillaDTO
                    {
                        Id = reader.GetFieldValue<int>(0),
                        X = "",
                        Nombres = reader["Nombres"].ToString(),
                        Teleoperadora = reader["Teleoperador"].ToString(),
                        NombreTeleoperador = reader["NombreTeleoperador"].ToString(),

                        FechaRegistra = Convert.ToDateTime(reader["FechaRegistra"]),
                        FechaAsignacion = reader["FechaAsignacion"] != DBNull.Value ? Convert.ToDateTime(reader["FechaAsignacion"]).ToString("dd-MM-yyyy hh:mm:ss tt") : null,
                        Celular = reader["Celular"].ToString(),
                        Email = reader["Email"].ToString(),
                        Distrito = reader["Distrito"].ToString(),
                        ZonaCorporal = reader["ZonaCorporal"].ToString(),
                        MedioContacto = Convert.ToString(reader["MedioContacto"]),
                        IdEstado = Convert.ToInt32(reader["IdEstado"]),
                        EstadoAtencion = Convert.ToString(reader["EstadoAtencion"]),
                        EsCliente = Convert.ToInt32(reader["EsCliente"]),
                        IdCliente = Convert.ToInt32(reader["IdCliente"]),
                        //Observacion = new List<string>(JsonSerializer.Deserialize<List<string>>(Convert.ToString(reader["Observacion"]))),

                        Observacion = new List<string>(),

                        UsuFacebook = reader["UsuFacebook"] != DBNull.Value ? Convert.ToString(reader["UsuFacebook"]) : null,
                        UsuInstagram = reader["UsuInstagram"] != DBNull.Value ? Convert.ToString(reader["UsuInstagram"]) : null,


                        UtmSource = reader["UtmSource"] != DBNull.Value ? Convert.ToString(reader["UtmSource"]) : null,
                        UtmMedium = reader["UtmMedium"] != DBNull.Value ? Convert.ToString(reader["UtmMedium"]) : null,
                        UtmCampaign = reader["UtmCampaign"] != DBNull.Value ? Convert.ToString(reader["UtmCampaign"]) : null,
                        UtmId = reader["UtmId"] != DBNull.Value ? Convert.ToString(reader["UtmId"]) : null,
                        UtmTerm = reader["UtmTerm"] != DBNull.Value ? Convert.ToString(reader["UtmTerm"]) : null,

                        Comentario = DBNull.Value == reader["Comentario"] ? null : Convert.ToString(reader["Comentario"]),
                        UsuarioRegistro = DBNull.Value == reader["UsuarioRegistro"] ? null : Convert.ToString(reader["UsuarioRegistro"]),

                        //AtencionCategoria = DBNull.Value == reader["AtencionCategoria"] ? null : Convert.ToString(reader["AtencionCategoria"]),
                        //AtencionOpcion = DBNull.Value == reader["AtencionOpcion"] ? null : Convert.ToString(reader["AtencionOpcion"])

                    };
                    lista.Add(obj);
                }


                if (reader.NextResult())
                {
                    while (await reader.ReadAsync())
                    {
                        observaciones.Add(
                            new PreferenteObservacionDTO()
                            {
                                IdPreferente = Convert.ToInt32(reader["IdPreferente"]),
                                Observacion = Convert.ToString(reader["Observacion"]),
                            }
                        );
                    }

                    foreach (var observacion in observaciones)
                    {
                        lista.Find(p => p.Id == observacion.IdPreferente).Observacion.Add(observacion.Observacion);
                    }


                }


                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<PreferenteVentasDTO>> ObtenerPreferentesVentas(int IdUsuario, DateTime? FechaDesde, DateTime? FechaHasta)
        {
            try
            {

                using (SqlConnection conn = GetConnection())
                {
                    await conn.OpenAsync();

                    using (SqlCommand cmd = new SqlCommand("sp_exportar_preferenteventas", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 30000;

                        cmd.Parameters.AddWithValue("@vi_idusuario", IdUsuario);
                        cmd.Parameters.AddWithValue("@dt_fechINI", (object)FechaDesde ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@dt_fechFIN", (object)FechaHasta ?? DBNull.Value);

                        var viParamOutput = new SqlParameter("@vi_param", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        var vvParamOutput = new SqlParameter("@vv_param", SqlDbType.VarChar, 100)
                        {
                            Direction = ParameterDirection.Output
                        };

                        cmd.Parameters.Add(viParamOutput);
                        cmd.Parameters.Add(vvParamOutput);


                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            var result = new List<PreferenteVentasDTO>();
                            while (await reader.ReadAsync())
                            {
                                result.Add(new PreferenteVentasDTO
                                {
                                    Preferente = reader["PREFERENTE"].ToString(),
                                    Estado = reader["ESTADO"].ToString(),
                                    Cliente = reader["CLIENTE"].ToString(),
                                    Atencion = reader["ATENCION"].ToString(),
                                    Venta = reader["VENTA"].ToString(),
                                    Celular = reader["CELULAR"].ToString(),
                                    Zona = reader["ZONA"].ToString(),
                                    Teleoperadora = reader["TELEOPERADORA"].ToString(),
                                    Correo = reader["CORREO"].ToString(),
                                    Contacto = reader["CONTACTO"].ToString(),
                                    Distrito = reader["DISTRITO"].ToString(),
                                    Observacion = reader["OBSERVACION"].ToString(),
                                    Comentario = reader["COMENTARIO"].ToString(),
                                    UsuFacebook = reader["USU_FACEBOOK"].ToString(),
                                    UsuInstagram = reader["USU_INSTAGRAM"].ToString(),
                                    UtmFuente = reader["UTM_FUENTE"].ToString(),
                                    UtmMedio = reader["UTM_MEDIO"].ToString(),
                                    UtmCampaña = reader["UTM_CAMPAÑA"].ToString(),
                                    UtmId = reader["UTM_ID"].ToString(),
                                    UtmTerm = reader["UTM_TERM"].ToString(),
                                    UtmCont = reader["UTM_CONT"].ToString(),
                                    FechaIngreso = reader["FEC_INGR"].ToString(),
                                    HoraIngreso = reader["HORA_INGR"].ToString(),
                                    UReg = reader["U_REG"].ToString(),
                                    FechaAsignacion = reader["FEC_ASIG"].ToString(),
                                    FechaAgendado = reader["FEC_AGENDO"].ToString(),
                                    Mes = reader["MES"].ToString(),
                                    Ejecutivo = reader["EJECUTIVO"].ToString(),
                                    Supervisor = reader["SUPERVISOR"].ToString(),
                                    Citas = reader["CITAS"].ToString()
                                });
                            }
                            conn.Close();
                            return result;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Considera registrar el error para depuración.
                throw new ApplicationException("Error al obtener los datos de preferentes de ventas.", ex);
            }
        }
    }
}

