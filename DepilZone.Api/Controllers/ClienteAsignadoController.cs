using DepilZone.Api.CustomFilter;
using DepilZone.Application.Implement;
using DepilZone.Application.Interface;
using DepilZone.Data.Response;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using DepilZone.Entidad.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace DepilZone.Api.Controllers
{
    [Route("api/cliente-asignado")]
    [ApiController]
    [Authorize]

    public class ClienteAsignadoController : ControllerBase
    {
        private readonly IClienteAsignadoApp _clienteAsignadoApp;
        public ClienteAsignadoController(IClienteAsignadoApp IClienteAsignadoApp)
        {
            _clienteAsignadoApp = IClienteAsignadoApp;
        }
        [HttpGet("{tipoCliente}/{idSede}/{fechaCita}/{asignado}")]
        [CustomFilter("000298")]
        public async Task<ActionResult> Get(int tipoCliente, int idSede, DateTime fechaCita, int asignado)
        {
            try
            {
                var data = await _clienteAsignadoApp.ObtenerAsignacion(tipoCliente, idSede, fechaCita, asignado);
                return Ok(new JsonResponse()
                {
                    Data = data,
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
        [CustomFilter("000299")]
        public async Task<int> Post(ClienteAsignarListaDTO model)
        {
            try
            {
                return await _clienteAsignadoApp.Insertar(model);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        [HttpPut("reasignar")]
        [CustomFilter("000300")]
        public async Task<int> Put(ClienteAsignarListaDTO model)
        {
            try
            {
                return await _clienteAsignadoApp.Reasignar(model);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        [HttpGet("asignados/{fechaConfirmacion}/{tipoCliente}/{idTipo}/{idSede}/{asignadoA}/{asignadoPor}")]
        [CustomFilter("000301")]
        public async Task<ActionResult> BuscarAsignados(DateTime fechaConfirmacion, int tipoCliente, int idTipo, int idSede, int asignadoA, int asignadoPor)
        {
            try
            {
                List<ClienteAsignadoDTO> collection = await _clienteAsignadoApp.BuscarAsignados(fechaConfirmacion, tipoCliente, idTipo, idSede, asignadoA, asignadoPor);
                return Ok(new JsonResponse()
                {
                    Data = collection,
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
        [HttpGet("asignados-usuario/{fechaConfirmacion}/{asignadoA}")]
        [CustomFilter("000302")]
        public async Task<ActionResult> BuscarAsignadosUsuario(DateTime fechaConfirmacion, int asignadoA)
        {
            try
            {
                List<ClienteAsignadoDTO> collection = await _clienteAsignadoApp.BuscarAsignadosUsuario(fechaConfirmacion, asignadoA);
                return Ok(new JsonResponse()
                {
                    Data = collection,
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
        [HttpPost("trabajar")]
        [CustomFilter("000303")]
        public async Task<ActionResult> Trabajar(ClienteAsignadoDTO model)
        {
            try
            {
                bool result = await _clienteAsignadoApp.Trabajar(model);

                return Ok(new JsonResponse()
                {
                    Data = result,
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
        [HttpPost("marcar-visto")]
        [CustomFilter("000304")]
        public async Task<ActionResult> MarcarVisto(List<int> model)
        {
            try
            {
                bool result = await _clienteAsignadoApp.MarcarVisto(model);

                return Ok(new JsonResponse()
                {
                    Data = result,
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
        [HttpGet("para-reasignados/{fechaConfirmacion}/{tipoCliente}/{idTipo}/{idSede}/{asignadoA}/{asignadoPor}")]
        [CustomFilter("000305")]
        public async Task<ActionResult> BuscarParaReasignados(DateTime fechaConfirmacion, int tipoCliente, int idTipo, int idSede, int asignadoA, int asignadoPor)
        {
            try
            {
                List<ClienteAsignadoDTO> collection = await _clienteAsignadoApp.BuscarParaReasignados(fechaConfirmacion, tipoCliente, idTipo, idSede, asignadoA, asignadoPor);
                return Ok(new JsonResponse()
                {
                    Data = collection,
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
        [HttpGet("historial/{idClienteAsignado}")]
        [CustomFilter("000306")]
        public async Task<ActionResult> BuscarHistorial(int idClienteAsignado)
        {
            try
            {
                List<ClientAsignadoHistoriaDTO> collection = await _clienteAsignadoApp.ObtenerHistoria(idClienteAsignado);
                return Ok(new JsonResponse()
                {
                    Data = collection,
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
        /*[HttpPost("trabajado")]
        public async Task<bool> Post(ClienteAsignadoDTO model)
        {
            return await _clienteAsignadoApp.Trabajado(model);
        }*/
    }   
}
