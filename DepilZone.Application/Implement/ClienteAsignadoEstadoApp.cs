using DepilZone.Application.Interface;
using DepilZone.Domain.Interface;
using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement
{
    public class ClienteAsignadoEstadoApp : IClienteAsignadoEstadoApp
    {
        private readonly IClienteAsignadoEstadoDom _IClienteAsignadoEstadoDom;
        public ClienteAsignadoEstadoApp(IClienteAsignadoEstadoDom IClienteAsignadoEstadoDom)
        {
            this._IClienteAsignadoEstadoDom = IClienteAsignadoEstadoDom;
        }

        public async Task<List<ClienteAsignadoEstadoDTO>> Listado()
        {
            return await _IClienteAsignadoEstadoDom.Listado();
        }

    }
}
