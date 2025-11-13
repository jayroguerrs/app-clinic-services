using DepilZone.Api.CustomFilter;
using DepilZone.Application.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
namespace DepilZone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class LibroReclamacionController : ControllerBase
    {
        private readonly ILibroReclamacionApp _LibroReclamacion;
        public LibroReclamacionController(ILibroReclamacionApp LibroReclamacionApp)
        {
            this._LibroReclamacion = LibroReclamacionApp;
        }
        [HttpPost]
        [CustomFilter("000408")]
        public async Task<Respuesta<LibroReclamacionDTO>> Post(LibroReclamacionEnt model)
        {
            return await _LibroReclamacion.Insertar(model);
        }
        [HttpGet("plantilla/{idTabla}")]
        [CustomFilter("000409")]
        public async Task<Respuesta<string>> ObtenerPlantilla(int idTabla)
        {
            return await _LibroReclamacion.ObtenerPlantilla(idTabla);
        }
    }
}