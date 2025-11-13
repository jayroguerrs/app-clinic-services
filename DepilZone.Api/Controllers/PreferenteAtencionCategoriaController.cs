using DepilZone.Api.CustomFilter;
using DepilZone.Application.Interface;
using DepilZone.Data.Response;
using DepilZone.Entidad.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Api.Controllers
{
    [Route("api/preferente-atencion-categoria")]
    [ApiController]
    [Authorize]

    public class PreferenteAtencionCategoriaController : ControllerBase
    {
        private readonly IPreferenteAtencionCategoriaApp _preferenteAtencionCategoria;

        public PreferenteAtencionCategoriaController(IPreferenteAtencionCategoriaApp PreferenteAtencionCategoriaApp)
        {
            _preferenteAtencionCategoria = PreferenteAtencionCategoriaApp;
        }

        [HttpGet("list")]
        [CustomFilter("000141")]
        public async Task<ActionResult> Get()
        {
            try
            {

                List<PreferenteAtencionCategoriaDTO> collection = await _preferenteAtencionCategoria.Listar();

                return Ok(new JsonResponse()
                {
                    Data = collection,
                    Error = null,
                    Status = StatusCodes.Status200OK
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new JsonResponse()
                {
                    Data = null,
                    Error = ex.Message,
                    Status = StatusCodes.Status400BadRequest

                });
            }
        }
       
    }

}

