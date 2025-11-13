using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Interface
{
    public interface ICitaEstadoMotivoApp
    {
        Task<List<CitaEstadoMotivoEnt>> Listar();
        Task<CitaEstadoMotivoEnt> Grabar( CitaEstadoMotivoDTO model );
        Task<List<CitaEstadoMotivoRespuestaEnt>> ObtenerReporteGeneral(CitaEstado_ParametrosDTO model);
    }
}
