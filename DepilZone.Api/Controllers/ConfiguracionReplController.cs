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

    public class ConfiguracionReplController : ControllerBase
    {
        private readonly IConfiguracionReplApp _configuracionRepl;

        public ConfiguracionReplController(IConfiguracionReplApp ConfiguracionReplApp)
        {
            this._configuracionRepl = ConfiguracionReplApp;
        }

        [HttpPut("{IdConfiguracion}")]
        [CustomFilter("000339")]
        public async Task<Respuesta<ConfiguracionReplEnt>> Put(int IdConfiguracion, ConfiguracionReplEnt model)
        {
            return await _configuracionRepl.Modificar(model);
        }
        [HttpGet("{DNI},{IdConfiguracion}")]
        [CustomFilter("000340")]
        public async Task<ConfiguracionReplEnt> Get(string DNI, string IdConfiguracion)
        {
            return await _configuracionRepl.ObtenerByIdConfiguracionDNI(DNI , IdConfiguracion);
        }
    }
}
