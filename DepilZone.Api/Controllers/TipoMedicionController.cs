using DepilZone.Api.CustomFilter;
using DepilZone.Application.Interface;
using DepilZone.Entidad.DTO;
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
    public class TipoMedicionController : ControllerBase
    {
        private readonly ITipoMedicionApp _alternativaMedicionApp;
        public TipoMedicionController(ITipoMedicionApp TipoMedicionApp)
        {
            this._alternativaMedicionApp = TipoMedicionApp;
        }

        [HttpGet]
        [CustomFilter("000456")]
        public async Task<ActionResult> Get()
        {
            try
            {
                var collection = await _alternativaMedicionApp.Listar();
                return Ok(new
                {
                    data = collection,
                    mensaje = "",
                    status = StatusCodes.Status200OK
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    data = new { },
                    mensaje = ex.Message,
                    status = StatusCodes.Status400BadRequest
                });
                throw;
            }
        }

    }
}
