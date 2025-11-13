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

    public class EstadoController : ControllerBase
    {
        private readonly IEstadoApp _IEstadoApp;

        public EstadoController(IEstadoApp IEstadoApp)
        {
            _IEstadoApp = IEstadoApp;
        }

        [HttpGet]
        [CustomFilter("000379")]
        public async Task<IEnumerable<EstadoEnt>> Get()
        {
            return await _IEstadoApp.Obtener();
        }
        [HttpGet("{entidad}")]
        [CustomFilter("000380")]
        public async Task<IEnumerable<EstadoEnt>> GetByEntidad(string entidad)
        {
            return await _IEstadoApp.ObtenerByEntidad(entidad);
        }
        [HttpGet("{entidad}/{idEstPadr}")]
        [CustomFilter("000381")]
        public async Task<IEnumerable<EstadoEnt>> selStateByFather(string entidad,int idEstPadr)
        {
            return await _IEstadoApp.selStateByFather(entidad,idEstPadr);
        }
    }
}
