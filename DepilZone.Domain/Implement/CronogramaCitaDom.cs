using DepilZone.Data.Interface;
using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Domain.Implement
{
	public class CronogramaCitaDom : ICronogramaCitaDom
	{
		private readonly ICronogramaCitaDat _ICronogramaCitaDat;
		public CronogramaCitaDom(ICronogramaCitaDat ICronogramaCitaDat)
		{
			this._ICronogramaCitaDat = ICronogramaCitaDat;
		}
		public async Task<int> Insertar(CronogramaCitaDTO model)
		{
			return await _ICronogramaCitaDat.Insertar(model);
		}
		public async Task<bool> Modificar(CronogramaCitaDTO model)
		{
			return await _ICronogramaCitaDat.Modificar(model);
		}
		public async Task<CronogramaCitaDTO> BuscarCronograma(int id)
		{
			return await _ICronogramaCitaDat.BuscarCronograma(id);
		}

		/*public async Task<List<CronogramaCitaSemanaDTO>> ListarSemanas(string uuid, int id)
        {
			return await _ICronogramaCitaDat.ListarSemanas(uuid, id);
		}*/

		public async Task<List<CronogramaCitaDTO>> ListarPorCliente(int idCliente, int idServicio)
		{
			return await _ICronogramaCitaDat.ListarPorCliente(idCliente, idServicio);
		}

		public async Task<List<CronogramaCita_CitaDTO>> ListarCitas(int idCronograma)
        {
			return await _ICronogramaCitaDat.ListarCitas(idCronograma);
		}


	}
}

