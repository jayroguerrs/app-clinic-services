
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Data.Interface
{
	public interface IReporteClienteDom
	{
		Task<List<ClienteCumpleaniosDTO>> ObtenerCumpleanios(DateTime fechaDesde, DateTime fechaHasta, int idEstadoAtendido);
	}
}
