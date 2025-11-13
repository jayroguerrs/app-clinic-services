using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Interface
{
    public interface IClienteAccesoApp
    {
        Task<bool> ModificarCorreo(int idCliente, ClienteAccesoDTO model);
        Task<bool> ModificarClave(int idCliente, ClienteAccesoDTO model);
        Task<ClienteAccesoDTO> ObtenerCredenciales(int idCliente);
    }
}
