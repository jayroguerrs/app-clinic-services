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
    public class FacturaDatosClienteController : ControllerBase
    {

        private readonly IFacturaDatosClienteApp _DatosClienteApp;
        public FacturaDatosClienteController(IFacturaDatosClienteApp FacturaDatosClienteApp)
        {
            _DatosClienteApp = FacturaDatosClienteApp;
        }

        [HttpGet("lista/{idUsuario}/{idCliente}")]
        public async Task<ActionResult> Listar(int IdUsuario, int IdCliente)
        {
            try
            {
                var lista = await _DatosClienteApp.ListarByCliente(IdUsuario, IdCliente);
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


        [HttpGet("lista2/{idUsuario}/{idCliente}")]
        public async Task<ActionResult> ListarByCliente2(int IdUsuario, int IdCliente)
        {
            try
            {
                var lista = await _DatosClienteApp.ListarByCliente2(IdUsuario, IdCliente);
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
        public async Task<ActionResult> Registrar(FacturaDatosClienteDTO model)
        {

            try
            {
                await _DatosClienteApp.Registrar(model);
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
        public async Task<ActionResult> Modificar(int id, FacturaDatosClienteDTO model)
        {
            try
            {
                await _DatosClienteApp.Modificar(id, model);
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
                var data = await _DatosClienteApp.Buscar(id,idUsuario);
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

        [HttpGet("predeterminado/{idCliente}/{idTipocomprobante}/{idUsuario}")]
        public async Task<ActionResult> BuscarPredeterminado(int idCliente, int idTipocomprobante, int idUsuario)
        {
            try
            {
                var data = await _DatosClienteApp.BuscarPredeterminado(idCliente, idTipocomprobante, idUsuario);
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


        [HttpGet("buscar/{numeroDocumento}/{idUsuario}")]
        public async Task<ActionResult> BuscarPorNumeroDocumento(string numeroDocumento, int idUsuario)
        {
            try
            {
                var data = await _DatosClienteApp.BuscarPorNumeroDocumento(numeroDocumento, idUsuario);
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
