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
using System.Threading.Tasks;

namespace DepilZone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class PromocionZonaController : ControllerBase
    {
        private readonly IPromocionZonaApp _IPromocionZonaApp;
        public PromocionZonaController(IPromocionZonaApp IPromocionZonaApp)
        {
            this._IPromocionZonaApp = IPromocionZonaApp;
        }

        [HttpGet("{idPromocion}/{idGenero}")]
        [CustomFilter("000110")]
        public async Task<IEnumerable<PromocionZonaDTO>> Get(int idPromocion, int idGenero)
        {
            return await _IPromocionZonaApp.Obtener(idPromocion, idGenero);
        }
        [HttpGet("servicio/{idServicio}/{idPromocion}/{idGenero}")]
        [CustomFilter("000111")]
        public async Task<IEnumerable<PromocionZonaDTO>> ObtenerByServicio(int idServicio, int idPromocion, int idGenero)
        {
            return await _IPromocionZonaApp.ObtenerByServicio( idServicio, idPromocion, idGenero);
        }
        [HttpGet("zonasCorporales/{idsZonasCorporales}")]
        [CustomFilter("000112")]
        public async Task<IEnumerable<PromocionZonaDTO>> GetByIdsZonasCorporales(string idsZonasCorporales)
        {
            return await _IPromocionZonaApp.ObtenerByIdsZonasCorporales(idsZonasCorporales);
        }
        [HttpGet("zona/{idZona}")]
        [CustomFilter("000113")]
        public async Task<ActionResult> ListarByZona(int idZona)
        {
            try
            {
                return Ok(new
                {
                    data = await _IPromocionZonaApp.ListarByZona(idZona),
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
        [HttpPut]
        [CustomFilter("000114")]
        public async Task<Respuesta<PromocionZonaEnt>> Put(PromocionZonaEnt model)
        {
            return await _IPromocionZonaApp.ModificarPrecioBase(model);
        }
        [HttpPost]
        [CustomFilter("000115")]
        public async Task<Respuesta<PromocionZonaDTO>> Post(PromocionZonaEnt model)
        {
            return await _IPromocionZonaApp.Insertar(model);
        }
        [HttpDelete("{id}")]
        [CustomFilter("000116")]
        public async Task<Respuesta<PromocionZonaEnt>> Delete(int id)
        {
            return await _IPromocionZonaApp.DeleteById(id);
        }
        [HttpPut("lista")]
        [CustomFilter("000117")]
        public async Task<ActionResult> DeleteByIds(PromocionDeleteIds model)
        {

            try
            {
                var data = await _IPromocionZonaApp.DeleteByIds(model.Ids);
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