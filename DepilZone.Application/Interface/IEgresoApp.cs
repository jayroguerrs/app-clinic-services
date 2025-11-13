using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Interface
{
	public interface IEgresoApp
	{
		Task<IEnumerable<EgresoDTO>> Obtener(DateTime fechaInicio, DateTime fechaTermino);
		Task<Respuesta<EgresoEnt>> Insertar(EgresoEnt model);
		Task<bool> AnularEgreso(EgresoEnt model);
	}
}
