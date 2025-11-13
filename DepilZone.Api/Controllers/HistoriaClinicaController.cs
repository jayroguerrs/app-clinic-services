using DepilZone.Api.CustomFilter;
using DepilZone.Application.Interface;
using DepilZone.Data.Response;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class HistoriaClinicaController : ControllerBase
    {
        private readonly IHistoriaClinicaApp _historiaClinicaApp;
        private RHistoriaClinica _response;

        public HistoriaClinicaController(IHistoriaClinicaApp HistoriaClinicaApp)
        {
            _historiaClinicaApp = HistoriaClinicaApp;
            _response = new RHistoriaClinica();
        }

        [HttpGet("cliente/{idCliente}/lista")]
        [CustomFilter("000396")]
        public async Task<ActionResult> ListarByCliente(int idCliente)
        {
            try
            {
                var collection = await _historiaClinicaApp.ListarByCliente(idCliente);
                return Ok(new
                {
                    data = _response.RespuestaListarByCliente(collection),
                    message = "",
                    status = 200
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    data = new { },
                    message = ex.Message,
                    status = 400
                });
            }
        }
        [HttpGet("cliente/{idCliente}/servicio/{idServicio}/lista")]
        [CustomFilter("000397")]
        public async Task<ActionResult> ListarByClientePorServicio(int idCliente, int idServicio)
        {
            try
            {
                var collection = await _historiaClinicaApp.ListarByClientePorServicio(idCliente, idServicio);
                return Ok(new
                {
                    data = _response.RespuestaListarByCliente(collection),
                    message = "",
                    status = 200
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    data = new { },
                    message = ex.Message,
                    status = 400
                });
            }
        }
        [HttpGet("cliente/{idCliente}")]
        [CustomFilter("000398")]
        public async Task<ActionResult> ObtenerDetallesCliente(int idCliente)
        {
            try
            {
                var detalles = await _historiaClinicaApp.ObtenerDetallesCliente(idCliente);
                return Ok(new
                {
                    data = _response.RespuestaByHistoria(detalles),
                    message = "",
                    status = 200
                });
            }
            catch (SystemException ex)
            {
                return Ok(new
                {
                    data = new { },
                    message = ex.Message,
                    status = 400
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    data = new { },
                    message = ex.Message,
                    status = 400
                });
            }
        }
        [HttpGet("{idFichaAdmision}")]
        [CustomFilter("000399")]
        public async Task<ActionResult> ObtenerDetallesById(int idFichaAdmision)
        {
            try
            {
                var detalles = await _historiaClinicaApp.ObtenerDetallesById(idFichaAdmision);
                return Ok(new
                {
                    data = _response.RespuestaByHistoria(detalles),
                    message = "",
                    status = 200
                });
            }
            catch (SystemException ex)
            {
                return Ok(new
                {
                    data = new { },
                    message = ex.Message,
                    status = 400
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    data = new { },
                    message = ex.Message,
                    status = 400
                });
            }
        }
        [HttpPost]
        [CustomFilter("000400")]
        public async Task<ActionResult> Insertar(HistoriaClinicaDTO model)
        {
            try
            {
                var historia = await _historiaClinicaApp.Insertar(model);
                return Ok(new
                {
                    data = _response.RespuestaInsertar(historia),
                    message = "",
                    status = 200
                });
            }
            catch (SystemException ex)
            {
                return Ok(new
                {
                    data = new { },
                    message = ex.Message,
                    status = 400
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    data = new { },
                    message = ex.Message,
                    status = 400
                });
            }
        }
        [HttpPut("anular/{idHistoria}/{idUsuario}")]
        [CustomFilter("000401")]
        public async Task<ActionResult> Anular(int idHistoria, int idUsuario)
        {
            try
            {
                var respuesta = await _historiaClinicaApp.Anular(idHistoria, idUsuario);
                return Ok(new
                {
                    data = respuesta,
                    message = "",
                    status = 200
                });
            }
            catch (SystemException ex)
            {
                return Ok(new
                {
                    data = new { },
                    message = ex.Message,
                    status = 400
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    data = new { },
                    message = ex.Message,
                    status = 400
                });
            }
        }
    }
}
