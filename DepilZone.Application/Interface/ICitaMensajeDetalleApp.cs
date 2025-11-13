using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Interface
{
	public interface ICitaMensajeDetalleApp
	{
		Task<IEnumerable<CitaMensajeDetalleEnt>> Obtener();
		Task<Respuesta<CitaMensajeDetalleEnt>> Insertar(CitaMensajeDetalleEnt model);
		Task<CitaMensajeDetalleEnt> ObtenerById(int Id);
		Task<Respuesta<CitaMensajeDetalleEnt>> Modificar(CitaMensajeDetalleEnt model);

		Task<List<CitaMensajeDetalleDTO>> ListarByCita(int idCita);
	}
}
