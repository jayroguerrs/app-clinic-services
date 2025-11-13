using DepilZone.Application.Interface;
using DepilZone.Data.Interface;
using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace DepilZone.Application.Implement
{
	public class CronogramaCitaApp : ICronogramaCitaApp
	{
		private readonly ICronogramaCitaDom _ICronogramaCitaDom;
		public CronogramaCitaApp(ICronogramaCitaDom ICronogramaCitaDom)
		{
			this._ICronogramaCitaDom = ICronogramaCitaDom;
		}
		public async Task<int> Insertar(CronogramaCitaDTO model)
		{
			return await _ICronogramaCitaDom.Insertar(model);
		}
		public async Task<bool> Modificar(CronogramaCitaDTO model)
		{
			return await _ICronogramaCitaDom.Modificar(model);
		}
		public async Task<CronogramaCitaDTO> BuscarCronograma(int id)
		{
			return await _ICronogramaCitaDom.BuscarCronograma(id);
		}
		/*public async Task<List<CronogramaCitaSemanaDTO>> ListarSemanas(string uuid, int id)
        {
			return await _ICronogramaCitaDom.ListarSemanas(uuid, id);
		}*/

		public async Task<List<CronogramaCitaDTO>> ListarPorCliente(int idCliente, int idServicio)
		{
			return await _ICronogramaCitaDom.ListarPorCliente(idCliente, idServicio);
		}

		public async Task<List<CronogramaCita_CitaDTO>> ListarCitas(int idCronograma)
        {
			return await _ICronogramaCitaDom.ListarCitas(idCronograma);
		}

	}
}