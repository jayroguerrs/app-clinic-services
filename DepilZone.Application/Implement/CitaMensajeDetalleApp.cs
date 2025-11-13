using DepilZone.Application.Interface;
using DepilZone.Domain.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement
{
	public class CitaMensajeDetalleApp : ICitaMensajeDetalleApp
	{
		private readonly ICitaMensajeDetalleDom _ICitaMensajeDetalleDom;
		public CitaMensajeDetalleApp(ICitaMensajeDetalleDom ICitaMensajeDetalleDom)
		{
			this._ICitaMensajeDetalleDom = ICitaMensajeDetalleDom;
		}
		public async Task<IEnumerable<CitaMensajeDetalleEnt>> Obtener()
		{
			return await _ICitaMensajeDetalleDom.Obtener();
		}
		public async Task<Respuesta<CitaMensajeDetalleEnt>> Insertar(CitaMensajeDetalleEnt model)
		{
			return await _ICitaMensajeDetalleDom.Insertar(model);
		}
		public async Task<Respuesta<CitaMensajeDetalleEnt>> Modificar(CitaMensajeDetalleEnt model)
		{
			return await _ICitaMensajeDetalleDom.Modificar(model);
		}
		public async Task<CitaMensajeDetalleEnt> ObtenerById(int Id)
		{
			return await _ICitaMensajeDetalleDom.ObtenerById(Id);
		}

		public async Task<List<CitaMensajeDetalleDTO>> ListarByCita(int idCita)
        {
			return await _ICitaMensajeDetalleDom.ListarByCita(idCita);
		}
	}
}
