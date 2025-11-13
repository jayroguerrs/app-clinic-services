using DepilZone.Api.CustomFilter;
using DepilZone.Api.Hubs;
using DepilZone.Api.Services;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace DepilZone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignalRController: ControllerBase
    {
        private readonly IHubContext<SignalHub> _hubContext;
        private readonly IChatService _chatService;
        public SignalRController(IHubContext<SignalHub> hubContext, IChatService chatService)
        {
            _hubContext = hubContext;
            _chatService = chatService;
        }

        [HttpGet("{action}")]
        [CustomFilter("000444")]
        public async Task<ActionResult<bool>> EscanearPregunta()
        {
            try
            {
                return await _chatService.EnviarMensajeTodos(JsonSerializer.Serialize(true), TipoAlerta.Actividad);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet("{action}/{mensaje}")]
        [CustomFilter("000445")]
        public async Task<ActionResult<bool>> MensajeGeneral(string mensaje)
        {
            try
            {
                return await _chatService.EnviarMensajeTodos(JsonSerializer.Serialize(mensaje), TipoAlerta.AvisoGeneral);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet("evento/{idTipoEvento}/{idUsuario}/{idUsuarioActual}")]
        [CustomFilter("000446")]
        public async Task<ActionResult<bool>> Evento(TipoEvento idTipoEvento, int idUsuario, int idUsuarioActual)
        {
            try
            {
                return await _chatService.EnviarEvento(idUsuario, idTipoEvento, idUsuarioActual);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost("{action}")]
        [CustomFilter("000447")]
        public async Task<ActionResult<bool>> EscanearRespuesta(UsuarioEnt usuario)
        {
            try
            {
                return await _chatService.EnviarMensajeTodos(JsonSerializer.Serialize(usuario), TipoAlerta.RespuestaActividad);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost("{action}")]
        [CustomFilter("000448")]
        public async Task<ActionResult<bool>> IdentificacionUsuario(IdentificacionUsuarioChatDTO identificacion)
        {
            identificacion.FechaHoraConeccion = DateTime.Now;
            if (UsuarioService.usuarios.ContainsKey(identificacion.ConnectionId))
            {
                IEnumerable<IdentificacionUsuarioChatDTO>  usuarios = UsuarioService.usuarios.Values.Where(u => u.IdUsuario == identificacion.IdUsuario && u.ConnectionId != identificacion.ConnectionId).ToList();
                foreach (IdentificacionUsuarioChatDTO usuario in usuarios)
                {
                    UsuarioService.usuarios.Remove(usuario.ConnectionId);
                }
                UsuarioService.usuarios[identificacion.ConnectionId] = identificacion;

                //Enviar el dato de la nueva conexion a todos
                var nuevaConexion = JsonSerializer.Serialize(new { idUsuario = identificacion.IdUsuario });
                await _chatService.EnviarMensajeTodos(nuevaConexion, TipoAlerta.ConexionNueva);

                ////Eliminar los que se quedaron pegados por mas de 1 minuto
                var pegados = UsuarioService.usuarios.Values.Where(u => DateTime.Now.Subtract(u.FechaHoraConeccion).Seconds > 15 && u.IdUsuario > 0).ToList();
                foreach (var peg in pegados)
                    UsuarioService.usuarios.Remove(peg.ConnectionId);

                //Enviar los datos de usuarios validados
                var usuariosValidados = (from u in UsuarioService.usuarios.Values where u.IdUsuario > 0 select u);
                var listaConectados = JsonSerializer.Serialize(usuariosValidados);

                return await _chatService.EnviarMensaje(listaConectados, TipoAlerta.ConexionListaUsuario, identificacion.ConnectionId);
            }
            else
            {
                var conexionRechazada = JsonSerializer.Serialize(new { idUSuario = identificacion.IdUsuario, mensaje = "Por favor intentar nuevamente" });
                return await _chatService.EnviarMensaje(conexionRechazada, TipoAlerta.ConexionRechazada, identificacion.ConnectionId);
            }
        }
    }
}
