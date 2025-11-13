using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace DepilZone.Domain.Interface
{
    public interface ICitaDetalleDom
	{
		//Task<IEnumerable<CitaDetalleEnt>> Obtener();
		//Task<CitaDetalleEnt> ObtenerById(int Id);
		//Task<Respuesta<CitaDetalleEnt>> Insertar(CitaDetalleEnt model);
		//Task<Respuesta<CitaDetalleEnt>> Modificar(CitaDetalleEnt model);
		Task<IEnumerable<CitaNoDisponibleDTO>> GetHorarioNoDisponible(DateTime fecha, int idMaquina, int idSede, int idUsuario, int modoAccion, int idCita);

		Task<IEnumerable<CitaDetalleZonaDTO>> ObtenerDetallesCitaByCita(int idCita);
	}
}
