using DepilZone.Api.CustomFilter;
using DepilZone.Application.Interface;
using DepilZone.Entidad.DTO;
using DepilZone.Entidad.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DepilZone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TecnologiaController : ControllerBase
    {

        private readonly ITecnologiaApp _Tecnologia;
        public TecnologiaController(ITecnologiaApp TecnologiaApp)
        {
            _Tecnologia = TecnologiaApp;
        }

        [HttpGet]
        [CustomFilter("000148")]
        public async Task<ActionResult> Listar()
        {
            try
            {
                var lista = await _Tecnologia.Listar();
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
                return BadRequest(new { 
                    data = new { },
                    message = ex.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
        }
        [HttpGet("estado/{idEstado}")]
        [CustomFilter("000149")]
        public async Task<ActionResult> ListarByEstado(int idEstado)
        {
            try
            {
                var lista = await _Tecnologia.ListarByEstado(idEstado);
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
        [HttpGet("servicio/{idServicio}")]
        [CustomFilter("000150")]
        public async Task<ActionResult> ListarByServicio(int idServicio)
        {
            try
            {
                var lista = await _Tecnologia.ListarByServicio(idServicio);
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
        [HttpPost]
        [CustomFilter("000151")]
        public async Task<ActionResult> Registrar(TecnologiaDTO model)
        {

            try
            {
                await _Tecnologia.Registrar(model);
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
        [HttpPut("{id}")]
        [CustomFilter("000152")]
        public async Task<ActionResult> Modificar(int id, TecnologiaDTO model)
        {
            try
            {
                await _Tecnologia.Modificar(id, model);
                return Ok(new
                {
                    data = new { },
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
