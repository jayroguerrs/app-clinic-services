using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Data.Interface
{
    public interface ICitaMedicionDat
    {
        Task Grabar(CitaMedicionDTO model);
        Task<CitaMedicionDTO> ObtenerByIdCita(int idCita, int idTipoMedicion);
        Task<List<CitaMedicionDTO>> ObtenerReporteGeneral(CitaMedicion_ParametrosDTO model);
        Task<CitasEncuestadasDTO> ObtenerCitasEncuestadas(DateTime Fdesde, DateTime Fhasta, int idSede);
    }
}
