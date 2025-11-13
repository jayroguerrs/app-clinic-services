using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Interface
{
	public interface IReporteCitaApp
	{
		Task<List<EspecialistaDTO>> ObtenerEspecialistasCitas(int idSede, DateTime fechaInicio, DateTime fechaTermino, int idUsuario);

		Task<List<EspecialistaCitaDTO>> ObtenerEspecialistasCitasDetalle(int idUsuario, DateTime fecha, int idSede);

		Task<List<CronogramaCitasAtendidasDTO>> ObtenerCronogramaCitasAtendidas(int idSede, DateTime fechaDesde, DateTime fechaHasta);

		Task<List<ReporteAtendidosDiariosDTO>> ReporteAtendidosDiarios(DateTime fecha, int idSede, int idServicio);
	}

}
