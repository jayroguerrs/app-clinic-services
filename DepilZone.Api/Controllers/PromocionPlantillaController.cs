using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DepilZone.Api.CustomFilter;
using DepilZone.Application.Interface;
using DepilZone.Entidad;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DepilZone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class PromocionPlantillaController : ControllerBase
    {
        private readonly IPromocionPlantillaApp _PromocionPlantilla;

        public PromocionPlantillaController(IPromocionPlantillaApp PromocionPlantillaApp)
        {
            this._PromocionPlantilla = PromocionPlantillaApp;
        }

        [HttpPost]
        [CustomFilter("000101")]
        public async Task<Respuesta<PromocionPlantillaEnt>> Post(PromocionPlantillaEnt model)
        {
            return await _PromocionPlantilla.Insertar(model);
        }
        [HttpPut("{id}")]
        [CustomFilter("000102")]
        public async Task<Respuesta<PromocionPlantillaEnt>> Put(int id, PromocionPlantillaEnt model)
        {
            return await _PromocionPlantilla.Modificar(model);
        }
        [HttpGet]
        [CustomFilter("000103")]
        public async Task<IEnumerable<PromocionPlantillaEnt>> Get()
        {
            return await _PromocionPlantilla.Obtener();
        }
        [HttpGet("search/{str}")]
        [CustomFilter("000104")]
        public async Task<IEnumerable<PromocionPlantillaEnt>> LikeAlias(string str)
        {
            return await _PromocionPlantilla.ObtenerByLikeAlias(str);
        }
        [HttpGet("{id}")]
        [CustomFilter("000105")]
        public async Task<PromocionPlantillaEnt> Get(int id)
        {
            return await _PromocionPlantilla.ObtenerByIdPlantillaPromocion(id);
        }
    }
}
