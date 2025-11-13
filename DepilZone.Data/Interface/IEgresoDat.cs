using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Data.Interface
{
	public interface IEgresoDat
	{
		Task<IEnumerable<EgresoDTO>> Obtener(DateTime fechaInicio, DateTime fechaTermino);
		Task<Respuesta<EgresoEnt>> Insertar(EgresoEnt model);
		Task<bool> AnularEgreso(EgresoEnt model);
	}
}
