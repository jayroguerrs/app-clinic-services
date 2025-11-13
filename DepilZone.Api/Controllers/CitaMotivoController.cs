using DepilZone.Api.CustomFilter;
using DepilZone.Application.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
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

    public class CitaMotivoController : ControllerBase
    {
        public readonly ICitaMotivoApp _ICitaMotivoApp;
        public CitaMotivoController(ICitaMotivoApp ICitaMotivoApp)
        {
            _ICitaMotivoApp = ICitaMotivoApp;
        }
        [HttpGet]
        [CustomFilter("000290")]
        public async Task<ActionResult<List<CitaMotivoEnt>>> Listar()
        {
            try
            {
                var collection = await _ICitaMotivoApp.Listar();
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
            }
        }
        [HttpGet("citaEstado/{idCitaEstado}")]
        [CustomFilter("000291")]
        public async Task<ActionResult<List<CitaMotivoEnt>>> ListarByCitaEstado( int idCitaEstado )
        {
            try
            {
                var collection = await _ICitaMotivoApp.ListarByCitaEstado(idCitaEstado);
                return Ok(new{
                    data = collection,
                    mensaje = "",
                    status = StatusCodes.Status200OK
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new{
                    data = new {},
                    mensaje = ex.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
        }
    }
}
