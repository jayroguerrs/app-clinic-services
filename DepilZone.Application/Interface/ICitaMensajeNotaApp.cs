using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace DepilZone.Application.Interface

{
	public interface ICitaMensajeNotaApp
	{
		Task<IEnumerable<CitaMensajeNotaEnt>> Obtener();
		Task<Respuesta<CitaMensajeNotaEnt>> Insertar(CitaMensajeNotaEnt model);
		Task<CitaMensajeNotaEnt> ObtenerById(int IdTipoCita);
		Task<Respuesta<CitaMensajeNotaEnt>> Modificar(CitaMensajeNotaEnt model);

		Task<List<CitaMensajeNotaDTO>> ListarByCita(int idCita);
			

	}

}
