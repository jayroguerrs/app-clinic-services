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
	public class ReporteClienteApp : IReporteClienteApp
	{
        private readonly IReporteClienteDom _IReporteClienteDom;
        public ReporteClienteApp(IReporteClienteDom IReporteClienteDom)
        {
            this._IReporteClienteDom = IReporteClienteDom;
        }

        public async Task<List<ClienteCumpleaniosDTO>> ObtenerCumpleanios(DateTime fechaDesde, DateTime fechaHasta, int idEstadoAtendido)
        {
            return await _IReporteClienteDom.ObtenerCumpleanios(fechaDesde, fechaHasta, idEstadoAtendido);
        }
    }
}
