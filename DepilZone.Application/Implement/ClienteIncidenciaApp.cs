using DepilZone.Application.Interface;
using DepilZone.Data.Interface;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement
{
    public class ClienteIncidenciaApp: IClienteIncidenciaApp
    {
        private readonly IClienteIncidenciaDom _IClienteIncidenciaDom;
        public ClienteIncidenciaApp(IClienteIncidenciaDom IClienteIncidenciaDom)
        {
            this._IClienteIncidenciaDom = IClienteIncidenciaDom;
        }

        public async Task<List<ClienteIncidenciaDTO>> Listar(int idSede, DateTime fechaDesde, DateTime fechaHasta)
        {
            return await _IClienteIncidenciaDom.Listar(idSede, fechaDesde, fechaHasta);
        }

        public async Task<List<ClienteIncidenciaDTO>> ListarPorCliente(int idCliente)
        {
            return await _IClienteIncidenciaDom.ListarPorCliente(idCliente);
        }
        public async Task<bool> Registrar(ClienteIncidenciaDTO model)
        {
            return await _IClienteIncidenciaDom.Registrar(model);
        }

    }
}
