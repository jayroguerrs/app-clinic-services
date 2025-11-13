using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Interface
{
    public interface IChatApp
    {
        Task<IEnumerable<ChatUsuarioListaDTO>> Obtener(int idUsuario);
        Task<Respuesta<ChatEnt>> Insertar(ChatEnt model);
        Task<Respuesta<ChatEnt>> Modificar(ChatEnt model);
        Task<IEnumerable<ChatEnt>> ObtenerMensajes(int idDeUsuario, int idParaUsuario);
        Task<bool> ActualizaUltimaConexion(int idUsuario);
        Task<bool> ActualizarMensajeLeido(int idDeUsuario, int idParaUsuario);
    }
}
