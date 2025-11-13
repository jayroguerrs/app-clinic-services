using DepilZone.Data.Interface;
using DepilZone.Domain.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace DepilZone.Domain.Implement
{
    public class CitaAsignadaDom : ICitaAsignadaDom
    {
        private readonly ICitaAsignadaDat _ICitaAsignadaDat;
        public CitaAsignadaDom(ICitaAsignadaDat ICitaAsignadaDat)
        {
            this._ICitaAsignadaDat = ICitaAsignadaDat;
        }

        public async Task<int> Insertar(CitaAsignadaListaDTO model)
        {
            return await _ICitaAsignadaDat.Insertar(model);
        }

        public async Task<IEnumerable<CitaAsignadaGrillaDTO>> ObtenerCitasAsignacion(DateTime fecha, bool sinAsignar, int idSede, int tipoCliente)
        {
            return await _ICitaAsignadaDat.ObtenerCitasAsignacion(fecha, sinAsignar, idSede, tipoCliente);
        }

        public async Task<List<CitaAsignadaGrillaDTO>> ObtenerCitasAbandonadasAsignacion(DateTime fecha, bool sinAsignar)
        {
            return await _ICitaAsignadaDat.ObtenerCitasAbandonadasAsignacion(fecha, sinAsignar);
        }
        public async Task<List<CitaAsignadaGrillaDTO>> ObtenerCitasAbandonadasAsignacionEnEspera(DateTime fecha)
        {
            return await _ICitaAsignadaDat.ObtenerCitasAbandonadasAsignacionEnEspera(fecha);
        }
        public async Task<IEnumerable<CitaAsignadaGrillaDTO>> ObtenerCitasAsignada(DateTime fecha, int idUsuarioReasignacion)
        {
            return await _ICitaAsignadaDat.ObtenerCitasAsignada(fecha, idUsuarioReasignacion);
        }
        public async Task<IEnumerable<CitaAsignadaGrillaDTO>> ObtenerByIdUsuario(int tipoAsignacion, DateTime fechaConfirmacion, int idUsuarioReasignacion)
        {
            return await _ICitaAsignadaDat.ObtenerByIdUsuario(tipoAsignacion, fechaConfirmacion, idUsuarioReasignacion);
        }
        public async Task<IEnumerable<CitaAsignadaGrillaDTO>> ObtenerListado(DateTime fechaConfirmar, bool sinAsignar, int asignadoA, int tipoSiguiente, int asignadoPor, int idSede, int idUsuario, int tipoCliente)
        {
            return await _ICitaAsignadaDat.ObtenerListado(fechaConfirmar, sinAsignar, asignadoA, tipoSiguiente, asignadoPor, idSede, idUsuario, tipoCliente);
        }

        public async Task<IEnumerable<CitaAsignadaGrillaDTO>> ObtenerReporte(DateTime fechaDesde, DateTime fechaHasta, bool sinAsignar, int asignadoA, int tipoSiguiente, int asignadoPor, int idSede, int idUsuario)
        {
            return await _ICitaAsignadaDat.ObtenerReporte(fechaDesde, fechaHasta, sinAsignar, asignadoA, tipoSiguiente, asignadoPor, idSede, idUsuario);
        }

        public async Task<List<CitaAsignadaGrillaDTO>> ObtenerListadoAbandonados(DateTime fechaConfirmar, bool sinAsignar, int asignadoA, int asignadoPor, int idUsuario)
        {
            return await _ICitaAsignadaDat.ObtenerListadoAbandonados(fechaConfirmar, sinAsignar, asignadoA, asignadoPor, idUsuario);
        }

        public async Task<List<CitaAsignadaGrillaDTO>> ObtenerAbandonadasByIdUsuario(int tipoAsignacion, DateTime fechaConfirmacion, int idUsuarioReasignacion)
        {
            return await _ICitaAsignadaDat.ObtenerAbandonadasByIdUsuario(tipoAsignacion, fechaConfirmacion, idUsuarioReasignacion);
        }
        public async Task<int> GuardarAbandonados(CitaAsignadaListaDTO model)
        {
            return await _ICitaAsignadaDat.GuardarAbandonados(model);
        }
        public async Task<int> AsignarAbandonadosEnEspera(CitaAsignadaListaDTO model)
        {
            return await _ICitaAsignadaDat.AsignarAbandonadosEnEspera(model);
        }
        public async Task<int> MarcarVisto(List<CitaAsignadaEnt> citaAsignada)
        {
            return await _ICitaAsignadaDat.MarcarVisto(citaAsignada);
        }


        public async Task<bool> CambiarFecha(CitaAsignadaGrillaDTO model)
        {
            return await _ICitaAsignadaDat.CambiarFecha(model);
        }


        public async Task<List<CitaAsignadaGrillaDTO>> ObtenerCitasPasadasAsignacion(int idSede, DateTime fechaInicial, DateTime fechaFinal, bool sinAsignar, int idEstado, int idTipoCliente, int idMotivo)
        {
            return await _ICitaAsignadaDat.ObtenerCitasPasadasAsignacion(idSede, fechaInicial, fechaFinal, sinAsignar, idEstado, idTipoCliente, idMotivo);
        }

    }
}
