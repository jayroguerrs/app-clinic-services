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
	public class CitaMensajeNotaDom : ICitaMensajeNotaDom
	{
		private readonly ICitaMensajeNotaDat _ICitaMensajeNotasDat;
		public CitaMensajeNotaDom(ICitaMensajeNotaDat ICitaMensajeNotaDat)
		{
			this._ICitaMensajeNotasDat = ICitaMensajeNotaDat;
		}
		public async Task<IEnumerable<CitaMensajeNotaEnt>> Obtener()
		{
			return await _ICitaMensajeNotasDat.Obtener();
		}
		public async Task<CitaMensajeNotaEnt> ObtenerById(int id)
		{
			return await _ICitaMensajeNotasDat.ObtenerById(id);
		}
		public async Task<Respuesta<CitaMensajeNotaEnt>> Insertar(CitaMensajeNotaEnt model)
		{
			return await _ICitaMensajeNotasDat.Insertar(model);
		}
		public async Task<Respuesta<CitaMensajeNotaEnt>> Modificar(CitaMensajeNotaEnt model)
		{
			return await _ICitaMensajeNotasDat.Modificar(model);
		}

		public async Task<List<CitaMensajeNotaDTO>> ListarByCita(int idCita)
        {
			return await _ICitaMensajeNotasDat.ListarByCita(idCita);
		}

	}
}
