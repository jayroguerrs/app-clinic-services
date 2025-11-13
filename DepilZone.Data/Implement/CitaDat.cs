using DepilZone.Data.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using DepilZone.Entidad.DTO.C360;
using DepilZone.Entidad.DTO.Facturacion;
using DepilZone.Entidad.Exceptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Reflection.PortableExecutable;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


namespace DepilZone.Data.Implement
{
    public class CitaDat : ICitaDat
    {
        private readonly string _connectionString;

        public CitaDat(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
        public async Task<IEnumerable<CitaDetalleZonaDTO>> ObtenerDetalleCitaPrecio(int idCita)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("sp_cita_obtenerdetalleprecio", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("idCita", idCita);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItemsZonaCita(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        public async Task<IEnumerable<CitaDTO>> Obtener(DateTime fechaCita, string horaInicio, string horaTermino, int idSede, int idEstado, string pacienteCelular, int tipoCita, int idServicio, int idZonaContiene, int nacio)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Cita_Obtener", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                if (pacienteCelular == "null") { pacienteCelular = null;  }
                if (horaInicio == "null") { horaInicio = null;  }
                if (horaTermino == "null") { horaTermino = null; }
                cmd.Parameters.AddWithValue("pFechaCita", fechaCita);
                if (horaInicio != null)
                    cmd.Parameters.AddWithValue("pHoraInicio", horaInicio);
                else
                    cmd.Parameters.AddWithValue("pHoraInicio", DBNull.Value);
                if (horaTermino != null)
                    cmd.Parameters.AddWithValue("pHoraTermino", horaTermino);
                else
                    cmd.Parameters.AddWithValue("pHoraTermino", DBNull.Value);
                if (pacienteCelular != null)
                    cmd.Parameters.AddWithValue("pPacienteCelular", pacienteCelular);
                else
                    cmd.Parameters.AddWithValue("pPacienteCelular", DBNull.Value);
                cmd.Parameters.AddWithValue("pIdSede", idSede);
                cmd.Parameters.AddWithValue("pIdEstado", idEstado);
                cmd.Parameters.AddWithValue("pIdTipoCita", tipoCita);
                cmd.Parameters.AddWithValue("pIdServicio", idServicio);
                cmd.Parameters.AddWithValue("pIdZona", idZonaContiene);
                cmd.Parameters.AddWithValue("pNacio", nacio);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItems(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        public async Task<List<CitaExportarDTO>> ObtenerExportar(DateTime fechaCita, string horaInicio, string horaTermino, int idSede, int idEstado, string pacienteCelular, int tipoCita)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Cita_ObtenerExportar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                if (pacienteCelular == "null") { pacienteCelular = null; }
                if (horaInicio == "null") { horaInicio = null; }
                if (horaTermino == "null") { horaTermino = null; }
                cmd.Parameters.AddWithValue("pFechaCita", fechaCita);
                cmd.Parameters.AddWithValue("pHoraInicio", horaInicio);
                cmd.Parameters.AddWithValue("pHoraTermino", horaTermino);
                cmd.Parameters.AddWithValue("pIdSede", idSede);
                cmd.Parameters.AddWithValue("pIdEstado", idEstado);
                cmd.Parameters.AddWithValue("pPacienteCelular", pacienteCelular);
                cmd.Parameters.AddWithValue("pIdTipoCita", tipoCita);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItemsExportar(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        public async Task<CitaDatosPreliminaresDTO> ObtenerDatosPreliminares()
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Cita_ObtenerDatosPreliminares", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadDatosPreliminares(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
            
        }

        public async Task<DashBoardDTO> ObtenerDashBoard(string fecha, int idSede, int idPerfil)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Cita_Dashboard", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pFecha", fecha);
                cmd.Parameters.AddWithValue("pIdSede", idSede);
                cmd.Parameters.AddWithValue("pIdPerfil", idPerfil);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItemsDashBoard(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        public async Task<IEnumerable<CitaDTO>> Obtenercitaid(int idCita)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Cita_ObtenerById2", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdCita", idCita);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItemsObtenercitaid(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        public async Task<IEnumerable<CitaDTO>> ObtenerParaPerfil(int idCliente)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Cita_ObtenerParaPerfil", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdCliente", idCliente);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItemsParaPerfil(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        public async Task<IEnumerable<CitaDTO>> ObtenerParaPerfilPorServicio(int idCliente, int idServicio)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Cita_ObtenerParaPerfilPorServicio", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdCliente", idCliente);
                cmd.Parameters.AddWithValue("pIdServicio", idServicio);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItemsParaPerfil(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        public async Task<CitaDTO> ObtenerById(int idCita, bool esReprogramacion)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Cita_ObtenerById", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdCita", idCita);
                cmd.Parameters.AddWithValue("pEsReprogramacion", esReprogramacion);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItemById(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        public async Task<Respuesta<CitaEnt>> Insertar(CitaEnt model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Cita_Insertar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdTipoCita", model.IdTipoCita);
                cmd.Parameters.AddWithValue("pIdCliente", model.IdCliente);
                cmd.Parameters.AddWithValue("pIdTipoCliente", model.IdTipoCliente);
                cmd.Parameters.AddWithValue("pIdMedioContacto", model.IdMedioContacto);
                cmd.Parameters.AddWithValue("pIdUsuario", model.IdUsuario);
                cmd.Parameters.AddWithValue("pIdMaquina", model.IdMaquina);
                cmd.Parameters.AddWithValue("pIdSede", model.IdSede);
                cmd.Parameters.AddWithValue("pIdEstado", model.IdEstado);
                cmd.Parameters.AddWithValue("pIdDescuento", model.IdDescuento);
                cmd.Parameters.AddWithValue("pDescuentoAplicaA", model.DescuentoAplicaA);
                cmd.Parameters.AddWithValue("pCuponDescuento", model.CuponDescuento);

                cmd.Parameters.AddWithValue("pFechaCita", model.FechaCita);
                cmd.Parameters.AddWithValue("pHoraInicio", model.HoraInicio);
                cmd.Parameters.AddWithValue("pHoraTermino", model.HoraTermino);
                cmd.Parameters.AddWithValue("pTotal", model.Total);
                cmd.Parameters.AddWithValue("pUsuarioRegistra", model.UsuarioRegistra);


                foreach (var detalle in model.Detalles)
                {
                    if (detalle.Estado == 9)
                    {
                        detalle.Estado = 1;
                    }
                    if (detalle.Duplicado == 9)
                    {
                        detalle.Duplicado = 1;
                    }
                    if (detalle.TratamientoRealizado == null)
                    {
                        detalle.TratamientoRealizado = 0;
                    }
                    if (detalle.SesionFinal != null)
                    {
                        await ModificarSesionFinal(detalle.IdZona, model.IdServicio, model.IdCliente, detalle.SesionFinal);
                    }
                }

                cmd.Parameters.AddWithValue("pDetalles", JsonSerializer.Serialize(model.Detalles));
                cmd.Parameters.AddWithValue("pCitaMensajeAvisos", JsonSerializer.Serialize(model.CitaMensajeAvisos));
                cmd.Parameters.AddWithValue("pCitaMensajeNotas", JsonSerializer.Serialize(model.CitaMensajeNotas));
                cmd.Parameters.AddWithValue("pCitaMensajeDetalles", JsonSerializer.Serialize(model.CitaMensajeDetalles));
                cmd.Parameters.AddWithValue("pIdServicio", model.IdServicio);
                cmd.Parameters.AddWithValue("pIdPreferente", model.IdPreferente);

                cmd.Parameters.AddWithValue("pTipoDePago", model.TipoDePago);
                cmd.Parameters.AddWithValue("pPrecioDePagoFinal", model.PrecioDePagoFinal);

                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItemInsertar(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        public async Task<Respuesta<CitaEnt>> Modificar(CitaEnt model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Cita_Modificar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdCita", model.IdCita);
                cmd.Parameters.AddWithValue("pIdTipoCita", model.IdTipoCita);
                cmd.Parameters.AddWithValue("pIdCliente", model.IdCliente);
                cmd.Parameters.AddWithValue("pIdTipoCliente", model.IdTipoCliente);
                cmd.Parameters.AddWithValue("pIdMedioContacto", model.IdMedioContacto);
                cmd.Parameters.AddWithValue("pIdUsuario", model.IdUsuario);
                cmd.Parameters.AddWithValue("pIdMaquina", model.IdMaquina);
                cmd.Parameters.AddWithValue("pIdSede", model.IdSede);
                cmd.Parameters.AddWithValue("pIdEstado", model.IdEstado);
                cmd.Parameters.AddWithValue("pIdDescuento", model.IdDescuento);
                cmd.Parameters.AddWithValue("pDescuentoAplicaA", model.DescuentoAplicaA);
                cmd.Parameters.AddWithValue("pCuponDescuento", model.CuponDescuento);

                cmd.Parameters.AddWithValue("pFechaCita", model.FechaCita);
                cmd.Parameters.AddWithValue("pHoraInicio", model.HoraInicio);
                cmd.Parameters.AddWithValue("pHoraTermino", model.HoraTermino);
                cmd.Parameters.AddWithValue("pTotal", model.Total);
                cmd.Parameters.AddWithValue("pUsuarioEdita", model.UsuarioRegistra);

                foreach (var detalle in model.Detalles)
                {
                    if (detalle.Estado == 9)
                    {
                        detalle.Estado = 1;
                    }
                    if(detalle.Duplicado == 9)
                    {
                        detalle.Duplicado = 1;
                    }
                    if (detalle.TratamientoRealizado == null)
                    {
                        detalle.TratamientoRealizado = 0;
                    }
                    if (detalle.SesionFinal != null)
                    {
                        await ModificarSesionFinal(detalle.IdZona, model.IdServicio, model.IdCliente, detalle.SesionFinal);
                    }
                }

                cmd.Parameters.AddWithValue("pDetalles", JsonSerializer.Serialize(model.Detalles));
                cmd.Parameters.AddWithValue("pCitaMensajeAvisos", JsonSerializer.Serialize(model.CitaMensajeAvisos));
                cmd.Parameters.AddWithValue("pCitaMensajeNotas", JsonSerializer.Serialize(model.CitaMensajeNotas));
                cmd.Parameters.AddWithValue("pCitaMensajeDetalles", JsonSerializer.Serialize(model.CitaMensajeDetalles));
                cmd.Parameters.AddWithValue("pIdServicio", model.IdServicio);

                cmd.Parameters.AddWithValue("pTipoDePago", model.TipoDePago);
                cmd.Parameters.AddWithValue("pPrecioDePagoFinal", model.PrecioDePagoFinal);

                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItemInsertar(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }


        public async Task ModificarSesionFinal(int idZona, int? idServicio, int idCliente, int? SesionFinal)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Actualizar_Sesion_Final", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("SesioFinal", SesionFinal);
                cmd.Parameters.AddWithValue("IdCliente", idCliente);
                cmd.Parameters.AddWithValue("IdServicio", idServicio);
                cmd.Parameters.AddWithValue("IdZona", idZona);

                var reader = await cmd.ExecuteReaderAsync();

                conn.Close();
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }


        public async Task<Respuesta<CitaDTO>> ActualizarCondicionAnular(CitaDTO model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Cita_Update_Anular", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdCita", model.IdCita);
                cmd.Parameters.AddWithValue("pIdEstado", model.IdEstado);
                cmd.Parameters.AddWithValue("pIdCliente", model.IdCliente);
                cmd.Parameters.AddWithValue("pCitaMensajeAvisos", JsonSerializer.Serialize(model.CitaMensajeAvisos));
                cmd.Parameters.AddWithValue("pCitaMensajeNotas", JsonSerializer.Serialize(model.CitaMensajeNotas));
                cmd.Parameters.AddWithValue("pCitaMensajeDetalles", JsonSerializer.Serialize(model.CitaMensajeDetalles));
                cmd.Parameters.AddWithValue("pIdUsuario", model.IdUsuario);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItemsCondicion(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        public async Task<Respuesta<CitaDTO>> ActualizarCondicionCancelar(CitaDTO model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Cita_Update_Cancelar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdCita", model.IdCita);
                cmd.Parameters.AddWithValue("pIdEstado", model.IdEstado);
                cmd.Parameters.AddWithValue("pIdCliente", model.IdCliente);
                cmd.Parameters.AddWithValue("pCitaMensajeAvisos", JsonSerializer.Serialize(model.CitaMensajeAvisos));
                cmd.Parameters.AddWithValue("pCitaMensajeNotas", JsonSerializer.Serialize(model.CitaMensajeNotas));
                cmd.Parameters.AddWithValue("pCitaMensajeDetalles", JsonSerializer.Serialize(model.CitaMensajeDetalles));
                cmd.Parameters.AddWithValue("pIdUsuario", model.IdUsuario);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItemsCondicion(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        public async Task<Respuesta<CitaDTO>> ActualizarCondicionNollamar(CitaDTO model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Cita_Update_Nollamar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdCita", model.IdCita);
                cmd.Parameters.AddWithValue("pIdEstado", model.IdEstado);
                cmd.Parameters.AddWithValue("pIdCliente", model.IdCliente);
                cmd.Parameters.AddWithValue("pCitaMensajeAvisos", JsonSerializer.Serialize(model.CitaMensajeAvisos));
                cmd.Parameters.AddWithValue("pCitaMensajeNotas", JsonSerializer.Serialize(model.CitaMensajeNotas));
                cmd.Parameters.AddWithValue("pCitaMensajeDetalles", JsonSerializer.Serialize(model.CitaMensajeDetalles));
                cmd.Parameters.AddWithValue("pIdUsuario", model.IdUsuario);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItemsCondicion(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        public async Task<GeneralResponse<bool>> ActualizarTratamientoRealizado(int estado, int idCitaDetalle)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_TratamientoRealizado", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("EstadoDetalle", estado);
                cmd.Parameters.AddWithValue("IdCitaDetalle", idCitaDetalle);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await TratamientoRealizado(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        public async Task<Respuesta<CitaDTO>> ActualizarCondicionConfirmar(CitaDTO model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Cita_Update_Confirmar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdCita", model.IdCita);
                cmd.Parameters.AddWithValue("pIdEstado", model.IdEstado);
                cmd.Parameters.AddWithValue("pIdCliente", model.IdCliente);
                cmd.Parameters.AddWithValue("pCitaMensajeAvisos", JsonSerializer.Serialize(model.CitaMensajeAvisos));
                cmd.Parameters.AddWithValue("pCitaMensajeNotas", JsonSerializer.Serialize(model.CitaMensajeNotas));
                cmd.Parameters.AddWithValue("pCitaMensajeDetalles", JsonSerializer.Serialize(model.CitaMensajeDetalles));
                cmd.Parameters.AddWithValue("pIdUsuario", model.IdUsuario);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItemsCondicion(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        public async Task<Respuesta<CitaDTO>> ActualizarCondicionConfirmarAsistencia(CitaDTO model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Cita_Update_ConfirmarAsistencia", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdCita", model.IdCita);
                cmd.Parameters.AddWithValue("pIdEstado", model.IdEstado);
                cmd.Parameters.AddWithValue("pIdCliente", model.IdCliente);
                cmd.Parameters.AddWithValue("pCitaMensajeAvisos", JsonSerializer.Serialize(model.CitaMensajeAvisos));
                cmd.Parameters.AddWithValue("pCitaMensajeNotas", JsonSerializer.Serialize(model.CitaMensajeNotas));
                cmd.Parameters.AddWithValue("pCitaMensajeDetalles", JsonSerializer.Serialize(model.CitaMensajeDetalles));
                cmd.Parameters.AddWithValue("pIdUsuario", model.IdUsuario);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItemsCondicion(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        public async Task<Respuesta<CitaDTO>> ActualizarCondicionNoAsistio(CitaDTO model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Cita_Update_NoAsistio", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdCita", model.IdCita);
                cmd.Parameters.AddWithValue("pIdEstado", model.IdEstado);
                cmd.Parameters.AddWithValue("pIdCliente", model.IdCliente);
                cmd.Parameters.AddWithValue("pCitaMensajeAvisos", JsonSerializer.Serialize(model.CitaMensajeAvisos));
                cmd.Parameters.AddWithValue("pCitaMensajeNotas", JsonSerializer.Serialize(model.CitaMensajeNotas));
                cmd.Parameters.AddWithValue("pCitaMensajeDetalles", JsonSerializer.Serialize(model.CitaMensajeDetalles));
                cmd.Parameters.AddWithValue("pIdUsuario", model.IdUsuario);                
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItemsCondicion(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public async Task<Respuesta<CitaDTO>> ActualizarCondicionPendiente(CitaDTO model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Cita_Update_Pendiente", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdCita", model.IdCita);
                cmd.Parameters.AddWithValue("pIdEstado", model.IdEstado);
                cmd.Parameters.AddWithValue("pIdCliente", model.IdCliente);
                cmd.Parameters.AddWithValue("pCitaMensajeAvisos", JsonSerializer.Serialize(model.CitaMensajeAvisos));
                cmd.Parameters.AddWithValue("pCitaMensajeNotas", JsonSerializer.Serialize(model.CitaMensajeNotas));
                cmd.Parameters.AddWithValue("pCitaMensajeDetalles", JsonSerializer.Serialize(model.CitaMensajeDetalles));
                cmd.Parameters.AddWithValue("pIdUsuario", model.IdUsuario);
                cmd.Parameters.AddWithValue("pIdEstadoPendiente", model.IdEstadoPendiente);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItemsCondicion(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }           
        }

        public async Task<int> EstadoAtendido(CitaEnt model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Cita_EstadoAtendido", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdCita", model.IdCita);
                cmd.Parameters.AddWithValue("pIdUsuarioAtendidoPor", model.IdUsuarioAtendidoPor);
                cmd.Parameters.AddWithValue("pNumeroBox", model.NumeroBox);
                cmd.Parameters.AddWithValue("pIdMaquinaMarca", model.IdMaquinaMarca);
                cmd.Parameters.AddWithValue("pIdUsuarioModifico", model.IdUsuario);

                cmd.Parameters.AddWithValue("pDetalles", JsonSerializer.Serialize(model.Detalles));
                var reader = await cmd.ExecuteReaderAsync();

                int output = 0;

                while (await reader.ReadAsync())
                {
                    output = output + 1;
                }

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        public async Task<Respuesta<CitaEnt>> InsertarReservacion(CitaEnt model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Cita_InsertarReservacion", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdCliente", model.IdCliente);
                cmd.Parameters.AddWithValue("pIdUsuario", model.IdUsuario);
                cmd.Parameters.AddWithValue("pIdMaquina", model.IdMaquina);
                cmd.Parameters.AddWithValue("pIdSede", model.IdSede);

                cmd.Parameters.AddWithValue("pFechaCita", model.FechaCita);
                cmd.Parameters.AddWithValue("pHoraInicio", model.HoraInicio);
                cmd.Parameters.AddWithValue("pHoraTermino", model.HoraTermino);

                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItemInsertar(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        public async Task<bool> EliminarReservacion(int idUsuario)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Cita_EliminarReservacion", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdUsuario", idUsuario);

                var output = cmd.ExecuteNonQuery() > 0;

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        public async Task<IEnumerable<CitaComisionResumenDTO>> ObtenerComisionesResumen(DateTime fechaInicio, DateTime fechaTermino, int idUsuarioOperador)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Cita_ObtenerComisionesResumen", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pFechaInicio", fechaInicio);
                cmd.Parameters.AddWithValue("pFechaTermino", fechaTermino);
                cmd.Parameters.AddWithValue("pIdUsuarioOperador", idUsuarioOperador);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItemComisionResumen(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        public async Task<IEnumerable<CitaComisionDetalleDTO>> ObtenerComisionesDetalle(DateTime fechaInicio, DateTime fechaTermino, int idUsuarioOperador)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Cita_ObtenerComisionesDetalle", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pFechaInicio", fechaInicio);
                cmd.Parameters.AddWithValue("pFechaTermino", fechaTermino);
                cmd.Parameters.AddWithValue("pIdUsuarioOperador", idUsuarioOperador);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItemComisionDetalle(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
       

        public async Task<IEnumerable<CitaMensajeNotaDTO>> ObtenerNotasEnCitaNueva(int idCliente)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Cita_ObtenerNotasCitaNueva", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdCliente", idCliente);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItemNotaCitaNueva(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }



        public async Task<List<CitaTotalDTO>> ObtenerAgendadas(DateTime fechaInicio, DateTime fechaFin, int idSede, int idGenero)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Cita_ListarAgendadas", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pFechaInicio", fechaInicio);
                cmd.Parameters.AddWithValue("pFechaFin", fechaFin);
                cmd.Parameters.AddWithValue("pIdSede", idSede);
                cmd.Parameters.AddWithValue("pIdGenero", idGenero);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItemsTotales(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        public async Task<List<CitaTotalDTO>> ObtenerAtendidas(DateTime fechaInicio, DateTime fechaFin, int idSede, int idGenero)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Cita_ListarAtendidas", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pFechaInicio", fechaInicio);
                cmd.Parameters.AddWithValue("pFechaFin", fechaFin);
                cmd.Parameters.AddWithValue("pIdSede", idSede);
                cmd.Parameters.AddWithValue("pIdGenero", idGenero);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItemsTotales(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        public async Task<List<HistorialParametroDTO>> ObtenerHistorialParametros(int idCliente, int idServicio, int idZona)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Historial_Parametros", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("IdCliente", idCliente);
                cmd.Parameters.AddWithValue("IdServicio", idServicio);
                cmd.Parameters.AddWithValue("IdZona", idZona);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItemsHistorialParametros(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        public async Task<GeneralResponse<ParametroUpdateDTO>> ActualizarParametro(ParametroUpdateDTO model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_ActualizarParametro", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("Parametro", model.Parametro);
                cmd.Parameters.AddWithValue("IdCitaDetalle", model.IdCitaDetalle);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadUpdateParametro(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        static async Task<GeneralResponse<ParametroUpdateDTO>> ReadUpdateParametro(DbDataReader reader)
        {
            try
            {
                GeneralResponse<ParametroUpdateDTO> generalRes = new GeneralResponse<ParametroUpdateDTO>
                {
                    Data = new ParametroUpdateDTO()
                };


                if (await reader.ReadAsync())
                {
                    generalRes.Message = "Parametro actualizado correctamente.";
                    generalRes.Status = 200;

                    generalRes.Data.IdCitaDetalle = Convert.ToInt32(reader["IdCitaDetalle"]);
                    generalRes.Data.Parametro = Convert.ToString(reader["Parametro"]);
                }

                return generalRes;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<CitaTotalDTO>> ObtenerAgendadasCortesia(DateTime fechaInicio, DateTime fechaFin, int idSede, int idGenero)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Cita_ListarAgendadasCortesia", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pFechaInicio", fechaInicio);
                cmd.Parameters.AddWithValue("pFechaFin", fechaFin);
                cmd.Parameters.AddWithValue("pIdSede", idSede);
                cmd.Parameters.AddWithValue("pIdGenero", idGenero);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItemsTotales(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }


        public async Task<List<CitaPromocionDTO>> ObtenerPorPromocion(DateTime fechaInicio, DateTime fechaFin, int idSede)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Cita_ListarPorPromocion", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pFechaInicio", fechaInicio);
                cmd.Parameters.AddWithValue("pFechaFin", fechaFin);
                cmd.Parameters.AddWithValue("pIdSede", idSede);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItemsPromociones(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }



        public async Task<List<CitaReporteDTO>> ObtenerReporte(DateTime fechaInicio, DateTime fechaFin, int idSede, int idEstado, int idServicio, int idTipoCita, int idZona, int? nuevoCliente)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Cita_ObtenerReporte", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure,
                    CommandTimeout = 180
                };
                cmd.Parameters.AddWithValue("pFechaInicio", fechaInicio);
                cmd.Parameters.AddWithValue("pFechaFin", fechaFin);
                cmd.Parameters.AddWithValue("pIdSede", idSede);
                cmd.Parameters.AddWithValue("pIdEstado", idEstado);
                cmd.Parameters.AddWithValue("pIdServicio", idServicio);
                cmd.Parameters.AddWithValue("pIdTipoCita", idTipoCita);
                cmd.Parameters.AddWithValue("pIdZona", idZona);

                cmd.Parameters.AddWithValue("pClienteNuevo", nuevoCliente);

                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadObtenerReporte(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }


        public async Task<List<CitaReporteDetalladoDTO>> ObtenerReporteDetallado(DateTime fechaInicio, DateTime fechaFin, int idSede, int idEstado, int idServicio, int idTipoCita, int idZona)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Cita_ObtenerReporteDetallado", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure,
                    CommandTimeout = 180
                };
                cmd.Parameters.AddWithValue("pFechaInicio", fechaInicio);
                cmd.Parameters.AddWithValue("pFechaFin", fechaFin);
                cmd.Parameters.AddWithValue("pIdSede", idSede);
                cmd.Parameters.AddWithValue("pIdEstado", idEstado);
                cmd.Parameters.AddWithValue("pIdServicio", idServicio);
                cmd.Parameters.AddWithValue("pIdTipoCita", idTipoCita);
                cmd.Parameters.AddWithValue("pIdZona", idZona);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadObtenerReporteDetallado(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }



        public async Task<bool> EnvioMasivoHistoria(CitaHistoriaMasivaDTO model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Cita_EnvioMasivoHistoria", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdUsuarioRegistro", model.IdUsuarioRegistro);
                cmd.Parameters.AddWithValue("pRegistros", JsonSerializer.Serialize(model.Registros));
                cmd.Parameters.AddWithValue("pNumeroRegistros", model.NumeroRegistros);
                cmd.Parameters.AddWithValue("pNombreArchivo", model.NombreArchivo);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadEnvioMasivoHistoria(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }


        public async Task<int> AgendarSiguienteCita(SiguienteCitaDTO model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Cita_SiguienteCita", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdCita", model.IdCita);
                cmd.Parameters.Add("pNumeroMeses", SqlDbType.Float).Value = model.NumeroMeses; // Asegurar que es Float
                cmd.Parameters.AddWithValue("pIdUsuario", model.IdUsuarioRegistro);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadAgendarSiguienteCita(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }


        public async Task<int> AgendarSiguienteCitaManual(SiguienteCitaDTO model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Cita_SiguienteCitaManual", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdTipo", model.IdTipo);
                cmd.Parameters.AddWithValue("pFecha", model.Fecha);
                cmd.Parameters.AddWithValue("pIdCita", model.IdCita);
                cmd.Parameters.AddWithValue("pNumeroMeses", model.NumeroMeses);
                cmd.Parameters.AddWithValue("pIdUsuario", model.IdUsuarioRegistro);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadAgendarSiguienteCitaManual(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        public async Task<CitaTacoDTO> ObtenerTaco(int IdCita, int IdUsuario)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Cita_ObtenerTacoByCita", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("IdCita", IdCita);
                cmd.Parameters.AddWithValue("IdUsuario", IdUsuario);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadObtenerTaco(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        public async Task<bool> MarcarAtendido(int IdCita, int IdUsuario)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Cita_MarcarAtendida", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("IdCita", IdCita);
                cmd.Parameters.AddWithValue("IdUsuario", IdUsuario);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadMarcarAtendido(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }


        public async Task<List<int>> ObtenerCitaAtendidasHoy()
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Cita_ObtenerCitaAtendidasHoy", conn)
                {
                CommandType = System.Data.CommandType.StoredProcedure
                };
                //cmd.Parameters.AddWithValue("Fecha", fechaHoy);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadObtenerCitaAtendidasHoy(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }


        public async Task<bool> SiguienteCitaAtendidasHoy(int IdCita)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Cita_SiguienteCitaById", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdCita", IdCita);
                var reader = await cmd.ExecuteReaderAsync();
                bool output = false;

                while (await reader.ReadAsync())
                {
                    output = Convert.ToBoolean(reader["Exito"]);
                }

                conn.Close();

                return output;

            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        public async Task<bool> AgregarDetalle(int idCita, CitaNuevoDetalle model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Cita_AgregarDetalle", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdCita", idCita);
                cmd.Parameters.AddWithValue("pIdSede", model.IdSede);
                cmd.Parameters.AddWithValue("pIdServicio", model.IdServicio);
                cmd.Parameters.AddWithValue("pIdZona", model.IdZona);
                cmd.Parameters.AddWithValue("pIdTecnologia", model.IdTecnologia);
                cmd.Parameters.AddWithValue("pIdPromocionPrecio", model.IdPromocionPrecio);
                cmd.Parameters.AddWithValue("pSesion", model.Sesion);
                cmd.Parameters.AddWithValue("pPrecio", model.Precio);
                cmd.Parameters.AddWithValue("pDuracion", model.Duracion);
                cmd.Parameters.AddWithValue("pIdAgendadoPor", model.IdAgendadoPor);
                cmd.Parameters.AddWithValue("pIdOrigenMedio", model.IdOrigenMedio);
                cmd.Parameters.AddWithValue("pRetroceso", model.Retroceso);
                cmd.Parameters.AddWithValue("pPagoWeb", model.PagoWeb);
                cmd.Parameters.AddWithValue("pIdUsuarioModifico", model.IdUsuarioModifico);
                var reader = await cmd.ExecuteReaderAsync();
  
                bool exito = false;
                string mensaje = "";
                string detalle = "";
                int codigoError = 0;

                while (await reader.ReadAsync())
                {
                    exito = Convert.ToBoolean(reader["Exito"]);
                    if (!exito) {
                        mensaje = Convert.ToString(reader["Mensaje"]);
                        codigoError = Convert.ToInt32(reader["ErrorNumero"]);
                        detalle = Convert.ToString(reader["ErrorDetalle"]);
                        throw new AlertException(mensaje);
                    }
                }


                conn.Close();

                return exito;

            }
            catch (Exception EX)
            {
                throw EX;
            }
        }



       
        public async Task<List<CitaSinSiguienteCitaDTO>> ObtenerCitasAtendidasSinSiguienteCita(DateTime fechaDesde, DateTime fechaHasta, int idServicio, int idUsuario)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Cita_ObtenerSinSiguienteCita", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pFechaDesde", fechaDesde);
                cmd.Parameters.AddWithValue("pFechaHasta", fechaHasta);
                cmd.Parameters.AddWithValue("pIdServicio", idServicio);
                cmd.Parameters.AddWithValue("pIdUsuario", idUsuario);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadObtenerCitasAtendidasSinSiguienteCita(reader);

                conn.Close();

                return output;

            }
            catch (Exception EX)
            {
                throw EX;
            }
        }





        public async Task<List<CitaReporteAgendadoOperador>> ObtenerReporteAgendado(DateTime fechaInicio, DateTime fechaFin, int idSede, int idServicio, int idTipoCliente, int idEstado, int idUsuarioAgendo)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Cita_ObtenerReporteAgendadoOperador", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure,
                    CommandTimeout = 30
                };
                cmd.Parameters.AddWithValue("pFechaInicio", fechaInicio);
                cmd.Parameters.AddWithValue("pFechaFin", fechaFin);
                cmd.Parameters.AddWithValue("pIdSede", idSede);
                cmd.Parameters.AddWithValue("pIdServicio", idServicio);
                cmd.Parameters.AddWithValue("pTipoCliente", idTipoCliente);
                cmd.Parameters.AddWithValue("pIdEstado", idEstado);
                cmd.Parameters.AddWithValue("pIdUsuarioAgendo", idUsuarioAgendo);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadObtenerObtenerReporteAgendado(reader);

                conn.Close();

                return output;

            }
            catch (Exception EX)
            {
                throw EX;
            }
        }


        public async Task<CitaDatosDTO> ObtenerDatos(int idCita, int idUsuario)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Cita_ObtenerDatosById", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure,
                    CommandTimeout = 30
                };
                cmd.Parameters.AddWithValue("pIdCita", idCita);
                cmd.Parameters.AddWithValue("pIdUsuario", idUsuario);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadObtenerDatos(reader);

                conn.Close();

                return output;

            }
            catch (Exception EX)
            {
                throw EX;
            }
        }




        public async Task<bool> ModificarMaquina(int IdCita, CitaModificaMaquinaDTO model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Cita_ModificarMaquina", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure,
                    CommandTimeout = 30
                };
                cmd.Parameters.AddWithValue("pIdCita", IdCita);
                cmd.Parameters.AddWithValue("pIdMaquina", model.IdMaquina);
                cmd.Parameters.AddWithValue("pHoraInicio", model.HoraInicio);
                cmd.Parameters.AddWithValue("pHoraTermino", model.HoraTermino);
                cmd.Parameters.AddWithValue("pIdUsuarioRegistro", model.IdUsuarioRegistro);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadModificarMaquina(reader);

                conn.Close();

                return output;

            }
            catch (Exception EX)
            {
                throw EX;
            }
        }



        public async Task<List<CitaReporteInfoClienteDTO>> ObtenerReporteInfoCliente(DateTime fechaCita, string horaInicio, string horaTermino, int idSede, int idEstado, string pacienteCelular, int tipoCita, int idServicio, int idZonaContiene, int nacio)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Cita_Obtener_ReporteInfoCliente", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                if (pacienteCelular == "null") { pacienteCelular = null; }
                if (horaInicio == "null") { horaInicio = null; }
                if (horaTermino == "null") { horaTermino = null; }
                cmd.Parameters.AddWithValue("pFechaCita", fechaCita);
                cmd.Parameters.AddWithValue("pHoraInicio", horaInicio);
                cmd.Parameters.AddWithValue("pHoraTermino", horaTermino);
                cmd.Parameters.AddWithValue("pIdSede", idSede);
                cmd.Parameters.AddWithValue("pIdEstado", idEstado);
                cmd.Parameters.AddWithValue("pPacienteCelular", pacienteCelular);
                cmd.Parameters.AddWithValue("pIdTipoCita", tipoCita);
                cmd.Parameters.AddWithValue("pIdServicio", idServicio);
                cmd.Parameters.AddWithValue("pIdZona", idZonaContiene);
                cmd.Parameters.AddWithValue("pNacio", nacio);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadObtenerReporteInfoCliente(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }



        public async Task<List<CitaClienteDTO>> ObtenerCitasCliente(int idClienteAsignado)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Cita_ObtenerParaClienteAsignado", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("pIdClienteAsignado", idClienteAsignado);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadObtenerCitasCliente(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }




        //****************************************************************** READERS

        static async Task<List<CitaTotalDTO>> ReadItemsTotales(DbDataReader reader)
        {
            try
            {
                List<CitaTotalDTO> collection = new List<CitaTotalDTO>();
                while (await reader.ReadAsync())
                {
                    var obj = new CitaTotalDTO();
                    obj.IdSede = Convert.ToInt32(reader["IdSede"]);
                    obj.Sede = Convert.ToString(reader["Sede"]);
                    obj.FechaCita = Convert.ToDateTime(reader["FechaCita"]);
                    obj.NumCitas = Convert.ToInt32(reader["NumCitas"]);
                    collection.Add(obj);
                }

                return collection;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        static async Task<List<HistorialParametroDTO>> ReadItemsHistorialParametros(DbDataReader reader)
        {
            try
            {
                List<HistorialParametroDTO> collection = new List<HistorialParametroDTO>();
                while (await reader.ReadAsync())
                {
                    var obj = new HistorialParametroDTO();
                    obj.Sesion = Convert.ToInt32(reader["Sesion"]);
                    obj.Parametro = Convert.ToString(reader["Parametros"]);
                    obj.Maquina = Convert.ToString(reader["Maquina"]);
                    collection.Add(obj);
                }

                return collection;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        
        static async Task<List<CitaPromocionDTO>> ReadItemsPromociones(DbDataReader reader)
        {
            try
            {
                List<CitaPromocionDTO> collection = new List<CitaPromocionDTO>();
                while (await reader.ReadAsync())
                {
                    var obj = new CitaPromocionDTO();
                    obj.IdCita = Convert.ToInt32(reader["IdCita"]);
                    obj.IdSede = Convert.ToInt32(reader["IdSede"]);
                    obj.Sede = reader["Sede"].ToString();
                    obj.NumeroCita = Convert.ToInt32(reader["NumeroCita"]);
                    obj.Cliente = reader["Cliente"].ToString();
                    obj.FechaCita = Convert.ToDateTime(reader["FechaCita"]);
                    obj.HoraCita = reader["HoraCita"].ToString();
                    obj.Zona = reader["Zona"].ToString();
                    obj.IdZona = Convert.ToInt32(reader["IdZona"]);
                    obj.Sesion = Convert.ToInt32(reader["Sesion"]);
                    obj.IdPromocion = Convert.ToInt32(reader["IdPromocion"]);
                    obj.Promocion = reader["Promocion"].ToString();
                    obj.PromoFechaIni = Convert.ToDateTime(reader["PromoFechaIni"]);
                    obj.PromoFechaFin = Convert.ToDateTime(reader["PromoFechaFin"]);
                    obj.PrecioZona = Convert.ToDecimal(reader["PrecioZona"]);
                    obj.TotalCita = Convert.ToDecimal(reader["TotalCita"]);
                    obj.Estado = reader["Estado"].ToString();
                    collection.Add(obj);
                }

                return collection;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        static async Task<IEnumerable<CitaMensajeNotaDTO>> ReadItemNotaCitaNueva(DbDataReader reader)
        {
            try
            {
                IList<CitaMensajeNotaDTO> lista = new List<CitaMensajeNotaDTO>();
                while (await reader.ReadAsync())
                {
                    CitaMensajeNotaDTO obj = new CitaMensajeNotaDTO
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        IdCita = Convert.ToInt32(reader["IdCita"]),
                        IdCliente = Convert.ToInt32(reader["IdCliente"]),
                        IdUsuario = Convert.ToInt32(reader["IdUsuario"]),
                        Nota = Convert.ToString(reader["Nota"]),
                        FechaRegistra = Convert.ToDateTime(reader["FechaRegistra"]),
                        InicialesUsuario = Convert.ToString(reader["InicialesUsuario"]),
                        UsuarioRegistra = Convert.ToString(reader["UsuarioRegistra"])
                    };
                    lista.Add(obj);
                }



                return lista;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        static async Task<CitaDatosPreliminaresDTO> ReadDatosPreliminares(DbDataReader reader)
        {
            try
            {
                CitaDatosPreliminaresDTO datosPreliminares = new CitaDatosPreliminaresDTO();

                datosPreliminares.CitaTipos = new List<CitaTipoEnt>();
                while (await reader.ReadAsync())
                {
                    datosPreliminares.CitaTipos.Add(new CitaTipoEnt
                    {
                        IdTipoCita = Convert.ToInt32(reader["IdTipoCita"]),
                        Nombre = reader["Nombre"].ToString(),
                        IdEstado = Convert.ToInt32(reader["IdEstado"])
                    });
                }


                if (reader.NextResult())
                {
                    datosPreliminares.ClienteTipos = new List<TipoClienteEnt>();
                    while (await reader.ReadAsync())
                    {
                        datosPreliminares.ClienteTipos.Add(new TipoClienteEnt
                        {
                            IdTipoCliente = Convert.ToInt32(reader["IdTipoCliente"]),
                            TipoCliente = reader["TipoCliente"].ToString()
                        });
                    }
                }

                //if (reader.NextResult())
                //{
                //    datosPreliminares.Usuarios = new List<UsuarioGridDTO>();
                //    while (await reader.ReadAsync())
                //    {
                //        datosPreliminares.Usuarios.Add(new UsuarioGridDTO
                //        {
                //            IdUsuario = Convert.ToInt32(reader["IdUsuario"]),
                //            Nombre = reader["Nombre"].ToString(),
                //            Usuario = reader["Usuario"].ToString(),
                //            Clave = reader["Clave"].ToString(),
                //            IdPerfil = Convert.ToInt32(reader["IdPerfil"]),
                //            IdEstado = Convert.ToInt32(reader["IdEstado"]),
                //            Perfil = reader["Perfil"].ToString(),
                //            UsuarioRegistra = reader["UsuarioRegistra"].ToString(),
                //            FechaRegistra = Convert.ToDateTime(reader["FechaRegistra"]).ToString("dd-MM-yyyy"),
                //            IdSede = Convert.ToInt32(reader["IdSede"]),
                //            Sede = reader["Sede"].ToString(),
                //            Foto = reader["Foto"].ToString()
                //        });
                //    }
                //}

                if (reader.NextResult())
                {
                    datosPreliminares.Sedes = new List<SedeEnt>();
                    while (await reader.ReadAsync())
                    {
                        SedeEnt sede = new SedeEnt
                        {
                            IdSede = Convert.ToInt32(reader["IdSede"]),
                            IdUbicacion = reader["IdUbicacion"].ToString(),
                            Nombre = reader["Nombre"].ToString(),
                            Estado = Convert.ToInt32(reader["Estado"]),
                            Direccion = reader["Direccion"].ToString(),
                        };
                        sede.Ubicacion.IdUbicacion = reader["IdUbicacion"].ToString();
                        sede.Ubicacion.Departamento = reader["Departamento"].ToString();
                        sede.Ubicacion.Ciudad = reader["Ciudad"].ToString();
                        sede.Ubicacion.Distrito = reader["Distrito"].ToString();
                        sede.HoraInicio = reader["HoraInicio"].ToString();
                        sede.HoraFin = reader["HoraFin"].ToString();

                        datosPreliminares.Sedes.Add(sede);
                    }
                }

                if (reader.NextResult())
                {
                    datosPreliminares.ZonasCorporales = new List<ZonaCorporalGridDTO>();
                    while (await reader.ReadAsync())
                    {
                        datosPreliminares.ZonasCorporales.Add(new ZonaCorporalGridDTO
                        {
                            Id = reader.GetFieldValue<int>(0),
                            Descripcion = reader["Descripcion"].ToString(),
                            Duracion = Convert.ToInt32(reader["Duracion"]),
                            IdEstado = Convert.ToInt32(reader["IdEstado"]),
                            Genero = reader["Genero"].ToString(),
                            Sesion = 1,
                        });
                    }
                }

                if (reader.NextResult())
                {
                    datosPreliminares.MaquinaSedes = new List<MaquinaSedeGridDTO>();
                    while (await reader.ReadAsync())
                    {
                        datosPreliminares.MaquinaSedes.Add(new MaquinaSedeGridDTO
                        {
                            Id = reader.GetFieldValue<int>(0),
                            HoraInicio = reader["HoraInicio"].ToString(),
                            HoraFin = reader["HoraFin"].ToString(),
                            Descripcion = reader["Descripcion"].ToString(),
                            Maquina = reader["Descripcion"].ToString(),
                            Sede = reader["Sede"].ToString(),
                            IdEstado = Convert.ToInt32(reader["IdEstado"]),
                            IdMaquina = Convert.ToInt32(reader["IdMaquina"]),
                            IdSede = Convert.ToInt32(reader["IdSede"])
                        });
                    }
                }



                return datosPreliminares;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        static async Task<Respuesta<CitaEnt>> ReadItemInsertar(DbDataReader reader)
        {
            try
            {
                Respuesta<CitaEnt> obj = new Respuesta<CitaEnt>
                {
                    Response = new CitaEnt()
                };
                while (await reader.ReadAsync())
                {
                    obj.Exito = Convert.ToBoolean(reader["Exito"]);
                    obj.Mensaje = Convert.ToString(reader["Mensaje"]);
                    obj.ErrorNumero = Convert.ToInt32(reader["ErrorNumero"]);
                    obj.ErrorDetalle = reader["ErrorDetalle"].ToString();
                    obj.IdCita = Convert.ToInt32(reader["IdCita"]);
                    obj.IdServicio = Convert.ToInt32(reader["IdServicio"]);
                    obj.IdCronograma = DBNull.Value == reader["IdCronograma"] ? (int?)null : Convert.ToInt32(reader["IdCronograma"]);


                    if (obj.Exito)
                    {
                        obj.Response.IdCita = Convert.ToInt32(reader["IdCita"]);
                        obj.Response.IdCliente = Convert.ToInt32(reader["IdCliente"]);
                        obj.Response.IdUsuario = Convert.ToInt32(reader["IdUsuario"]);
                        obj.Response.FechaCita = Convert.ToDateTime(reader["FechaCita"]);
                        obj.Response.HoraInicio = reader["HoraInicio"].ToString();
                        obj.Response.HoraTermino = reader["HoraTermino"].ToString();
                        obj.Response.IdMaquina = Convert.ToInt32(reader["IdMaquina"].ToString());
                        obj.Response.IdSede = Convert.ToInt32(reader["IdSede"].ToString());
                        obj.Response.IdPreferente = Convert.ToInt32(reader["IdPreferente"]);
                    }
                }



                return obj;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        static async Task<DashBoardDTO> ReadItemsDashBoard(DbDataReader reader)
        {
            try
            {
                DashBoardDTO dashBoard = new DashBoardDTO();

                //Obtener informacion de los dashboard permitidos
                dashBoard.ElementosPermitidos = new List<DashboardElementosPermitidosDTO>();
                while (await reader.ReadAsync())
                {
                    dashBoard.ElementosPermitidos.Add(new DashboardElementosPermitidosDTO()
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Nombre = Convert.ToString(reader["Nombre"])
                    });
                }

                for (int i = 0; i < dashBoard.ElementosPermitidos.Count; i++)
                {
                    int idElemento = dashBoard.ElementosPermitidos[i].Id;
                    if (reader.NextResult())
                        dashBoard = await LeerSiguienteResultado(reader, dashBoard, idElemento);
                }



                return dashBoard;
            }
            catch (Exception EX)
            {
                throw EX;
            }
            
        }
        static async Task<DashBoardDTO> LeerSiguienteResultado(DbDataReader reader, DashBoardDTO dashboard, int IdElemento)
        {
            try
            {
                switch (IdElemento)
                {
                    case 1:
                        //Evolucion de citas
                        dashboard.ResumenCantidad = new CitaResumenCantidadDTO();
                        while (await reader.ReadAsync())
                        {
                            dashboard.Mes = Convert.ToString(reader["Mes"]);
                            dashboard.Anio = Convert.ToInt32(reader["Anio"]);
                            dashboard.DiaInicioMes = Convert.ToInt32(reader["DiaInicioMes"]);
                            dashboard.DiaTerminoMes = Convert.ToInt32(reader["DiaTerminoMes"]);
                            dashboard.ResumenCantidad.CitasTotales = Convert.ToInt32(reader["CitasTotales"]);
                            dashboard.ResumenCantidad.CitasRegistradas = Convert.ToInt32(reader["CitasRegistradas"]);
                            dashboard.ResumenCantidad.CitasConfirmadas = Convert.ToInt32(reader["CitasConfirmadas"]);
                            dashboard.ResumenCantidad.CitasAtendidas = Convert.ToInt32(reader["CitasAtendidas"]);
                            dashboard.ResumenCantidad.CitasCanceladas = Convert.ToInt32(reader["CitasCanceladas"]);
                            dashboard.ResumenCantidad.CitasAnuladas = Convert.ToInt32(reader["CitasAnuladas"]);
                            dashboard.ResumenCantidad.CitasReprogramadas = Convert.ToInt32(reader["CitasReprogramadas"]);
                        }
                        break;
                    case 2:
                        //Ultimas 5 citas atendidas
                        dashboard.UltimasAtendidas = new List<CitaUltimaAtendidadDTO>();
                        while (await reader.ReadAsync())
                        {
                            dashboard.UltimasAtendidas.Add(new CitaUltimaAtendidadDTO()
                            {
                                Apellidos = Convert.ToString(reader["Apellidos"]),
                                Foto = Convert.ToString(reader["Foto"]),
                                Nombres = Convert.ToString(reader["Nombres"]),
                                HoraInicio = Convert.ToString(reader["HoraInicio"]),
                                IdCliente = Convert.ToInt32(reader["Id"])
                            });
                        }
                        break;
                    case 3:
                        //Grafico semanal de citas
                        dashboard.CitasSemanal = new List<CitaAtendidaSemanalDTO>();
                        while (await reader.ReadAsync())
                        {
                            dashboard.CitasSemanal.Add(new CitaAtendidaSemanalDTO()
                            {
                                Day = Convert.ToString(reader["Day"]),
                                Value = Convert.ToInt32(reader["Value"])
                            });
                        }
                        break;
                    case 4:
                        //Grafico anual por mes de citas
                        dashboard.CitasAnual = new List<CitaAtendidaAnualDTO>();
                        while (await reader.ReadAsync())
                        {
                            CitaAtendidaAnualDTO citaAnual = new CitaAtendidaAnualDTO()
                            {
                                Year = Convert.ToString(reader["Year"]),
                                Value = Convert.ToInt32(reader["Value"]),
                                Value2 = Convert.ToInt32(reader["Value2"]),
                            };
                            dashboard.CitasAnual.Add(citaAnual);
                        }
                        break;
                    case 5:
                        //Grafico Zonas mas atendidas por dia
                        dashboard.CitasZonasAtendidas = new List<CitaAtendidaZonaCantidadDTO>();
                        while (await reader.ReadAsync())
                        {
                            dashboard.CitasZonasAtendidas.Add(new CitaAtendidaZonaCantidadDTO()
                            {
                                ZonaCorporal = Convert.ToString(reader["Zona"]),
                                Valor = Convert.ToInt32(reader["Cantidad"]),
                                Color1 = Convert.ToString(reader["Color1"]),
                                Color2 = Convert.ToString(reader["Color2"]),
                            });
                        }
                        break;
                    case 6:
                        //Grafico mensual por dia de citas
                        dashboard.CitasMensual = new List<CitaAtendidaMensualDTO>();
                        while (await reader.ReadAsync())
                        {
                            dashboard.CitasMensual.Add(new CitaAtendidaMensualDTO()
                            {
                                Average = Convert.ToString(reader["Average"]),
                                Value = Convert.ToInt32(reader["Value"]),
                                Color1 = Convert.ToString(reader["Color1"]),
                                Color2 = Convert.ToString(reader["Color2"]),
                            });
                        }
                        break;
                }



                return dashboard;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        static async Task<IEnumerable<CitaDTO>> ReadItems(DbDataReader reader)
        {
            try
            {
                IList<CitaDTO> lista = new List<CitaDTO>();
                while (await reader.ReadAsync())
                {
                    CitaDTO obj = new CitaDTO
                    {
                        IdCita = reader.GetFieldValue<int>(0),
                        Foto = reader["Foto"]==DBNull.Value ? "" :  reader["Foto"].ToString(),
                        NuevoCliente = Convert.ToBoolean(reader["NuevoCliente"]),
                        IdCliente = Convert.ToInt32(reader["IdCliente"]),
                        IdSede = Convert.ToInt32(reader["IdSede"]),
                        IdEstado = Convert.ToInt32(reader["IdEstado"]),
                        IdMaquina = Convert.ToInt32(reader["IdMaquina"]),
                        Sede = reader["Sede"].ToString(),
                        Nombres = reader["Nombres"].ToString(),
                        Apellidos = reader["Apellidos"].ToString(),
                        SeudonimoPaciente = reader["Seudonimo"].ToString(),
                        NumeroDocumentoIdentidad = reader["Documento"].ToString(),
                        FechaCita = Convert.ToDateTime(reader["FechaCita"]),
                        NumerosCelulares = reader["Celular1"].ToString() + " - " + reader["Celular2"].ToString(),
                        HoraCita = reader["HoraInicio"].ToString(),
                        HoraInicio = reader["HoraInicio"].ToString(),
                        HoraTermino = reader["HoraTermino"].ToString(),
                        Duracion = Convert.ToInt32(reader["Duracion"]),
                        Fiesta = Convert.ToBoolean(reader["Fiesta"]),
                        TipoCita = reader["TipoCita"].ToString(),
                        NumeroHistoria = reader["IdHistoriaClinica"].ToString(),
                        ColorTipoCita = reader["ColorTipoCita"].ToString(),
                        ColorTextoTipoCita = reader["ColorTextoTipoCita"].ToString(),
                        Estado = reader["Estado"].ToString().ToUpper(),
                        ColorEstado = reader["ColorEstado"].ToString(),
                        Pagado = Convert.ToBoolean(reader["Pagado"]),
                        ColorPagado = reader["ColorPagado"].ToString(),
                        TipoCliente = reader["TipoCliente"].ToString(),
                        ColorTipoCliente = reader["ColorTipoCliente"].ToString(),
                        IdGenero = reader["IdGenero"] == DBNull.Value ? (Int32?)null : Convert.ToInt32(reader["IdGenero"]),
                        FechaRegistra = Convert.ToDateTime(reader["FechaRegistra"]),
                        UsuarioRegistra = Convert.ToString(reader["UsuarioRegistra"]),
                        IdUsuario = Convert.ToInt32(reader["IdUsuario"]),
                        Usuario = reader["Usuario"].ToString(),
                        Efectividad = Convert.ToInt32(reader["Efectividad"]),
                        Satisfaccion = Convert.ToInt32(reader["Satisfaccion"].ToString()),
                        IdFichaAdmision = reader["IdFichaAdmision"] == DBNull.Value ? (Int32?)null : Convert.ToInt32(reader["IdFichaAdmision"]),
                        IdServicio = reader["IdServicio"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["IdServicio"]),
                        Servicio = reader["Servicio"] == DBNull.Value ? null : Convert.ToString(reader["Servicio"]),
                        ServicioColor = reader["ServicioColor"] == DBNull.Value ? null : Convert.ToString(reader["ServicioColor"]),
                        Total = Convert.ToDecimal(reader["Total"]),
                        IdCronograma = reader["IdCronograma"] == DBNull.Value ? (int?)null :  Convert.ToInt32(reader["IdCronograma"]),
                        IdPreferente = Convert.ToInt32(reader["IdPreferente"]),
                        PrecioDePagoFinal = reader["PrecioDePagoFinal"] == DBNull.Value ? (float?)null : Convert.ToSingle(reader["PrecioDePagoFinal"]),
                        IdTipoCliente = reader["IdTipoCliente"] == DBNull.Value ? 0 : Convert.ToInt32(reader["IdTipoCliente"])
                        //CitaAvisos = new List<CitaMensajeAvisoEnt>(JsonSerializer.Deserialize<List<CitaMensajeAvisoEnt>>(Convert.ToString(reader["MensajeAviso"]))),
                        //CitaDetalles = new List<CitaMensajeDetalleEnt>(JsonSerializer.Deserialize<List<CitaMensajeDetalleEnt>>(Convert.ToString(reader["MensajeDetalle"]))),
                    };
                    lista.Add(obj);
                }

                //Leer los avisos
                List<CitaMensajeAvisoEnt> avisos = new List<CitaMensajeAvisoEnt>();
                if (reader.NextResult())
                {
                    while (await reader.ReadAsync())
                    {
                        CitaMensajeAvisoEnt aviso = new CitaMensajeAvisoEnt()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Aviso = reader["Aviso"].ToString(),
                            FechaRegistra = Convert.ToDateTime(reader["FechaRegistra"]),
                            IdCita = Convert.ToInt32(reader["IdCita"])
                        };
                        avisos.Add(aviso);
                    }
                }
                //Leer los detalles
                List<CitaMensajeDetalleEnt> detalles = new List<CitaMensajeDetalleEnt>();
                if (reader.NextResult())
                {
                    while (await reader.ReadAsync())
                    {
                        CitaMensajeDetalleEnt detalle = new CitaMensajeDetalleEnt()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Detalle = reader["Detalle"].ToString(),
                            FechaRegistra = Convert.ToDateTime(reader["FechaRegistra"]),
                            IdCita = Convert.ToInt32(reader["IdCita"])
                        };
                        detalles.Add(detalle);
                    }
                }

                //Leer las zonas concatenadas
                List<ZonasContatenadasDTO> zonasConcatenadas = new List<ZonasContatenadasDTO>();
                if (reader.NextResult())
                {
                    while (await reader.ReadAsync())
                    {
                        ZonasContatenadasDTO zonas = new ZonasContatenadasDTO()
                        {
                            IdCita = Convert.ToInt32(reader["IdCita"]),
                            TotalCita = Convert.ToDouble(reader["Total"]),
                            ZonaContatenada = Convert.ToString(reader["Zonas"])
                        };
                        zonasConcatenadas.Add(zonas);
                    }
                }

                foreach (CitaDTO cita in lista)
                {
                    if (avisos.Count > 0)
                        cita.CitaAvisos = (from aviso in avisos where aviso.IdCita == cita.IdCita select aviso).ToList();
                    if (detalles.Count > 0)
                        cita.CitaDetalles = (from detalle in detalles where detalle.IdCita == cita.IdCita select detalle).ToList();
                    if (zonasConcatenadas != null && zonasConcatenadas.Count > 0)
                    {
                        var item = (from zona in zonasConcatenadas where zona.IdCita == cita.IdCita select zona).FirstOrDefault();
                        if (item != null)
                        {
                            cita.Zonas = item.ZonaContatenada.Split("***");
                            cita.Total = Convert.ToDecimal(item.TotalCita);

                        }
                        else
                        {
                            cita.Zonas = [];
                            cita.Total = 0;
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


        static async Task<IEnumerable<CitaDTO>> ReadItemsObtenercitaid(DbDataReader reader)
        {
            try
            {
                IList<CitaDTO> lista = new List<CitaDTO>();
                while (await reader.ReadAsync())
                {
                    CitaDTO obj = new CitaDTO
                    {
                        IdCita = reader.GetFieldValue<int>(0),
                        Foto = reader["Foto"] == DBNull.Value ? "" : reader["Foto"].ToString(),
                        IdCliente = Convert.ToInt32(reader["IdCliente"]),
                        IdSede = Convert.ToInt32(reader["IdSede"]),
                        IdMaquina = Convert.ToInt32(reader["IdMaquina"]),
                        Sede = reader["Sede"].ToString(),
                        Nombres = reader["Nombres"].ToString(),
                        Apellidos = reader["Apellidos"].ToString(),
                        SeudonimoPaciente = reader["Seudonimo"].ToString(),
                        NumeroDocumentoIdentidad = reader["Documento"].ToString(),
                        FechaCita = Convert.ToDateTime(reader["FechaCita"]),
                        NumerosCelulares = reader["Celular1"].ToString() + " - " + reader["Celular2"].ToString(),
                        HoraCita = reader["HoraInicio"].ToString(),
                        HoraInicio = reader["HoraInicio"].ToString(),
                        HoraTermino = reader["HoraTermino"].ToString(),
                        Duracion = Convert.ToInt32(reader["Duracion"]),
                        TipoCita = reader["TipoCita"].ToString(),
                        NumeroHistoria = reader["IdHistoriaClinica"].ToString(),
                        ColorTipoCita = reader["ColorTipoCita"].ToString(),
                        ColorTextoTipoCita = reader["ColorTextoTipoCita"].ToString(),
                        Estado = reader["Estado"].ToString().ToUpper(),
                        ColorEstado = reader["ColorEstado"].ToString(),
                        Pagado = Convert.ToBoolean(reader["Pagado"]),
                        ColorPagado = reader["ColorPagado"].ToString(),
                        TipoCliente = reader["TipoCliente"].ToString(),
                        ColorTipoCliente = reader["ColorTipoCliente"].ToString(),
                        IdGenero = reader["IdGenero"] == DBNull.Value ? (Int32?)null : Convert.ToInt32(reader["IdGenero"]),
                        FechaRegistra = Convert.ToDateTime(reader["FechaRegistra"]),
                        UsuarioRegistra = Convert.ToString(reader["UsuarioRegistra"]),
                        IdUsuario = Convert.ToInt32(reader["IdUsuario"]),
                        Usuario = reader["Usuario"].ToString(),
                        Efectividad = Convert.ToInt32(reader["Efectividad"]),
                        Satisfaccion = Convert.ToInt32(reader["Satisfaccion"].ToString()),
                        IdFichaAdmision = reader["IdFichaAdmision"] == DBNull.Value ? (Int32?)null : Convert.ToInt32(reader["IdFichaAdmision"]),
                        IdServicio = reader["IdServicio"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["IdServicio"]),
                        Servicio = reader["Servicio"] == DBNull.Value ? null : Convert.ToString(reader["Servicio"]),
                        ServicioColor = reader["ServicioColor"] == DBNull.Value ? null : Convert.ToString(reader["ServicioColor"]),

                    };
                    lista.Add(obj);
                }

                //Leer los avisos
                List<CitaMensajeAvisoEnt> avisos = new List<CitaMensajeAvisoEnt>();
                if (reader.NextResult())
                {
                    while (await reader.ReadAsync())
                    {
                        CitaMensajeAvisoEnt aviso = new CitaMensajeAvisoEnt()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Aviso = reader["Aviso"].ToString(),
                            FechaRegistra = Convert.ToDateTime(reader["FechaRegistra"]),
                            IdCita = Convert.ToInt32(reader["IdCita"])
                        };
                        avisos.Add(aviso);
                    }
                }
                //Leer los detalles
                List<CitaMensajeDetalleEnt> detalles = new List<CitaMensajeDetalleEnt>();
                if (reader.NextResult())
                {
                    while (await reader.ReadAsync())
                    {
                        CitaMensajeDetalleEnt detalle = new CitaMensajeDetalleEnt()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Detalle = reader["Detalle"].ToString(),
                            FechaRegistra = Convert.ToDateTime(reader["FechaRegistra"]),
                            IdCita = Convert.ToInt32(reader["IdCita"])
                        };
                        detalles.Add(detalle);
                    }
                }

                //Leer las zonas concatenadas
                List<ZonasContatenadasDTO> zonasConcatenadas = new List<ZonasContatenadasDTO>();
                if (reader.NextResult())
                {
                    while (await reader.ReadAsync())
                    {
                        ZonasContatenadasDTO zonas = new ZonasContatenadasDTO()
                        {
                            IdCita = Convert.ToInt32(reader["IdCita"]),
                            TotalCita = Convert.ToDouble(reader["Total"]),
                            ZonaContatenada = Convert.ToString(reader["Zonas"])
                        };
                        zonasConcatenadas.Add(zonas);
                    }
                }

                foreach (CitaDTO cita in lista)
                {
                    if (avisos.Count > 0)
                        cita.CitaAvisos = (from aviso in avisos where aviso.IdCita == cita.IdCita select aviso).ToList();
                    if (detalles.Count > 0)
                        cita.CitaDetalles = (from detalle in detalles where detalle.IdCita == cita.IdCita select detalle).ToList();
                    if (zonasConcatenadas != null && zonasConcatenadas.Count > 0)
                    {
                        var item = (from zona in zonasConcatenadas where zona.IdCita == cita.IdCita select zona).FirstOrDefault();
                        if (item != null)
                        {
                            cita.Zonas = item.ZonaContatenada.Split("***");
                            cita.Total = Convert.ToDecimal(item.TotalCita);

                        }
                        else
                        {
                            cita.Zonas = [];
                            cita.Total = 0;
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

        static async Task<List<CitaExportarDTO>> ReadItemsExportar(DbDataReader reader)
        {
            try
            {
                List<CitaExportarDTO> lista = new List<CitaExportarDTO>();
                while (await reader.ReadAsync())
                {
                    CitaExportarDTO obj = new CitaExportarDTO
                    {
                        IdCita = Convert.ToInt32(reader["IdCita"]),
                        Sede = reader["Sede"].ToString(),
                        Cliente = reader["Cliente"].ToString(),
                        FechaCita = reader["FechaCita"].ToString(),
                        Zonas = reader["Zonas"].ToString(),
                        Promociones = reader["Promociones"].ToString(),
                        HoraInicio = reader["HoraInicio"].ToString(),
                        Estado = reader["Estado"].ToString(),
                        Pagado = reader["Pagado"].ToString(),
                        Total = Convert.ToDecimal(reader["Total"])
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

        static async Task<IEnumerable<CitaDTO>> ReadItemsParaPerfil(DbDataReader reader)
        {
            try
            {
                IList<CitaDTO> lista = new List<CitaDTO>();
                while (await reader.ReadAsync())
                {
                    CitaDTO obj = new CitaDTO
                    {
                        IdCronograma = DBNull.Value == reader["IdCronograma"] ? (int?)null : Convert.ToInt32(reader["IdCronograma"]),
                        IdCita = Convert.ToInt32(reader["IdCita"]),
                        IdCliente = Convert.ToInt32(reader["IdCliente"]),
                        IdSede = Convert.ToInt32(reader["IdSede"]),
                        Sede = reader["Sede"].ToString(),
                        FechaCita = reader["FechaCita"] == DBNull.Value ? Convert.ToDateTime("2030-01-01") : Convert.ToDateTime(reader["FechaCita"]),
                        IdEstado = Convert.ToInt32(reader["IdEstado"]),
                        HoraCita = reader["HoraInicio"].ToString(),
                        Duracion = Convert.ToInt32(reader["Duracion"]),
                        Estado = reader["Estado"].ToString(),
                        ColorEstado = reader["ColorEstado"].ToString(),
                        TipoCita = reader["TipoCita"].ToString(),
                        Pagado = Convert.ToBoolean(reader["Pagado"]),
                        Resumen = reader["Resumen"].ToString(),
                        IdServicio = Convert.ToInt32(reader["IdServicio"]),
                        Servicio = reader["Servicio"] == DBNull.Value ? null : Convert.ToString(reader["Servicio"]),
                        ServicioColor = reader["ServicioColor"] == DBNull.Value ? null : Convert.ToString(reader["ServicioColor"]),
                        IdPreferente = Convert.ToInt32(reader["IdPreferente"]),
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

        static async Task<GeneralResponse<bool>> TratamientoRealizado(DbDataReader reader)
        {
            try
            {
                GeneralResponse<bool> generalRes = new GeneralResponse<bool>
                {
                    Data = false
                };


                if (await reader.ReadAsync())
                {
                    generalRes.Message = "Tratamiento actualizado exitosamente.";
                    generalRes.Status = 200;

                    generalRes.Data = Convert.ToBoolean(reader["TratamientoRealizado"]);
                }

                return generalRes;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        static async Task<Respuesta<CitaDTO>> ReadItemsCondicion(DbDataReader reader)
        {
            try
            {
                Respuesta<CitaDTO> obj = new Respuesta<CitaDTO>
                {
                    Response = new CitaDTO()
                };
                while (await reader.ReadAsync())
                {
                    obj.Exito = Convert.ToBoolean(reader["Exito"]);
                    obj.Mensaje = Convert.ToString(reader["Mensaje"]);
                    obj.ErrorNumero = Convert.ToInt32(reader["ErrorNumero"]);
                    obj.ErrorDetalle = reader["ErrorDetalle"].ToString();
                    if (obj.Exito)
                    {
                        obj.Response.IdCita = Convert.ToInt32(reader["IdCita"]);
                        obj.Response.IdCliente = Convert.ToInt32(reader["IdCliente"]);
                        obj.Response.IdSede = Convert.ToInt32(reader["IdSede"]);
                        obj.Response.IdMaquina = Convert.ToInt32(reader["IdMaquina"]);
                        obj.Response.Sede = reader["Sede"].ToString();
                        obj.Response.Nombres = reader["Nombres"].ToString();
                        obj.Response.Apellidos = reader["Apellidos"].ToString();
                        obj.Response.NumeroDocumentoIdentidad = reader["Documento"].ToString();
                        obj.Response.NumeroHistoria = reader["IdHistoriaClinica"].ToString();
                        obj.Response.FechaCita = Convert.ToDateTime(reader["FechaCita"]);
                        obj.Response.NumerosCelulares = reader["Celular1"].ToString() + " - " + reader["Celular2"].ToString();
                        obj.Response.HoraCita = reader["HoraInicio"].ToString();
                        obj.Response.HoraInicio = reader["HoraInicio"].ToString();
                        obj.Response.HoraTermino = reader["HoraTermino"].ToString();
                        obj.Response.Duracion = Convert.ToInt32(reader["Duracion"]);
                        obj.Response.Total = Convert.ToDecimal(reader["Total"]);
                        obj.Response.Zonas = reader["Zonas"].ToString().Split(',');
                        obj.Response.TipoCita = reader["TipoCita"].ToString();
                        obj.Response.Estado = reader["Estado"].ToString();
                        obj.Response.ColorEstado = reader["ColorEstado"].ToString();
                    }
                }



                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        static async Task<IEnumerable<CitaDetalleZonaDTO>> ReadItemsZonaCita(DbDataReader reader)
        {
            try
            {
                IList<CitaDetalleZonaDTO> lista = new List<CitaDetalleZonaDTO>();
                while (await reader.ReadAsync())
                {
                    CitaDetalleZonaDTO obj = new CitaDetalleZonaDTO
                    {
                        IdCita = reader.GetFieldValue<int>(0),
                        Descripcion = Convert.ToString(reader["Descripcion"]),
                        Precio = Convert.ToDecimal(reader["Precio"]),
                    };
                    lista.Add(obj);
                }


                return lista;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        static async Task<CitaDTO> ReadItemById(DbDataReader reader)
        {
            try
            {
                CitaDTO cita = new CitaDTO();
                while (await reader.ReadAsync())
                {
                    cita.IdCita = Convert.ToInt32(reader["IdCita"]);
                    cita.IdCliente = Convert.ToInt32(reader["IdCliente"]);
                    cita.IdUsuario = Convert.ToInt32(reader["IdUsuario"]);
                    cita.FechaCita = Convert.ToDateTime(reader["FechaCita"]);
                    cita.IdTipoCita = Convert.ToInt32(reader["IdTipoCita"]);
                    cita.IdEstado = Convert.ToInt32(reader["IdEstado"]);
                    cita.IdUsuarioAtendidoPor = Convert.ToInt32(reader["IdUsuarioAtendidoPor"]);
                    cita.UsuarioAtendidoPor = reader["UsuarioAtendidoPor"].ToString();
                    cita.HoraCita = reader["HoraInicio"].ToString();
                    cita.HoraInicio = reader["HoraInicio"].ToString();
                    cita.HoraTermino = reader["HoraTermino"].ToString();
                    cita.IdTipoCliente = Convert.ToInt32(reader["IdTipoCliente"]);
                    cita.IdSede = Convert.ToInt32(reader["IdSede"]);
                    cita.IdMaquina = Convert.ToInt32(reader["IdMaquina"]);
                    cita.Sede = reader["Sede"].ToString();
                    cita.Apellidos = reader["Apellidos"].ToString();
                    cita.Nombres = reader["Nombres"].ToString();
                    cita.NumerosCelulares = reader["NumerosCelulares"].ToString();
                    cita.NumeroDocumentoIdentidad = reader["Documento"].ToString();
                    cita.Duracion = Convert.ToInt32(reader["Duracion"]);
                    cita.Total = reader["Total"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["Total"]);
                    cita.FechaRegistra = Convert.ToDateTime(reader["FechaRegistra"]);
                    cita.UsuarioRegistra = Convert.ToString(reader["UsuarioRegistra"]);
                    cita.ColorEstado = Convert.ToString(reader["ColorEstado"]);
                    cita.IdMedioContacto = reader["IdMedioContacto"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["IdMedioContacto"]);
                    cita.OtroMedioContacto = reader["OtroMedioContacto"] == DBNull.Value ? null : reader["OtroMedioContacto"].ToString();


                    cita.IdDescuento = Convert.ToInt32(reader["IdDescuento"]);
                    cita.DescuentoAplicaA = reader["DescuentoAplicaA"] == DBNull.Value ? null : reader["DescuentoAplicaA"].ToString();
                    cita.CuponDescuento = reader["CuponDescuento"] == DBNull.Value ? null : reader["CuponDescuento"].ToString();

                    CitaMaquinaDTO citaMaquina = new CitaMaquinaDTO
                    {
                        Id = Convert.ToInt32(reader["IdMaquina"]),
                        Descripcion = reader["Maquina"].ToString()
                    };

                    cita.Maquina = citaMaquina;
                    cita.IdServicio = reader["IdServicio"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["IdServicio"]);

                    cita.IdCitaAsignacion = reader["IdCitaAsignacion"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["IdCitaAsignacion"]);
                    cita.FechaConfirmacion = reader["FechaConfirmacion"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["FechaConfirmacion"]);
                    cita.IdUsuarioAsignado = reader["IdUsuarioAsignado"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["IdUsuarioAsignado"]);

                    cita.IdPreferente = Convert.ToInt32(reader["IdPreferente"]);
                    cita.NumeroBox = Convert.ToInt32(reader["NumeroBox"]);
                    cita.IdMaquinaMarca = reader["IdMaquinaMarca"] == DBNull.Value ? 0 : Convert.ToInt32(reader["IdMaquinaMarca"]);
                    cita.EsNotificado = Convert.ToBoolean(reader["NotificacionEstado"]);

                    cita.PrecioDePagoFinal = reader["PrecioDePagoFinal"] == DBNull.Value ? (float?)null : Convert.ToSingle(reader["PrecioDePagoFinal"]);
                    cita.TipoDePago = reader["TipoDePago"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["TipoDePago"]);
                }

                //Leer detalle
                List<CitaDetalleZonaDTO> citaDetalles = new List<CitaDetalleZonaDTO>();
                if (reader.NextResult())
                {
                    while (await reader.ReadAsync())
                    {
                        CitaDetalleZonaDTO citaDetalle = new CitaDetalleZonaDTO()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            IdCita = Convert.ToInt32(reader["IdCita"]),
                            IdZona = Convert.ToInt32(reader["IdZona"]),
                            Sesion = Convert.ToInt32(reader["Sesion"]),
                            SesionFinal = reader["SesionFinal"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["SesionFinal"]),
                            IdPromocionPrecio = reader["IdPromocionPrecio"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["IdPromocionPrecio"]),
                            Precio = Convert.ToDecimal(reader["Precio"]),
                            PrecioDescuento = Convert.ToDecimal(reader["PrecioDescuento"]),
                            PagoWeb = Convert.ToBoolean(reader["PagoWeb"]),
                            RetroTratam = Convert.ToBoolean(reader["RetroTratam"]),
                            //HoraInicio = reader["HoraInicio"].ToString(),
                            //HoraTermino = reader["HoraTermino"].ToString(),
                            Descripcion = reader["Descripcion"].ToString(),
                            Duracion = Convert.ToInt32(reader["Duracion"]),
                            IdUsuarioAgendado = reader["IdUsuarioAgendado"] == DBNull.Value ? (Int32?)null : Convert.ToInt32(reader["IdUsuarioAgendado"]),
                            UsuarioAgendado = reader["usuarioAgendado"].ToString(),
                            IdMedioContactoOrigen = reader["IdMedioContactoOrigen"] == DBNull.Value ? (Int32?)null : Convert.ToInt32(reader["IdMedioContactoOrigen"]),
                            Tratamientos = JsonSerializer.Deserialize<List<ZonaTratamientoDTO>>(Convert.ToString(reader["Tratamientos"])),
                            Estado = Convert.ToBoolean(reader["Estado"]),
                            Duplicado = Convert.ToBoolean(reader["Duplicado"]),
                            Parametros = reader["Parametros"] == DBNull.Value ? "" : reader["Parametros"].ToString(),
                            TratamientoRealizado = reader["TratamientoRealizado"] == DBNull.Value ? false : Convert.ToBoolean(reader["TratamientoRealizado"])
                        };
                        citaDetalles.Add(citaDetalle);
                    }
                    cita.ZonasCorporales = citaDetalles;
                }

                //Leer Promociones Involucradas por cada zona del detalle
                List<PromocionZonaDTO> citaPromocionZonas = new List<PromocionZonaDTO>();
                if (reader.NextResult())
                {
                    while (await reader.ReadAsync())
                    {
                        PromocionZonaDTO citaPromocionZona = new PromocionZonaDTO()
                        {
                            Descripcion = reader["Descripcion"].ToString(),
                            Sexo = reader["Sexo"].ToString(),
                            IdPromocionPrecio = Convert.ToInt32(reader["IdPromocionPrecio"]),
                            IdPromocionZona = Convert.ToInt32(reader["IdPromocionZona"]),
                            IdZona = Convert.ToInt32(reader["IdZona"]),
                            PrecioBase = Convert.ToDecimal(reader["PrecioBase"]),
                            PrecioPromocion = Convert.ToDecimal(reader["Precio"])
                        };
                        citaPromocionZonas.Add(citaPromocionZona);
                    }
                }

                //relacionar las promociones al detalle
                foreach (CitaDetalleZonaDTO citaDetalle in citaDetalles)
                {
                    citaDetalle.Promociones = new List<PromocionZonaDTO>();
                    foreach(PromocionZonaDTO promocion in citaPromocionZonas)
                    {
                        if(citaDetalle.IdZona == promocion.IdZona || citaDetalle.IdPromocionPrecio == promocion.IdPromocionPrecio)
                        {
                            citaDetalle.Promociones.Add(promocion);
                        }
                    }

                    // citaDetalle.Promociones = (from pz in citaPromocionZonas where pz.IdZona == citaDetalle.IdZona select pz).ToList();
                }

                //Leer Mensaje Detalle
                List<CitaMensajeDetalleDTO> citaMensajeDetalles = new List<CitaMensajeDetalleDTO>();
                if (reader.NextResult())
                {
                    while (await reader.ReadAsync())
                    {
                        CitaMensajeDetalleDTO citaMensajeDetalle = new CitaMensajeDetalleDTO()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            IdCita = Convert.ToInt32(reader["IdCita"]),
                            Detalle = reader["Detalle"].ToString(),
                            FechaRegistra = Convert.ToDateTime(reader["FechaRegistra"]),
                            IdUsuario = Convert.ToInt32(reader["IdUsuario"]),
                            InicialesUsuario = reader["InicialesUsuario"].ToString(),
                            UsuarioRegistra = reader["UsuarioRegistra"].ToString(),
                            Destacado = Convert.ToBoolean(reader["Destacado"]),
                        };
                        citaMensajeDetalles.Add(citaMensajeDetalle);
                    }
                    cita.CitaMensajeDetalles = citaMensajeDetalles;
                }

                //Leer Mensaje Nota
                List<CitaMensajeNotaDTO> citaMensajeNotas = new List<CitaMensajeNotaDTO>();
                if (reader.NextResult())
                {
                    while (await reader.ReadAsync())
                    {
                        CitaMensajeNotaDTO citaMensajeNota = new CitaMensajeNotaDTO()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            IdCita = Convert.ToInt32(reader["IdCita"]),
                            Nota = reader["Nota"].ToString(),
                            FechaRegistra = Convert.ToDateTime(reader["FechaRegistra"]),
                            IdUsuario = Convert.ToInt32(reader["IdUsuario"]),
                            InicialesUsuario = reader["InicialesUsuario"].ToString(),
                            IdCliente = Convert.ToInt32(reader["IdCliente"]),
                            UsuarioRegistra = reader["UsuarioRegistra"].ToString(),
                            Destacado = Convert.ToBoolean(reader["Destacado"]),
                        };
                        citaMensajeNotas.Add(citaMensajeNota);
                    }
                    cita.CitaMensajeNotas = citaMensajeNotas;
                }

                //Leer Mensaje Aviso
                List<CitaMensajeAvisoDTO> citaMensajeAvisos = new List<CitaMensajeAvisoDTO>();
                if (reader.NextResult())
                {
                    while (await reader.ReadAsync())
                    {
                        CitaMensajeAvisoDTO citaMensajeAviso = new CitaMensajeAvisoDTO()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            IdCita = Convert.ToInt32(reader["IdCita"]),
                            Aviso = reader["Aviso"].ToString(),
                            FechaRegistra = Convert.ToDateTime(reader["FechaRegistra"]),
                            IdUsuario = Convert.ToInt32(reader["IdUsuario"]),
                            InicialesUsuario = reader["InicialesUsuario"].ToString(),
                            UsuarioRegistra = reader["UsuarioRegistra"].ToString(),
                            Destacado = Convert.ToBoolean(reader["Destacado"]),
                        };
                        citaMensajeAvisos.Add(citaMensajeAviso);
                    }
                    cita.CitaMensajeAvisos = citaMensajeAvisos;
                }



                return cita;
            }
            catch (Exception EX)
            {
                throw EX;
            }
            
        }
        static async Task<IEnumerable<CitaComisionResumenDTO>> ReadItemComisionResumen(DbDataReader reader)
        {
            try
            {
                IList<CitaComisionResumenDTO> lista = new List<CitaComisionResumenDTO>();
                while (await reader.ReadAsync())
                {
                    CitaComisionResumenDTO obj = new CitaComisionResumenDTO
                    {
                        IdUsuarioOperador = Convert.ToInt32(reader["IdUsuarioOperador"]),
                        NumCitas = Convert.ToInt32(reader["NumCitas"]),
                        MontoComision = Convert.ToDecimal(reader["MontoComision"]),
                        MontoComisionIgv = Convert.ToDecimal(reader["MontoComisionIgv"]),
                        MontoTotal = Convert.ToDecimal(reader["MontoTotal"]),
                        NumZonas = Convert.ToInt32(reader["NumZonas"]),
                        UsuarioOperador = reader["UsuarioOperador"].ToString()
                    };
                    lista.Add(obj);
                }



                return lista;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        static async Task<IEnumerable<CitaComisionDetalleDTO>> ReadItemComisionDetalle(DbDataReader reader)
        {

            try
            {
                IList<CitaComisionDetalleDTO> lista = new List<CitaComisionDetalleDTO>();
                while (await reader.ReadAsync())
                {
                    CitaComisionDetalleDTO obj = new CitaComisionDetalleDTO
                    {
                        IdCita = Convert.ToInt32(reader["IdCita"]),
                        IdZona = Convert.ToInt32(reader["IdZona"]),
                        ZonaCorporal = reader["ZonaCorporal"].ToString(),
                        IdUsuarioAgendado = Convert.ToInt32(reader["IdUsuarioAgendado"]),
                        Operador = reader["Operador"].ToString(),
                        Precio = Convert.ToDecimal(reader["Precio"]),
                        FechaCita = Convert.ToDateTime(reader["FechaCita"]),
                        PorcentajeComision = Convert.ToDecimal(reader["PorcentajeComision"]),
                        Comision = Convert.ToDecimal(reader["Comision"]),
                        Cliente = reader["Cliente"].ToString()
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

        static async Task<List<CitaReporteDTO>> ReadObtenerReporte(DbDataReader reader)
        {
            try
            {
                List<CitaReporteDTO> collection = new List<CitaReporteDTO>();
                while (await reader.ReadAsync())
                {
                    var obj = new CitaReporteDTO();
                    obj.FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"]);
                    obj.IdCita = Convert.ToInt32(reader["IdCita"]);
                    obj.IdSede = Convert.ToInt32(reader["IdSede"]);
                    obj.Sede = Convert.ToString(reader["Sede"]);
                    obj.IdCliente = Convert.ToInt32(reader["IdCliente"]);
                    obj.Cliente = Convert.ToString(reader["Cliente"]);
                    obj.Distrito = Convert.ToString(reader["Distrito"]);
                    obj.Zonas = Convert.ToString(reader["Zonas"]);
                    obj.Fecha = Convert.ToDateTime(reader["Fecha"]);
                    obj.IdServicio = Convert.ToInt32(reader["IdServicio"]);
                    obj.Servicio = Convert.ToString(reader["Servicio"]);
                    obj.IdEstado = Convert.ToInt32(reader["IdEstado"]);
                    obj.IdTipoCita = Convert.ToInt32(reader["IdTipoCita"]); 
                    obj.TipoCita = Convert.ToString(reader["TipoCita"]);
                    obj.Zonas = Convert.ToString(reader["Zonas"]);
                    obj.Estado = Convert.ToString(reader["Estado"]);
                    obj.EstadoColor = Convert.ToString(reader["EstadoColor"]);
                    obj.TipoCliente = Convert.ToString(reader["TipoCliente"]);
                    obj.Telefono = Convert.ToString(reader["Telefono"]);
                    obj.DocumentoIdentidad = Convert.ToString(reader["DocumentoIdentidad"]);
                    obj.Genero = Convert.ToString(reader["Genero"]);
                    obj.Alias = Convert.ToString(reader["Alias"]);
                    obj.AtendidoPor = Convert.ToString(reader["AtendidoPor"]);
                    obj.Total = Convert.ToDecimal(reader["Total"]);
                    obj.UtmTerm = reader["UtmTerm"].ToString();
                    obj.UtmSource = reader["UtmSource"].ToString();
                    obj.UtmCampaign = reader["UtmCampaign"].ToString();
                    obj.UtmCont = reader["UtmCont"].ToString();
                    obj.MedioContacto = reader["MedioContacto"].ToString();
                    obj.UtmMedium = reader["UtmMedium"].ToString();
                    obj.Motivo = reader["Motivo"].ToString();
                    obj.UsuarioSeguimiento = reader["UsuarioSeguimiento"] == DBNull.Value ? "" : reader["UsuarioSeguimiento"].ToString();
                    collection.Add(obj);
                }

                return collection;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }



        static async Task<List<CitaReporteDetalladoDTO>> ReadObtenerReporteDetallado(DbDataReader reader)
        {
            try
            {
                List<CitaReporteDetalladoDTO> collection = new List<CitaReporteDetalladoDTO>();
                while (await reader.ReadAsync())
                {
                    var obj = new CitaReporteDetalladoDTO();
                    obj.IdCita = Convert.ToInt32(reader["IdCita"]);
                    obj.IdSede = Convert.ToInt32(reader["IdSede"]);
                    obj.Sede = Convert.ToString(reader["Sede"]);
                    obj.IdCliente = Convert.ToInt32(reader["IdCliente"]);
                    obj.Cliente = Convert.ToString(reader["Cliente"]);
                    obj.Zona = Convert.ToString(reader["Zona"]);
                    obj.Sesion = Convert.ToInt32(reader["Sesion"]);
                    obj.Promocion = Convert.ToString(reader["Promocion"]);
                    obj.Origen = Convert.ToString(reader["Origen"]);
                    obj.AgendadoPor = Convert.ToString(reader["AgendadoPor"]);
                    obj.Fecha = Convert.ToDateTime(reader["Fecha"]);
                    obj.IdServicio = Convert.ToInt32(reader["IdServicio"]);
                    obj.Servicio = Convert.ToString(reader["Servicio"]);
                    obj.IdEstado = Convert.ToInt32(reader["IdEstado"]);
                    obj.IdTipoCita = Convert.ToInt32(reader["IdTipoCita"]);
                    obj.TipoCita = Convert.ToString(reader["TipoCita"]);
                    obj.Estado = Convert.ToString(reader["Estado"]);
                    obj.EstadoColor = Convert.ToString(reader["EstadoColor"]);
                    obj.TipoCliente = Convert.ToString(reader["TipoCliente"]);
                    obj.Telefono = Convert.ToString(reader["Telefono"]);
                    obj.DocumentoIdentidad = Convert.ToString(reader["DocumentoIdentidad"]);
                    obj.Genero = Convert.ToString(reader["Genero"]);
                    obj.Alias = Convert.ToString(reader["Alias"]);
                    obj.UsuarioRegistro = Convert.ToString(reader["UsuarioRegistro"]);
                    obj.Precio = Convert.ToDecimal(reader["Precio"]);
                    obj.Total = Convert.ToDecimal(reader["Total"]);
                    collection.Add(obj);
                }

                return collection;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }


        static async Task<bool> ReadEnvioMasivoHistoria(DbDataReader reader)
        {
            try
            {
                bool exito = true;
                string mensaje = "";
                string detalle = "";
                int codigoError = 0;
                while (await reader.ReadAsync())
                {
                    exito = Convert.ToBoolean(reader["Exito"]);
                    if (!exito)
                    {
                        mensaje = Convert.ToString(reader["Mensaje"]);
                        codigoError = Convert.ToInt32(reader["ErrorNumero"]);
                        detalle = Convert.ToString(reader["ErrorDetalle"]);
                        throw new AlertException(mensaje);
                    }
                }

                return exito;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }


        static async Task<int> ReadAgendarSiguienteCita(DbDataReader reader)
        {
            try
            {
                bool exito = true;
                string mensaje = "";
                string detalle = "";
                int codigoError = 0;
                int idCita = 0;
                while (await reader.ReadAsync())
                {
                    exito = Convert.ToBoolean(reader["Exito"]);
                    if (!exito)
                    {
                        mensaje = Convert.ToString(reader["Mensaje"]);
                        codigoError = Convert.ToInt32(reader["ErrorNumero"]);
                        detalle = Convert.ToString(reader["ErrorDetalle"]);
                        throw new AlertException(mensaje);
                    }
                    idCita = Convert.ToInt32(reader["IdCita"]);
                }

                return idCita;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }


        static async Task<int> ReadAgendarSiguienteCitaManual(DbDataReader reader)
        {
            try
            {
                bool exito = true;
                string mensaje = "";
                string detalle = "";
                int codigoError = 0;
                int idCita = 0;
                while (await reader.ReadAsync())
                {
                    exito = Convert.ToBoolean(reader["Exito"]);
                    if (!exito)
                    {
                        mensaje = Convert.ToString(reader["Mensaje"]);
                        codigoError = Convert.ToInt32(reader["ErrorNumero"]);
                        detalle = Convert.ToString(reader["ErrorDetalle"]);
                        throw new AlertException(mensaje);
                    }
                    idCita = Convert.ToInt32(reader["IdCita"]);
                }

                return idCita;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }



        static async Task<CitaTacoDTO> ReadObtenerTaco(DbDataReader reader)
        {
            try
            {
                CitaTacoDTO output = new CitaTacoDTO();
                while (await reader.ReadAsync())
                {
                    output.IdCita = Convert.ToInt32(reader["IdCita"]);
                    output.FechaHora = Convert.ToDateTime(reader["FechaHora"]);
                    output.TipoCita = reader["TipoCita"] == DBNull.Value ? null : Convert.ToString(reader["TipoCita"]);
                    output.IdCliente = Convert.ToInt32(reader["IdCliente"]);
                    output.Cliente = Convert.ToString(reader["Cliente"]);
                    output.ClienteDocumento = reader["ClienteDocumento"] == DBNull.Value ? null : Convert.ToString(reader["ClienteDocumento"]);
                    output.Especialista = reader["Especialista"] == DBNull.Value ? null : Convert.ToString(reader["Especialista"]);
                    output.Usuario = reader["Usuario"] == DBNull.Value ? null : Convert.ToString(reader["Usuario"]);
                    output.NuevoCliente = Convert.ToBoolean(reader["NuevoCliente"]);
                    output.Detalle = new List<CitaTacoDetalleDTO>(JsonSerializer.Deserialize<List<CitaTacoDetalleDTO>>(Convert.ToString(reader["CitaDetalle"])));
                    output.Notas = new List<CitaTacoNotasDTO>(JsonSerializer.Deserialize<List<CitaTacoNotasDTO>>(Convert.ToString(reader["Notas"])));
                }

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }


        static async Task<bool> ReadMarcarAtendido(DbDataReader reader)
        {
            try
            {
                bool exito = false;
                string mensaje = "";
                string detalle = "";
                int codigoError = 0;
                int idCita = 0;
                while (await reader.ReadAsync())
                {
                    exito = Convert.ToBoolean(reader["Exito"]);
                    if (!exito)
                    {
                        mensaje = Convert.ToString(reader["Mensaje"]);
                        codigoError = Convert.ToInt32(reader["ErrorNumero"]);
                        detalle = Convert.ToString(reader["ErrorDetalle"]);
                        throw new AlertException(mensaje);
                    }
                }

                return exito;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }


        static async Task<List<int>> ReadObtenerCitaAtendidasHoy(DbDataReader reader)
        {
            try
            {
                List<int> idCitas = new List<int>();
                while (await reader.ReadAsync())
                {
                    int idCita = Convert.ToInt32(reader["IdCita"]);
                    idCitas.Add(idCita);
                }

                return idCitas;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }


        static async Task<List<CitaSinSiguienteCitaDTO>> ReadObtenerCitasAtendidasSinSiguienteCita(DbDataReader reader)
        {
            try
            {
                bool exito = true;
                string mensaje = "";
                string detalle = "";
                int codigoError = 0;

                while (await reader.ReadAsync())
                {
                    exito = Convert.ToBoolean(reader["Exito"]);
                    if (!exito)
                    {
                        mensaje = Convert.ToString(reader["Mensaje"]);
                        codigoError = Convert.ToInt32(reader["ErrorNumero"]);
                        detalle = Convert.ToString(reader["ErrorDetalle"]);
                        throw new AlertException(mensaje);
                    }
                }


                List<CitaSinSiguienteCitaDTO> collection = new List<CitaSinSiguienteCitaDTO>();
                if (reader.NextResult())
                {
                    while (await reader.ReadAsync())
                    {
                        CitaSinSiguienteCitaDTO obj = new CitaSinSiguienteCitaDTO();
                        obj.IdCita = Convert.ToInt32(reader["IdCita"]);
                        obj.IdCliente = Convert.ToInt32(reader["IdCliente"]);
                        obj.Cliente = Convert.ToString(reader["Cliente"]);
                        obj.Servicio = Convert.ToString(reader["Servicio"]);
                        obj.ColorServicio = Convert.ToString(reader["ColorServicio"]);
                        obj.Sede = Convert.ToString(reader["Sede"]);
                        obj.TelefonoCliente = reader["TelefonoCliente"] == DBNull.Value ? null : Convert.ToString(reader["TelefonoCliente"]);
                        obj.FechaCita = Convert.ToDateTime(reader["FechaCita"]);
                        obj.EstadoCita = Convert.ToString(reader["EstadoCita"]);
                        obj.ColorEstadoCita = Convert.ToString(reader["ColorEstadoCita"]);
                        obj.Pagado = Convert.ToBoolean(reader["Pagado"]);
                        collection.Add(obj);
                    }
                }

                return collection;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }




        static async Task<List<CitaReporteAgendadoOperador>> ReadObtenerObtenerReporteAgendado(DbDataReader reader)
        {
            try
            {
                List<CitaReporteAgendadoOperador> output = new List<CitaReporteAgendadoOperador>();
                while (await reader.ReadAsync())
                {
                    CitaReporteAgendadoOperador obj = new CitaReporteAgendadoOperador();
                    obj.IdCita = Convert.ToInt32(reader["IdCita"]);
                    obj.IdCliente = Convert.ToInt32(reader["IdCliente"]);
                    obj.NombreCliente = Convert.ToString(reader["NombreCliente"]);
                    obj.ApellidoCliente = Convert.ToString(reader["ApellidoCliente"]);
                    obj.DocumentoCliente = Convert.ToString(reader["DocumentoCliente"]);
                    obj.TelefonoCliente = Convert.ToString(reader["TelefonoCliente"]);
                    obj.Zona = Convert.ToString(reader["Zona"]);
                    obj.Sesion = Convert.ToInt32(reader["Sesion"]);
                    obj.Promocion = Convert.ToString(reader["Promocion"]);
                    obj.Precio = Convert.ToDecimal(reader["Precio"]);
                    obj.IdEstado = Convert.ToInt32(reader["IdEstado"]);
                    obj.Estado = Convert.ToString(reader["Estado"]);
                    obj.EstadoColor = Convert.ToString(reader["EstadoColor"]);
                    obj.TipoCliente = Convert.ToString(reader["TipoCliente"]);
                    obj.IdTipoCliente = Convert.ToInt32(reader["IdTipoCliente"]);
                    obj.IdSede = Convert.ToInt32(reader["IdSede"]);
                    obj.Sede = Convert.ToString(reader["Sede"]);
                    obj.FechaCita = Convert.ToDateTime(reader["FechaCita"]);
                    obj.IdServicio = Convert.ToInt32(reader["IdServicio"]);
                    obj.Servicio = Convert.ToString(reader["Servicio"]);
                    obj.ServicioColor = Convert.ToString(reader["ServicioColor"]);
                    obj.IdUsuarioAgendo = Convert.ToInt32(reader["IdUsuarioAgendo"]);
                    obj.UsuarioAgendo = Convert.ToString(reader["UsuarioAgendo"]);
                    obj.IdUsuarioRegistro = Convert.ToInt32(reader["IdUsuarioRegistro"]);
                    obj.UsuarioRegistro = Convert.ToString(reader["UsuarioRegistro"]);
                    obj.FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"]);

                    output.Add(obj);
                }

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }



        static async Task<CitaDatosDTO> ReadObtenerDatos(DbDataReader reader)
        {
            try
            {
                CitaDatosDTO obj = new CitaDatosDTO();
                while (await reader.ReadAsync())
                {
                    obj.IdCita = Convert.ToInt32(reader["IdCita"]);
                    obj.FechaCita = Convert.ToDateTime(reader["FechaCita"]);
                    obj.IdSede = Convert.ToInt32(reader["IdSede"]);
                    obj.Sede = Convert.ToString(reader["Sede"]);
                    obj.IdServicio = Convert.ToInt32(reader["IdServicio"]);
                    obj.Servicio = Convert.ToString(reader["Servicio"]);
                    obj.ServicioColor = Convert.ToString(reader["ServicioColor"]);
                    obj.Duracion = Convert.ToInt32(reader["Duracion"]);
                    obj.HoraInicio = Convert.ToString(reader["HoraInicio"]);
                    obj.HoraTermino = Convert.ToString(reader["HoraTermino"]);
                    obj.MinutoInicio = Convert.ToInt32(reader["MinutoInicio"]);
                    obj.MinutoTermino = Convert.ToInt32(reader["MinutoTermino"]);
                    obj.IdEstado = Convert.ToInt32(reader["IdEstado"]);
                    obj.Estado = Convert.ToString(reader["Estado"]);
                    obj.EstadoColor = Convert.ToString(reader["EstadoColor"]);

                }

                return obj;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }



        static async Task<bool> ReadModificarMaquina(DbDataReader reader)
        {
            try
            {
                bool exito = false;
                string mensaje = "";
                string detalle = "";
                int codigoError = 0;
                int idCita = 0;
                while (await reader.ReadAsync())
                {
                    exito = Convert.ToBoolean(reader["Exito"]);
                    if (!exito)
                    {
                        mensaje = Convert.ToString(reader["Mensaje"]);
                        codigoError = Convert.ToInt32(reader["ErrorNumero"]);
                        detalle = Convert.ToString(reader["ErrorDetalle"]);
                        throw new AlertException(mensaje);
                    }
                }

                return exito;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }


        static async Task<List<CitaReporteInfoClienteDTO>> ReadObtenerReporteInfoCliente(DbDataReader reader)
        {
            try
            {
                List<CitaReporteInfoClienteDTO> lista = new List<CitaReporteInfoClienteDTO>();
                while (await reader.ReadAsync())
                {
                    CitaReporteInfoClienteDTO obj = new CitaReporteInfoClienteDTO
                    {
                        IdCita = Convert.ToInt32(reader["IdCita"]),
                        NumeroDocumento = Convert.ToString(reader["NumeroDocumento"]),
                        Cliente = Convert.ToString(reader["Cliente"]),
                        Telefono = Convert.ToString(reader["Telefono"]),
                        TipoCliente = Convert.ToString(reader["TipoCliente"]),
                        FechaUltimaCita = DBNull.Value == reader["FechaUltimaCita"] ? null : Convert.ToString(reader["FechaUltimaCita"]),
                        ZonasAtendidas = Convert.ToString(reader["ZonasAtendidas"]),
                        PromocionesAdquiridas = Convert.ToString(reader["PromocionesAdquiridas"]),
                        UltimaCitaZonas = DBNull.Value == reader["UltimaCitaZonas"] ? null : Convert.ToString(reader["UltimaCitaZonas"]),
                        Sede = Convert.ToString(reader["Sede"]),
                        FechaCita = Convert.ToString(reader["FechaCita"]),
                        ZonasCitaActual = Convert.ToString(reader["ZonasCitaActual"]),
                        PromocionesActual = Convert.ToString(reader["PromocionesActual"]),
                        HoraInicio = Convert.ToString(reader["HoraInicio"]),
                        Estado = Convert.ToString(reader["Estado"]),
                        Pagado = Convert.ToString(reader["Pagado"]),
                        Total = Convert.ToDecimal(reader["Total"])
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


        static async Task<List<CitaClienteDTO>> ReadObtenerCitasCliente(DbDataReader reader)
        {
            try
            {
                List<CitaClienteDTO> collection = new List<CitaClienteDTO>();
                while (await reader.ReadAsync())
                {
                    var obj = new CitaClienteDTO();

                    obj.Id = Convert.ToInt32(reader["Id"]);
                    obj.IdCronograma = DBNull.Value == reader["IdCronograma"] ? (int?)null : Convert.ToInt32(reader["IdCronograma"]);
                    obj.Cliente = Convert.ToString(reader["Cliente"]);
                    obj.IdCliente = Convert.ToInt32(reader["IdCliente"]);
                    obj.Fecha = Convert.ToDateTime(reader["Fecha"]);
                    obj.Telefono = Convert.ToString(reader["Telefono"]);
                    obj.Servicio = Convert.ToString(reader["Servicio"]);
                    obj.ServicioColor = Convert.ToString(reader["ServicioColor"]);
                    obj.IdServicio = Convert.ToInt32(reader["IdServicio"]);
                    obj.Sede = Convert.ToString(reader["Sede"]);
                    obj.IdSede = Convert.ToInt32(reader["IdSede"]);
                    obj.Estado = Convert.ToString(reader["Estado"]);
                    obj.EstadoColor = Convert.ToString(reader["EstadoColor"]);
                    obj.IdEstado = Convert.ToInt32(reader["IdEstado"]);

                    collection.Add(obj);
                }

                return collection;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }


    }

}