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
	public class CitaMensajeAvisoDom : ICitaMensajeAvisoDom
	{
		private readonly ICitaMensajeAvisoDat _ICitaMensajeAvisosDat;
		public CitaMensajeAvisoDom(ICitaMensajeAvisoDat IAvisosDat)
		{
			this._ICitaMensajeAvisosDat = IAvisosDat;
		}
		public async Task<IEnumerable<CitaMensajeAvisoEnt>> Obtener(int idCita)
		{
			return await _ICitaMensajeAvisosDat.Obtener(idCita);
		}
		//public async Task<CitaMensajeAvisoEnt> ObtenerById(int id)
		//{
		//	return await _IAvisosDat.ObtenerById(id);
		//}
		public async Task<Respuesta<CitaMensajeAvisoEnt>> Insertar(CitaMensajeAvisoEnt model)
		{
			return await _ICitaMensajeAvisosDat.Insertar(model);
		}
		public async Task<Respuesta<CitaMensajeAvisoEnt>> Modificar(CitaMensajeAvisoEnt model)
		{
			return await _ICitaMensajeAvisosDat.Modificar(model);
		}

		public async Task<List<CitaMensajeAvisoDTO>> ListarByCita(int idCita)
        {
			return await _ICitaMensajeAvisosDat.ListarByCita(idCita);
		}
	}
}
