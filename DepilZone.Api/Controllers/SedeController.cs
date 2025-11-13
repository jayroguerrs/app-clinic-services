using DepilZone.Api.CustomFilter;
using DepilZone.Application.Interface;
using DepilZone.Entidad;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class SedeController : ControllerBase
    {

        private readonly ISedeApp _sede;
        public SedeController(ISedeApp SedeApp)
        {
            this._sede = SedeApp;
        }
        [HttpGet]
        [CustomFilter("000072")]
        public async Task<IEnumerable<SedeEnt>> Get()
        {
            return await _sede.Obtener();
        }
        [HttpGet("search/{str}")]
        [CustomFilter("000073")]
        public async Task<IEnumerable<SedeEnt>> LikeNombre(string str)
        {
            return await _sede.ObtenerByLikeNombre(str);
        }
        [HttpPost]
        [CustomFilter("000074")]
        public async Task<Respuesta<SedeEnt>> Post(SedeEnt model)
        {
            return await _sede.Insertar(model);
        }
        [HttpGet("{id}")]
        [CustomFilter("000075")]
        public async Task<SedeEnt> Get(int id)
        {
            return await _sede.ObtenerById(id);
        }
        [HttpPut]
        [CustomFilter("000076")]
        public async Task<Respuesta<SedeEnt>> Put(SedeEnt model)
        {
            return await _sede.Modificar(model);
        }
    }
}
