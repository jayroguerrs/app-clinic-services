using DepilZone.Data.Interface;
using DepilZone.Domain.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Domain.Implement
{
	public class CitaSeguimientoDom: ICitaSeguimientoDom
	{
		private readonly ICitaSeguimientoDat _ISeguimientoCitaDat;
		public CitaSeguimientoDom(ICitaSeguimientoDat ISeguimientoCitaDat)
		{
			this._ISeguimientoCitaDat = ISeguimientoCitaDat;
		}
		public async Task<IEnumerable<CitaSeguimientoDTO>> ObtenerGridByCita(int idCita)
		{
			return await _ISeguimientoCitaDat.ObtenerGridByCita(idCita);
		}
		public async Task<IEnumerable<CitaSeguimientoDTO>> ObtenerGridByCliente(int idCliente)
		{
			return await _ISeguimientoCitaDat.ObtenerGridByCliente(idCliente);
		}
		public async Task<IEnumerable<CitaSeguimientoDTO>> ObtenerGridByClientePorServicio(int idCliente, int idServicio)
		{
			return await _ISeguimientoCitaDat.ObtenerGridByClientePorServicio(idCliente, idServicio);
		}

	}
}
