using DepilZone.Application.Interface;
using DepilZone.Domain.Interface;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement
{
    public class ClienteEncuestaApp: IClienteEncuestaApp
    {
        private readonly IClienteEncuestaDom _IClienteEncuestaDom;
        public ClienteEncuestaApp(IClienteEncuestaDom IClienteEncuestaDom)
        {
            this._IClienteEncuestaDom = IClienteEncuestaDom;
        }

        public async Task<List<ClienteEncuestaDTO>> ObtenerReporteGeneral(int IdSede, DateTime? Fdesde, DateTime? Fhasta)
        {
            return await _IClienteEncuestaDom.ObtenerReporteGeneral(IdSede, Fdesde, Fhasta);
        }

        public async Task<List<CE_PreguntaDTO>> ObtenerReporteGrafico(int IdSede, DateTime? Fdesde, DateTime? Fhasta)
        {
            return await _IClienteEncuestaDom.ObtenerReporteGrafico(IdSede, Fdesde, Fhasta);
        }
    }
}
