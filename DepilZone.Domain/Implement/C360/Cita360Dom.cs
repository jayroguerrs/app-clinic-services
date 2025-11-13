using DepilZone.Data.Interface.C360;
using DepilZone.Domain.Interface.C360;
using DepilZone.Entidad.DTO.C360;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Domain.Implement
{
    public class Cita360Dom : ICita360Dom
	{
		private readonly ICita360Dat _ICita360Dat;
		public Cita360Dom(ICita360Dat ICita360Dat)
		{
			this._ICita360Dat = ICita360Dat;
		}
		public async Task<bool> Insertar(Cita360DTO model)
		{
			return await _ICita360Dat.Insertar(model);
		}
		public async Task<bool> Modificar(int idCita, Cita360DTO model)
		{
			return await _ICita360Dat.Modificar(idCita, model);
		}
		public async Task<List<Cita360DTO>> BuscarByCronograma(int idCronograma)
		{
			return await _ICita360Dat.BuscarByCronograma(idCronograma);
		}
		public async Task<Cita360DTO> BuscarById(int idCita)
		{
			return await _ICita360Dat.BuscarById(idCita);
		}
		public async Task<bool> Cancelar(Cita360DTO model)
		{
			return await _ICita360Dat.Cancelar(model);
		}
		public async Task<bool> Pendiente(Cita360DTO model)
		{
			return await _ICita360Dat.Pendiente(model);
		}
		public async Task<bool> Anular(Cita360DTO model)
		{
			return await _ICita360Dat.Anular(model);
		}
		public async Task<bool> Confirmar(Cita360DTO model)
		{
			return await _ICita360Dat.Confirmar(model);
		}
        public async Task<bool> ConfirmarAsistencia(Cita360DTO model)
        {
            return await _ICita360Dat.ConfirmarAsistencia(model);
        }
        public async Task<bool> Atender(Cita360DTOAtender model)
		{
			return await _ICita360Dat.Atender(model);
		}

        public async Task<bool> NoLlamar(Cita360DTO model)
        {
            return await _ICita360Dat.NoLlamar(model);
        }

    }
}

