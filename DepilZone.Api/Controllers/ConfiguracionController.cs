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

    public class ConfiguracionController : ControllerBase
    {
        private readonly IConfiguracionApp _configuracion;
        public ConfiguracionController(IConfiguracionApp ConfiguracionApp)
        {
            this._configuracion = ConfiguracionApp;
        }
        [HttpPost]
        [CustomFilter("000334")]
        public async Task<Respuesta<ConfiguracionEnt>> Post(ConfiguracionEnt model)
        {
            return await _configuracion.Insertar(model);
        }
        [HttpPut("{IdConfiguracion}")]
        [CustomFilter("000335")]
        public async Task<Respuesta<ConfiguracionEnt>> Put(int IdConfiguracion, ConfiguracionEnt model)
        {
            return await _configuracion.Modificar(model);
        }
        [HttpGet("{IdConfiguracion}")]
        [CustomFilter("000336")]
        public async Task<ConfiguracionEnt> Get(int IdConfiguracion)
        {
            return await _configuracion.ObtenerByIdConfiguracion(IdConfiguracion);
        }
        [HttpGet("search/{str}")]
        [CustomFilter("000337")]
        public async Task<IEnumerable<ConfiguracionEnt>> LikeNombre(string str)
        {
            return await _configuracion.ObtenerByLikeNombre(str);
        }
        [HttpGet("dasdasdas")]
        [CustomFilter("000338")]
        public async Task<IEnumerable<ConfiguracionEnt>> Get()
        {
            return await _configuracion.Obtener();
        }
    }
}
