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
	public class AperturaApp : IAperturaApp
	{
		private readonly IAperturaDom _IAperturaDom;
		public AperturaApp(IAperturaDom IAperturaDom)
		{
			this._IAperturaDom = IAperturaDom;
		}
		public async Task<Respuesta<ListadoAperturayCierreEnt>> Insertar(ListadoAperturayCierreEnt model)
		{
			return await _IAperturaDom.Insertar(model);
		}
		public async Task<IEnumerable<ListadoAperturayCierreEnt>> Obtenerlistadoaperturaycierreporfechayidturno(DateTime fechaInicio, int idturno, int idcaja)
		{
			return await _IAperturaDom.Obtenerlistadoaperturaycierreporfechayidturno(fechaInicio, idturno, idcaja);
		}
		public async Task<IEnumerable<ReporteAperturaEnt>> reportecierre(DateTime fechaInicio, int idturno)
		{
			return await _IAperturaDom.reportecierre(fechaInicio, idturno);
		}
		public async Task<IEnumerable<ReporteAperturaEnt>> montototal(DateTime fechaInicio, int idturno)
		{
			return await _IAperturaDom.montototal(fechaInicio, idturno);
		}
		public async Task<IEnumerable<ReporteAperturaEnt>> principal(DateTime fechaInicio, int idturno, int idcaja)
		{
			return await _IAperturaDom.principal(fechaInicio, idturno, idcaja);
		}
		public async Task<Respuesta<ListadoAperturayCierreEnt>> Modificar(ListadoAperturayCierreEnt model)
		{
			return await _IAperturaDom.Modificar(model);
		}
	}
}
