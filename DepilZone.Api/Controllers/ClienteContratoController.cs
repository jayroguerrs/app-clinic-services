
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DepilZone.Api.CustomFilter;
using DepilZone.Application.Interface;
using DepilZone.Data.Response;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using DepilZone.Entidad.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace DepilZone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class ClienteContratoController : ControllerBase
    {
        private readonly IClienteContratoApp _contrato;
        private RClienteContrato _response;
        public ClienteContratoController(IClienteContratoApp ClienteContratoApp)
        {
            _contrato = ClienteContratoApp;
            _response = new RClienteContrato();
        }
        [HttpPost]
        [CustomFilter("000308")]
        public async Task<ActionResult> GuardarContrato( ClienteContratoDTO model )
        {
            try
            {
                var response = await _contrato.GuardarContrato(model);
                return Ok(new {
                    data = response,
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
                    status = StatusCodes.Status400BadRequest
                });
            }
        }
        [HttpGet("cliente/{idCliente}")]
        [CustomFilter("000309")]
        public async Task<ActionResult> ListarByIdCliente(int idCLiente)
        {
            try
            {
                var collection = await _contrato.ListarByIdCliente(idCLiente);
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
                    status = StatusCodes.Status400BadRequest
                });
            }
        }
        [HttpGet("cliente/{idCliente}/servicio/{idServicio}")]
        [CustomFilter("000310")]
        public async Task<ActionResult> ListarByIdClientePorServicio(int idCLiente, int idServicio)
        {
            try
            {
                var collection = await _contrato.ListarByIdClientePorServicio(idCLiente, idServicio);
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
                    status = StatusCodes.Status400BadRequest
                });
            }
        }
        [HttpPut("anular")]
        [CustomFilter("000311")]
        public async Task<ActionResult> AnularContrato(ClienteContratoDTO model)
        {
            try
            {
                await _contrato.AnularContrato(model.Id, model);
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
        [HttpGet("{idContrato}")]
        [CustomFilter("000312")]
        public async Task<ActionResult> verContrato(int idContrato)
        {
            try
            {
                var response = await _contrato.verContrato(idContrato);
                return Ok(new
                {
                    data = _response.VerContrato(response),
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
                    data = new {},
                    message = ex.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
        }
        [HttpGet("buscar-confirmado/{idContrato}")]
        //[CustomFilter("000313")]
        public async Task<ActionResult> buscarContratoConfirmado(string idContrato)
        {
            try
            {
                var response = await _contrato.BuscarContratoConfirmado(idContrato);
                return Ok(new
                {
                    data = response,
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
        [HttpPut("{idContrato}/{idCliente}/confirmar")]
        //[CustomFilter("000314")]
        public async Task<ActionResult> confirmarContrato(string idContrato, int idCliente)
        {
            try
            {
                var response = await _contrato.ConfirmarContrato(idContrato, idCliente);
                return Ok(new
                {
                    data = response,
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
        [HttpPost("enviarEmail")]
        [CustomFilter("000315")]
        public async Task<ActionResult> sendMailToClient(ClienteContratoDTO model)
        {
            try
            {
                await _contrato.EnviarContratoPorCorreo(model);
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