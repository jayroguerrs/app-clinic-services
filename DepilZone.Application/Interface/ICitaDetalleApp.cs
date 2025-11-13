using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Interface
{
	public interface ICitaDetalleApp
	{
		//Task<IEnumerable<CitaDetalleEnt>> Obtener();
		//Task<Respuesta<CitaDetalleEnt>> Insertar(CitaDetalleEnt model);
		//Task<CitaDetalleEnt> ObtenerById(int IdTipoCita);
		//Task<Respuesta<CitaDetalleEnt>> Modificar(CitaDetalleEnt model);
		Task<IEnumerable<CitaNoDisponibleDTO>> GetHorarioNoDisponible(DateTime fecha, int idMaquina, int idSede, int idUsuario, int idAccion, int idCita);

		Task<IEnumerable<CitaDetalleZonaDTO>> ObtenerDetallesCitaByCita(int idCita);
	}
}
