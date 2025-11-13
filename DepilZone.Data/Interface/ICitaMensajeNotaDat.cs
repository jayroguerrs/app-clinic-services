using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Data.Interface
{
	public interface ICitaMensajeNotaDat
	{
		Task<IEnumerable<CitaMensajeNotaEnt>> Obtener();

		Task<CitaMensajeNotaEnt> ObtenerById(int Id);
		Task<Respuesta<CitaMensajeNotaEnt>> Insertar(CitaMensajeNotaEnt model);
		Task<Respuesta<CitaMensajeNotaEnt>> Modificar(CitaMensajeNotaEnt model);

		Task<List<CitaMensajeNotaDTO>> ListarByCita(int idCita);
	}
}
