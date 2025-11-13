using DepilZone.Api.CustomFilter;
using DepilZone.Application.Implement;
using DepilZone.Application.Interface;
using DepilZone.Entidad.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DepilZone.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]

    public class PermisosController : ControllerBase
    {
        private readonly IPermisosApp _IPermisosApp;

        public PermisosController(IPermisosApp IPermisosApp)
        {
            _IPermisosApp = IPermisosApp;
        }

        // Método GET para obtener los permisos de un usuario
        [HttpPost("obtener-permisos")]
        [CustomFilter("000420")]
        public async Task<IActionResult> ObtenerPermisos([FromBody] PermisosDTO model)
        {
            var permisos = await _IPermisosApp.ObtenerPermisosPorId(model.IdUsuario, model.Permisos);

            if (permisos != null)
            {
                return Ok(new 
                { 
                    Status = "Success", 
                    Result = permisos, 
                    Message = "Datos obtenidos correctamente" 
                });
            }
            else
            {
                return BadRequest(new 
                { 
                    Status = "Error", 
                    Message = "No se encontraron permisos para este usuario" 
                });
            }
        }
    }
}
