using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Interface
{
    public interface IClienteEncuestaApp
    {
        Task<List<ClienteEncuestaDTO>> ObtenerReporteGeneral(int IdSede, DateTime? Fdesde, DateTime? Fhasta);

        Task<List<CE_PreguntaDTO>> ObtenerReporteGrafico(int IdSede, DateTime? Fdesde, DateTime? Fhasta);
    }
}
