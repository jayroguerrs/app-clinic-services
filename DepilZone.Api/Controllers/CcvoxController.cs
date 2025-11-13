using DepilZone.Api.Hubs;
using DepilZone.Application.Implement;
using DepilZone.Application.Interface;
using DepilZone.Entidad.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace DepilZone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CcvoxController: ControllerBase
    {
        private readonly ICcvoxApp _CcvoxApp;

        public CcvoxController(ICcvoxApp CcvoxApp)
        {
            this._CcvoxApp = CcvoxApp;
        }

        [HttpGet("esCliente/{Numero}")]
        public async Task<ResponseRedirect> EsCliente(string Numero)
        {
            return await _CcvoxApp.EsCliente2(Numero);
        }
    }
}
