using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DepilZone.Api.CustomFilter;
using DepilZone.Application.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DepilZone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ZonaCorporalController : ControllerBase
    {
        private readonly IZonaCorporalApp _zonaCorporal;

        public ZonaCorporalController(IZonaCorporalApp ZonaApp)
        {
            this._zonaCorporal = ZonaApp;
        }

        [HttpGet]
        [CustomFilter("000047")]
        public async Task<IEnumerable<ZonaCorporalGridDTO>> Get()
        {
            return await _zonaCorporal.Obtener();
        }
        [HttpGet("listado")]
        [CustomFilter("000048")]
        public async Task<IEnumerable<ZonaCorporalGridDTO>> ObtenerListado()
        {
            try
            {
                return await _zonaCorporal.ObtenerListado();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        [HttpGet("zona-servicio")]
        [CustomFilter("000049")]
        public async Task<IEnumerable<ZonaServicio>> ObtenerListadoZonaCorporalServicio()
        {
            try
            {
                return await _zonaCorporal.ObtenerListadoZonaCorporalServicio();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        [HttpGet("servicio/{idServicio}")]
        [CustomFilter("000050")]
        public async Task<ActionResult> ObtenerListadoByServicio(int idServicio)
        {
            try
            {
                var collection = await _zonaCorporal.ObtenerListadoByServicio(idServicio);
                return Ok(new
                {
                    data = collection,
                    message = "",
                    status = StatusCodes.Status200OK
                });
            }
            catch (Exception e)
            {
                return BadRequest(new
                {
                    data = new { },
                    message = e.Message,
                    status = StatusCodes.Status400BadRequest
                });
                //throw e;
            }
        }
        [HttpGet("search/{str}")]
        [CustomFilter("000051")]
        public async Task<IEnumerable<ZonaCorporalGridDTO>> LikeNombre(string str)
        {
            return await _zonaCorporal.ObtenerByNombre(str);
        }
        [HttpGet("{id}")]
        [CustomFilter("000052")]
        public async Task<ZonaCorporalEnt> Get(int id)
        {
            return await _zonaCorporal.ObtenerById(id);
        }
        [HttpPost]
        [CustomFilter("000053")]
        public async Task<Respuesta<ZonaCorporalDTO>> Post(ZonaCorporalDTO model)
        {
            try
            {
                return await _zonaCorporal.Insertar(model);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        [HttpPut]
        [CustomFilter("000054")]
        public async Task<Respuesta<ZonaCorporalDTO>> Put(ZonaCorporalDTO model)
        {
            try
            {
                return await _zonaCorporal.Modificar(model);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        [HttpGet("zonaspromocion/{id}")]
        [CustomFilter("000055")]
        public async Task<IEnumerable<ZonaPromocionEnt>> ObtenerZonas_PromocionByIdZona(int id)
        {
            return await _zonaCorporal.ObtenerZonas_PromocionByIdZona(id);
        }
        [HttpGet("promocionesPorZonas/{idsZonas}")]
        [CustomFilter("000056")]
        public async Task<IEnumerable<ZonaPromocionEnt>> Obtener_PromocionesPorZonasCorporales(string idsZonas)
        {
            return await _zonaCorporal.Obtener_PromocionesPorZonasCorporales(idsZonas);
        }
        [HttpGet("genero/{id}")]
        [CustomFilter("000057")]
        public async Task<IEnumerable<ZonaCorporalDTO>> ObtenerZonaByGenero(int id)
        {
            return await _zonaCorporal.ObtenerByGenero(id);
        }
        [HttpGet("genero-servicio/{idGenero}/{idServicio}")]
        [CustomFilter("000058")]
        public async Task<IEnumerable<ZonaCorporalDTO>> ObtenerZonaByGeneroByServicio(int idGenero, int idServicio)
        {
            try
            {
                return await _zonaCorporal.ObtenerByGeneroByServicio(idGenero, idServicio);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet("genero/{id}/{idpromocion}")]
        [CustomFilter("000059")]
        public async Task<IEnumerable<ZonaCorporalDTO>> ObtenerZonaByGeneroByPromocion(int id, int idpromocion)
        {
            return await _zonaCorporal.ObtenerByGeneroByPromocion(id, idpromocion);
        }
        [HttpGet("genero/{id}/{idpromocion}/{idServicio}")]
        [CustomFilter("000060")]
        public async Task<IEnumerable<ZonaCorporalDTO>> ObtenerZonaByGeneroByPromocionByServicio(int id, int idpromocion, int idServicio)
        {
            return await _zonaCorporal.ObtenerByGeneroByPromocionByServicio(id, idpromocion, idServicio);
        }
        [HttpGet("cita/{idcita}")]
        [CustomFilter("000061")]
        public async Task<IEnumerable<ZonaCitaEnt>> ObtenerZonaByCita(int idcita)
        {
            return await _zonaCorporal.ObtenerZonaByCita(idcita);
        }
        [HttpGet("{idZona}/listarZonas")]
        [CustomFilter("000062")]
        public async Task<IEnumerable<ZonaCorporalDTO>> ObtenerZonasParaSubZonaByGenero(int idZona)
        {
            return await _zonaCorporal.ObtenerZonasParaSubZonaByGenero(idZona);
        }
        [HttpPut("{id}/subZonas")]
        [CustomFilter("000063")]
        public async Task<Respuesta<ZonaCorporalDTO>> AssignSubZones(int id, int[] idZones)
        {
            return await _zonaCorporal.AsignarSubZonas(id, idZones);
        }
        [HttpGet("{id}/subZonas")]
        [CustomFilter("006064")]
        public async Task<ActionResult<IEnumerable<ZonaCorporalDTO>>> FindSubZones(int id)
        {
            try
            {
                var zonas = await _zonaCorporal.ObtenerSubZonasById(id);
                return Ok(new{
                    data = zonas,
                    message = "",
                    status = 200
                });
            }
            catch (Exception e)
            {
                return BadRequest(new {
                    data = new { },
                    message = e.Message,
                    status = 400
                });
            }
        }
        [HttpGet("cantidad/{fechaInicio}/{fechaFin}/{idSede}/{idGenero}/{numeroSesion}/{idTipo}")]
        [CustomFilter("000065")]
        public async Task<ActionResult> ObtenerCantidad(DateTime fechaInicio, DateTime fechaFin, int idSede, int idGenero, int numeroSesion, int idTipo)
        {
            try
            {
                List<ZonaCantidad> zonas = await _zonaCorporal.ObtenerCantidad(fechaInicio, fechaFin, idSede, idGenero, numeroSesion, idTipo);
                return Ok(new
                {
                    data = zonas,
                    message = "",
                    status = 200
                });
            }
            catch (Exception e)
            {
                return BadRequest(new
                {
                    data = new { },
                    message = e.Message,
                    status = 400
                });
            }
        }
        [HttpGet("top10/cantidad/{fechaInicio}/{fechaFin}/{idSede}/{idGenero}/{numeroSesion}/{idTipo}")]
        [CustomFilter("000066")]
        public async Task<ActionResult> ObtenerTop10Cantidad(DateTime fechaInicio, DateTime fechaFin, int idSede, int idGenero, int numeroSesion, int idTipo)
        {
            try
            {
                List<ZonaCantidad> zonas = await _zonaCorporal.ObtenerTop10Cantidad(fechaInicio, fechaFin, idSede, idGenero, numeroSesion, idTipo);
                return Ok(new
                {
                    data = zonas,
                    message = "",
                    status = 200
                });
            }
            catch (Exception e)
            {
                return BadRequest(new
                {
                    data = new { },
                    message = e.Message,
                    status = 400
                });
            }
        }
    }
}
