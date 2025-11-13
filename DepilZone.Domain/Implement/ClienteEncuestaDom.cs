using DepilZone.Data.Interface;
using DepilZone.Domain.Interface;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Domain.Implement
{
    public class ClienteEncuestaDom : IClienteEncuestaDom
    {
        private readonly IClienteEncuestaDat _IClienteEncuestaDat;
        public ClienteEncuestaDom(IClienteEncuestaDat IClienteEncuestaDat)
        {
            this._IClienteEncuestaDat = IClienteEncuestaDat;
        }
        
        public async Task<List<ClienteEncuestaDTO>> ObtenerReporteGeneral(int IdSede, DateTime? Fdesde, DateTime? Fhasta)
        {
            return await _IClienteEncuestaDat.ObtenerReporteGeneral(IdSede, Fdesde, Fhasta);
        }

        public async Task<List<CE_PreguntaDTO>> ObtenerReporteGrafico(int IdSede, DateTime? Fdesde, DateTime? Fhasta)
        {
            return await _IClienteEncuestaDat.ObtenerReporteGrafico(IdSede, Fdesde, Fhasta);
        }
    }
}
