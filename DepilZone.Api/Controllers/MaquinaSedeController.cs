using DepilZone.Api.CustomFilter;
using DepilZone.Application.Interface;
using DepilZone.Entidad;
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

    public class MaquinaSedeController : ControllerBase
    {
        private readonly IMaquinaSedeApp _IMaquinaSedeApp;

        public MaquinaSedeController(IMaquinaSedeApp IMaquinaSedeApp)
        {
            _IMaquinaSedeApp = IMaquinaSedeApp;
        }
        [HttpPost]
        [CustomFilter("000038")]
        public async Task<Respuesta<MaquinaSedeEnt>> Post(MaquinaSedeEnt model)
        {
            return await _IMaquinaSedeApp.Insertar(model);
        }
        [HttpPut]
        [CustomFilter("000039")]
        public async Task<Respuesta<MaquinaSedeEnt>> Put(MaquinaSedeEnt model)
        {
            return await _IMaquinaSedeApp.Modificar(model);
        }
        [HttpGet("{id}")]
        [CustomFilter("000040")]
        public async Task<MaquinaSedeEnt> Get(int id)
        {
            return await _IMaquinaSedeApp.ObtenerById(id);
        }
        [HttpGet("nombre/{nombre}")]
        [CustomFilter("000041")]
        public async Task<IEnumerable<MaquinaSedeGridDTO>> ObtenerByNombre(string nombre)
        {
            return await _IMaquinaSedeApp.ObtenerByNombre(nombre);
        }
        [HttpGet("sede/{idSede}")]
        [CustomFilter("000042")]
        public async Task<IEnumerable<MaquinaSedeGridDTO>> ObtenerBySede(int idSede)
        {
            return await _IMaquinaSedeApp.ObtenerBySede(idSede);
        }
        [HttpGet("{nombre}/{idSede}")]
        [CustomFilter("000043")]
        public async Task<IEnumerable<MaquinaSedeGridDTO>> ObtenerByFiltros(string nombre, int idSede)
        {
            return await _IMaquinaSedeApp.ObtenerByFiltros(nombre, idSede);
        }
        [HttpGet("listadoGrilla/{idEstado}")]
        [CustomFilter("000044")]
        public async Task<IEnumerable<MaquinaSedeGridDTO>> GetListadoGrilla(int idEstado)
        {
            return await _IMaquinaSedeApp.Obtener(idEstado);
        }
        [HttpGet("buscar-por-servicio/{idUsuario}/{idSede}/{idServicio}")]
        [CustomFilter("000045")]
        public async Task<ActionResult> BuscarPorSedeyServicio(int idUsuario, int idSede, int idServicio)
        {
            try
            {
                List<MaquinaSedeGridDTO> collection = await _IMaquinaSedeApp.BuscarPorSedeyServicio(idUsuario, idSede, idServicio);
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
        [HttpGet("buscar-ficticios/{idUsuario}/{idSede}/{idServicio}")]
        [CustomFilter("000046")]
        public async Task<ActionResult> BuscarFicticios(int idUsuario, int idSede, int idServicio)
        {
            try
            {
                List<MaquinaSedeGridDTO> collection = await _IMaquinaSedeApp.BuscarFicticios(idUsuario, idSede, idServicio);
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
