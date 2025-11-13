using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Data.Interface
{
    public interface ICitaDom
	{
		Task<Respuesta<CitaEnt>> Insertar(CitaEnt model);
		Task<Respuesta<CitaEnt>> Modificar(CitaEnt model);
		Task<int> EstadoAtendido(CitaEnt model);


        Task<Respuesta<CitaDTO>> ActualizarCondicionNoAsistio(CitaDTO model);
        Task<Respuesta<CitaDTO>> ActualizarCondicionPendiente(CitaDTO model);
		Task<Respuesta<CitaDTO>> ActualizarCondicionAnular(CitaDTO model);
		Task<Respuesta<CitaDTO>> ActualizarCondicionCancelar(CitaDTO model);
		Task<Respuesta<CitaDTO>> ActualizarCondicionNollamar(CitaDTO model);
        Task<Respuesta<CitaDTO>> ActualizarCondicionConfirmar(CitaDTO model);
		Task<Respuesta<CitaDTO>> ActualizarCondicionConfirmarAsistencia(CitaDTO model);



        Task<IEnumerable<CitaDTO>> Obtener(DateTime fecha, string horaInicio, string horaTermino, int idSede, int idEstado, string pacienteCelular, int tipoCita, int idServicio, int idZonaContiene, int nacio);
		Task<List<CitaExportarDTO>> ObtenerExportar(DateTime fecha, string horaInicio, string horaTermino, int idSede, int idEstado, string pacienteCelular, int tipoCita);
		Task<CitaDatosPreliminaresDTO> ObtenerDatosPreliminares();
		Task<DashBoardDTO> ObtenerDashBoard(string fecha, int idSede, int idPerfil);
		Task<IEnumerable<CitaDTO>>	Obtenercitaid(int idCita);
		Task<IEnumerable<CitaDTO>> ObtenerParaPerfil(int idCliente);
		Task<IEnumerable<CitaDTO>> ObtenerParaPerfilPorServicio(int idCliente, int idServicio);
		Task<CitaDTO> ObtenerById(int idCita, bool esReprogramacion);
		Task<IEnumerable<CitaDetalleZonaDTO>> ObtenerDetalleCitaPrecio(int idCita);
		Task<Respuesta<CitaEnt>> InsertarReservacion(CitaEnt model);
		Task<bool> EliminarReservacion(int idUsuario);
		Task<IEnumerable<CitaComisionResumenDTO>> ObtenerComisionesResumen(DateTime fechaInicio, DateTime fechaTermino, int idUsuarioOperador);
		Task<IEnumerable<CitaComisionDetalleDTO>> ObtenerComisionesDetalle(DateTime fechaInicio, DateTime fechaTermino, int idUsuarioOperador);
		Task<IEnumerable<CitaMensajeNotaDTO>> ObtenerNotasEnCitaNueva(int idCliente);

		Task<List<CitaTotalDTO>> ObtenerAgendadas(DateTime fechaInicio, DateTime fechaFin, int idSede, int idGenero);
		Task<List<CitaTotalDTO>> ObtenerAtendidas(DateTime fechaInicio, DateTime fechaFin, int idSede, int idGenero);
		Task<List<CitaTotalDTO>> ObtenerAgendadasCortesia(DateTime fechaInicio, DateTime fechaFin, int idSede, int idGenero);
		Task<List<CitaPromocionDTO>> ObtenerPorPromocion(DateTime fechaInicio, DateTime fechaFin, int idSede);
		Task<List<CitaReporteDTO>> ObtenerReporte(DateTime fechaInicio, DateTime fechaFin, int idSede, int idEstado, int idServicio, int idTipoCita, int idZona, int? nuevoCliente);
		Task<List<CitaReporteDetalladoDTO>> ObtenerReporteDetallado(DateTime fechaInicio, DateTime fechaFin, int idSede, int idEstado, int idServicio, int idTipoCita, int idZona);

        Task<bool> EnvioMasivoHistoria(CitaHistoriaMasivaDTO model);

        Task<int> AgendarSiguienteCita(SiguienteCitaDTO model);
        Task<int> AgendarSiguienteCitaManual(SiguienteCitaDTO model);

        Task<CitaTacoDTO> ObtenerTaco(int IdCita, int IdUsuario);

        Task<bool> MarcarAtendido(int IdCita, int IdUsuario);
        Task<List<int>> ObtenerCitaAtendidasHoy();
        Task<bool> SiguienteCitaAtendidasHoy(int IdCita);
        Task<bool> AgregarDetalle(int idCita, CitaNuevoDetalle model);

		Task<List<CitaSinSiguienteCitaDTO>> ObtenerCitasAtendidasSinSiguienteCita(DateTime fechaDesde, DateTime fechaHasta, int idServicio, int idUsuario);

		Task<List<CitaReporteAgendadoOperador>> ObtenerReporteAgendado(DateTime fechaInicio, DateTime fechaFin, int idSede, int idServicio, int idTipoCliente, int idEstado, int idUsuarioAgendo);


        Task<CitaDatosDTO> ObtenerDatos(int idCita, int idUsuario);

        Task<bool> ModificarMaquina(int IdCita, CitaModificaMaquinaDTO model);

		Task<List<CitaReporteInfoClienteDTO>> ObtenerReporteInfoCliente(DateTime fecha, string horaInicio, string horaTermino, int idSede, int idEstado, string pacienteCelular, int tipoCita, int idServicio, int idZonaContiene, int nacio);

		Task<List<CitaClienteDTO>> ObtenerCitasCliente(int idClienteAsignado);
		Task<GeneralResponse<bool>> ActualizarTratamientoRealizado(int estado, int idCitaDetalle);

		Task<List<HistorialParametroDTO>> ObtenerHistorialParametros(int idCliente, int idServicio, int idZona);
		Task<GeneralResponse<ParametroUpdateDTO>> ActualizarParametro(ParametroUpdateDTO model);
    }
}
