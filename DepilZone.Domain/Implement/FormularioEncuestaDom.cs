using DepilZone.Data.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Domain.Implement
{
    public class FormularioEncuestaDom: IFormularioEncuestaDom
	{
		private readonly IFormularioEncuestaDat _IFormularioEncuestaDat;
		public FormularioEncuestaDom(IFormularioEncuestaDat IFormularioEncuestaDat)
		{
			this._IFormularioEncuestaDat = IFormularioEncuestaDat;
		}
		public async Task<List<FormularioEncuestaDTO>> ObtenerListado(int idTipo)
		{
			return await _IFormularioEncuestaDat.ObtenerListado(idTipo);
		}


		public async Task<List<FormularioEncuestaDTO>> ObtenerListadoByCliente(int idCliente, int idTipo)
		{
			return await _IFormularioEncuestaDat.ObtenerListadoByCliente(idCliente, idTipo);
		}


		public async Task<FormularioEncuestaDTO> ObtenerById(int idFormulario)
		{
			return await _IFormularioEncuestaDat.ObtenerById(idFormulario);
		}

		public async Task<bool> GuardarEncuesta(FormularioEncuestaRespuestaDTO model)
        {
			return await _IFormularioEncuestaDat.GuardarEncuesta(model);
		}


		public async Task<List<FormularioEncuestaPreguntaDTO>> ObtenerReporte(int idSede, int idFormulario, DateTime fechaInicio, DateTime fechaFin)
        {
			return await _IFormularioEncuestaDat.ObtenerReporte(idSede, idFormulario, fechaInicio, fechaFin);
		}

		public async Task<List<FormularioEncuestaPreguntaDTO>> BuscarReporte(int idFormulario)
        {
			return await _IFormularioEncuestaDat.BuscarReporte( idFormulario);

		}

		public async Task<List<ClienteDTO>> ObtenerClientes(int idSede, int idFormulario, DateTime fechaInicio, DateTime fechaFin)
        {
			return await _IFormularioEncuestaDat.ObtenerClientes(idSede, idFormulario, fechaInicio, fechaFin);
		}

		public async Task<List<FormularioEncuestaRespuestaDTO>> ObtenerListadoByClienteFormulario(int idCliente, int idFormulario)
        {
			return await _IFormularioEncuestaDat.ObtenerListadoByClienteFormulario( idCliente,  idFormulario);
		}


	}
}
