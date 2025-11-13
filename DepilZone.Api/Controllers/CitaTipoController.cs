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

    public class CitaTipoController : ControllerBase
    {
        private readonly ICitaTipoApp _TipoCita;

        public CitaTipoController(ICitaTipoApp TipoCitaApp)
        {
            this._TipoCita = TipoCitaApp;
        }
        [HttpPost]
        [CustomFilter("000067")]
        public async Task<Respuesta<CitaTipoEnt>> Post(CitaTipoEnt model)
        {
            return await _TipoCita.Insertar(model);
        }
        [HttpPut]
        [CustomFilter("000068")]
        public async Task<Respuesta<CitaTipoEnt>> Put(CitaTipoEnt model)
        {
            return await _TipoCita.Modificar(model);
        }
        [HttpGet]
        [CustomFilter("000069")]
        public async Task<IEnumerable<CitaTipoEnt>> Get()
        {
            return await _TipoCita.Obtener();
        }
        [HttpGet("search/{str}")]
        [CustomFilter("000070")]
        public async Task<IEnumerable<CitaTipoEnt>> LikeNombre(string str)
        {
            return await _TipoCita.ObtenerByLikeNombre(str);
        }
        [HttpGet("{id}")]
        [CustomFilter("000071")]
        public async Task<CitaTipoEnt> Get(int id)
        {
            return await _TipoCita.ObtenerById(id);
        }
    }
}
