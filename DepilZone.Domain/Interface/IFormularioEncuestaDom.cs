
﻿using DepilZone.Entidad.DTO;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Data.Interface
{
	public interface IFormularioEncuestaDom
	{
        Task<List<FormularioEncuestaDTO>> ObtenerListado(int idTipo);
        Task<FormularioEncuestaDTO> ObtenerById(int idFormulario);

        Task<List<FormularioEncuestaDTO>> ObtenerListadoByCliente(int idCliente,int idTipo);
        Task<bool> GuardarEncuesta(FormularioEncuestaRespuestaDTO model);

        Task<List<FormularioEncuestaPreguntaDTO>> ObtenerReporte(int idSede, int idFormulario, DateTime fechaInicio, DateTime fechaFin);
        Task<List<FormularioEncuestaPreguntaDTO>> BuscarReporte( int idFormulario);
        Task<List<ClienteDTO>> ObtenerClientes(int idSede, int idFormulario, DateTime fechaInicio, DateTime fechaFin);

        Task<List<FormularioEncuestaRespuestaDTO>> ObtenerListadoByClienteFormulario(int idCliente, int idFormulario);
    }
}
