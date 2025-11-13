using DepilZone.Application.Interface;
using DepilZone.Domain.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement
{
    public class CitaAsignadaApp : ICitaAsignadaApp
    {
        private readonly ICitaAsignadaDom _ICitaAsignadaDom;
        public CitaAsignadaApp(ICitaAsignadaDom ICitaAsignadaDom)
        {
            this._ICitaAsignadaDom = ICitaAsignadaDom;
        }

        public async Task<int> Insertar(CitaAsignadaListaDTO model)
        {
            return await _ICitaAsignadaDom.Insertar(model);
        }

        public async Task<IEnumerable<CitaAsignadaGrillaDTO>> ObtenerCitasAsignacion(DateTime fecha, bool sinAsignar, int idSede, int tipoCliente)
        {
            return await _ICitaAsignadaDom.ObtenerCitasAsignacion(fecha, sinAsignar, idSede, tipoCliente);
        }

        public async Task<List<CitaAsignadaGrillaDTO>> ObtenerCitasAbandonadasAsignacion(DateTime fecha, bool sinAsignar)
        {
            return await _ICitaAsignadaDom.ObtenerCitasAbandonadasAsignacion(fecha, sinAsignar);
        }
        public async Task<List<CitaAsignadaGrillaDTO>> ObtenerCitasAbandonadasAsignacionEnEspera(DateTime fecha)
        {
            return await _ICitaAsignadaDom.ObtenerCitasAbandonadasAsignacionEnEspera(fecha);
        }

        public async Task<IEnumerable<CitaAsignadaGrillaDTO>> ObtenerCitasAsignada(DateTime fecha, int idUsuarioReasignacion)
        {
            return await _ICitaAsignadaDom.ObtenerCitasAsignada(fecha, idUsuarioReasignacion);
        }

        public async Task<IEnumerable<CitaAsignadaGrillaDTO>> ObtenerByIdUsuario(int tipoAsignacion, DateTime fechaConfirmacion, int idUsuarioReasignacion)
        {
            return await _ICitaAsignadaDom.ObtenerByIdUsuario(tipoAsignacion, fechaConfirmacion, idUsuarioReasignacion);
        }

        public async Task<IEnumerable<CitaAsignadaGrillaDTO>> ObtenerListado(DateTime fechaConfirmar, bool sinAsignar, int asignadoA, int tipoSiguiente, int asignadoPor, int idSede, int idUsuario, int tipoCliente)
        {
            return await _ICitaAsignadaDom.ObtenerListado(fechaConfirmar, sinAsignar, asignadoA, tipoSiguiente, asignadoPor, idSede, idUsuario, tipoCliente);
        }

        public async Task<IEnumerable<CitaAsignadaGrillaDTO>> ObtenerReporte(DateTime fechaDesde, DateTime fechaHasta, bool sinAsignar, int asignadoA, int tipoSiguiente, int asignadoPor, int idSede, int idUsuario)
        {
            return await _ICitaAsignadaDom.ObtenerReporte(fechaDesde, fechaHasta, sinAsignar, asignadoA, tipoSiguiente, asignadoPor, idSede, idUsuario);
        }

        public async Task<List<CitaAsignadaGrillaDTO>> ObtenerListadoAbandonados(DateTime fechaConfirmar, bool sinAsignar, int asignadoA, int asignadoPor, int idUsuario)
        {
            return await _ICitaAsignadaDom.ObtenerListadoAbandonados(fechaConfirmar, sinAsignar, asignadoA, asignadoPor, idUsuario);
        }

        public async Task<List<CitaAsignadaGrillaDTO>> ObtenerAbandonadasByIdUsuario(int tipoAsignacion, DateTime fechaConfirmacion, int idUsuarioReasignacion)
        {
            return await _ICitaAsignadaDom.ObtenerAbandonadasByIdUsuario(tipoAsignacion, fechaConfirmacion, idUsuarioReasignacion);
        }

        public async Task<int> GuardarAbandonados(CitaAsignadaListaDTO model)
        {
            return await _ICitaAsignadaDom.GuardarAbandonados(model);
        }

        public async Task<int> AsignarAbandonadosEnEspera(CitaAsignadaListaDTO model)
        {
            return await _ICitaAsignadaDom.AsignarAbandonadosEnEspera(model);
        }

        public async Task<int> MarcarVisto(List<CitaAsignadaEnt> citaAsignada)
        {
            return await _ICitaAsignadaDom.MarcarVisto(citaAsignada);
        }

        public async Task<bool> CambiarFecha(CitaAsignadaGrillaDTO model)
        {
            return await _ICitaAsignadaDom.CambiarFecha(model);
        }

        public async Task<List<CitaAsignadaGrillaDTO>> ObtenerCitasPasadasAsignacion(int idSede, DateTime fechaInicial, DateTime fechaFinal, bool sinAsignar, int idEstado, int idTipoCliente, int idMotivo)
        {
            return await _ICitaAsignadaDom.ObtenerCitasPasadasAsignacion(idSede, fechaInicial, fechaFinal, sinAsignar, idEstado, idTipoCliente, idMotivo);
        }

    }
}
