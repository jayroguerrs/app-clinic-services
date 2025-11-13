using DepilZone.Entidad;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Interface
{
	public interface ITipoClienteApp
	{
		Task<IEnumerable<TipoClienteEnt>> Obtener();
	}
}
