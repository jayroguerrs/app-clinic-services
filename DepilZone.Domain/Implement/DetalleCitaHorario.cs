using DepilZone.Data.Interface;
using DepilZone.Domain.Interface;
using DepilZone.Entidad;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Domain.Implement
{
    public class DetalleCitaHorarioDom : IDetalleCitaHorarioDom
	{
		private readonly IDetalleCitaHorarioDat _IDetalleCitaHorarioDat;
		public DetalleCitaHorarioDom(IDetalleCitaHorarioDat IDetalleCitaHorarioDat)
		{
			this._IDetalleCitaHorarioDat = IDetalleCitaHorarioDat;
		}
		public async Task<IEnumerable<DetalleCitaHorarioEnt>> Obtener()
		{
			return await _IDetalleCitaHorarioDat.Obtener();
		}
		public async Task<DetalleCitaHorarioEnt> ObtenerById(int id)
		{
			return await _IDetalleCitaHorarioDat.ObtenerById(id);
		}
		public async Task<Respuesta<DetalleCitaHorarioEnt>> Insertar(DetalleCitaHorarioEnt model)
		{
			return await _IDetalleCitaHorarioDat.Insertar(model);
		}
		public async Task<Respuesta<DetalleCitaHorarioEnt>> Modificar(DetalleCitaHorarioEnt model)
		{
			return await _IDetalleCitaHorarioDat.Modificar(model);
		}
		public async Task<IEnumerable<RangoHorarioEnt>> Obteneridhorariocita(string horainicio, string horafin, int IdMaquina, int IdSede)
		{
			return await _IDetalleCitaHorarioDat.Obteneridhorariocita(horainicio, horafin, IdMaquina , IdSede);
		}
	}
}
