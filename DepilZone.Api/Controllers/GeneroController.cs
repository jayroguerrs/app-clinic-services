using DepilZone.Api.CustomFilter;
using DepilZone.Application.Interface;
using DepilZone.Entidad;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepilZone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class GeneroController : ControllerBase
    {
        public readonly IGeneroApp _IGeneroApp;
        public GeneroController(IGeneroApp IGeneroApp)
        {
            _IGeneroApp = IGeneroApp;
        }

        [HttpGet]
        [CustomFilter("000395")]
        public async Task<IEnumerable<GeneroEnt>> Get()
        {
            return await _IGeneroApp.Obtener();
        }
    }
}
