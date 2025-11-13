using DepilZone.Application.Interface;
using DepilZone.Domain.Interface;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement
{
    public class ClienteAsignadoApp : IClienteAsignadoApp
    {
        private readonly IClienteAsignadoDom _IClienteAsignadoDom;
        public ClienteAsignadoApp(IClienteAsignadoDom IClienteAsignadoDom)
        {
            this._IClienteAsignadoDom = IClienteAsignadoDom;
        }

        public async Task<List<ClienteAsignadoDTO>> ObtenerAsignacion(int tipoCliente, int idSede, DateTime fechaCita, int asignado)
        {
            return await _IClienteAsignadoDom.ObtenerAsignacion(tipoCliente, idSede, fechaCita, asignado);
        }

        public async Task<int> Insertar(ClienteAsignarListaDTO model)
        {
            return await _IClienteAsignadoDom.Insertar(model);
        }

        public async Task<int> Reasignar(ClienteAsignarListaDTO model)
        {
            return await _IClienteAsignadoDom.Reasignar(model);
        }

        public async Task<List<ClienteAsignadoDTO>> BuscarAsignados(DateTime fechaConfirmacion, int tipoCliente, int idTipo, int idSede, int asignadoA, int asignadoPor)
        {
            return await _IClienteAsignadoDom.BuscarAsignados( fechaConfirmacion,  tipoCliente,  idTipo,  idSede,  asignadoA,  asignadoPor);
        }

        public async Task<List<ClienteAsignadoDTO>> BuscarParaReasignados(DateTime fechaConfirmacion, int tipoCliente, int idTipo, int idSede, int asignadoA, int asignadoPor)
        {
            return await _IClienteAsignadoDom.BuscarParaReasignados(fechaConfirmacion, tipoCliente, idTipo, idSede, asignadoA, asignadoPor);
        }

        public async Task<List<ClienteAsignadoDTO>> BuscarAsignadosUsuario(DateTime fechaConfirmacion, int asignadoA)
        {
            return await _IClienteAsignadoDom.BuscarAsignadosUsuario(fechaConfirmacion, asignadoA);
        }

        public async Task<bool> Trabajar(ClienteAsignadoDTO model)
        {
            return await _IClienteAsignadoDom.Trabajar(model);
        }

        public async Task<bool> MarcarVisto(List<int> model)
        {
            return await _IClienteAsignadoDom.MarcarVisto(model);
        }

        public async Task<List<ClientAsignadoHistoriaDTO>> ObtenerHistoria(int idClientAsignado)
        {
            return await _IClienteAsignadoDom.ObtenerHistoria(idClientAsignado);
        }

    }
}
