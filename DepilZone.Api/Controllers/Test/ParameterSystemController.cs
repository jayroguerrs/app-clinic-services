using DepilZone.Application.Interface.Test;
using DepilZone.Application.Responses;
using DepilZone.Domain.Interface.Test;
using DepilZone.Entidad.DTO.Test;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DepilZone.Api.Controllers.Test
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParameterSystemController(IParameterSystemApp parameterSystemApp) : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> Create(ParameterSystemDTO model)
        {
            if (model == null)
            {
                var response = new ApiResponse<ErrorResponse>
                {
                    Status = "error",
                    Errors =
               [
                new() {
                    Code = HttpStatusCode.BadRequest.ToString(),
                    Message = "the body can not be null."
                },
                 new() {
                    Code = HttpStatusCode.BadRequest.ToString(),
                    Message = "The camp Id is required."
                }
                 ],
                    Message = "Errors on the request.",
                    Succeeded = false
                };

                return BadRequest(response);
            }

            try
            {
                var successResponse = await parameterSystemApp.Create(model);

                var response = new ApiResponse<ParameterSystemResponseDTO>
                {
                    Status = "su",
                    Errors = [],
                    Message = "ParameterSystem created successfully.",
                    Succeeded = true
                };

                return Ok(successResponse);
            }
            catch (Exception ex)
            {
                var errorResponse = new ApiResponse<ErrorResponse>
                {
                    Status = "error",
                    Errors =
                    [
                        new() {
                            Code = "500",
                            Message = ex.Message
                        }
                    ],
                    Message = "An error occurred on the server.",
                    Succeeded = false
                };

                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }

    }
}
