using DepilZone.Data.Interface;
using DepilZone.Domain.Interface;
using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Domain.Implement
{
    public class ClienteAsignadoEstadoDom : IClienteAsignadoEstadoDom
    {
        private readonly IClienteAsignadoEstadoDat _IClienteAsignadoEstadoDat;
        public ClienteAsignadoEstadoDom(IClienteAsignadoEstadoDat IClienteAsignadoEstadoDat)
        {
            this._IClienteAsignadoEstadoDat = IClienteAsignadoEstadoDat;
        }

     
        public async Task<List<ClienteAsignadoEstadoDTO>> Listado()
        {
            return await _IClienteAsignadoEstadoDat.Listado();
        }

    }
}
