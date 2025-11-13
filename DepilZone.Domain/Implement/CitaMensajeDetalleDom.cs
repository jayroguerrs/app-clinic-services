using DepilZone.Data.Interface;
using DepilZone.Domain.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Domain.Implement
{
    public class CitaMensajeDetalleDom : ICitaMensajeDetalleDom
	{
		private readonly ICitaMensajeDetalleDat _ICitaMensajeDetalleDat;
		public CitaMensajeDetalleDom(ICitaMensajeDetalleDat ICitaMensajeDetalleDat)
		{
			this._ICitaMensajeDetalleDat = ICitaMensajeDetalleDat;
		}
		public async Task<IEnumerable<CitaMensajeDetalleEnt>> Obtener()
		{
			return await _ICitaMensajeDetalleDat.Obtener();
		}
		public async Task<CitaMensajeDetalleEnt> ObtenerById(int id)
		{
			return await _ICitaMensajeDetalleDat.ObtenerById(id);
		}
		public async Task<Respuesta<CitaMensajeDetalleEnt>> Insertar(CitaMensajeDetalleEnt model)
		{
			return await _ICitaMensajeDetalleDat.Insertar(model);
		}
		public async Task<Respuesta<CitaMensajeDetalleEnt>> Modificar(CitaMensajeDetalleEnt model)
		{
			return await _ICitaMensajeDetalleDat.Modificar(model);
		}

		public async Task<List<CitaMensajeDetalleDTO>> ListarByCita(int idCita)
        {
			return await _ICitaMensajeDetalleDat.ListarByCita(idCita);
		}
	}
}
