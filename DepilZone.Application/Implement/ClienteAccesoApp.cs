using DepilZone.Application.Interface;
using DepilZone.Data.Interface;
using DepilZone.Entidad.DTO;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement
{
    public class ClienteAccesoApp: IClienteAccesoApp
    {
        private readonly IClienteAccesoDom _IClienteAccesoDom;
        public ClienteAccesoApp(IClienteAccesoDom IClienteAccesoDom)
        {
            this._IClienteAccesoDom = IClienteAccesoDom;
        }

        public async Task<bool> ModificarCorreo(int idCliente, ClienteAccesoDTO model)
        {
            return await _IClienteAccesoDom.ModificarCorreo(idCliente, model);
        }
        public async Task<bool> ModificarClave(int idCliente, ClienteAccesoDTO model)
        {
            return await _IClienteAccesoDom.ModificarClave(idCliente, model);
        }


        public async Task<ClienteAccesoDTO> ObtenerCredenciales(int idCliente)
        {
            return await _IClienteAccesoDom.ObtenerCredenciales(idCliente);
        }
    }
}
