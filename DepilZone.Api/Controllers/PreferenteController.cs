using DepilZone.Api.CustomFilter;
using DepilZone.Api.Hubs;
using DepilZone.Application.Interface;
using DepilZone.Application.Responses;
using DepilZone.Data.Response;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using DepilZone.Entidad.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace DepilZone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class PreferenteController : ControllerBase
    {
        private readonly IHubContext<SignalHub> _hubContext;
        private readonly IPreferenteApp _preferente;

        public PreferenteController(IPreferenteApp PreferenteApp, IHubContext<SignalHub> hubContext)
        {
            _preferente = PreferenteApp;
            _hubContext = hubContext;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("exportar/{IdUsuario}/{FechaDesde}/{FechaHasta}")]
        [CustomFilter("000118")]
        public async Task<IActionResult> ExportarPreferenteVentas(int IdUsuario, string FechaDesde, string FechaHasta)
        {
            try
            {
                if (IdUsuario <= 0)
                {
                    var errorResponse = new ApiResponse<List<PreferenteVentasDTO>>
                    {
                        Status = "Error",
                        Errors = new List<ErrorResponse>
                {
                    new ErrorResponse
                    {
                        Code = "400",
                        Message = "ID de usuario inválido."
                    }
                },
                        Succeeded = false
                    };

                    return BadRequest(errorResponse);
                }

                DateTime? fechaDesde = null;
                DateTime? fechaHasta = null;

                if (!string.IsNullOrEmpty(FechaDesde))
                {
                    if (DateTime.TryParse(FechaDesde, out DateTime parsedFechaDesde))
                    {
                        fechaDesde = parsedFechaDesde;
                    }
                    else
                    {
                        var errorResponse = new ApiResponse<List<PreferenteVentasDTO>>
                        {
                            Status = "Error",
                            Errors = new List<ErrorResponse>
                    {
                        new ErrorResponse
                        {
                            Code = "400",
                            Message = "La fecha de inicio no es válida."
                        }
                    },
                            Succeeded = false
                        };

                        return BadRequest(errorResponse);
                    }
                }

                if (!string.IsNullOrEmpty(FechaHasta))
                {
                    if (DateTime.TryParse(FechaHasta, out DateTime parsedFechaHasta))
                    {
                        fechaHasta = parsedFechaHasta;
                    }
                    else
                    {
                        var errorResponse = new ApiResponse<List<PreferenteVentasDTO>>
                        {
                            Status = "Error",
                            Errors = new List<ErrorResponse>
                            {
                                new ErrorResponse
                                {
                                    Code = "400",
                                    Message = "La fecha de fin no es válida."
                                }
                            },
                            Succeeded = false
                        };

                        return BadRequest(errorResponse);
                    }
                }

                if (fechaDesde.HasValue && fechaHasta.HasValue && fechaDesde > fechaHasta)
                {
                    var errorResponse = new ApiResponse<List<PreferenteVentasDTO>>
                    {
                        Status = "Error",
                        Errors = new List<ErrorResponse>
                {
                    new ErrorResponse
                    {
                        Code = "400",
                        Message = "La fecha de inicio no puede ser mayor que la fecha de fin."
                    }
                },
                        Succeeded = false
                    };

                    return BadRequest(errorResponse);
                }

                var preferentes = await _preferente.ObtenerPreferentesVentas(IdUsuario, fechaDesde, fechaHasta);

                var preferentesList = preferentes.ToList();

                var response = new ApiResponse<List<PreferenteVentasDTO>>
                {
                    Status = "Success",
                    Result = new Result<List<PreferenteVentasDTO>>
                    {
                        Data = preferentesList,
                        Empty = !preferentes.Any(),
                        TotalElements = preferentes.Count(),
                        TotalPages = 1,
                        Number = 1,
                        First = true,
                        Last = true
                    },
                    Succeeded = true
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorResponse = new ApiResponse<List<PreferenteVentasDTO>>
                {
                    Status = "Error",
                    Errors = new List<ErrorResponse>
            {
                new ErrorResponse
                {
                    Code = "500",
                    Message = "Error interno del servidor: " + ex.Message
                }
            },
                    Succeeded = false
                };

                return StatusCode(500, errorResponse);
            }
        }
        [HttpGet("{fechaDesde}/{fechaHasta}/{idEstado}/{idTeleoperador}/{IdMedioContacto}/{idUsuarioSistema}/{idEstadoAtencion}/{esCliente}")]
        [CustomFilter("000119")]
        public async Task<IEnumerable<PreferenteGrillaDTO>> Get(DateTime fechaDesde, DateTime fechaHasta, int idEstado, int idTeleoperador, int IdMedioContacto, int IdUsuarioSistema, int idEstadoAtencion, int esCliente)
        {
            try
            {
                return await _preferente.Obtener(fechaDesde, fechaHasta, idEstado, idTeleoperador, IdMedioContacto, IdUsuarioSistema, idEstadoAtencion, esCliente);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet("mobilePreferentes")]
        public async Task<IEnumerable<PreferenteMobileGrillaDTO>> ObtenerMobilePreferentes()
        {
            try
            {
                return await _preferente.ObtenerMobilePreferentes();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPatch("estadoMobilePreferentes/{IdCita}/{EstadoId}")]
        public async Task<GeneralResponse<PreferenteMobileResponseDTO>> UpdateMobilePreferenteEstado(int IdCita, int EstadoId)
        {
            try
            {
                return await _preferente.UpdateMobilePreferenteEstado(IdCita, EstadoId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet("reporte/{fechaDesde}/{fechaHasta}/{idEstado}/{idTeleoperador}/{IdMedioContacto}/{idUsuarioSistema}/{idEstadoAtencion}/{esCliente}")]
        [CustomFilter("000120")]
        public async Task<IEnumerable<PreferenteGrillaDTO>> GetReportePreferente(DateTime fechaDesde, DateTime fechaHasta, int idEstado, int idTeleoperador, int IdMedioContacto, int IdUsuarioSistema, int idEstadoAtencion, int esCliente)
        {
            try
            {
                return await _preferente.ObtenerReportePreferente(fechaDesde, fechaHasta, idEstado, idTeleoperador, IdMedioContacto, IdUsuarioSistema, idEstadoAtencion, esCliente);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet("telefono/{fechaDesde}/{fechaHasta}/{idEstado}/{idTeleoperador}/{IdMedioContacto}/{idUsuarioSistema}/{idEstadoAtencion}/{esCliente}")]
        [CustomFilter("000121")]
        public async Task<IEnumerable<PreferenteGrillaDTO>> GetHasPhone(DateTime fechaDesde, DateTime fechaHasta, int idEstado, int idTeleoperador, int IdMedioContacto, int IdUsuarioSistema, int idEstadoAtencion, int esCliente)
        {
            try
            {
                return await _preferente.ObtenerConTelefono(fechaDesde, fechaHasta, idEstado, idTeleoperador, IdMedioContacto, IdUsuarioSistema, idEstadoAtencion, esCliente);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet("{id}/{idUsuarioSistema}")]
        [CustomFilter("000122")]
        public async Task<PreferenteDTO> Get(int id, int IdUsuarioSistema)
        {
            return await _preferente.ObtenerById(id, IdUsuarioSistema);
        }
        [HttpGet("facebook/{usuarioFacebook}")]
        [CustomFilter("000123")]
        public async Task<ActionResult> GetByFacebookUser(String usuarioFacebook)
        {
            try
            {
                var resultado = await _preferente.ObtenerByFacebookUser(usuarioFacebook);
                return Ok(new JsonResponse()
                {
                    Data = resultado,
                    Error = null,
                    Status = StatusCodes.Status200OK
                });
            }
            catch (AlertException ex)
            {
                return Ok(new JsonResponse()
                {
                    Data = null,
                    Error = ex.Message,
                    Status = StatusCodes.Status400BadRequest
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new JsonResponse()
                {
                    Data = null,
                    Error = ex.Message,
                    Status = StatusCodes.Status400BadRequest
                });
            }
        }
        [HttpGet("instagram/{usuarioInstagram}")]
        [CustomFilter("000124")]
        public async Task<ActionResult> GetByInstagramUser(String usuarioInstagram)
        {
            try
            {
                var resultado = await _preferente.ObtenerByInstagramUser(usuarioInstagram);
                return Ok(new JsonResponse()
                {
                    Data = resultado,
                    Error = null,
                    Status = StatusCodes.Status200OK
                });
            }
            catch (AlertException ex)
            {
                return Ok(new JsonResponse()
                {
                    Data = null,
                    Error = ex.Message,
                    Status = StatusCodes.Status400BadRequest
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new JsonResponse()
                {
                    Data = null,
                    Error = ex.Message,
                    Status = StatusCodes.Status400BadRequest
                });
            }
        }
        [HttpPost]
        [CustomFilter("000125")]
        public async Task<Respuesta<PreferenteEnt>> Post(PreferenteEnt model)
        {
            try
            {   
                return await _preferente.Insertar(model);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        [HttpPut]
        [CustomFilter("000126")]
        public async Task<Respuesta<PreferenteEnt>> Put(PreferenteEnt model)
        {
            return await _preferente.Modificar(model);
        }
        [HttpPut("actualizaEstadoVisto")]
        [CustomFilter("000127")]
        public async Task<int> ActualizaEstadoVisto(ListaIdsDTO idsPreferente)
        {
            return await _preferente.ActualizaEstadoVisto(idsPreferente);
        }
        [HttpPut("{action}")]
        [CustomFilter("000128")]
        public async Task<Respuesta<PreferenteEnt>> Asignar(PreferenteEnt model)
        {
            try
            {
                var resultado = await _preferente.Asignar(model);

                MensajeSignalR mensajeSignalR = new MensajeSignalR()
                {
                    Exito = true,
                    Mensaje = TipoAlerta.PreferenteAsignado.ToString(),
                    DatosJSON = JsonSerializer.Serialize(resultado),
                    Tipo = TipoAlerta.PreferenteAsignado
                };
                await _hubContext.Clients.All.SendAsync("mensajeroSignal", mensajeSignalR);

                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPut("atendido")]
        [CustomFilter("000129")]
        public async Task<Respuesta<PreferenteEnt>> Atendido(PreferenteEnt model)
        {
            try
            {
                var resultado = await _preferente.Atendido(model);

                MensajeSignalR mensajeSignalR = new MensajeSignalR()
                {
                    Exito = true,
                    Mensaje = TipoAlerta.PreferenteAtendido.ToString(),
                    DatosJSON = JsonSerializer.Serialize(resultado),
                    Tipo = TipoAlerta.PreferenteAtendido
                };
                await _hubContext.Clients.All.SendAsync("mensajeroSignal", mensajeSignalR);

                return resultado;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [HttpPost("importarExcel")]
        [CustomFilter("000130")]
        public async Task<ActionResult> ImportarExcel(List<PreferenteImportarDTO> list)
        {
            try
            {
                var resultado = await _preferente.ImportarExcel(list);
                return Ok(new
                {
                    data = resultado,
                    message = "",
                    status = StatusCodes.Status201Created
                });
            }
            catch (SystemException ex)
            {
                return Ok(new
                {
                    data = new { },
                    message = ex.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    data = new { },
                    message = ex.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
        }
        [HttpPost("asignarLista")]
        [CustomFilter("000131")]
        public async Task<ActionResult> AsignarLista(List<PreferenteAsignarListaDTO> list)
        {
            try
            {
                string usuarios = await _preferente.AsignarLista(list);

                MensajeSignalR mensajeSignalR = new MensajeSignalR()
                {
                    Exito = true,
                    Mensaje = TipoAlerta.PreferentesAsignados.ToString(),
                    DatosJSON = JsonSerializer.Serialize(usuarios.Split(',')),
                    Tipo = TipoAlerta.PreferentesAsignados
                };
                await _hubContext.Clients.All.SendAsync("mensajeroSignal", mensajeSignalR);



                return Ok(new
                {
                    data = new { },
                    message = "",
                    status = StatusCodes.Status201Created
                });
            }
            catch (SystemException ex)
            {
                return Ok(new
                {
                    data = new { },
                    message = ex.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    data = new { },
                    message = ex.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
        }
        [HttpGet("numeroAsignados/{idUsuario}/{fecha}")]
        [CustomFilter("000132")]
        public async Task<ActionResult> ObtenerNumeroAsignados(int idUsuario, DateTime fecha)
        {
            try
            {
                int total = await _preferente.ObtenerNumeroAsignados(idUsuario, fecha);
                return Ok(new
                {
                    data = total,
                    message = "",
                    status = StatusCodes.Status200OK
                });
            }
            catch (SystemException ex)
            {
                return Ok(new
                {
                    data = new { },
                    message = ex.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    data = new { },
                    message = ex.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
        }
        [HttpGet("asignadosDelDia")]
        [CustomFilter("000133")]
        public async Task<ActionResult> ObtenerAsignadosDelDia()
        {
            try
            {
                List<PreferenteDTO> total = await _preferente.ObtenerAsignadosDelDia();
                return Ok(new
                {
                    data = total,
                    message = "",
                    status = StatusCodes.Status200OK
                });
            }
            catch (SystemException ex)
            {
                return Ok(new
                {
                    data = new { },
                    message = ex.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    data = new { },
                    message = ex.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
        }
        [HttpGet("pendientes-actuales")]
        [CustomFilter("000134")]
        public async Task<ActionResult> ObtenerPendientesActuales()
        {
            try
            {
                //int total = await _preferente.ObtenerPendientesActuales();
                return Ok(new
                {
                    data = 0,
                    message = "",
                    status = StatusCodes.Status200OK
                });
            }
            catch (SystemException ex)
            {
                return Ok(new
                {
                    data = new { },
                    message = ex.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    data = new { },
                    message = ex.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
        }
        [HttpGet("retornados")]
        [CustomFilter("000135")]
        public async Task<ActionResult> ObtenerRetornados()
        {
            try
            {
                List<PreferenteDTO> total = await _preferente.ObtenerRetornados();
                return Ok(new
                {
                    data = total,
                    message = "",
                    status = StatusCodes.Status200OK
                });
            }
            catch (SystemException ex)
            {
                return Ok(new
                {
                    data = new { },
                    message = ex.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    data = new { },
                    message = ex.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
        }
        [HttpPut("atendiendo/{idPreferente}/{termino}")]
        [CustomFilter("000136")]
        public async Task<ActionResult> AtendiendoPreferente(int idPreferente, int termino)
        {
            try
            {
                await _preferente.AtendiendoPreferente(idPreferente, termino);
                MensajeSignalR mensajeSignalR = new MensajeSignalR()
                {
                    Exito = true,
                    Mensaje = TipoAlerta.AtendiendoPreferente.ToString(),
                    DatosJSON = JsonSerializer.Serialize(new List<Object>()),
                    Tipo = TipoAlerta.AtendiendoPreferente
                };
                await _hubContext.Clients.All.SendAsync("mensajeroSignal", mensajeSignalR);
                return Ok(new
                {
                    data = new { },
                    message = "",
                    status = StatusCodes.Status200OK
                });
            }
            catch (SystemException ex)
            {
                return Ok(new
                {
                    data = new { },
                    message = ex.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    data = new { },
                    message = ex.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
        }
        [HttpPost("formulario-web")]
        [CustomFilter("000137")]
        public async Task<ActionResult> FormularioWeb(FormularioWebDTO model)
        {
            try
            {
                await _preferente.FormularioWeb(model);
                MensajeSignalR mensajeSignalR = new MensajeSignalR()
                {
                    Exito = true,
                    Mensaje = TipoAlerta.NuevoPreferente.ToString(),
                    DatosJSON = JsonSerializer.Serialize(new List<Object>()),
                    Tipo = TipoAlerta.NuevoPreferente
                };
                await _hubContext.Clients.All.SendAsync("mensajeroSignal", mensajeSignalR);
                return Ok(new
                {
                    data = new { },
                    message = "",
                    status = StatusCodes.Status200OK
                });
            }
            catch (SystemException ex)
            {
                return Ok(new
                {
                    data = new { },
                    message = ex.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    data = new { },
                    message = ex.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
        }
        [HttpPost("formulario-web-landing")]
        [AllowAnonymous]
        [LandingFilterAttribute]
        public async Task<ActionResult> FormularioWebLanding(FormularioWebLandingDTO model)
        {
            try
            {
                await _preferente.FormularioWebLanding(model);
                MensajeSignalR mensajeSignalR = new MensajeSignalR()
                {
                    Exito = true,
                    Mensaje = TipoAlerta.NuevoPreferente.ToString(),
                    DatosJSON = JsonSerializer.Serialize(new List<Object>()),
                    Tipo = TipoAlerta.NuevoPreferente
                };
                await _hubContext.Clients.All.SendAsync("mensajeroSignal", mensajeSignalR);
                return Ok(new
                {
                    data = new { },
                    message = "",
                    status = StatusCodes.Status200OK
                });
            }
            catch (SystemException ex)
            {
                return Ok(new
                {
                    data = new { },
                    message = ex.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    data = new { },
                    message = ex.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
        }
        [HttpGet("{idPreferente}/historia")]
        [CustomFilter("000138")]
        public async Task<ActionResult> ObtenerHistoria(int idPreferente)
        {
            try
            {
                List<PreferenteHistoriaDTO> collection = await _preferente.ObtenerHistoria(idPreferente);
                return Ok(new JsonResponse()
                {
                    Data = collection,
                    Error = null,
                    Status = StatusCodes.Status200OK
                });
            }
            catch (SystemException ex)
            {
                return Ok(new JsonResponse()
                {
                    Data = new { },
                    Error = ex.Message,
                    Status = StatusCodes.Status400BadRequest
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new JsonResponse()
                {
                    Data = new { },
                    Error = ex.Message,
                    Status = StatusCodes.Status400BadRequest
                });
            }
        }
        [HttpPut("reasignar")]
        [CustomFilter("000139")]
        public async Task<ActionResult> Put(PreferenteReasignarDTO model)
        {
            try
            {
                await _preferente.Reasignar(model);
                return Ok(new JsonResponse()
                {
                    Data = null,
                    Error = null,
                    Status = StatusCodes.Status200OK
                });
            }
            catch (SystemException ex)
            {
                return Ok(new JsonResponse()
                {
                    Data = new { },
                    Error = ex.Message,
                    Status = StatusCodes.Status400BadRequest
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new JsonResponse()
                {
                    Data = new { },
                    Error = ex.Message,
                    Status = StatusCodes.Status400BadRequest
                });
            }
        }
        [HttpPost("buscar")]
        [CustomFilter("000140")]
        public async Task<List<PreferenteGrillaDTO>> Buscar(BuscarPreferenteDTO model)
        {
            try
            {
                return await _preferente.Buscar(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public class PreferenteMonitor : BackgroundService
        {
            private readonly IPreferenteApp _preferenteApp;
            private readonly IHubContext<SignalHub> _hubContext;
            public PreferenteMonitor(IPreferenteApp IPreferenteApp, IHubContext<SignalHub> hub)
            {
                _preferenteApp = IPreferenteApp;
                _hubContext = hub;
            }

            protected override async Task ExecuteAsync(CancellationToken stoppingToken)
            {
                while (!stoppingToken.IsCancellationRequested)
                {
                    int preferentesSinAtender = await _preferenteApp.ObtenerSinAtender();
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
        }
    }
}

