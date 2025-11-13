using DepilZone.Application.Interface;
using DepilZone.Domain.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement
{
	public class CitaDetalleApp : ICitaDetalleApp
	{
		private readonly ICitaDetalleDom _ICitaDetalleDom;
		public CitaDetalleApp(ICitaDetalleDom ICitaDetalleDom)
		{
			this._ICitaDetalleDom = ICitaDetalleDom;
		}
		//public async Task<IEnumerable<CitaDetalleEnt>> Obtener()
		//{
		//	return await _ICitaDetalleDom.Obtener();
		//}
		//public async Task<Respuesta<CitaDetalleEnt>> Insertar(CitaDetalleEnt model)
		//{
		//	return await _ICitaDetalleDom.Insertar(model);
		//}
		//public async Task<Respuesta<CitaDetalleEnt>> Modificar(CitaDetalleEnt model)
		//{
		//	return await _ICitaDetalleDom.Modificar(model);
		//}
		//public async Task<CitaDetalleEnt> ObtenerById(int Id)
		//{
		//	return await _ICitaDetalleDom.ObtenerById(Id);
		//}

		public async Task<IEnumerable<CitaNoDisponibleDTO>> GetHorarioNoDisponible(DateTime fecha, int idMaquina, int idSede, int idUsuario, int idAccion, int idCita)
		{
			return await _ICitaDetalleDom.GetHorarioNoDisponible(fecha, idMaquina, idSede, idUsuario, idAccion, idCita);
		}

		public async Task<IEnumerable<CitaDetalleZonaDTO>> ObtenerDetallesCitaByCita(int idCita)
        {
			return await _ICitaDetalleDom.ObtenerDetallesCitaByCita(idCita);
		}

	}
}
