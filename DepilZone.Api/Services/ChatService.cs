using DepilZone.Api.Hubs;
using DepilZone.Entidad;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using System;

namespace DepilZone.Api.Services
{
    public interface IChatService
    {
        Task<bool> EnviarMensajeTodos(string datosJSON, TipoAlerta tipo);
        Task<bool> EnviarEvento(int idUsuario, TipoEvento tipo, int idUsuarioActual);
        Task<bool> EnviarMensaje(string datosJSON, TipoAlerta tipo, string connectionId);
    }

    public class ChatService : IChatService
    {
        private readonly IHubContext<SignalHub> _hubContext;

        public ChatService(IHubContext<SignalHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task<bool> EnviarMensajeTodos(string datosJSON, TipoAlerta tipo)
        {
            try
            {
                MensajeSignalR mensajeSignalR = new MensajeSignalR()
                {
                    Exito = true,
                    Mensaje = tipo.ToString(),
                    DatosJSON = datosJSON,
                    Tipo = tipo
                };
                await _hubContext.Clients.All.SendAsync("mensajeroSignal", mensajeSignalR);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> EnviarEvento(int idUsuario, TipoEvento tipo, int idUsuarioActual)
        {
            try
            {
                EventoSignalR eventoSignalR = new EventoSignalR()
                {
                    IdUsuario = idUsuario,
                    Tipo = tipo,
                    IdUsuarioActual = idUsuarioActual
                };
                await _hubContext.Clients.All.SendAsync("eventoSignal", eventoSignalR);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> EnviarMensaje(string datosJSON, TipoAlerta tipo, string connectionId)
        {
            try
            {
                MensajeSignalR mensajeSignalR = new MensajeSignalR()
                {
                    Exito = true,
                    Mensaje = tipo.ToString(),
                    DatosJSON = datosJSON,
                    Tipo = tipo
                };
                await _hubContext.Clients.Client(connectionId).SendAsync("mensajeroSignal", mensajeSignalR);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }

}
