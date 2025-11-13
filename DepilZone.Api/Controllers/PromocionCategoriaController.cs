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

    public class PromocionCategoriaController : ControllerBase
    {
        private readonly IPromocionCategoriaApp _IPromocionCategoriaApp;        
        public PromocionCategoriaController(IPromocionCategoriaApp IPromocionCategoriaApp)
        {
            this._IPromocionCategoriaApp = IPromocionCategoriaApp;
        }

        [HttpGet()]
        [CustomFilter("000098")]
        public async Task<ActionResult> Listar()
        {
            try
            {
                var output = await _IPromocionCategoriaApp.Listar();
                return Ok(new
                {
                    data = output,
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
        [HttpPost()]
        [CustomFilter("000099")]
        public async Task<ActionResult> Registrar(PromocionCategoriaDTO model)
        {
            try
            {
                var output = await _IPromocionCategoriaApp.Registrar(model);
                return Ok(new
                {
                    data = output,
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
        [CustomFilter("000100")]
        public async Task<ActionResult> Modificar(int id, PromocionCategoriaDTO model)
        {
            try
            {
                var output = await _IPromocionCategoriaApp.Modificar(id, model);
                return Ok(new
                {
                    data = output,
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
