using DepilZone.Api.CustomFilter;
using DepilZone.Data.Interface;
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

    public class MedioContactoController : ControllerBase
    {
        private readonly IMedioContactoApp _IMedioContactoApp;

        public MedioContactoController(IMedioContactoApp IMedioContactoApp)
        {
            this._IMedioContactoApp = IMedioContactoApp;
        }

        [HttpGet]
        [CustomFilter("000412")]
        public async Task<IEnumerable<MedioContactoEnt>> Get()
        {
            return await _IMedioContactoApp.Obtener();
        }
    }
}
