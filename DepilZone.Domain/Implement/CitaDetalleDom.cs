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
	public class CitaDetalleDom : ICitaDetalleDom
	{
		private readonly ICitaDetalleDat _ICitaDetalleDat;
		public CitaDetalleDom(ICitaDetalleDat ICitaDetalleDat)
		{
			this._ICitaDetalleDat = ICitaDetalleDat;
		}
		//public async Task<IEnumerable<CitaDetalleEnt>> Obtener()
		//{
		//	return await _ICitaDetalleDat.Obtener();
		//}
		//public async Task<CitaDetalleEnt> ObtenerById(int id)
		//{
		//	return await _ICitaDetalleDat.ObtenerById(id);
		//}

		//public async Task<Respuesta<CitaDetalleEnt>> Insertar(CitaDetalleEnt model)
		//{
		//	return await _ICitaDetalleDat.Insertar(model);
		//}
		//public async Task<Respuesta<CitaDetalleEnt>> Modificar(CitaDetalleEnt model)
		//{
		//	return await _ICitaDetalleDat.Modificar(model);
		//}

        public async Task<IEnumerable<CitaNoDisponibleDTO>> GetHorarioNoDisponible(DateTime fecha, int idMaquina, int idSede, int idUsuario, int idAccion, int idCita)
        {
			return await _ICitaDetalleDat.GetHorarioNoDisponible(fecha, idMaquina, idSede, idUsuario, idAccion, idCita);
        }

		public async Task<IEnumerable<CitaDetalleZonaDTO>> ObtenerDetallesCitaByCita(int idCita)
		{
			return await _ICitaDetalleDat.ObtenerDetallesCitaByCita(idCita);
		}
	}
}
