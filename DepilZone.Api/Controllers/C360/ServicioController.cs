using DepilZone.Api.CustomFilter;
using DepilZone.Application.Interface.C360;
using DepilZone.Entidad.DTO.C360;
using DepilZone.Entidad.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DepilZone.Api.Controllers.C360
{
    [Route("api/c360/[controller]")]
    [ApiController]
    public class ServicioController : ControllerBase
    {

        private readonly IServicioApp _Servicio;
        public ServicioController(IServicioApp ServicioApp)
        {
            _Servicio = ServicioApp;
        }

        [HttpGet]
        [CustomFilter("000540")]
        public async Task<ActionResult> Listar()
        {
            try
            {
                var lista = await _Servicio.Listar();
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
        [CustomFilter("000541")]
        public async Task<ActionResult> ListarByEstado(int idEstado)
        {
            try
            {
                var lista = await _Servicio.ListarByEstado(idEstado);
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
        [CustomFilter("000542")]
        public async Task<ActionResult> Registrar(Servicio360DTO model)
        {

            try
            {
                await _Servicio.Registrar(model);
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
        [CustomFilter("000543")]
        public async Task<ActionResult> Modificar(int id, Servicio360DTO model)
        {
            try
            {
                await _Servicio.Modificar(id, model);
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
        [HttpGet("{id}")]
        [CustomFilter("000544")]
        public async Task<ActionResult> Buscar(int id)
        {
            try
            {
                Servicios360DTO model =  await _Servicio.BuscarById(id);
                return Ok(new
                {
                    data = model,
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
