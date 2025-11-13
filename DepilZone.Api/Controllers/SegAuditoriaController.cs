using DepilZone.Api.CustomFilter;
using DepilZone.Application.Interface;
using DepilZone.Entidad.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DepilZone.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class SegAuditoriaController : ControllerBase
    {
        private readonly ISegAuditoriaApp _segAuditoriaApp;
        public SegAuditoriaController(ISegAuditoriaApp segAuditoriaApp)
        {
            this._segAuditoriaApp = segAuditoriaApp;
        }

        [HttpPost]
        [CustomFilter("000443")]
        public async Task<IActionResult> Registrar(SegAuditoriaDTO model)
        {
            try
            {                
                var data = await _segAuditoriaApp.Insertar(model);

                if (data)
                {
                    return Ok(new
                    {
                        data = "",
                        error = new { },
                        status = StatusCodes.Status200OK,
                        message = "Registro exitoso"
                    });
                }
                else {
                    return BadRequest(new
                    {
                        data = "",
                        error = new { },    
                        status = StatusCodes.Status400BadRequest,
                        message = "Error al registrar"
                    });
                }                                
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    data = "",
                    error = new { },
                    status = StatusCodes.Status500InternalServerError,
                    message = ex.Message
                });
            }
        }
    }
}
