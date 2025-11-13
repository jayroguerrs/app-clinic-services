using DepilZone.Api.CustomFilter;
using DepilZone.Api.Hubs;
using DepilZone.Api.Services;
using DepilZone.Application.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace DepilZone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class ChatController : ControllerBase
    {
        private readonly IChatApp _chat;
        private readonly IHubContext<SignalHub> _hubContext;

        public ChatController(IChatApp ChatApp, IHubContext<SignalHub> hubContext)
        {
            _chat = ChatApp;
            _hubContext = hubContext;
        }
        [HttpPost]
        [CustomFilter("000205")]
        public async Task<Respuesta<ChatEnt>> Post(ChatEnt model)
        {
            Respuesta<ChatEnt> respuesta = await _chat.Insertar(model);
            IdentificacionUsuarioChatDTO usuarioDestino = UsuarioService.usuarios.Values.Where(x => x.IdUsuario == respuesta.Response.IdParaUsuario).FirstOrDefault();
            if (usuarioDestino != null)
            {
                MensajeSignalR mensajeSignalR = new MensajeSignalR()
                {
                    Tipo = TipoAlerta.NuevoMensaje,
                    DatosJSON = JsonSerializer.Serialize(respuesta.Response),
                    Exito = true,
                    Mensaje = TipoAlerta.NuevoMensaje.ToString()
                };

                await _hubContext.Clients.Client(usuarioDestino.ConnectionId).SendAsync("mensajeroSignal", mensajeSignalR);
            }
            return respuesta;
        }
        [HttpPut]
        [CustomFilter("000206")]
        public async Task<Respuesta<ChatEnt>> Put(ChatEnt model)
        {
            return await _chat.Modificar(model);
        }
        [HttpGet("{idUsuario}")]
        [CustomFilter("000207")]
        public async Task<IEnumerable<ChatUsuarioListaDTO>> Get(int idUsuario)
        {
            return await _chat.Obtener(idUsuario);
        }
        [HttpGet("mensajes/{idDeUsuario}/{idParaUsuario}")]
        [CustomFilter("000208")]
        public async Task<IEnumerable<ChatEnt>> GetMensajes(int idDeUsuario, int idParaUsuario)
        {
            return await _chat.ObtenerMensajes(idDeUsuario, idParaUsuario);
        }
        [HttpGet("hi")]
        [CustomFilter("000209")]
        public async Task<bool> ActualizaUltimaConexion(int idUsuario)
        {
            return await _chat.ActualizaUltimaConexion(idUsuario);
        }
        [HttpGet("mensajes/leido/{idDeUsuario}/{idParaUsuario}")]
        [CustomFilter("000210")]
        public async Task<bool> ActualizarMensajeLeido(int idDeUsuario, int idParaUsuario)
        {
            return await _chat.ActualizarMensajeLeido(idDeUsuario, idParaUsuario);
        }
    }
}
