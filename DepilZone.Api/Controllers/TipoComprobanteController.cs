using DepilZone.Api.CustomFilter;
using DepilZone.Application.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepilZone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class TipoComprobanteController : ControllerBase
    {
        private readonly ITipoComprobanteApp _ITipoComprobanteApp;

        public TipoComprobanteController(ITipoComprobanteApp iTipoComprobanteApp)
        {
            _ITipoComprobanteApp = iTipoComprobanteApp;
        }

        [HttpGet]
        [CustomFilter("000451")]
        public async Task<IEnumerable<TipoComprobanteEnt>> Get()
        {
            return await _ITipoComprobanteApp.Obtener();
        }
        [HttpGet("{id}")]
        [CustomFilter("000452")]
        public async Task<TipoComprobanteEnt> GetById(int id)
        {
            return await _ITipoComprobanteApp.ObtenerById(id);
        }
        [HttpPost]
        [CustomFilter("000453")]
        public async Task<Respuesta<TipoComprobanteEnt>> Post(TipoComprobanteEnt model)
        {
            return await _ITipoComprobanteApp.Insertar(model);
        }
        [HttpPut]
        [CustomFilter("000454")]
        public async Task<Respuesta<TipoComprobanteEnt>> Put(TipoComprobanteEnt model)
        {
            return await _ITipoComprobanteApp.Modificar(model);
        }
        [HttpGet("punto-venta/{idUsuario}")]
        [CustomFilter("000455")]
        public async Task<ActionResult> GetToPuntoVenta(int idUsuario)
        {
            try
            {
                var collection =  await _ITipoComprobanteApp.ObtenerToPuntoVenta(idUsuario);
                return Ok(new
                {
                    data = collection,
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
