using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Domain.Interface
{
    public interface IClienteAsignadoEstadoDom
    {
        Task<List<ClienteAsignadoEstadoDTO>> Listado();

    }
}
