using Microsoft.AspNetCore.Mvc;
using DepilZone.Data.Interface; 
using DepilZone.Entidad.DTO; 
using DepilZone.Application.Responses;
using Microsoft.AspNetCore.Authorization;
using DepilZone.Api.CustomFilter;

namespace DepilZone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FormularioController : ControllerBase
    {
        private readonly IFormularioDat _formularioDat;

        public FormularioController(IFormularioDat formularioDat)
        {
            _formularioDat = formularioDat;
        }

        [HttpGet("tipocliente/{idUsuario}")]
        [CustomFilter("000172")]
        public async Task<ActionResult<ApiResponse<IEnumerable<TipoClienteDTO>>>> ObtenerTipoCliente(int idUsuario)
        {
            var response = new ApiResponse<IEnumerable<TipoClienteDTO>>();

            try
            {
                var tipoClientes = await _formularioDat.ObtenerTipoCliente(idUsuario);

                if (tipoClientes == null || !tipoClientes.Any())
                {
                    response.Status = "NotFound";
                    response.Errors = new List<ErrorResponse>
                    {
                        new ErrorResponse { Code = "404", Message = "No se encontraron tipos de cliente." }
                    };
                    response.Succeeded = false;
                    return NotFound(response);
                }

                response.Status = "Success";
                response.Result = new Result<IEnumerable<TipoClienteDTO>>
                {
                    Data = tipoClientes,
                    Empty = !tipoClientes.Any()
                };
                response.Succeeded = true;
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                response.Status = "Error";
                response.Errors = new List<ErrorResponse>
                {
                    new ErrorResponse { Code = "500", Message = ex.Message }
                };
                response.Succeeded = false;
                return StatusCode(500, response);
            }
        }
        [HttpGet("promociones/{idUsuario}")]
        [CustomFilter("000173")]
        public async Task<ActionResult<ApiResponse<IEnumerable<PromocionFormDTO>>>> ObtenerPromociones(int idUsuario)
        {
            var response = new ApiResponse<IEnumerable<PromocionFormDTO>>();

            try
            {
                var promociones = await _formularioDat.ObtenerPromocion(idUsuario);

                if (promociones == null || !promociones.Any())
                {
                    response.Status = "NotFound";
                    response.Errors = new List<ErrorResponse>
                    {
                        new ErrorResponse { Code = "404", Message = "No se encontraron promociones." }
                    };
                    response.Succeeded = false;
                    return NotFound(response);
                }

                response.Status = "Success";
                response.Result = new Result<IEnumerable<PromocionFormDTO>>
                {
                    Data = promociones,
                    Empty = !promociones.Any()
                };
                response.Succeeded = true;
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                response.Status = "Error";
                response.Errors = new List<ErrorResponse>
                {
                    new ErrorResponse { Code = "500", Message = ex.Message }
                };
                response.Succeeded = false;
                return StatusCode(500, response);
            }
        }
        [HttpGet("servicios/promocion/{idPromocion}/{idUsuario}")]
        [CustomFilter("000174")]
        public async Task<ActionResult> ObtenerServiciosPorPromocion(int idPromocion, int idUsuario)
        {

            var data = await _formularioDat.ObtenerServiciosPorPromocion(idPromocion, idUsuario);

            try
            {

                if (data == null || !data.Any())
                {
                    return Ok(new
                    {
                        data = new { },
                        error = new { },
                        status = 404
                    });
                }
                else
                {
                    return Ok(new
                    {
                        data = data,
                        error = new { },
                        status = 200
                    });
                }                
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }            
        }
        [HttpPost("registrarventa")]
        [CustomFilter("000175")]
        public async Task<ActionResult<ApiResponse<bool>>> RegistrarVenta([FromBody] FormDTO formDTO)
        {
            var response = new ApiResponse<bool>();

            try
            {
                if (formDTO == null)
                {
                    response.Status = "BadRequest";
                    response.Errors =
            [
                new ErrorResponse { Code = "400", Message = "Los datos de la venta no son válidos." }
            ];
                    response.Succeeded = false;
                    return BadRequest(response);
                }

                bool resultado = await _formularioDat.RegistrarVenta(formDTO);

                if (!resultado)
                {
                    response.Status = "InternalServerError";
                    response.Errors =
            [
                new ErrorResponse { Code = "500", Message = "No se pudo registrar la venta." }
            ];
                    response.Succeeded = false;
                    return StatusCode(500, response);
                }

                response.Status = "Success";
                response.Message = "Venta registrada exitosamente."; // Mensaje informativo
                response.Succeeded = true;
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                response.Status = "Error";
                response.Errors =
        [
            new ErrorResponse { Code = "500", Message = ex.Message }
        ];
                response.Succeeded = false;
                return StatusCode(500, response);
            }
        }
        [HttpPost("reporteventa")]
        [CustomFilter("000176")]
        public async Task<ActionResult<ApiResponse<IEnumerable<TipoClienteDTO>>>> ReporteVenta([FromBody] FilterFormDTO filterDTO)
        {
            var response = new ApiResponse<IEnumerable<TipoClienteDTO>>();

            try
            {
                var lstReporteVenta = await _formularioDat.ReporteVenta(filterDTO);

                if (lstReporteVenta.Count > 0)
                {
                    return Ok(new
                    {
                        code = 200,
                        message = "Proceso exitoso",
                        data = lstReporteVenta.ToList()
                    });
                }
                else
                {
                    return Ok(new
                    {
                        code = 400,
                        message = "No se encontraron registros",
                        data = lstReporteVenta
                    });
                }                
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    code = 500,
                    message = ex.Message,
                    data = new object[0]
                });
            }
        }

    }
}
