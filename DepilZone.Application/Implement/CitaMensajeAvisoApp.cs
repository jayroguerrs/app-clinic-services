using DepilZone.Application.Interface;
using DepilZone.Domain.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement
{
	public class CitaMensajeAvisoApp : ICitaMensajeAvisosApp
	{
		private readonly ICitaMensajeAvisoDom _IAvisosDom;
		public CitaMensajeAvisoApp(ICitaMensajeAvisoDom IAvisosDom)
		{
			this._IAvisosDom = IAvisosDom;
		}
		public async Task<IEnumerable<CitaMensajeAvisoEnt>> Obtener(int idCita)
		{
			return await _IAvisosDom.Obtener(idCita);
		}
		public async Task<Respuesta<CitaMensajeAvisoEnt>> Insertar(CitaMensajeAvisoEnt model)
		{
			return await _IAvisosDom.Insertar(model);
		}
		public async Task<Respuesta<CitaMensajeAvisoEnt>> Modificar(CitaMensajeAvisoEnt model)
		{
			return await _IAvisosDom.Modificar(model);
		}
		//public async Task<CitaMensajeAvisoEnt> ObtenerById(int Id)
		//{
		//	return await _IAvisosDom.ObtenerById(Id);
		//}

		public async Task<List<CitaMensajeAvisoDTO>> ListarByCita(int idCita)
        {
			return await _IAvisosDom.ListarByCita(idCita);
		}
	}
}
