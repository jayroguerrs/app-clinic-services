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

    public class CronogramaSeguimientoController : ControllerBase
    {
        private readonly ICronogramaSeguimientoApp _CronogramaSeguimiento;

        public CronogramaSeguimientoController(ICronogramaSeguimientoApp citaSeguimientoApp)
        {
            this._CronogramaSeguimiento = citaSeguimientoApp;
        }

        [HttpGet("cronograma/{idCronograma}")]
        [CustomFilter("000346")]
        public async Task<ActionResult> ObtenerByCronograma(int idCronograma)
        {
            try
            {
                List < CronogramaSeguimientoDTO > collection = await _CronogramaSeguimiento.ObtenerByCronograma(idCronograma);
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
    }
}
