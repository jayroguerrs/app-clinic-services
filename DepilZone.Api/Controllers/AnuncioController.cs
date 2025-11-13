using DepilZone.Api.CustomFilter;
using DepilZone.Application.Interface;
using DepilZone.Entidad;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DepilZone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AnuncioController : ControllerBase
    {
        private readonly IAnuncioApp _anuncio;
        public AnuncioController(IAnuncioApp AnuncioApp)
        {
            this._anuncio = AnuncioApp;
        }
        
        [HttpPost]
        [CustomFilter("000001")]
        public async Task<Respuesta<AnuncioEnt>> Post(AnuncioEnt model)
        {
            return await _anuncio.Insertar(model);
        }
        [HttpPut]
        [CustomFilter("000002")]
        public async Task<Respuesta<AnuncioEnt>> Put(AnuncioEnt model)
        {
            return await _anuncio.Modificar(model);
        }
        [HttpGet]
        [CustomFilter("000003")]
        public async Task<IEnumerable<AnuncioEnt>> Get()
        {
            return await _anuncio.Obtener();
        }
        [HttpGet("{id}")]
        [CustomFilter("000004")]
        public async Task<AnuncioEnt> Get(int id)
        {
            return await _anuncio.ObtenerById(id);
        }
    }
}
