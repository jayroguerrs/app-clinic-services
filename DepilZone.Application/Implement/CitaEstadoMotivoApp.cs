using DepilZone.Application.Interface;
using DepilZone.Domain.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement
{
    public class CitaEstadoMotivoApp : ICitaEstadoMotivoApp
    {
        private readonly ICitaEstadoMotivoDom _ICitaEstadoMotivoDom;
        public CitaEstadoMotivoApp(ICitaEstadoMotivoDom ICitaEstadoMotivoDom)
        {
            _ICitaEstadoMotivoDom = ICitaEstadoMotivoDom;
        }
        public async Task<List<CitaEstadoMotivoEnt>> Listar()
        {
            return await _ICitaEstadoMotivoDom.Listar();
        }

        public async Task<CitaEstadoMotivoEnt> Grabar( CitaEstadoMotivoDTO model )
        {
            return await _ICitaEstadoMotivoDom.Grabar(model);
        }

        public async Task<List<CitaEstadoMotivoRespuestaEnt>> ObtenerReporteGeneral(CitaEstado_ParametrosDTO model)
        {
            return await _ICitaEstadoMotivoDom.ObtenerReporteGeneral(model);
        }
    }
}
