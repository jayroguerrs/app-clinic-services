using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DepilZone.Api.CustomFilter;
using DepilZone.Application.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DepilZone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]     
    public class MaquinaController : ControllerBase
    {
        private readonly IMaquinaApp _maquina;
        public MaquinaController(IMaquinaApp UsuarioApp)
        {
            this._maquina = UsuarioApp;
        }

        [HttpPost]
        [CustomFilter("000032")]
        public async Task<Respuesta<MaquinaEnt>> Post(MaquinaEnt model)
        {
            return await _maquina.Insertar(model);
        }
        [HttpPut]
        [CustomFilter("000033")]
        public async Task<Respuesta<MaquinaEnt>> Put(MaquinaEnt model)
        {
            return await _maquina.Modificar(model);
        }
        [HttpGet("{id}")]
        [CustomFilter("000034")]
        public async Task<MaquinaEnt> Get(int id)
        {
            return await _maquina.ObtenerById(id);
        }
        [HttpGet("search/{str}")]
        [CustomFilter("000035")]
        public async Task<IEnumerable<MaquinaEnt>> LikeNombre(string str)
        {
            return await _maquina.ObtenerByLikeNombre(str);
        }
        [HttpGet]
        [CustomFilter("000036")]
        public async Task<IEnumerable<MaquinaEnt>> Get()
        {
            return await _maquina.Obtener();
        }
        [HttpGet("{fechaCita}/{idSede}")]
        [CustomFilter("000037")]
        public async Task<ActionResult> ObtenerMinutos( DateTime fechaCita, int idSede )
        {
            try
            {
                var collection = await _maquina.ObtenerMinutos(fechaCita, idSede);
                return Ok(new { 
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
