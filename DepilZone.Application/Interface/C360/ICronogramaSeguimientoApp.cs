using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace DepilZone.Application.Interface

{
	public interface ICronogramaSeguimientoApp
	{
		Task<List<CronogramaSeguimientoDTO>> ObtenerByCronograma(int idCronograma);
	}
}
