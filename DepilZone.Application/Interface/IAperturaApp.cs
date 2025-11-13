using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace DepilZone.Application.Interface
{
	public interface IAperturaApp
	{
		Task<Respuesta<ListadoAperturayCierreEnt>> Insertar(ListadoAperturayCierreEnt model);
		Task<IEnumerable<ListadoAperturayCierreEnt>> Obtenerlistadoaperturaycierreporfechayidturno(DateTime fechaInicio, int idturno, int idcaja);
		Task<IEnumerable<ReporteAperturaEnt>> reportecierre(DateTime fechaInicio, int idturno);
		Task<IEnumerable<ReporteAperturaEnt>> montototal(DateTime fechaInicio, int idturno);
		Task<IEnumerable<ReporteAperturaEnt>> principal(DateTime fechaInicio, int idturno, int idcaja);
		Task<Respuesta<ListadoAperturayCierreEnt>> Modificar(ListadoAperturayCierreEnt model);
	}
}
