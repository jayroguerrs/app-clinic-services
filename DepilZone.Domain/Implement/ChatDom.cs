using DepilZone.Data.Interface;
using DepilZone.Domain.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Domain.Implement
{
    public class ChatDom : IChatDom
    {
        private readonly IChatDat _IChatDat;

        public ChatDom(IChatDat iChatDat)
        {
            _IChatDat = iChatDat;
        }
            
        public async Task<Respuesta<ChatEnt>> Insertar(ChatEnt model)
        {
            return await _IChatDat.Insertar(model);
        }

        public async Task<Respuesta<ChatEnt>> Modificar(ChatEnt model)
        {
            return await _IChatDat.Modificar(model);
        }

        public async Task<IEnumerable<ChatUsuarioListaDTO>> Obtener(int idUsuario)
        {
            return await _IChatDat.Obtener(idUsuario);
        }
        public async Task<IEnumerable<ChatEnt>> ObtenerMensajes(int idDeUsuario, int idParaUsuario)
        {
            return await _IChatDat.ObtenerMensajes(idDeUsuario, idParaUsuario);
        }

        public async Task<bool> ActualizaUltimaConexion(int idUsuario)
        {
            return await _IChatDat.ActualizaUltimaConexion(idUsuario);
        }
        public async Task<bool> ActualizarMensajeLeido(int idDeUsuario, int idParaUsuario)
        {
            return await _IChatDat.ActualizarMensajeLeido(idDeUsuario, idParaUsuario);
        }
    }
}
