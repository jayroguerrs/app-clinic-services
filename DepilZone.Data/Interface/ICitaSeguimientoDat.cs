using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Data.Interface
{
    public interface ICitaSeguimientoDat
	{
		Task<IEnumerable<CitaSeguimientoDTO>> ObtenerGridByCita(int idCita);
		Task<IEnumerable<CitaSeguimientoDTO>> ObtenerGridByCliente(int idCliente);
		Task<IEnumerable<CitaSeguimientoDTO>> ObtenerGridByClientePorServicio(int idCliente, int idServicio);
		Task<CitaSeguimientoEnt> ObtenerById(int Id);
	}
}
