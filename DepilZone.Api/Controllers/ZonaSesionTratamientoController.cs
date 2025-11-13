using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using DepilZone.Api.CustomFilter;
using DepilZone.Application.Interface;
using DepilZone.Data.Response;
using DepilZone.Entidad.DTO;
using DepilZone.Entidad.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DepilZone.Api.Controllers
{
    [Route("api/zona-sesion-tratamiento")]
    [ApiController]
    [Authorize]
    public class ZonaSesionTratamientoController : ControllerBase
    {
        private readonly IZonaSesionTratamientoApp _zonaTratamiento;

        public ZonaSesionTratamientoController(IZonaSesionTratamientoApp ZonaApp)
        {
            this._zonaTratamiento = ZonaApp;
        }

        [HttpGet("collection/{idUsuario}/{idZona}")]
        [CustomFilter("000507")]
        public async Task<ActionResult> ObtenerByZona(int idUsuario, int idZona)
        {
            try
            {
                List<ZonaSesionTratamientoDTO> respuesta = await _zonaTratamiento.ObtenerByZona(idZona, idUsuario);
                return Ok(new JsonResponse()
                {
                    Data = respuesta,
                    Error = null,
                    Status = StatusCodes.Status200OK
                });
            }
            catch (AlertException e)
            {
                return Ok(new JsonResponse()
                {
                    Data = null,
                    Error = e.Message,
                    Status = StatusCodes.Status400BadRequest
                });
            }
            catch (Exception e)
            {
                return BadRequest(new JsonResponse()
                {
                    Data = null,
                    Error = e.Message,
                    Status = StatusCodes.Status400BadRequest
                });
            }
        }
        [HttpGet("list/{idUsuario}/{idZona}/{sesion}")]
        [CustomFilter("000508")]
        public async Task<ActionResult> ObtenerByZonaSesion(int idUsuario, int idZona, int sesion)
        {
            try
            {
                List<ZonaTratamientoDTO> respuesta = await _zonaTratamiento.ObtenerByZonaSesion(idZona, idUsuario, sesion);
                return Ok(new JsonResponse()
                {
                    Data = respuesta,
                    Error = null,
                    Status = StatusCodes.Status200OK
                });
            }
            catch (AlertException e)
            {
                return Ok(new JsonResponse()
                {
                    Data = null,
                    Error = e.Message,
                    Status = StatusCodes.Status400BadRequest
                });
            }
            catch (Exception e)
            {
                return BadRequest(new JsonResponse()
                {
                    Data = null,
                    Error = e.Message,
                    Status = StatusCodes.Status400BadRequest
                });
            }
        }
        [HttpPost]
        [CustomFilter("000509")]
        public async Task<ActionResult> Insertar(ZonaSesionTratamientosDTO model)
        {
            try
            {
                bool respuesta = await _zonaTratamiento.Insertar(model);
                return Ok(new JsonResponse() {
                    Data = respuesta,
                    Error = null,
                    Status = StatusCodes.Status201Created
                });
            }
            catch (AlertException e)
            {
                return Ok(new JsonResponse() {
                    Data = null,
                    Error = e.Message,
                    Status = StatusCodes.Status400BadRequest
                });
            }
            catch (Exception e)
            {
                return BadRequest(new JsonResponse() {
                    Data = null,
                    Error = e.Message,
                    Status = StatusCodes.Status400BadRequest
                });
            }
        }
    }
}
