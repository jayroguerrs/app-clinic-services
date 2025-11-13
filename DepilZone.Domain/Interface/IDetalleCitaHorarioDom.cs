using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace DepilZone.Domain.Interface
{
	public interface IDetalleCitaHorarioDom
	{
		Task<IEnumerable<DetalleCitaHorarioEnt>> Obtener();
		Task<DetalleCitaHorarioEnt> ObtenerById(int Id);
		Task<Respuesta<DetalleCitaHorarioEnt>> Insertar(DetalleCitaHorarioEnt model);
		Task<Respuesta<DetalleCitaHorarioEnt>> Modificar(DetalleCitaHorarioEnt model);
		Task<IEnumerable<RangoHorarioEnt>> Obteneridhorariocita(string horainicio, string horafin, int IdMaquina, int IdSede);
	}
}
