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
    [Route("api/zona-tratamiento")]
    [ApiController]
    [Authorize]
    public class ZonaTratamientoController : ControllerBase
    {
        private readonly IZonaTratamientoApp _zonaTratamiento;

        public ZonaTratamientoController(IZonaTratamientoApp ZonaApp)
        {
            this._zonaTratamiento = ZonaApp;
        }

        [HttpGet("collection/{idUsuario}")]
        [CustomFilter("000168")]
        public async Task<ActionResult> Obtener(int idUsuario)
        {
            try
            {
                List<ZonaTratamientoDTO> respuesta = await _zonaTratamiento.Obtener(idUsuario);
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
        [HttpGet("list/{idServicio}/{idUsuario}")]
        [CustomFilter("000169")]
        public async Task<ActionResult> ObtenerListadoPorServicio(int idServicio, int idUsuario)
        {

            try
            {
                List<ZonaTratamientoDTO> respuesta = await _zonaTratamiento.ObtenerListadoByServicio(idServicio, idUsuario);
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
        [CustomFilter("000170")]
        public async Task<ActionResult> Insertar(ZonaTratamientoDTO model)
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
        [HttpPut]
        [CustomFilter("000171")]
        public async Task<ActionResult> Modificar(ZonaTratamientoDTO model)
        {
            try
            {
                bool respuesta = await _zonaTratamiento.Modificar(model);
                return Ok(new JsonResponse() {
                    Data = respuesta,
                    Error = null,
                    Status = StatusCodes.Status200OK
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
