
using DepilZone.Data.Interface.C360;
using DepilZone.Domain.Interface.C360;
using DepilZone.Entidad.DTO;
using DepilZone.Entidad.DTO.C360;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Domain.Implement
{
    public class MaquinaSede360Dom : IMaquinaSede360Dom
	{
		private readonly IMaquinaSede360Dat _IMaquinaSede360Dat;
		public MaquinaSede360Dom(IMaquinaSede360Dat IMaquinaSede360Dat)
		{
			this._IMaquinaSede360Dat = IMaquinaSede360Dat;
		}
		public async Task<List<MaquinaSede360DisponibleDTO>> BuscarFechaDisponible(DateTime fechaDesde, DateTime fechaHasta, int idServicio, int idSede)
		{
			return await _IMaquinaSede360Dat.BuscarFechaDisponible( fechaDesde,  fechaHasta,  idServicio,  idSede);
		}
		public async Task<List<MaquinaSede360DTO>> VerMaquinaDisponible(DateTime fecha, int idServicio, int idSede)
		{
			return await _IMaquinaSede360Dat.VerMaquinaDisponible(fecha, idServicio, idSede);
		}

		public async Task<MaquinaSede360DTO> VerMaquinaDisponibleById(int IdMaquinaSede, DateTime fecha, int idServicio, int idSede)
        {
			return await _IMaquinaSede360Dat.VerMaquinaDisponibleById(IdMaquinaSede, fecha, idServicio, idSede);
		}

		public async Task<bool> AsignarTecnologias(int idMaquinaSede, MaquinaSedeTecnologia360DTO model)
		{
			return await _IMaquinaSede360Dat.AsignarTecnologias( idMaquinaSede, model);
		}
		public async Task<List<TecnologiaDTO>> ListarTecnologias(int idMaquinaSede)
        {
			return await _IMaquinaSede360Dat.ListarTecnologias(idMaquinaSede);
		}


	}
}

