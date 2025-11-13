using DepilZone.Application.Interface;
using DepilZone.Domain.Interface;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement
{
    public class CitaMedicionApp: ICitaMedicionApp
    {
        private readonly ICitaMedicionDom _ICitaMedicionDom;
        public CitaMedicionApp(ICitaMedicionDom ICitaMedicionDom)
        {
            this._ICitaMedicionDom = ICitaMedicionDom;
        }

        public async Task Grabar(CitaMedicionDTO model)
        {
            await _ICitaMedicionDom.Grabar(model);
        }

        public async Task<CitaMedicionDTO> ObtenerByIdCita(int idCita, int idTipoMedicion)
        {
            return await _ICitaMedicionDom.ObtenerByIdCita(idCita, idTipoMedicion);
        }

        public async Task<List<CitaMedicionDTO>> ObtenerReporteGeneral(CitaMedicion_ParametrosDTO input)
        {
            return await _ICitaMedicionDom.ObtenerReporteGeneral(input);
        }

        public async Task<CitasEncuestadasDTO> ObtenerCitasEncuestadas(DateTime Fdesde, DateTime Fhasta, int idSede)
        {
            return await _ICitaMedicionDom.ObtenerCitasEncuestadas(Fdesde, Fhasta, idSede);
        }

    }
}
