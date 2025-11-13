using DepilZone.Data.Interface;
using DepilZone.Domain.Interface;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace DepilZone.Domain.Implement
{
    public class ClienteAsignadoDom : IClienteAsignadoDom
    {
        private readonly IClienteAsignadoDat _IClienteAsignadoDat;
        public ClienteAsignadoDom(IClienteAsignadoDat IClienteAsignadoDat)
        {
            this._IClienteAsignadoDat = IClienteAsignadoDat;
        }

     
        public async Task<List<ClienteAsignadoDTO>> ObtenerAsignacion(int tipoCliente, int idSede, DateTime fechaCita, int asignado)
        {
            return await _IClienteAsignadoDat.ObtenerAsignacion(tipoCliente, idSede, fechaCita, asignado);
        }

        public async Task<int> Insertar(ClienteAsignarListaDTO model)
        {
            return await _IClienteAsignadoDat.Insertar(model);
        }

        public async Task<int> Reasignar(ClienteAsignarListaDTO model)
        {
            return await _IClienteAsignadoDat.Reasignar(model);
        }

        public async Task<List<ClienteAsignadoDTO>> BuscarAsignados(DateTime fechaConfirmacion, int tipoCliente, int idTipo, int idSede, int asignadoA, int asignadoPor)
        {
            return await _IClienteAsignadoDat.BuscarAsignados(fechaConfirmacion, tipoCliente, idTipo, idSede, asignadoA, asignadoPor);
        }

        public async Task<List<ClienteAsignadoDTO>> BuscarParaReasignados(DateTime fechaConfirmacion, int tipoCliente, int idTipo, int idSede, int asignadoA, int asignadoPor)
        {
            return await _IClienteAsignadoDat.BuscarParaReasignados(fechaConfirmacion, tipoCliente, idTipo, idSede, asignadoA, asignadoPor);
        }

        public async Task<List<ClienteAsignadoDTO>> BuscarAsignadosUsuario(DateTime fechaConfirmacion, int asignadoA)
        {
            return await _IClienteAsignadoDat.BuscarAsignadosUsuario(fechaConfirmacion, asignadoA);
        }

        public async Task<bool> Trabajar(ClienteAsignadoDTO model)
        {
            return await _IClienteAsignadoDat.Trabajar(model);
        }

        public async Task<bool> MarcarVisto(List<int> model)
        {
            return await _IClienteAsignadoDat.MarcarVisto(model);
        }

        public async Task<List<ClientAsignadoHistoriaDTO>> ObtenerHistoria(int idClientAsignado)
        {
            return await _IClienteAsignadoDat.ObtenerHistoria(idClientAsignado);
        }


    }
}
