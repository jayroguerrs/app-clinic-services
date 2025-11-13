using DepilZone.Api.CustomFilter;
using DepilZone.Application.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using DepilZone.Entidad.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepilZone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CitaAsignadaController : ControllerBase
    {
        private readonly ICitaAsignadaApp _citaAsignadaApp;

        public CitaAsignadaController(ICitaAsignadaApp ICitaAsignadaApp)
        {
            _citaAsignadaApp = ICitaAsignadaApp;
        }

        [HttpPost]
        [CustomFilter("000211")]
        public async Task<int> Post(CitaAsignadaListaDTO model)
        {
            return await _citaAsignadaApp.Insertar(model);
        }
        [HttpGet("{fecha}/{sinAsignar}/{idSede}/{tipoCliente}")]
        [CustomFilter("000212")]
        public async Task<IEnumerable<CitaAsignadaGrillaDTO>> Get(DateTime fecha, bool sinAsignar, int idSede, int tipoCliente)
        {
            return await _citaAsignadaApp.ObtenerCitasAsignacion(fecha, sinAsignar, idSede, tipoCliente);
        }        
        [HttpGet("citas-pasadas/{idSede}/{fechaInicial}/{fechaFinal}/{sinAsignar}/{idEstado}/{idTipoCliente}/{idMotivo}")]
        [CustomFilter("000213")]
        public async Task<IEnumerable<CitaAsignadaGrillaDTO>> ObtenerCitasPasadasAsignacion(int idSede, DateTime fechaInicial, DateTime fechaFinal, bool sinAsignar, int idEstado, int idTipoCliente, int idMotivo)
        {
            try
            {
                return await _citaAsignadaApp.ObtenerCitasPasadasAsignacion(idSede, fechaInicial, fechaFinal, sinAsignar, idEstado, idTipoCliente, idMotivo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        [HttpGet("reasignado/{fecha}/{idUsuarioReasignacion}")]
        [CustomFilter("000214")]
        public async Task<IEnumerable<CitaAsignadaGrillaDTO>> ObtenerCitasAsignada(DateTime fecha, int idUsuarioReasignacion)
        {
            return await _citaAsignadaApp.ObtenerCitasAsignada(fecha, idUsuarioReasignacion);
        }
        [HttpGet("reasignadoByIdUsuario/{tipoAsignacion}/{fechaConfirmacion}/{idUsuarioReasignacion}")]
        [CustomFilter("000215")]
        public async Task<IEnumerable<CitaAsignadaGrillaDTO>> ObtenerByIdUsuario(int tipoAsignacion, DateTime fechaConfirmacion, int idUsuarioReasignacion)
        {
            return await _citaAsignadaApp.ObtenerByIdUsuario(tipoAsignacion, fechaConfirmacion, idUsuarioReasignacion);
        }
        [HttpGet("lista/{fechaConfirmar}/{sinAsignar}/{asignadoA}/{tipoSiguiente}/{asignadoPor}/{idSede}/{idUsuario}/{tipoCliente}")]
        [CustomFilter("000216")]
        public async Task<IEnumerable<CitaAsignadaGrillaDTO>> GetListado(DateTime fechaConfirmar, bool sinAsignar, int asignadoA, int tipoSiguiente, int asignadoPor, int idSede,  int idUsuario, int tipoCliente)
        {
            try
            {
                return await _citaAsignadaApp.ObtenerListado(fechaConfirmar, sinAsignar, asignadoA, tipoSiguiente, asignadoPor, idSede, idUsuario, tipoCliente);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        [HttpGet("reporte/{fechaDesde}/{fechaHasta}/{sinAsignar}/{asignadoA}/{tipoSiguiente}/{asignadoPor}/{idSede}/{idUsuario}")]
        [CustomFilter("000217")]
        public async Task<IEnumerable<CitaAsignadaGrillaDTO>> GetReporte(DateTime fechaDesde, DateTime fechaHasta, bool sinAsignar, int asignadoA, int tipoSiguiente, int asignadoPor, int idSede, int idUsuario)
        {
            try
            {
                return await _citaAsignadaApp.ObtenerReporte(fechaDesde, fechaHasta, sinAsignar, asignadoA, tipoSiguiente, asignadoPor, idSede, idUsuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        [HttpGet("abandonadas/lista/{fechaConfirmar}/{sinAsignar}/{asignadoA}/{asignadoPor}/{idUsuario}")]
        [CustomFilter("000218")]
        public async Task<ActionResult> GetListadoAbandonados(DateTime fechaConfirmar, bool sinAsignar, int asignadoA, int asignadoPor, int idUsuario)
        {
            try
            {
                var collection = await _citaAsignadaApp.ObtenerListadoAbandonados(fechaConfirmar, sinAsignar, asignadoA, asignadoPor, idUsuario);
                return Ok(new
                {
                    data = collection,
                    message = "",
                    status = StatusCodes.Status200OK
                }) ;
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    data = new { },
                    message = ex.Message,
                    status = StatusCodes.Status200OK
                });
            }

        }
        [HttpGet("abandonadas/{fecha}/{sinAsignar}")]
        [CustomFilter("000219")]
        public async Task<ActionResult> GetAbandonadas(DateTime fecha, bool sinAsignar)
        {
            try
            {
                var collection = await _citaAsignadaApp.ObtenerCitasAbandonadasAsignacion(fecha, sinAsignar);
                return Ok(new
                {
                    data = collection,
                    message = "",
                    status = StatusCodes.Status200OK
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    data = new { },
                    message = ex.Message,
                    status = StatusCodes.Status200OK
                });
            }
        }
        [HttpGet("abandonadas/en-espera/{fecha}")]
        [CustomFilter("000220")]
        public async Task<ActionResult> GetAbandonadasEnEspera(DateTime  fecha)
        {
            try
            {
                var collection = await _citaAsignadaApp.ObtenerCitasAbandonadasAsignacionEnEspera(fecha);
                return Ok(new
                {
                    data = collection,
                    message = "",
                    status = StatusCodes.Status200OK
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    data = new { },
                    message = ex.Message,
                    status = StatusCodes.Status200OK
                });
            }
        }
        [HttpGet("abandonadas/reasignadoByIdUsuario/{tipoAsignacion}/{fechaConfirmacion}/{idUsuarioReasignacion}")]
        [CustomFilter("000221")]
        public async Task<ActionResult> ObtenerAbandonadasByIdUsuario(int tipoAsignacion, DateTime fechaConfirmacion, int idUsuarioReasignacion)
        {
            try
            {
                var collection = await _citaAsignadaApp.ObtenerAbandonadasByIdUsuario(tipoAsignacion, fechaConfirmacion, idUsuarioReasignacion);
                return Ok(new
                {
                    data = collection,
                    message = "",
                    status = StatusCodes.Status200OK
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    data = new { },
                    message = ex.Message,
                    status = StatusCodes.Status200OK
                });
            }
        }
        [HttpPost("abandonadas")]
        [CustomFilter("000222")]
        public async Task<int> GuardarAbandonados(CitaAsignadaListaDTO model)
        {
            return await _citaAsignadaApp.GuardarAbandonados(model);
        }
        [HttpPost("abandonadas/en-espera")]
        [CustomFilter("000223")]
        public async Task<int> AsignarAbandonadosEnEspera(CitaAsignadaListaDTO model)
        {
            return await _citaAsignadaApp.AsignarAbandonadosEnEspera(model);
        }
        [HttpPost("cambiarFecha")]
        [CustomFilter("000224")]
        public async Task<ActionResult> CambiarFecha(CitaAsignadaGrillaDTO model)
        {
            try
            {
                var output = await _citaAsignadaApp.CambiarFecha(model);
                return Ok(new
                {
                    data = output,
                    message = "",
                    status = StatusCodes.Status200OK
                });
            }
            catch (AlertException ex)
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
        [HttpPut("marcarVisto")]
        [CustomFilter("000225")]
        public async Task<int> MarcarVisto(List<CitaAsignadaEnt> citaAsignadas) 
        {
            return await _citaAsignadaApp.MarcarVisto(citaAsignadas);
        }
    }   
}
