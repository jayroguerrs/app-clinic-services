using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Interface
{
    public interface IClienteAsignadoEstadoApp
    {
        Task<List<ClienteAsignadoEstadoDTO>> Listado();
    }

}
