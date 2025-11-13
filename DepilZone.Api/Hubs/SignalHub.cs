using DepilZone.Api.Controllers;
using DepilZone.Api.Services;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace DepilZone.Api.Hubs
{
    public class SignalHub: Hub
    {
        readonly ChatController _chatController;

        public SignalHub(ChatController chatController)
        {
            _chatController = chatController;
        }

        private void PreferenteController_PreferenteSignalR(object sender, EventArgs e)
        {
            Console.WriteLine("aqui");
        }

        public string GetConnectionId()
        {
            return Context.ConnectionId;
        }

        public Task SendChatMessageTodos(MensajeSignalR message)
        {
            return Clients.All.SendAsync("mensajeroSignal", message);
        }
        public Task SendChatMessage(MensajeSignalR message, string ConnectionId)
        {
            return Clients.Client(ConnectionId).SendAsync("mensajeroSignal", message);
        }

        public override async Task OnConnectedAsync()
        {
            var group = Context.GetHttpContext().Request.Query["idUsuario"];
            int idUsuario = !string.IsNullOrEmpty(group.ToString()) ? int.Parse(group.ToString()) : 0;

            UsuarioService.usuarios.Add(Context.ConnectionId, new IdentificacionUsuarioChatDTO
            {
                FechaHoraConeccion = DateTime.Now,
                ConnectionId = Context.ConnectionId,
                IdUsuario = idUsuario
            });
            await Task.Delay(500);
            EnviarListaUsuario();
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            var usuarioDesconectado = UsuarioService.usuarios[Context.ConnectionId];
            UsuarioService.usuarios.Remove(Context.ConnectionId);
            await Task.Delay(500);


            EnviarUsuarioDesconectado(usuarioDesconectado);

            await base.OnDisconnectedAsync(exception);
        }

        public void EnviarListaUsuario()
        {
            MensajeSignalR mensajeSignalR = new MensajeSignalR()
            {
                Exito = true,
                Mensaje = TipoAlerta.ConexionListaUsuario.ToString(),
                DatosJSON = JsonSerializer.Serialize(UsuarioService.usuarios.Values),
                Tipo = TipoAlerta.ConexionListaUsuario
            };
            SendChatMessageTodos(mensajeSignalR);
        }
        public async void EnviarUsuarioDesconectado(IdentificacionUsuarioChatDTO usuarioDesconectado) 
        {
            MensajeSignalR mensajeSignalR = new MensajeSignalR()
            {
                Exito = true,
                Mensaje = TipoAlerta.ConexionListaUsuario.ToString(),
                DatosJSON = JsonSerializer.Serialize(usuarioDesconectado),
                Tipo = TipoAlerta.DesconexionUsuario
            };
            await SendChatMessageTodos(mensajeSignalR);
            await _chatController.ActualizaUltimaConexion(usuarioDesconectado.IdUsuario);
        }

        public MensajeSignalR MensajeSignal(TipoAlerta  tipoAlerta, object datos)
        {
            return new MensajeSignalR()
            {
                DatosJSON = JsonSerializer.Serialize(datos),
                Exito = true,
                Mensaje = tipoAlerta.ToString(),
                Tipo = tipoAlerta
            };
        }
    }
}
