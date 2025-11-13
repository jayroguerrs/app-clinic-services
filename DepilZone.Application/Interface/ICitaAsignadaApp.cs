using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Interface
{
    public interface ICitaAsignadaApp
    {
        Task<int> Insertar(CitaAsignadaListaDTO model);
        Task<IEnumerable<CitaAsignadaGrillaDTO>> ObtenerCitasAsignacion(DateTime fecha, bool sinAsignar, int idSede, int tipoCliente);
        Task<List<CitaAsignadaGrillaDTO>> ObtenerCitasAbandonadasAsignacion(DateTime fecha, bool sinAsignar);
        Task<List<CitaAsignadaGrillaDTO>> ObtenerCitasAbandonadasAsignacionEnEspera(DateTime fecha);
        Task<IEnumerable<CitaAsignadaGrillaDTO>> ObtenerCitasAsignada(DateTime fecha, int idUsuarioReasignacion);
        Task<IEnumerable<CitaAsignadaGrillaDTO>> ObtenerByIdUsuario(int tipoAsignacion, DateTime fechaConfirmacion, int idUsuarioReasignacion);
        Task<IEnumerable<CitaAsignadaGrillaDTO>> ObtenerListado(DateTime fechaConfirmar, bool sinAsignar, int asignadoA, int tipoSiguiente, int asignadoPor, int idSede, int idUsuario, int tipoCliente);
        Task<IEnumerable<CitaAsignadaGrillaDTO>> ObtenerReporte(DateTime fechaDesde, DateTime fechaHasta, bool sinAsignar, int asignadoA, int tipoSiguiente, int asignadoPor, int idSede, int idUsuario);

        Task<List<CitaAsignadaGrillaDTO>> ObtenerListadoAbandonados(DateTime fechaConfirmar, bool sinAsignar, int asignadoA, int asignadoPor, int idUsuario);
        Task<List<CitaAsignadaGrillaDTO>> ObtenerAbandonadasByIdUsuario(int tipoAsignacion, DateTime fechaConfirmacion, int idUsuarioReasignacion);
        Task<int> GuardarAbandonados(CitaAsignadaListaDTO model);
        Task<int> AsignarAbandonadosEnEspera(CitaAsignadaListaDTO model);
        Task<int> MarcarVisto(List<CitaAsignadaEnt> citaAsignada);
        Task<bool> CambiarFecha(CitaAsignadaGrillaDTO model);
        Task<List<CitaAsignadaGrillaDTO>> ObtenerCitasPasadasAsignacion(int idSede, DateTime fechaInicial, DateTime fechaFinal, bool sinAsignar, int idEstado, int idTipoCliente, int idMotivo);
    }

}
