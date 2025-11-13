using DepilZone.Application.Interface;
using DepilZone.Domain.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement
{
	public class CitaSeguimientoApp : ICitaSeguimientoApp
	{
		private readonly ICitaSeguimientoDom _ISeguimientoCitaDom;
		public CitaSeguimientoApp(ICitaSeguimientoDom ISeguimientoCitaDom)
		{
			this._ISeguimientoCitaDom = ISeguimientoCitaDom;
		}
		public async Task<IEnumerable<CitaSeguimientoDTO>> ObtenerGridByCita(int idCita)
		{
			return await _ISeguimientoCitaDom.ObtenerGridByCita(idCita);
		}
		public async Task<IEnumerable<CitaSeguimientoDTO>> ObtenerGridByCliente(int idCliente)
		{
			return await _ISeguimientoCitaDom.ObtenerGridByCliente(idCliente);
		}
		public async Task<IEnumerable<CitaSeguimientoDTO>> ObtenerGridByClientePorServicio(int idCliente, int idServicio)
		{
			return await _ISeguimientoCitaDom.ObtenerGridByClientePorServicio(idCliente, idServicio);
		}
	}
}
