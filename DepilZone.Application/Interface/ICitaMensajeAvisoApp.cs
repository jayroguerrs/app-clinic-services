using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Interface
{
	public interface ICitaMensajeAvisosApp
	{
		Task<IEnumerable<CitaMensajeAvisoEnt>> Obtener(int idCita);
		Task<Respuesta<CitaMensajeAvisoEnt>> Insertar(CitaMensajeAvisoEnt model);
		Task<Respuesta<CitaMensajeAvisoEnt>> Modificar(CitaMensajeAvisoEnt model);

		Task<List<CitaMensajeAvisoDTO>> ListarByCita(int idCita);
	}
}
