using DepilZone.Application.Interface;
using DepilZone.Data.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement
{
	public class FormularioEncuestaApp : IFormularioEncuestaApp
	{
		private readonly IFormularioEncuestaDom _IFormularioEncuestaDom;
        public FormularioEncuestaApp(IFormularioEncuestaDom IFormularioEncuestaDom)
        {
            this._IFormularioEncuestaDom = IFormularioEncuestaDom;
        }

        public async Task<List<FormularioEncuestaDTO>> ObtenerListado(int idTipo)
        {
            return await _IFormularioEncuestaDom.ObtenerListado(idTipo);
        }


        public async Task<List<FormularioEncuestaDTO>> ObtenerListadoByCliente(int idCliente, int idTipo)
        {
            return await _IFormularioEncuestaDom.ObtenerListadoByCliente(idCliente, idTipo);
        }


        public async Task<FormularioEncuestaDTO> ObtenerById(int idFormulario)
        {
            return await _IFormularioEncuestaDom.ObtenerById(idFormulario);
        }

        public async Task<bool> GuardarEncuesta(FormularioEncuestaRespuestaDTO model)
        {
            return await _IFormularioEncuestaDom.GuardarEncuesta(model);
        }


        public async Task<List<FormularioEncuestaPreguntaDTO>> ObtenerReporte(int idSede, int idFormulario, DateTime fechaInicio, DateTime fechaFin)
        {
            return await _IFormularioEncuestaDom.ObtenerReporte( idSede,  idFormulario,  fechaInicio,  fechaFin);
        }

        public async Task<List<FormularioEncuestaPreguntaDTO>> BuscarReporte(int idFormulario)
        {
            return await _IFormularioEncuestaDom.BuscarReporte( idFormulario);
        }

        public async Task<List<ClienteDTO>> ObtenerClientes(int idSede, int idFormulario, DateTime fechaInicio, DateTime fechaFin)
        {
            return await _IFormularioEncuestaDom.ObtenerClientes(idSede, idFormulario, fechaInicio, fechaFin);
        }

        public async Task<List<FormularioEncuestaRespuestaDTO>> ObtenerListadoByClienteFormulario(int idCliente, int idFormulario)
        {
            return await _IFormularioEncuestaDom.ObtenerListadoByClienteFormulario(idCliente, idFormulario);
        }

    }
}
