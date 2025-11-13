using DepilZone.Api.CustomFilter;
using DepilZone.Api.Services;
using DepilZone.Application.Interface;
using DepilZone.Application.Responses;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;

namespace DepilZone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]    
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioApp _usuario;
        private readonly TokenService _tokenService;
        public UsuarioController(IUsuarioApp UsuarioApp, TokenService tokenService)
        {
            this._usuario = UsuarioApp;
            _tokenService = tokenService;


        }

        [HttpPost]
        [CustomFilter("000463")]
        public async Task<Respuesta<UsuarioEnt>> Post(UsuarioEnt model)
        {
            return await _usuario.Insertar(model);
        }

        [HttpPut("actualizarDatos")]
        //[CustomFilter("000463")]
        public async Task<UsuarioActualizarDatosDTO> ActualizarDatos(UsuarioActualizarDatosDTO model)
        {
            return await _usuario.ActualizarDatos(model);
        }

        [HttpPut("personalizarClinic")]
        //[CustomFilter("000463")]
        public async Task<PersonalizarClinicDTO> PerzonalizarClinic(PersonalizarClinicDTO model)
        {
            return await _usuario.PerzonalizarClinic(model);
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginDTO model)
        {
            var response = await _usuario.Login(model);
            var apiResponse = new ApiResponse<LoginDTO>();

            if (response.Exito)
            {
                var token = _tokenService.GenerateToken(response.Response);

                apiResponse.Status = "Success";
                apiResponse.Succeeded = true;
                apiResponse.Message = "Login successful.";
                apiResponse.Result = new Result<LoginDTO>
                {
                    Data = response.Response,
                };
                apiResponse.Token = token;

                return Ok(apiResponse);
            }

            apiResponse.Status = "Error";
            apiResponse.Succeeded = false;
            apiResponse.Message = response.Mensaje;
            apiResponse.Errors =
            [
                new() {
                    Code = HttpStatusCode.BadRequest.ToString(),
                    Message = response.Mensaje
                }
            ];

            return BadRequest(apiResponse);
        }
        [HttpPut]
        [CustomFilter("000464")]
        public async Task<Respuesta<UsuarioEnt>> Put(UsuarioEnt model)
        {
            return await _usuario.Modificar(model);
        }
        [HttpPut("cambiarClave")]
        [CustomFilter("000465")]
        public async Task<Respuesta<UsuarioCambiarClaveDTO>> CambiarClave(UsuarioCambiarClaveDTO model)
        {
            return await _usuario.CambiarClave(model);
        }       
        [HttpGet("estado/{idEstado}")]
        [CustomFilter("000466")]
        public async Task<IEnumerable<UsuarioGridDTO>> ObtenerByEstado(bool idEstado)
        {
            return await _usuario.Obtener(idEstado);
        }
        [HttpGet("listadoGrilla")]
        [CustomFilter("000467")]
        public async Task<IEnumerable<UsuarioGridDTO>> ObtenerListadoGrilla()
        {
            return await _usuario.ObtenerListadoGrilla();
        }
        [HttpGet("listadoGrillaBySupervisor/{idSupervisor}")]
        [CustomFilter("PRIV-UsuarioSupervisados")]
        public async Task<IEnumerable<UsuarioGridDTO>> ObtenerListadoGrillaBySupervisor(int idSupervisor)
        {
            return await _usuario.ObtenerListadoGrillaBySupervisor(idSupervisor);
        }

        [HttpGet("listadoDeSupervisores")]
        public async Task<IEnumerable<SupervisorDTO>> ObtenerListadoSupervisores()
        {
            return await _usuario.ObtenerListadoSupervisores();
        }

        [HttpPost("confirmarSupervisor")]
        public async Task<GeneralResponse<RespuestaConfirmarSupervisorDTO>> ConfirmarSupervisor(ConfirmarSupervisorDTO model)
        {
            return await _usuario.ConfirmarSupervisor(model.IdUsuario, model.UsuarioSupervisor);
        }
        [HttpPut("aprobarUsuario")]
        public async Task<GeneralResponse<bool>> CambiarEstadoAprobacion(AprobarUsuarioDTO model)
        {
            return await _usuario.CambiarEstadoAprobacion(model.IdUsuario, model.EstadoAprobacion);
        }
        [HttpGet("obtenerEstadoAprobadoByUsuario/{idUsuario}")]
        public async Task<byte> ObtenerEstadoAprobacionUsuario(int idUsuario)
        {
            return await _usuario.ObtenerEstadoAprobacionUsuario(idUsuario);
        }
        [HttpGet("obtenerPrivilegioByUsuario/{idUsuario}")]
        public async Task<AccesoUsuarioDTO> ObtenerEstadoPrivilegioUsuario(int idUsuario)
        {
            return await _usuario.ObtenerEstadoPrivilegioUsuario(idUsuario);
        }

        [HttpGet("{id}")]
        [CustomFilter("000468")]
        public async Task<UsuarioEnt> Get(int id)
        {
            return await _usuario.ObtenerByIdUsuario(id);
        }
        [HttpGet("search/{str}")]
        [CustomFilter("000469")]
        public async Task<IEnumerable<UsuarioGridDTO>> LikeNombre(string str)
        {
            return await _usuario.ObtenerByLikeNombre(str);
        }
        [HttpGet("perfil/{idPerfil},{idSede}")]
        [CustomFilter("000470")]
        public async Task<IEnumerable<UsuarioGridDTO>> GetByIdPerfil(string idPerfil, int idSede)
        {
            return await _usuario.ObtenerByIdPerfil(idPerfil, idSede);
        }
        [HttpGet("perfil/{idUsuario}")]
        [CustomFilter("000471")]
        public async Task<IEnumerable<UsuarioGridDTO>> GetByIdPerfilUsuario(int idUsuario)
        {
            return await _usuario.ObtenerByIdPerfilUsuario(idUsuario);
        }
        [HttpGet]
        [CustomFilter("000472")]
        public async Task<IEnumerable<UsuarioGridDTO>> ResponsableCaja()
        {
            return await _usuario.ObtenerResponsableCaja();
        }
        [HttpGet("perfil/preferentes")]
        [CustomFilter("000473")]
        public async Task<ActionResult> ListarParaPreferentes()
        {
            try
            {
                var collection = await _usuario.ListarParaPreferentes();
                return Ok(new { 
                    data = collection,
                    message = "",
                    status = StatusCodes.Status200OK
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    data = new {},
                    message = ex.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
        }
        [HttpGet("perfil/preferentes/{idPerfil}")]
        [CustomFilter("000474")]
        public async Task<ActionResult> ListarParaPreferentesPorUsuario(int idPerfil)
        {
            try
            {
                var collection = await _usuario.ListarParaPreferentesPorUsuario(idPerfil);
                return Ok(new
                {
                    data = collection,
                    message = "",
                    status = StatusCodes.Status200OK
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    data = new { },
                    message = ex.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
        }
        [HttpGet("menu/perfil/{idPerfil}")]
        [CustomFilter("000475")]
        public async Task<List<MenuDTO>> ObtenerMenuByPerfil(int idPerfil)
        {
            return await _usuario.ObtenerMenuByPerfil(idPerfil);
        }
        [HttpGet("collection/{idEstado}")]
        [CustomFilter("000476")]
        public async Task<ActionResult> CollectionByEstado(int idEstado)
        {
            try
            {
                return Ok(new
                {
                    data = await _usuario.CollectionByEstado(idEstado),
                    message = "",
                    status = StatusCodes.Status200OK
                });
            }
            catch (Exception EX)
            {
                return BadRequest(new
                {
                    data = new { },
                    message = EX.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
        }
        [HttpGet("{idUsuario}/obtener-clave")]
        [CustomFilter("000477")]
        public async Task<ActionResult> ObtenerClave(int idUsuario)
        {
            try
            {
                return Ok(new
                {
                    data = await _usuario.ObtenerClave(idUsuario),
                    message = "",
                    status = StatusCodes.Status200OK
                });
            }
            catch (Exception EX)
            {
                return BadRequest(new
                {
                    data = new { },
                    message = EX.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
        }
        [HttpPut("cambiar-clave")]
        [CustomFilter("000478")]
        public async Task<ActionResult> ActualizarClave( UsuarioCambiarClaveDTO model)
        {
            try
            {
                return Ok(new
                {
                    data = await _usuario.CambiarClave(model.IdUsuario, model.ClaveNueva),
                    message = "",
                    status = StatusCodes.Status200OK
                });
            }
            catch (Exception EX)
            {
                return BadRequest(new
                {
                    data = new { },
                    message = EX.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
        }
        [HttpGet("lista-para-cita")]
        [CustomFilter("000479")]
        public async Task<IEnumerable<UsuarioGridDTO>> GetToCita()
        {
            try
            {
                return await _usuario.ObtenerParaCita();
            }
            catch (Exception e)
            {

                throw e;
            }
            
        }

        [HttpGet("verClaveUsuario/{idUsuario}")]
        //[CustomFilter("000467")]
        public async Task<IActionResult> ObtenerClaveUsuario(string idUsuario)
        {
            int idUsuarioInt = int.Parse(idUsuario);

            var clave =  await _usuario.ObtenerClaveUsuario(idUsuarioInt);
            return Ok(new { clave });
        }

    }
}
