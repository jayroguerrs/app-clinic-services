using DepilZone.Api.Hubs;
using DepilZone.Application.Interface;
using DepilZone.Entidad;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using DepilZone.Entidad.DTO;
using Microsoft.AspNetCore.Http;
using DepilZone.Entidad.Exceptions;
using Microsoft.Extensions.Hosting;
using System.Threading;
using NCrontab;
using DepilZone.Data.Response;
using Microsoft.AspNetCore.Authorization;
using DepilZone.Api.CustomFilter;
using DepilZone.Application.Implement;

namespace DepilZone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CitaController : ControllerBase
    {
        private readonly ICitaApp _cita;
        private readonly IHubContext<SignalHub> _hubContext;

        public CitaController(ICitaApp CitaApp, IHubContext<SignalHub> hubContext)
        {
            _cita = CitaApp;
            _hubContext = hubContext;
        }

        [HttpGet("datosPreliminares")]
        [CustomFilter("000226")]
		public async Task<CitaDatosPreliminaresDTO> ObtenerDatosPreliminares()
		{
			return await _cita.ObtenerDatosPreliminares();
		}
		[HttpPost]
        [CustomFilter("000227")]
        public async Task<Respuesta<CitaEnt>> Post(CitaEnt model)
		{
            try
            {
				return await _cita.Insertar(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
			
		}
		[HttpPut]
        [CustomFilter("000228")]
        public async Task<Respuesta<CitaEnt>> Put(CitaEnt model)
		{
			return await _cita.Modificar(model);
		}
		[HttpPut("estadoAtendido")]
        [CustomFilter("000229")]
        public async Task<int> EstadoAtendido(CitaEnt model)
		{
            try
            {
				return await _cita.EstadoAtendido(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
		}
        [HttpPut("actualizarCitaNoAsistio")]
        [CustomFilter("000657")]
        public async Task<Respuesta<CitaDTO>> ActualizarCondicionNoAsistio(CitaDTO model)
        {
            try
            {
                return await _cita.ActualizarCondicionNoAsistio(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        [HttpPut("actualizarCitaPendiente")]
        [CustomFilter("000230")]
        public async Task<Respuesta<CitaDTO>> ActualizarCondicionPendiente(CitaDTO model)
		{
            try
            {
				return await _cita.ActualizarCondicionPendiente(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
			
		}
		[HttpPut("actualizarCitaAnular")]
        [CustomFilter("000231")]
        public async Task<Respuesta<CitaDTO>> ActualizarCondicionAnular(CitaDTO model)
		{
			return await _cita.ActualizarCondicionAnular(model);
		}
		[HttpPut("actualizarCitaCancelar")]
        [CustomFilter("000232")]
        public async Task<Respuesta<CitaDTO>> ActualizarCondicionCancelar(CitaDTO model)
		{
			return await _cita.ActualizarCondicionCancelar(model);
		}
        [HttpPut("actualizarCitaNollamar")]
        [CustomFilter("000233")]
        public async Task<Respuesta<CitaDTO>> ActualizarCondicionNollamar(CitaDTO model)
        {
            return await _cita.ActualizarCondicionNollamar(model);
        }
        [HttpPut("actualizarCitaConfirmar")]
        [CustomFilter("000234")]
        public async Task<Respuesta<CitaDTO>> ActualizarCondicionConfirmar(CitaDTO model)
		{
			return await _cita.ActualizarCondicionConfirmar(model);
		}
        [HttpPut("actualizarCitaConfirmarAsistencia")]
        [CustomFilter("000235")]
        public async Task<Respuesta<CitaDTO>> ActualizarCondicionConfirmarAsistencia(CitaDTO model)
        {
            return await _cita.ActualizarCondicionConfirmarAsistencia(model);
        }
        [HttpPost("{fechaCita}/{idSede}")]
        [CustomFilter("000236")]
        public async Task<Respuesta<CitaEnt>> Reservacion(CitaEnt model)
		{
			Respuesta<CitaEnt> resultado = await _cita.InsertarReservacion(model);

			if (resultado.Exito)
			{
				MensajeSignalR mensajeSignalR = new MensajeSignalR()
				{
					Tipo = TipoAlerta.CitaReservada,
					DatosJSON = JsonSerializer.Serialize(resultado.Response),
					Exito = true,
					Mensaje = TipoAlerta.CitaReservada.ToString()
				};
				await _hubContext.Clients.All.SendAsync("mensajeroSignal", mensajeSignalR);
			}
			return resultado;
		}
		[HttpDelete("reservacion/{idUsuario}")]
        [CustomFilter("000237")]
        public async Task<bool> ReservacionEliminar(int idUsuario)
		{
			bool resultado = await _cita.EliminarReservacion(idUsuario);

			if (resultado)
			{
				MensajeSignalR mensajeSignalR = new MensajeSignalR()
				{
					Tipo = TipoAlerta.ReservaEliminada,
					DatosJSON = JsonSerializer.Serialize(idUsuario),
					Exito = true,
					Mensaje = TipoAlerta.ReservaEliminada.ToString()
				};
				await _hubContext.Clients.All.SendAsync("mensajeroSignal", mensajeSignalR);
			}
			return resultado;
		}		
		/// <summary>
		/// Permite obtener el listado de citas segun los parametros asignados
		/// </summary>
		/// <param name="fechaCita">Parametro para buscar las citas con la fecha indicada</param>
		/// <param name="idSede">Codigo de la sede que tiene la cita</param>
		/// <param name="pacienteCelular">Nombre del paciente o numero de celular que coincida con la cita</param>
		/// <returns></returns>
		[HttpGet("{fechaCita},{horaInicio},{horaTermino},{idSede},{idEstado},{pacienteCelular},{tipoCita},{idServicio},{idZonaContiene},{nacio}")]
        [CustomFilter("000238")]
        public async Task<IEnumerable<CitaDTO>> Obtener(DateTime fechaCita, string horaInicio, string horaTermino, int idSede, int idEstado, string pacienteCelular, int tipoCita, int idServicio, int idZonaContiene, int nacio)
		{
            try
            {
				return await _cita.Obtener(fechaCita, horaInicio, horaTermino, idSede, idEstado, pacienteCelular, tipoCita, idServicio, idZonaContiene, nacio);
            }
            catch (Exception ex)
            {
                throw ex;
            }
			
		}
        [HttpGet("reporte-info/{fechaCita},{horaInicio},{horaTermino},{idSede},{idEstado},{pacienteCelular},{tipoCita},{idServicio},{idZonaContiene},{nacio}")]
        [CustomFilter("000239")]
        public async Task<List<CitaReporteInfoClienteDTO>> ObtenerReporteInfoCliente(DateTime fechaCita, string horaInicio, string horaTermino, int idSede, int idEstado, string pacienteCelular, int tipoCita, int idServicio, int idZonaContiene, int nacio)
        {
            try
            {
                return await _cita.ObtenerReporteInfoCliente(fechaCita, horaInicio, horaTermino, idSede, idEstado, pacienteCelular, tipoCita, idServicio, idZonaContiene, nacio);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet("exportar/{fechaCita},{horaInicio},{horaTermino},{idSede},{idEstado},{pacienteCelular},{tipoCita}")]
        [CustomFilter("000240")]
        public async Task<ActionResult> ObtenerExportar(DateTime fechaCita, string horaInicio, string horaTermino, int idSede, int idEstado, string pacienteCelular, int tipoCita)
		{
            try
            {
				var collection = await _cita.ObtenerExportar(fechaCita, horaInicio, horaTermino, idSede, idEstado, pacienteCelular, tipoCita);
				return Ok(new { 
					data = collection,
					message = "",
					status = StatusCodes.Status200OK
				});
			}
            catch (Exception e)
            {
				return BadRequest(new{
					data = new { },
					message = e.Message,
					status = StatusCodes.Status400BadRequest
				});
            }
		}
		[HttpGet("obtenerDashboard/{fecha},{idSede},{idPerfil}")]
        [CustomFilter("000241")]
        public async Task<DashBoardDTO> ObtenerDashBoard(string fecha, int idSede, int idPerfil)
		{
            try
            {
                return await _cita.ObtenerDashBoard(fecha, idSede, idPerfil);
            }
            catch (Exception ex)
            {

                throw ex;
            }
			
		}
		[HttpGet("byId/{idCita}/{esReprogramacion}")]
        [CustomFilter("000242")]
        public async Task<CitaDTO> ObtenerById(int idCita, bool esReprogramacion)
		{
            try
            {
				return await _cita.ObtenerById(idCita, esReprogramacion);
            }
            catch (Exception e)
            {
                throw e;
            }
			
		}		
		[HttpGet("detalleCitaPrecio/{idCita}")]
        [CustomFilter("000243")]
        public async Task<IEnumerable<CitaDetalleZonaDTO>> ObtenerDetalleCitaPrecio(int idCita)
		{
			return await _cita.ObtenerDetalleCitaPrecio(idCita);
		}
		[HttpGet("citaid/{idCita}")]
        [CustomFilter("000244")]
        public async Task<IEnumerable<CitaDTO>> Obtenercitaid(int idCita)
		{
			return await _cita.Obtenercitaid(idCita);
		}
		[HttpGet("resumenParaPerfil/{idCliente}")]
        [CustomFilter("000245")]
        public async Task<IEnumerable<CitaDTO>> ObtenerParaPerfil(int idCliente)
		{
			return await _cita.ObtenerParaPerfil(idCliente);
		}
		[HttpGet("resumenParaPerfil/{idCliente}/servicio/{idServicio}")]
        [CustomFilter("000246")]
        public async Task<IEnumerable<CitaDTO>> ObtenerParaPerfilPorServicio(int idCliente, int idServicio)
		{
            try
            {
				return await _cita.ObtenerParaPerfilPorServicio(idCliente, idServicio);
            }
            catch (Exception ex)
            {
                throw ex;
            }
		}
		[HttpGet("resumenComisiones/{fechainicio}/{fechaTermino}/{idUsuarioOperador}")]
        [CustomFilter("000247")]
        public async Task<IEnumerable<CitaComisionResumenDTO>> ObtenerComisionesResumen(DateTime fechaInicio, DateTime fechaTermino, int idUsuarioOperador)
		{
			return await _cita.ObtenerComisionesResumen(fechaInicio, fechaTermino, idUsuarioOperador);
		}
		[HttpGet("detalleComisiones/{fechainicio}/{fechaTermino}/{idUsuarioOperador}")]
        [CustomFilter("000248")]
        public async Task<IEnumerable<CitaComisionDetalleDTO>> ObtenerComisionesDetalle(DateTime fechaInicio, DateTime fechaTermino, int idUsuarioOperador)
		{
			return await _cita.ObtenerComisionesDetalle(fechaInicio, fechaTermino, idUsuarioOperador);
		}
		[HttpGet("obtenerNotasCitaNueva/{idCliente}")]
        [CustomFilter("000249")]
        public async Task<IEnumerable<CitaMensajeNotaDTO>> ObtenerNotasEnCitaNueva(int idCliente)
		{
			return await _cita.ObtenerNotasEnCitaNueva(idCliente);
		}
		[HttpGet("agendadas/{fechaInicio}/{fechaFin}/{idSede}/{idGenero}")]
        [CustomFilter("000250")]
        public async Task<ActionResult> ObtenerAgendadas(DateTime fechaInicio, DateTime fechaFin, int idSede, int idGenero)
		{
			try
			{
				List<CitaTotalDTO> citas = await _cita.ObtenerAgendadas(fechaInicio, fechaFin, idSede, idGenero);
				return Ok(new
				{
					data = citas,
					message = "",
					status = 200
				});
			}
			catch (Exception e)
			{
				return BadRequest(new
				{
					data = new { },
					message = e.Message,
					status = 400
				});
			}
		}
		[HttpGet("atendidas/{fechaInicio}/{fechaFin}/{idSede}/{idGenero}")]
        [CustomFilter("000251")]
        public async Task<ActionResult> ObtenerAtendidas(DateTime fechaInicio, DateTime fechaFin, int idSede, int idGenero)
		{
			try
			{
				List<CitaTotalDTO> citas = await _cita.ObtenerAtendidas(fechaInicio, fechaFin, idSede, idGenero);
				return Ok(new
				{
					data = citas,
					message = "",
					status = 200
				});
			}
			catch (Exception e)
			{
				return BadRequest(new
				{
					data = new { },
					message = e.Message,
					status = 400
				});
			}
		}
		[HttpGet("cortesia/{fechaInicio}/{fechaFin}/{idSede}/{idGenero}")]
        [CustomFilter("000252")]
        public async Task<ActionResult> ObtenerAgendadasCortesia(DateTime fechaInicio, DateTime fechaFin, int idSede, int idGenero)
		{
			try
			{
				List<CitaTotalDTO> citas = await _cita.ObtenerAgendadasCortesia(fechaInicio, fechaFin, idSede, idGenero);
				return Ok(new
				{
					data = citas,
					message = "",
					status = 200
				});
			}
			catch (Exception e)
			{
				return BadRequest(new
				{
					data = new { },
					message = e.Message,
					status = 400
				});
			}
		}
		[HttpGet("promocion/{fechaInicio}/{fechaFin}/{idSede}")]
        [CustomFilter("000253")]
        public async Task<ActionResult> ObtenerPorPromocion(DateTime fechaInicio, DateTime fechaFin, int idSede)
		{
			try
			{
				List<CitaPromocionDTO> citas = await _cita.ObtenerPorPromocion(fechaInicio, fechaFin, idSede);
				return Ok(new
				{
					data = citas,
					message = "",
					status = 200
				});
			}
			catch (Exception e)
			{
				return BadRequest(new
				{
					data = new { },
					message = e.Message,
					status = 400
				});
			}
		}
		[HttpGet("reporte/{fechaInicio}/{fechaFin}/{idSede}/{idEstado}/{idServicio}/{idTipoCita}/{idZona}")]
        [CustomFilter("000254")]
        public async Task<ActionResult> ObtenerReporte(DateTime fechaInicio, DateTime fechaFin, int idSede, int idEstado, int idServicio, int idTipoCita, int idZona, [FromQuery] int? nuevoCliente)
		{
			try
			{
				List<CitaReporteDTO> citas = await _cita.ObtenerReporte( fechaInicio,  fechaFin,  idSede,  idEstado,  idServicio,  idTipoCita, idZona, nuevoCliente);
				return Ok(new
				{
					data = citas,
					message = "",
					status = 200
				});
			}
			catch (Exception e)
			{
				return BadRequest(new
				{
					data = new { },
					message = e.Message,
					status = 400
				});
			}
		}
        [HttpGet("reporte-detallado/{fechaInicio}/{fechaFin}/{idSede}/{idEstado}/{idServicio}/{idTipoCita}/{idZona}")]
        [CustomFilter("000255")]
        public async Task<ActionResult> ObtenerReporteDetallado(DateTime fechaInicio, DateTime fechaFin, int idSede, int idEstado, int idServicio, int idTipoCita, int idZona)
        {
            try
            {
                List<CitaReporteDetalladoDTO> citas = await _cita.ObtenerReporteDetallado(fechaInicio, fechaFin, idSede, idEstado, idServicio, idTipoCita, idZona);
                return Ok(new
                {
                    data = citas,
                    message = "",
                    status = 200
                });
            }
            catch (Exception e)
            {
                return BadRequest(new
                {
                    data = new { },
                    message = e.Message,
                    status = 400
                });
            }
        }
        [HttpGet("reporte-agendado-operador/{fechaInicio}/{fechaFin}/{idSede}/{idServicio}/{idTipoCliente}/{idEstado}/{idUsuarioAgendo}")]
        [CustomFilter("000256")]
        public async Task<ActionResult> ObtenerReporteAgendadoOperador(DateTime fechaInicio, DateTime fechaFin, int idSede, int idServicio, int idTipoCliente, int idEstado, int idUsuarioAgendo)
        {
            try
            {
                List<CitaReporteAgendadoOperador> citas = await _cita.ObtenerReporteAgendado( fechaInicio,  fechaFin,  idSede,  idServicio,  idTipoCliente,  idEstado, idUsuarioAgendo);
                return Ok(new
                {
                    data = citas,
                    message = "",
                    status = 200
                });
            }
            catch (Exception e)
            {
                return BadRequest(new
                {
                    data = new { },
                    message = e.Message,
                    status = 400
                });
            }
        }
        [HttpPost("envio-masivo-historia")]
        [CustomFilter("000257")]
        public async Task<ActionResult> EnvioMasivoHistoria(CitaHistoriaMasivaDTO model)
        {
            try
            {
                bool respuesta = await _cita.EnvioMasivoHistoria(model);
                return Ok(new
                {
                    data = respuesta,
                    message = "",
                    status = 200
                });
            }
            catch (Exception e)
            {
                return BadRequest(new
                {
                    data = new { },
                    message = e.Message,
                    status = 400
                });
            }
        }
        [HttpPost("siguiente-cita")]
        [CustomFilter("000258")]
        public async Task<ActionResult> AgendarSiguienteCita(SiguienteCitaDTO model)
        {
            try
            {
                int respuesta = await _cita.AgendarSiguienteCita(model);
                return Ok(new
                {
                    data = respuesta,
                    message = "",
                    status = 201
                });
            }
            catch (AlertException e)
            {
                return Ok(new
                {
                    data = new { },
                    message = e.Message,
                    status = 400
                });
            }
            catch (Exception e)
            {
                return BadRequest(new
                {
                    data = new { },
                    message = e.Message,
                    status = 400
                });
            }
        }

        [HttpPatch("actualizar-parametro")]
        public async Task<ActionResult> ActualizarParametro(ParametroUpdateDTO model)
        {
            try
            {
                GeneralResponse<ParametroUpdateDTO> respuesta = await _cita.ActualizarParametro(model);
                return Ok(new
                {
                    data = respuesta,
                    message = "",
                    status = 201
                });
            }
            catch (AlertException e)
            {
                return Ok(new
                {
                    data = new { },
                    message = e.Message,
                    status = 400
                });
            }
            catch (Exception e)
            {
                return BadRequest(new
                {
                    data = new { },
                    message = e.Message,
                    status = 400
                });
            }
        }

        [HttpPost("siguiente-cita-manual")]
        [CustomFilter("000259")]
        public async Task<ActionResult> AgendarSiguienteCitaManual(SiguienteCitaDTO model)
        {
            try
            {
                int respuesta = await _cita.AgendarSiguienteCitaManual(model);
                return Ok(new
                {
                    data = respuesta,
                    message = "",
                    status = 201
                });
            }
            catch (AlertException e)
            {
                return Ok(new
                {
                    data = new { },
                    message = e.Message,
                    status = 400
                });
            }
            catch (Exception e)
            {
                return BadRequest(new
                {
                    data = new { },
                    message = e.Message,
                    status = 400
                });
            }
        }
        [HttpGet("obtener-taco/{idCita}/{idUsuario}")]
        [CustomFilter("000260")]
        public async Task<ActionResult> ObtenerTaco(int idCita, int idUsuario)
        {
            try
            {
                CitaTacoDTO taco = await _cita.ObtenerTaco(idCita, idUsuario);
                return Ok(new
                {
                    data = taco,
                    message = "",
                    status = 200
                });
            }
            catch (Exception e)
            {
                return BadRequest(new
                {
                    data = new { },
                    message = e.Message,
                    status = 400
                });
            }
        }
        [HttpPut("{idCita}/{idUsuario}/marcar-atendido")]
        [CustomFilter("000261")]
        public async Task<ActionResult> MarcarAtendido(int idCita, int idUsuario)
        {
            try
            {
                bool respuesta = await _cita.MarcarAtendido(idCita, idUsuario);
                return Ok(new
                {
                    data = respuesta,
                    message = "",
                    status = 200
                });
            }
            catch (AlertException e)
            {
                return Ok(new
                {
                    data = new { },
                    message = e.Message,
                    status = 400
                });
            }
            catch (Exception e)
            {
                return BadRequest(new
                {
                    data = new { },
                    message = e.Message,
                    status = 400
                });
            }
        }
		[HttpGet("prueba")]
		public async Task<ActionResult> prueba() {
            DateTime localDate = DateTime.Now;
		

			return Ok(new
			{
				data = localDate.ToString()
			});
        }
        [HttpGet("fecha")]
        public async Task<ActionResult> fecha()
        {
            DateTime localDate = DateTime.Now;


            return Ok(new
            {
                data = localDate.ToString()
            });
        }
        [HttpPost("{idCita}/agregar-detalle")]
        [CustomFilter("000262")]
        public async Task<ActionResult> AgregarDetalle(int idCita, CitaNuevoDetalle model)
        {

            try
            {
                bool respuesta = await _cita.AgregarDetalle(idCita, model);
                return Ok(new
                {
                    data = respuesta,
                    message = "",
                    status = 201
                });
            }
            catch (AlertException e)
            {
                return Ok(new
                {
                    data = new { },
                    message = e.Message,
                    status = 400
                });
            }
            catch (Exception e)
            {
                return BadRequest(new
                {
                    data = new { },
                    message = e.Message,
                    status = 400
                });
            }
        }
        [HttpGet("obtener-sin-siguientecita/{fechaDesde}/{fechaHasta}/{idServicio}/{idUsuario}")]
        [CustomFilter("000263")]
        public async Task<ActionResult> ObtenerCitasAtendidasSinSiguienteCita(DateTime fechaDesde, DateTime fechaHasta, int idServicio, int idUsuario)
        {

            try
            {
                List<CitaSinSiguienteCitaDTO> collection = await _cita.ObtenerCitasAtendidasSinSiguienteCita(fechaDesde, fechaHasta, idServicio, idUsuario);
                return Ok(new
                {
                    data = collection,
                    message = "",
                    status = 200
                });
            }
            catch (AlertException e)
            {
                return Ok(new
                {
                    data = new { },
                    message = e.Message,
                    status = 400
                });
            }
            catch (Exception e)
            {
                return BadRequest(new
                {
                    data = new { },
                    message = e.Message,
                    status = 400
                });
            }
        }
        [HttpGet("historial-parametros/{idCliente}/{idServicio}/{idZona}")]
        public async Task<List<HistorialParametroDTO>> ObtenerHistorialParametros(int idCliente, int idServicio, int idZona)
        {
            return await _cita.ObtenerHistorialParametros(idCliente, idServicio, idZona);
        }

        [HttpGet("obtener-datos/{idCita}/{idUsuario}")]
        [CustomFilter("000264")]
        public async Task<ActionResult> ObtenerDatos(int idCita, int idUsuario)
        {
            try
            {
                var cita =  await _cita.ObtenerDatos(idCita, idUsuario);
                return Ok(new JsonResponse
                {
                    Data = cita,
                    Error = "",
                    Status = 200
                });
            }
            catch (AlertException e)
            {
                return Ok(new JsonResponse
                {
                    Data = null,
                    Error = e.Message,
                    Status = 400
                });
            }
            catch (Exception e)
            {
                return BadRequest(new JsonResponse
                {
                    Data = new { },
                    Error = e.Message,
                    Status = 400
                });
            }
        }
        [HttpPut("{idCita}/modificar-maquina")]
        [CustomFilter("000265")]
        public async Task<ActionResult> ModificarMaquina(int idCita, CitaModificaMaquinaDTO model)
        {
            try
            {
                bool respuesta = await _cita.ModificarMaquina(idCita, model);
                return Ok(new JsonResponse
                {
                    Data = respuesta,
                    Error = null,
                    Status = 200
                });
            }
            catch (AlertException e)
            {
                return Ok(new JsonResponse
                {
                    Data = null,
                    Error = e.Message,
                    Status = 400
                });
            }
            catch (Exception e)
            {
                return BadRequest(new JsonResponse
                {
                    Data = null,
                    Error = e.Message,
                    Status = 400
                });
            }
        }
        [HttpPut("{estado}/{idCitaDetalle}/actualizar-tratamiento-realizado")]
        public async Task<GeneralResponse<bool>> ActualizarTratamientoRealizado(int estado, int idCitaDetalle)
        {
            var result = await _cita.ActualizarTratamientoRealizado(estado, idCitaDetalle);
            return result;
        }
        [HttpGet("cliente-asignado/{idClienteAsignado}")]
        [CustomFilter("000266")]
        public async Task<ActionResult> ObtenerCitasCliente(int idClienteAsignado)
        {
            try
            {
                List<CitaClienteDTO> collection = await _cita.ObtenerCitasCliente(idClienteAsignado);
                return Ok(new JsonResponse
                {
                    Data = collection,
                    Error = null,
                    Status = 200
                });
            }
            catch (AlertException e)
            {
                return Ok(new JsonResponse
                {
                    Data = null,
                    Error = e.Message,
                    Status = 400
                });
            }
            catch (Exception e)
            {
                return BadRequest(new JsonResponse
                {
                    Data = null,
                    Error = e.Message,
                    Status = 400
                });
            }
        }
        /*public class CitaMonitor : BackgroundService
        {
            private readonly ICitaApp _citaApp;
            //private readonly IHubContext<SignalHub> _hubContext;
            public CitaMonitor(ICitaApp ICitaApp)
            {
                _citaApp = ICitaApp;
                //_hubContext = hub;
            }

            protected override async Task ExecuteAsync(CancellationToken stoppingToken)
            {
                DateTime localDate = DateTime.Now;
				localDate.ToString("es-ES");


                while (!stoppingToken.IsCancellationRequested)
                {
                    int preferentesSinAtender = await _citaApp.ObtenerSinAtender();
                    if (preferentesSinAtender > 0)
                    {
                        MensajeSignalR mensajeSignalR = new MensajeSignalR()
                        {
                            Exito = true,
                            Mensaje = TipoAlerta.RetornoPreferente.ToString(),
                            DatosJSON = JsonSerializer.Serialize(preferentesSinAtender),
                            Tipo = TipoAlerta.RetornoPreferente
                        };
                        await _hubContext.Clients.All.SendAsync("mensajeroSignal", mensajeSignalR);
                    }

                    await Task.Delay(60000);
                }
            }
        }*/
        public class MyTestHostedService : BackgroundService
        {
            private CrontabSchedule _schedule;
            private DateTime _nextRun;
            //private readonly IServicioApp _servicioApp;
			private readonly ICitaApp _citaApp;

            //private string Schedule => "* 0-59 23 * * *"; //Todos los dias a las 11 de la noche
            private string Schedule => "* 0-59 23 * * *"; //Todos los dias a todas las horas


            public MyTestHostedService(ICitaApp ICitaApp)
            {
				_citaApp = ICitaApp;


                _schedule = CrontabSchedule.Parse(Schedule, new CrontabSchedule.ParseOptions { IncludingSeconds = true });
                _nextRun = _schedule.GetNextOccurrence(DateTime.Now);
            }

            protected override async Task ExecuteAsync(CancellationToken stoppingToken)
            {
                do
                {
                    var now = DateTime.Now;
                    var nextrun = _schedule.GetNextOccurrence(now);
                    if (now > _nextRun)
                    {

						try
						{
						
							List<int> idCitas = await _citaApp.ObtenerCitaAtendidasHoy();

							foreach (var idCita in idCitas)
							{
								await _citaApp.SiguienteCitaAtendidasHoy(idCita);
							}

                        }
						catch (Exception e)
						{
							throw e;
						}
						

                        //Process();
                        _nextRun = _schedule.GetNextOccurrence(DateTime.Now);
                    }
                    await Task.Delay(30000, stoppingToken); //1 minute delay
                }
                while (!stoppingToken.IsCancellationRequested);
            }
        }
    }
}