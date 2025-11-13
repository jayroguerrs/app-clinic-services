using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DepilZone.Data.Interface;
using DepilZone.Entidad.DTO;

namespace DepilZone.Domain
{
    public class ClienteIncidenciaDom : IClienteIncidenciaDom
    {

        private readonly IClienteIncidenciaDat _IClienteIncidenciaDat;
        public ClienteIncidenciaDom(IClienteIncidenciaDat IClienteIncidenciaDat)
        {
            this._IClienteIncidenciaDat = IClienteIncidenciaDat;
        }
        public async Task<List<ClienteIncidenciaDTO>> Listar(int idSede, DateTime fechaDesde, DateTime fechaHasta)
        {
            return await _IClienteIncidenciaDat.Listar(idSede, fechaDesde, fechaHasta);
        }

        public async Task<List<ClienteIncidenciaDTO>> ListarPorCliente(int idCliente)
        {
            return await _IClienteIncidenciaDat.ListarPorCliente(idCliente);
        }

        public async Task<bool> Registrar(ClienteIncidenciaDTO model)
        {
            return await _IClienteIncidenciaDat.Registrar(model);
        }
    }




}
