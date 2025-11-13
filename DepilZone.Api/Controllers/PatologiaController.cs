using DepilZone.Api.CustomFilter;
using DepilZone.Application.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class PatologiaController : ControllerBase
    {
        private readonly IPatologiaApp _IPatologiaApp;

        public PatologiaController(IPatologiaApp IPatologiaApp)
        {
            _IPatologiaApp = IPatologiaApp;
        }
     
        [HttpGet("listado")]
        [CustomFilter("000415")]
        public async Task<IEnumerable<PatologiaEnt>> ObtenerListado()
        {
            return await _IPatologiaApp.ObtenerListado();
        }

    }
}
