using DepilZone.Application.Interface.Facturacion;
using DepilZone.Entidad.DTO.Facturacion;
using DepilZone.Entidad.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DepilZone.Api.Controllers.Facturacion
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComprobanteSerieController : ControllerBase
    {

        private readonly IComprobanteSerieApp _ComprobanteSerie;
        public ComprobanteSerieController(IComprobanteSerieApp ComprobanteSerieApp)
        {
            _ComprobanteSerie = ComprobanteSerieApp;
        }

        [HttpGet("lista/{idUsuario}")]
        public async Task<ActionResult> Listar(int IdUsuario)
        {
            try
            {
                var lista = await _ComprobanteSerie.Listar(IdUsuario);
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

        [HttpGet("lista2/{idUsuario}")]
        public async Task<ActionResult> Listar2(int IdUsuario)
        {
            try
            {
                var lista = await _ComprobanteSerie.Listar2(IdUsuario);
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



        [HttpGet("listar-sede-tipo/{idUsuario}/{idSede}/{idTipoComprobante}")]
        public async Task<ActionResult> ListarBySedeTipoComprobante(int idUsuario, int idSede, int idTipoComprobante)
        {
            try
            {
                var lista = await _ComprobanteSerie.ListarBySedeTipoComprobante(idUsuario, idSede, idTipoComprobante);
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



        [HttpGet("listar-tipo/{idUsuario}/{idTipoComprobante}")]
        public async Task<ActionResult> ListarByTipoComprobante(int idUsuario, int idTipoComprobante)
        {
            try
            {
                var lista = await _ComprobanteSerie.ListarByTipoComprobante(idUsuario, idTipoComprobante);
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


        [HttpGet("listar-nota-credito/{idUsuario}")]
        public async Task<ActionResult> ListarToNotaCredito(int idUsuario)
        {
            try
            {
                var lista = await _ComprobanteSerie.ListarToNotaCredito(idUsuario);
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
        public async Task<ActionResult> Registrar(ComprobanteSerieDTO model)
        {

            try
            {
                await _ComprobanteSerie.Registrar(model);
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
        public async Task<ActionResult> Modificar(int id, ComprobanteSerieDTO model)
        {
            try
            {
                await _ComprobanteSerie.Modificar(id, model);
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


        [HttpGet("{id}/{idUsuario}")]
        public async Task<ActionResult> Buscar(int id, int idUsuario)
        {
            try
            {
                var data = await _ComprobanteSerie.Buscar(id,idUsuario);
                return Ok(new
                {
                    data = data,
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
