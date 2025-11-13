using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DepilZone.Data;
using DepilZone.Data.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;

namespace DepilZone.Domain.Implement
{
	public  class AperturaDom : IAperturaDom
	{
		private readonly IAperturaDat _IAperturaDat;
		public AperturaDom(IAperturaDat IAperturaDat)
		{
			this._IAperturaDat = IAperturaDat;
		}
		public async Task<Respuesta<ListadoAperturayCierreEnt>> Insertar(ListadoAperturayCierreEnt model)
		{
			return await _IAperturaDat.Insertar(model);
		}
		public async Task<IEnumerable<ListadoAperturayCierreEnt>> Obtenerlistadoaperturaycierreporfechayidturno(DateTime fechaInicio, int idturno, int idcaja)
		{
			return await _IAperturaDat.Obtenerlistadoaperturaycierreporfechayidturno(fechaInicio, idturno, idcaja);
		}
		public async Task<IEnumerable<ReporteAperturaEnt>> reportecierre(DateTime fechaInicio, int idturno)
		{
			return await _IAperturaDat.reportecierre(fechaInicio, idturno);
		}
		public async Task<IEnumerable<ReporteAperturaEnt>> montototal(DateTime fechaInicio, int idturno)
		{
			return await _IAperturaDat.montototal(fechaInicio, idturno);
		}
		public async Task<IEnumerable<ReporteAperturaEnt>> principal(DateTime fechaInicio, int idturno, int idcaja)
		{
			return await _IAperturaDat.principal(fechaInicio, idturno, idcaja);
		}
		public async Task<Respuesta<ListadoAperturayCierreEnt>> Modificar(ListadoAperturayCierreEnt model)
		{
			return await _IAperturaDat.Modificar(model);
		}
	}
}
