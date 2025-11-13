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

    public class PromocionBloqueController : ControllerBase
    {
        private readonly IPromocionBloqueApp _IPromocionBloque;
        public PromocionBloqueController(IPromocionBloqueApp IPromocionBloque)
        {
            _IPromocionBloque = IPromocionBloque;
        }
        [HttpGet("obtenerByIdpromocion/{id}")]
        [CustomFilter("000096")]
        public async Task<IEnumerable<PromocionBloqueEnt>> ObtenerByIdpromocion(int id)
        {
            return await _IPromocionBloque.ObtenerByIdPromocion(id);
        }
        [HttpPost("grabarPlantillas")]
        [CustomFilter("000097")]
        public async Task<IEnumerable<PromocionBloqueEnt>> GrabarPlantillas(IList<PromocionBloqueEnt> promocionBloques )
        {
            return await _IPromocionBloque.GrabarPlantillas(promocionBloques);
        }
    }
}
