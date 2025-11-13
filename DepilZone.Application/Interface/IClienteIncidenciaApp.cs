using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Interface
{
    public interface IClienteIncidenciaApp
    {
        Task<List<ClienteIncidenciaDTO>> Listar(int idSede, DateTime fechaDesde, DateTime fechaHasta);
        Task<List<ClienteIncidenciaDTO>> ListarPorCliente(int idCliente);
        Task<bool> Registrar(ClienteIncidenciaDTO model);
    }
}
