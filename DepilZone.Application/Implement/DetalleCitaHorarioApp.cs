using DepilZone.Application.Interface;
using DepilZone.Domain.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace DepilZone.Application.Implement
{
	public class DetalleCitaHorarioApp : IDetalleCitaHorarioApp
	{
		private readonly IDetalleCitaHorarioDom _IDetalleCitaHorarioDom;
		public DetalleCitaHorarioApp(IDetalleCitaHorarioDom IDetalleCitaHorarioDom)
		{
			this._IDetalleCitaHorarioDom = IDetalleCitaHorarioDom;
		}
		public async Task<IEnumerable<DetalleCitaHorarioEnt>> Obtener()
		{
			return await _IDetalleCitaHorarioDom.Obtener();
		}
		public async Task<Respuesta<DetalleCitaHorarioEnt>> Insertar(DetalleCitaHorarioEnt model)
		{
			return await _IDetalleCitaHorarioDom.Insertar(model);
		}
		public async Task<Respuesta<DetalleCitaHorarioEnt>> Modificar(DetalleCitaHorarioEnt model)
		{
			return await _IDetalleCitaHorarioDom.Modificar(model);
		}
		public async Task<DetalleCitaHorarioEnt> ObtenerById(int Id)
		{
			return await _IDetalleCitaHorarioDom.ObtenerById(Id);
		}
		public async Task<IEnumerable<RangoHorarioEnt>> Obteneridhorariocita(string horainicio, string horafin, int IdMaquina, int IdSede)
		{
			return await _IDetalleCitaHorarioDom.Obteneridhorariocita(horainicio, horafin, IdMaquina , IdSede);
		}
	}
}
