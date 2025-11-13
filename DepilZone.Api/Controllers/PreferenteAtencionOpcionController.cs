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
    [Route("api/preferente-atencion-opcion")]
    [ApiController]
    [Authorize]

    public class PreferenteAtencionOpcionController : ControllerBase
    {
        private readonly IPreferenteAtencionOpcionApp _preferenteAtencionCategoria;

        public PreferenteAtencionOpcionController(IPreferenteAtencionOpcionApp PreferenteAtencionOpcionApp)
        {
            _preferenteAtencionCategoria = PreferenteAtencionOpcionApp;
        }

        [HttpGet("categoria/{idCategoria}/listar")]
        [CustomFilter("000142")]
        public async Task<ActionResult> ListarByCategoria(int idCategoria)
        {
            try
            {

                List<PreferenteAtencionOpcionDTO> collection = await _preferenteAtencionCategoria.ListarByCategoria(idCategoria);

                return Ok(new JsonResponse() { 
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

