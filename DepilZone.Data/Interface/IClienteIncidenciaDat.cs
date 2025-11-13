using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Data.Interface
{
    public interface IClienteIncidenciaDat
    {
        Task<List<ClienteIncidenciaDTO>> Listar(int idSede, DateTime fechaDesde, DateTime fechaHasta);
        Task<List<ClienteIncidenciaDTO>> ListarPorCliente(int idCliente);
        Task<bool> Registrar(ClienteIncidenciaDTO model);
    }
}
