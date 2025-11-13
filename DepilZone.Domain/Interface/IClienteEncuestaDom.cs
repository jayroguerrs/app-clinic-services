using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Domain.Interface
{
    public interface IClienteEncuestaDom
    {
        Task<List<ClienteEncuestaDTO>> ObtenerReporteGeneral(int IdSede, DateTime? Fdesde, DateTime? Fhasta);

        Task<List<CE_PreguntaDTO>> ObtenerReporteGrafico(int IdSede, DateTime? Fdesde, DateTime? Fhasta);
    }
}
