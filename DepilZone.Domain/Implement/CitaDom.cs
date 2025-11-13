using DepilZone.Data.Implement;
using DepilZone.Data.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace DepilZone.Domain.Implement
{
	public class CitaDom : ICitaDom
	{
		private readonly ICitaDat _ICitaDat;
		public CitaDom(ICitaDat ICitaDat)
		{
			this._ICitaDat = ICitaDat;
		}
		public async Task<Respuesta<CitaEnt>> Insertar(CitaEnt model)
		{
			return await _ICitaDat.Insertar(model);
		}
		public async Task<Respuesta<CitaEnt>> Modificar(CitaEnt model)
		{
			return await _ICitaDat.Modificar(model);
		}
		
		
		
		
		public async Task<Respuesta<CitaDTO>> ActualizarCondicionAnular(CitaDTO model)
		{
			return await _ICitaDat.ActualizarCondicionAnular(model);
		}
		public async Task<Respuesta<CitaDTO>> ActualizarCondicionCancelar(CitaDTO model)
		{
			return await _ICitaDat.ActualizarCondicionCancelar(model);
		}

        public async Task<Respuesta<CitaDTO>> ActualizarCondicionNollamar(CitaDTO model)
        {
            return await _ICitaDat.ActualizarCondicionNollamar(model);
        }
        public async Task<Respuesta<CitaDTO>> ActualizarCondicionConfirmar(CitaDTO model)
		{
			return await _ICitaDat.ActualizarCondicionConfirmar(model);
		}
        public async Task<Respuesta<CitaDTO>> ActualizarCondicionConfirmarAsistencia(CitaDTO model)
        {
            return await _ICitaDat.ActualizarCondicionConfirmarAsistencia(model);
        }
        public async Task<Respuesta<CitaDTO>> ActualizarCondicionNoAsistio(CitaDTO model)
        {
            return await _ICitaDat.ActualizarCondicionNoAsistio(model);
        }
        public async Task<Respuesta<CitaDTO>> ActualizarCondicionPendiente(CitaDTO model)
		{
			return await _ICitaDat.ActualizarCondicionPendiente(model);
		}


		public async Task<Respuesta<CitaEnt>> InsertarReservacion(CitaEnt model)
		{
			return await _ICitaDat.InsertarReservacion(model);
		}
		public async Task<bool> EliminarReservacion(int idUsuario)
		{
			return await _ICitaDat.EliminarReservacion(idUsuario);
		}
		public async Task<IEnumerable<CitaDTO>> Obtener(DateTime fecha, string horaInicio, string horaTermino, int idSede, int idEstado, string pacienteCelular, int tipoCita, int idServicio, int idZonaContiene, int nacio)
		{
			return await _ICitaDat.Obtener(fecha, horaInicio, horaTermino, idSede, idEstado, pacienteCelular, tipoCita, idServicio, idZonaContiene, nacio);
		}
		public async Task<List<CitaExportarDTO>> ObtenerExportar(DateTime fecha, string horaInicio, string horaTermino, int idSede, int idEstado, string pacienteCelular, int tipoCita)
		{
			return await _ICitaDat.ObtenerExportar(fecha, horaInicio, horaTermino, idSede, idEstado, pacienteCelular, tipoCita);
		}
		public async Task<CitaDatosPreliminaresDTO> ObtenerDatosPreliminares()
		{
			return await _ICitaDat.ObtenerDatosPreliminares();
		}
		public async Task<DashBoardDTO> ObtenerDashBoard(string fecha, int idSede, int idPerfil)
		{
			return await _ICitaDat.ObtenerDashBoard(fecha, idSede, idPerfil);
		}
		public async Task<IEnumerable<CitaDTO>> Obtenercitaid(int idCita)
		{
			return await _ICitaDat.Obtenercitaid(idCita);
		}

		public async Task<IEnumerable<CitaDTO>> ObtenerParaPerfil(int idCliente)
		{
			return await _ICitaDat.ObtenerParaPerfil(idCliente);
		}
		public async Task<IEnumerable<CitaDTO>> ObtenerParaPerfilPorServicio(int idCliente, int idServicio)
		{
			return await _ICitaDat.ObtenerParaPerfilPorServicio(idCliente, idServicio);
		}

		public async Task<CitaDTO> ObtenerById(int idCita, bool esReprogramacion)
		{
			return await _ICitaDat.ObtenerById(idCita, esReprogramacion);
		}
		public async Task<IEnumerable<CitaDetalleZonaDTO>> ObtenerDetalleCitaPrecio(int idCita)
		{
			return await _ICitaDat.ObtenerDetalleCitaPrecio(idCita);
		}

        public async Task<IEnumerable<CitaComisionResumenDTO>> ObtenerComisionesResumen(DateTime fechaInicio, DateTime fechaTermino, int idUsuarioOperador)
        {
			return await _ICitaDat.ObtenerComisionesResumen(fechaInicio, fechaTermino, idUsuarioOperador);
        }
		public async Task<IEnumerable<CitaComisionDetalleDTO>> ObtenerComisionesDetalle(DateTime fechaInicio, DateTime fechaTermino, int idUsuarioOperador)
		{
			return await _ICitaDat.ObtenerComisionesDetalle(fechaInicio, fechaTermino, idUsuarioOperador);
		}

        public async Task<int> EstadoAtendido(CitaEnt model)
        {
			return await _ICitaDat.EstadoAtendido(model);
        }
		
		public async Task<IEnumerable<CitaMensajeNotaDTO>> ObtenerNotasEnCitaNueva(int idCliente)
		{
			return await _ICitaDat.ObtenerNotasEnCitaNueva(idCliente);
		}

		public async Task<List<CitaTotalDTO>> ObtenerAgendadas(DateTime fechaInicio, DateTime fechaFin, int idSede, int idGenero)
		{
			return await _ICitaDat.ObtenerAgendadas(fechaInicio, fechaFin, idSede, idGenero);
		}
		public async Task<List<CitaTotalDTO>> ObtenerAtendidas(DateTime fechaInicio, DateTime fechaFin, int idSede, int idGenero)
		{
			return await _ICitaDat.ObtenerAtendidas(fechaInicio, fechaFin, idSede, idGenero);
		}
		public async Task<List<CitaTotalDTO>> ObtenerAgendadasCortesia(DateTime fechaInicio, DateTime fechaFin, int idSede, int idGenero)
		{
			return await _ICitaDat.ObtenerAgendadasCortesia(fechaInicio, fechaFin, idSede, idGenero);
		}

		public async Task<List<CitaPromocionDTO>> ObtenerPorPromocion(DateTime fechaInicio, DateTime fechaFin, int idSede)
        {
			return await _ICitaDat.ObtenerPorPromocion(fechaInicio, fechaFin, idSede);
		}

		public async Task<List<CitaReporteDTO>> ObtenerReporte(DateTime fechaInicio, DateTime fechaFin, int idSede, int idEstado, int idServicio, int idTipoCita, int idZona, int? nuevoCliente)
        {
			return await _ICitaDat.ObtenerReporte(fechaInicio, fechaFin, idSede, idEstado, idServicio, idTipoCita, idZona, nuevoCliente);
		}
        public async Task<List<CitaReporteDetalladoDTO>> ObtenerReporteDetallado(DateTime fechaInicio, DateTime fechaFin, int idSede, int idEstado, int idServicio, int idTipoCita, int idZona)
        {
            return await _ICitaDat.ObtenerReporteDetallado(fechaInicio, fechaFin, idSede, idEstado, idServicio, idTipoCita, idZona);
        }

        public async Task<bool> EnvioMasivoHistoria(CitaHistoriaMasivaDTO model)
		{
            return await _ICitaDat.EnvioMasivoHistoria(model);
        }

        public async Task<int> AgendarSiguienteCita(SiguienteCitaDTO model)
        {
            return await _ICitaDat.AgendarSiguienteCita(model);
        }

        public async Task<int> AgendarSiguienteCitaManual(SiguienteCitaDTO model)
        {
            return await _ICitaDat.AgendarSiguienteCitaManual(model);
        }


        public async Task<CitaTacoDTO> ObtenerTaco(int IdCita, int IdUsuario)
		{
            return await _ICitaDat.ObtenerTaco(IdCita, IdUsuario);
        }


		public async Task<bool> MarcarAtendido(int IdCita, int IdUsuario)
		{
            return await _ICitaDat.MarcarAtendido(IdCita, IdUsuario);
        }



        public async Task<List<int>> ObtenerCitaAtendidasHoy()
		{
			return await _ICitaDat.ObtenerCitaAtendidasHoy();
		}

		public async Task<bool> SiguienteCitaAtendidasHoy(int IdCita)
		{
            return await _ICitaDat.SiguienteCitaAtendidasHoy(IdCita);
        }

        public async Task<bool> AgregarDetalle(int idCita, CitaNuevoDetalle model)
        {
            return await _ICitaDat.AgregarDetalle(idCita, model);
        }

        public async Task<List<CitaSinSiguienteCitaDTO>> ObtenerCitasAtendidasSinSiguienteCita(DateTime fechaDesde, DateTime fechaHasta, int idServicio, int idUsuario)
        {
            return await _ICitaDat.ObtenerCitasAtendidasSinSiguienteCita( fechaDesde,  fechaHasta,  idServicio,  idUsuario);
        }


        public async Task<List<CitaReporteAgendadoOperador>> ObtenerReporteAgendado(DateTime fechaInicio, DateTime fechaFin, int idSede, int idServicio, int idTipoCliente, int idEstado, int idUsuarioAgendo)
        {
            return await _ICitaDat.ObtenerReporteAgendado(fechaInicio, fechaFin, idSede, idServicio, idTipoCliente, idEstado, idUsuarioAgendo);
        }

		public async Task<CitaDatosDTO> ObtenerDatos(int idCita, int idUsuario)
		{
            return await _ICitaDat.ObtenerDatos(idCita, idUsuario);
        }

		public async Task<bool> ModificarMaquina(int IdCita, CitaModificaMaquinaDTO model)
		{
            return await _ICitaDat.ModificarMaquina(IdCita, model);
        }

        public async Task<List<CitaReporteInfoClienteDTO>> ObtenerReporteInfoCliente(DateTime fecha, string horaInicio, string horaTermino, int idSede, int idEstado, string pacienteCelular, int tipoCita, int idServicio, int idZonaContiene, int nacio)
        {
            return await _ICitaDat.ObtenerReporteInfoCliente(fecha, horaInicio, horaTermino, idSede, idEstado, pacienteCelular, tipoCita, idServicio, idZonaContiene, nacio);
        }

        public async Task<List<CitaClienteDTO>> ObtenerCitasCliente(int idClienteAsignado)
        {
            return await _ICitaDat.ObtenerCitasCliente(idClienteAsignado);
        }

        public async Task<GeneralResponse<bool>> ActualizarTratamientoRealizado(int estado, int idCitaDetalle)
		{
            return await _ICitaDat.ActualizarTratamientoRealizado(estado, idCitaDetalle);
        }
        public async Task<List<HistorialParametroDTO>> ObtenerHistorialParametros(int idCliente, int idServicio, int idZona)
		{
			return await _ICitaDat.ObtenerHistorialParametros(idCliente, idServicio, idZona);
		}
        public async Task<GeneralResponse<ParametroUpdateDTO>> ActualizarParametro(ParametroUpdateDTO model)
		{
            return await _ICitaDat.ActualizarParametro(model);
        }
    }
}

