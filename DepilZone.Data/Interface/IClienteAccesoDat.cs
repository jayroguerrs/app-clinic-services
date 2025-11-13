using DepilZone.Entidad.DTO;
using System.Threading.Tasks;

namespace DepilZone.Data.Interface
{
    public interface IClienteAccesoDat
    {
        Task<bool> ModificarCorreo(int idCliente, ClienteAccesoDTO model);
        Task<bool> ModificarClave(int idCliente, ClienteAccesoDTO model);
        Task<ClienteAccesoDTO> ObtenerCredenciales(int idCliente);
    }
}
