using DepilZone.Api.CustomFilter;
using DepilZone.Application.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using DepilZone.Entidad.Exceptions;
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

    public class FichaAdmisionController : ControllerBase
    {
        private readonly IFichaAdmisionApp _fichaAdmision;
        public FichaAdmisionController(IFichaAdmisionApp FichaAdmisionApp)
        {
            this._fichaAdmision = FichaAdmisionApp;
        }

        //[HttpPost]
        //public async Task<Respuesta<FichaAdmisionEnt>> Post(FichaAdmisionEnt model)
        //{
        //    return await _fichaAdmision.Insertar(model);
        //}

        [HttpGet("editar/{idFichaAdmision}")]
        [CustomFilter("000393")]
        public async Task<ActionResult> ObtenerFichaById(int idFichaAdmision)
        {
            try
            {
                var ficha = await _fichaAdmision.ObtenerFichaById(idFichaAdmision);
                return Ok(new
                {
                    data = ficha,
                    message = "",
                    status = 200
                });
            }
            catch (AlertException ex)
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

        [HttpPut("editar/{idFichaAdmision}")]
        [CustomFilter("000394")]
        public async Task<ActionResult> EditarFichaAdmision(FichaAdmisionDTO model)
        {
            try
            {
                var ficha = await _fichaAdmision.EditarFichaAdmision(model);
                return Ok(new
                {
                    data = ficha,
                    message = "",
                    status = 200
                });
            }
            catch (AlertException ex)
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
