using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace DepilZone.Application.Interface

{
	public interface ICitaSeguimientoApp
	{
		Task<IEnumerable<CitaSeguimientoDTO>> ObtenerGridByCita(int idCita);
		Task<IEnumerable<CitaSeguimientoDTO>> ObtenerGridByCliente(int idCliente);
		Task<IEnumerable<CitaSeguimientoDTO>> ObtenerGridByClientePorServicio(int idCliente, int idServicio);
	}
}
