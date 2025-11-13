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
    public class AlternativaMedicionController : ControllerBase
    {
        private readonly IAlternativaMedicionApp _alternativaMedicionApp;
        public AlternativaMedicionController(IAlternativaMedicionApp AlternativaMedicionApp)
        {
            this._alternativaMedicionApp = AlternativaMedicionApp;
        }

        [HttpGet("{tipo}")]
        [CustomFilter("000185")]
        public async Task<ActionResult> Get(int tipo)
        {
            try
            {
                var collection = await _alternativaMedicionApp.ListarByTipo(tipo);
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
