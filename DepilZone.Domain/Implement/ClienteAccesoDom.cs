using System.Threading.Tasks;
using DepilZone.Data.Interface;
using DepilZone.Entidad.DTO;

namespace DepilZone.Domain
{
    public class ClienteAccesoDom : IClienteAccesoDom
    {

        private readonly IClienteAccesoDat _IClienteAccesoDat;
        public ClienteAccesoDom(IClienteAccesoDat IClienteAccesoDat)
        {
            this._IClienteAccesoDat = IClienteAccesoDat;
        }
        public async Task<bool> ModificarCorreo(int idCliente, ClienteAccesoDTO model)
        {
            return await _IClienteAccesoDat.ModificarCorreo(idCliente, model);
        }

        public async Task<bool> ModificarClave(int idCliente, ClienteAccesoDTO model)
        {
            return await _IClienteAccesoDat.ModificarClave(idCliente, model);
        }

        public async Task<ClienteAccesoDTO> ObtenerCredenciales(int idCliente)
        {
            return await _IClienteAccesoDat.ObtenerCredenciales(idCliente);
        }

    }




}
