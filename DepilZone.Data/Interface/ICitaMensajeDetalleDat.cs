using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Data.Interface
{
    public interface ICitaMensajeDetalleDat
	{
		Task<IEnumerable<CitaMensajeDetalleEnt>> Obtener();
		Task<CitaMensajeDetalleEnt> ObtenerById(int Id);
		Task<Respuesta<CitaMensajeDetalleEnt>> Insertar(CitaMensajeDetalleEnt model);
		Task<Respuesta<CitaMensajeDetalleEnt>> Modificar(CitaMensajeDetalleEnt model);

		Task<List<CitaMensajeDetalleDTO>> ListarByCita(int idCita);
	}
}

