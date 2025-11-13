using DepilZone.Api.CustomFilter;
using DepilZone.Application.Interface;
using DepilZone.Entidad;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DepilZone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class ParametroSistemaController : ControllerBase
    {
        private readonly IParametroSistemaApp _IParametroSistemaApp;

        public ParametroSistemaController(IParametroSistemaApp parametroSistemaApp)
        {
            this._IParametroSistemaApp = parametroSistemaApp;
        }

        [HttpGet("{Id}")]
        [CustomFilter("000414")]
        public async Task<Respuesta<ParametroSistemaEnt>> ObtenerById(int Id)
        {
            return await _IParametroSistemaApp.ObtenerById(Id);
        }


        [HttpGet("linkQA")]
        public async Task<Respuesta<string>> ObtenerLinkQA()
        {
            return await _IParametroSistemaApp.ObtenerLinkQA();
        }
    }
}
