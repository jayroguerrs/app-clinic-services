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
	public class ClienteRecurrenteDom: IClienteRecurrenteDom
	{
		private readonly IClienteRecurrenteDat _IClienteRecurrenteDat;

		public ClienteRecurrenteDom(IClienteRecurrenteDat IClienteRecurrenteDat)
		{
			this._IClienteRecurrenteDat = IClienteRecurrenteDat;
		}
		public async Task<IEnumerable<ClienteRecurrenteDTO>> Obtener()
		{
			return await _IClienteRecurrenteDat.Obtener();
		}
		public async Task<IEnumerable<ClienteRecurrenteDTO>> Obtenercitafecha(DateTime fechaInicio, DateTime fechaTermino)
		{
			return await _IClienteRecurrenteDat.Obtenercitafecha(fechaInicio, fechaTermino);
		}
	}
}
