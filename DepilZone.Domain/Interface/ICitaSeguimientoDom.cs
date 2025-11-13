using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Domain.Interface
{
    public interface ICitaSeguimientoDom
	{
        Task<IEnumerable<CitaSeguimientoDTO>> ObtenerGridByCita(int idCita);
        Task<IEnumerable<CitaSeguimientoDTO>> ObtenerGridByCliente(int idCliente);
        Task<IEnumerable<CitaSeguimientoDTO>> ObtenerGridByClientePorServicio(int idCliente, int idServicio);
    }
}
