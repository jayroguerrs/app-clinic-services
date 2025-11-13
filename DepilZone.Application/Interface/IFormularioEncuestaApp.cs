using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace DepilZone.Application.Interface
{
    public interface IFormularioEncuestaApp
	{
		Task<List<FormularioEncuestaDTO>> ObtenerListado(int idTipo);

		Task<List<FormularioEncuestaDTO>> ObtenerListadoByCliente(int idCliente, int idTipo);

		Task<FormularioEncuestaDTO> ObtenerById(int idFormulario);

		Task<bool> GuardarEncuesta(FormularioEncuestaRespuestaDTO model);

		Task<List<FormularioEncuestaPreguntaDTO>> ObtenerReporte(int idSede, int idFormulario, DateTime fechaInicio, DateTime fechaFin);

		Task<List<FormularioEncuestaPreguntaDTO>> BuscarReporte(int idFormulario);

		Task<List<ClienteDTO>> ObtenerClientes(int idSede, int idFormulario, DateTime fechaInicio, DateTime fechaFin);

		Task<List<FormularioEncuestaRespuestaDTO>> ObtenerListadoByClienteFormulario(int idCliente, int idFormulario);

	}
}
