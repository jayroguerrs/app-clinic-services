using DepilZone.Api.CustomFilter;
using DepilZone.Application.Interface;
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

    public class MenuController : ControllerBase
    {
        private readonly IMenuApp _menuApp;
        public MenuController(IMenuApp MenuApp)
        {
            this._menuApp = MenuApp;
        }

        [HttpGet("{idUsuario}")]
        [CustomFilter("000413")]
        public async Task<IEnumerable<MenuDTO>> Get(int idUsuario)
        {
            return await _menuApp.ObtenerParaMenu(idUsuario);
        }

    }
}
