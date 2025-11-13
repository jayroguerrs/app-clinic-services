using DepilZone.Entidad;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Interface
{
	public interface IDetalleCitaHorarioApp
	{
		Task<IEnumerable<DetalleCitaHorarioEnt>> Obtener();
		Task<Respuesta<DetalleCitaHorarioEnt>> Insertar(DetalleCitaHorarioEnt model);
		Task<DetalleCitaHorarioEnt> ObtenerById(int Id);
		Task<Respuesta<DetalleCitaHorarioEnt>> Modificar(DetalleCitaHorarioEnt model);
		Task<IEnumerable<RangoHorarioEnt>> Obteneridhorariocita(string horainicio, string horafin, int IdMaquina, int IdSede);
	}
}
