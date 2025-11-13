using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Interface
{
	public interface ICronogramaCitaApp
	{
		Task<int> Insertar(CronogramaCitaDTO model);
		Task<bool> Modificar(CronogramaCitaDTO model);
		Task<CronogramaCitaDTO> BuscarCronograma(int id);
		//Task<List<CronogramaCitaSemanaDTO>> ListarSemanas(string uuid, int id);
		Task<List<CronogramaCitaDTO>> ListarPorCliente(int idCliente, int idServicio);

		Task<List<CronogramaCita_CitaDTO>> ListarCitas(int idCronograma);

	}
}
