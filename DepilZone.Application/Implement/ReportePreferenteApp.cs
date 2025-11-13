using DepilZone.Application.Interface;
using DepilZone.Data.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement
{
	public class ReportePreferenteApp : IReportePreferenteApp
	{
        private readonly IReportePreferenteDom _IReportePreferenteDom;
        public ReportePreferenteApp(IReportePreferenteDom IReportePreferenteDom)
        {
            this._IReportePreferenteDom = IReportePreferenteDom;
        }

        public async Task<List<PreferenteReporteMedioContactoDTO>> ObtenerReportePorMedioContacto(DateTime fechaDesde, DateTime fechaHasta, int idMedioContacto)
        {
            return await _IReportePreferenteDom.ObtenerReportePorMedioContacto(fechaDesde, fechaHasta, idMedioContacto);
        }

        public async Task<PreferenteReporteTotalDTO> ObtenerReporteTotal(DateTime fecha)
        {
            return await _IReportePreferenteDom.ObtenerReporteTotal(fecha);
        }
    }
}
