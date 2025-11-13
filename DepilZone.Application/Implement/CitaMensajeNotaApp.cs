using DepilZone.Application.Interface;
using DepilZone.Domain.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement
{
	public class CitaMensajeNotaApp : ICitaMensajeNotaApp
	{
		private readonly ICitaMensajeNotaDom _ICitaMensajeNotaDom;
		public CitaMensajeNotaApp(ICitaMensajeNotaDom ICitaMensajeNotaDom)
		{
			this._ICitaMensajeNotaDom = ICitaMensajeNotaDom;
		}
		public async Task<IEnumerable<CitaMensajeNotaEnt>> Obtener()
		{
			return await _ICitaMensajeNotaDom.Obtener();
		}
		public async Task<Respuesta<CitaMensajeNotaEnt>> Insertar(CitaMensajeNotaEnt model)
		{
			return await _ICitaMensajeNotaDom.Insertar(model);
		}
		public async Task<Respuesta<CitaMensajeNotaEnt>> Modificar(CitaMensajeNotaEnt model)
		{
			return await _ICitaMensajeNotaDom.Modificar(model);
		}
		public async Task<CitaMensajeNotaEnt> ObtenerById(int Id)
		{
			return await _ICitaMensajeNotaDom.ObtenerById(Id);
		}

		public async Task<List<CitaMensajeNotaDTO>> ListarByCita(int idCita)
        {
			return await _ICitaMensajeNotaDom.ListarByCita(idCita);
		}
	}
}
