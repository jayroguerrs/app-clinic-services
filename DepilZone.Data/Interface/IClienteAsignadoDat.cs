using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Data.Interface
{
    public interface IClienteAsignadoDat
    {
        Task<List<ClienteAsignadoDTO>> ObtenerAsignacion(int tipoCliente, int idSede, DateTime fechaCita, int asignado);

        Task<int> Insertar(ClienteAsignarListaDTO model);

        Task<int> Reasignar(ClienteAsignarListaDTO model);

        Task<List<ClienteAsignadoDTO>> BuscarAsignados(DateTime fechaConfirmacion, int tipoCliente, int idTipo, int idSede, int asignadoA, int asignadoPor);
        Task<List<ClienteAsignadoDTO>> BuscarParaReasignados(DateTime fechaConfirmacion, int tipoCliente, int idTipo, int idSede, int asignadoA, int asignadoPor);
        Task<List<ClienteAsignadoDTO>> BuscarAsignadosUsuario(DateTime fechaConfirmacion, int asignadoA);

        Task<bool> Trabajar(ClienteAsignadoDTO model);
        Task<bool> MarcarVisto(List<int> model);
        Task<List<ClientAsignadoHistoriaDTO>> ObtenerHistoria(int idClientAsignado);
    }
}
