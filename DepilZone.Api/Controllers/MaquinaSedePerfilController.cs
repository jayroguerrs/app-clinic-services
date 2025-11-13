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
using System.Reflection;
using System.Threading.Tasks;

namespace DepilZone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class MaquinaSedePerfilController : ControllerBase
    {
        private readonly IMaquinaSedePerfilApp _IMaquinaSedePerfilApp;

        public MaquinaSedePerfilController(IMaquinaSedePerfilApp IMaquinaSedePerfilApp)
        {
            _IMaquinaSedePerfilApp = IMaquinaSedePerfilApp;
        }

        [HttpPost]
        [CustomFilter("000410")]
        public async Task<ActionResult> Insertar(MaquinaSedePerfilDTO model)
        {
            try
            {
                var lista = await _IMaquinaSedePerfilApp.Insertar(model);
                return Ok(new
                {
                    data = new { },
                    message = "",
                    status = StatusCodes.Status201Created
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
        [HttpGet("maquina-sede/{idUsuario}/{idMaquinaSede}")]
        [CustomFilter("000411")]
        public async Task<ActionResult> ObtenerByMaquinaSede(int idUsuario, int idMaquinaSede)
        {

            try
            {
                var lista = await _IMaquinaSedePerfilApp.ObtenerByMaquinaSede(idUsuario, idMaquinaSede);
                return Ok(new
                {
                    data = lista,
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
    }
}
