using DepilZone.Application.Interface;
using DepilZone.Domain.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement
{
    public class ChatApp : IChatApp
    {
        private readonly IChatDom _IChatDom;
        public ChatApp(IChatDom iChatDom)
        {
            _IChatDom = iChatDom;
        }
        public async Task<Respuesta<ChatEnt>> Insertar(ChatEnt model)
        {
            return await _IChatDom.Insertar(model);
        }

        public async Task<Respuesta<ChatEnt>> Modificar(ChatEnt model)
        {
            return await _IChatDom.Modificar(model);
        }

        public async Task<IEnumerable<ChatUsuarioListaDTO>> Obtener(int idUsuario)
        {
            return await _IChatDom.Obtener(idUsuario);
        }

        public async Task<IEnumerable<ChatEnt>> ObtenerMensajes(int idDeUsuario, int idParaUsuario)
        {
            return await _IChatDom.ObtenerMensajes(idDeUsuario, idParaUsuario);
        }
        public async Task<bool> ActualizaUltimaConexion(int idUsuario)
        {
            return await _IChatDom.ActualizaUltimaConexion(idUsuario);
        }
        public async Task<bool> ActualizarMensajeLeido(int idDeUsuario, int idParaUsuario)
        {
            return await _IChatDom.ActualizarMensajeLeido(idDeUsuario, idParaUsuario);
        }
    }
}
