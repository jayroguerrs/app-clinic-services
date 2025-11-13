using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Data.Interface
{
	public interface ICitaMensajeAvisoDat
	{
		Task<IEnumerable<CitaMensajeAvisoEnt>> Obtener(int idCita);

		//Task<CitaMensajeAvisoEnt> ObtenerById(int Id);
		Task<Respuesta<CitaMensajeAvisoEnt>> Insertar(CitaMensajeAvisoEnt model);
		Task<Respuesta<CitaMensajeAvisoEnt>> Modificar(CitaMensajeAvisoEnt model);
		Task<List<CitaMensajeAvisoDTO>> ListarByCita(int idCita);
	}
}
