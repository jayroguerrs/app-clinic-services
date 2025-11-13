using DepilZone.Data.Interface;
using DepilZone.Domain.Interface;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Domain.Implement
{
    public class CitaMedicionDom : ICitaMedicionDom
    {
        private readonly ICitaMedicionDat _ICitaMedicionDat;
        public CitaMedicionDom(ICitaMedicionDat ICitaMedicionDat)
        {
            this._ICitaMedicionDat = ICitaMedicionDat;
        }
        public async Task Grabar(CitaMedicionDTO model)
        {
            await _ICitaMedicionDat.Grabar(model);
        }
        public async Task<CitaMedicionDTO> ObtenerByIdCita(int idCita, int idTipoMedicion)
        {
            return await _ICitaMedicionDat.ObtenerByIdCita(idCita, idTipoMedicion);
        }
        public async Task<List<CitaMedicionDTO>> ObtenerReporteGeneral(CitaMedicion_ParametrosDTO input)
        {
            return await _ICitaMedicionDat.ObtenerReporteGeneral(input);
        }
        public async Task<CitasEncuestadasDTO> ObtenerCitasEncuestadas(DateTime Fdesde, DateTime Fhasta, int idSede)
        {
            return await _ICitaMedicionDat.ObtenerCitasEncuestadas(Fdesde, Fhasta, idSede);
        }

    }
}
