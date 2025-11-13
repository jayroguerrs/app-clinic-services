using System;
using System.Collections.Generic;
using System.Text;

namespace DepilZone.Entidad.DTO
{
    public class CitaDTO
    {
        public int? IdCronograma { get; set; }
        public int IdCita { get; set; }
        public bool NuevoCliente { get; set; }
        public string Foto { get; set; }
        public int IdTipoCita { get; set; }
        public int IdCliente { get; set; }
        public int IdTipoCliente { get; set; }
        public int IdUsuario { get; set; }
        public int IdMaquina { get; set; }
        public int IdSede { get; set; }
        public int IdEstado { get; set; }
        public int? IdUsuarioAtendidoPor { get; set; }
        public string UsuarioAtendidoPor { get; set; }
        public string Sede { get; set; }
        public int? IdGenero { get; set; }
        public bool Fiesta { get; set; }
        public IList<CitaDetalleZonaDTO> ZonasCorporales { get; set; }
        public IList<CitaMensajeAvisoDTO> CitaMensajeAvisos { get; set; }
        public IList<CitaMensajeNotaDTO> CitaMensajeNotas { get; set; }
        public IList<CitaMensajeDetalleDTO> CitaMensajeDetalles { get; set; }

        public DateTime FechaCita { get; set; }
        public string HoraInicio { get; set; }
        public string HoraTermino { get; set; }
        public int Duracion { get; set; }

        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Paciente {
            get { return Nombres + " " + Apellidos; }
        }
        public string SeudonimoPaciente { get; set; }
        public string NumeroCita
        {
            get { return "CI-" + IdCita.ToString("000000"); }
        }
        public string CodigoPaciente
        {
            get { return "PA-" + IdCliente.ToString("000000"); }
        }
        public string HoraCita { get; set; }
        public string NumeroDocumentoIdentidad { get; set; }
        public string NumeroHistoria { get; set; }
        public string NumerosCelulares { get; set; }
        public string TipoCita { get; set; }
        /// <summary>
        /// Usado para mostrar en el listado de citas de forma vertical al lado derecho
        /// </summary>
        public string TipoCitaCorto {
            get
            {

                return (TipoCita == null) ? "" : (TipoCita.Length > 9 ? TipoCita.Substring(0, 9) : TipoCita);
            }
        }
        public string ColorTipoCita { get; set; }
        public string ColorTextoTipoCita { get; set; }
        public int NumeroSesion { get; set; }
        public IList<string> Zonas { get; set; }
        public IList<ZonasContatenadasDTO> ZonaContatenadaCitaDetalle { get; set; }
        public IList<CitaMensajeAvisoEnt> CitaAvisos { get; set; }
        public IList<CitaMensajeDetalleEnt> CitaDetalles { get; set; }
        public decimal Total { get; set; }
        public decimal? PagoFinal { get; set; }
        

        public string Estado { get; set; }
        public string ColorEstado { get; set; }
        public bool Pagado { get; set; }
        public bool EsNotificado { get; set; }
        public string TextoPagado {
            get
            {
                return Pagado ? "PAGADO" : "NO PAGADO";
            }
        }
        public string ColorPagado { get; set; }
        public string TipoCliente { get; set; }
        public string ColorTipoCliente { get; set; }
        public string ColorTextoTipoCliente { get; set; }

        public DateTime FechaRegistra { get; set; }
        public string UsuarioRegistra { get; set; }
        public string Usuario { get; set; }
        public int? IdEstadoPendiente { get; set; }
        public string Resumen { get; set; }
        public CitaMaquinaDTO Maquina { get; set; }

        //// Encuesta
        public int Efectividad { get; set; }
        public int Satisfaccion { get; set; }

        // Medio contacto
        public int? IdMedioContacto { get; set; }
        public string? OtroMedioContacto { get; set; }



        public int IdDescuento { get; set; }
        public string? DescuentoAplicaA { get; set; }
        public string? CuponDescuento { get; set; }

        public DateTime FechaEncuesta { get; set; }

        public int? IdFichaAdmision { get; set; }

        public int? IdCitaAsignacion { get; set; }
        public int? IdUsuarioAsignado { get; set; }
        public DateTime? FechaConfirmacion { get; set; }

        public int? IdServicio { get; set; }
        public string? Servicio { get; set; }
        public string? ServicioColor { get; set; }

        public string? Genero { get; set; }

        public int IdPreferente { get; set; }
        public int NumeroBox { get; set; }
        public int? IdMaquinaMarca { get; set; }
        public float? PrecioDePagoFinal { get; set; }
        public int? TipoDePago { get; set; }
    }

    public class ZonasContatenadasDTO
    {
        public int IdCita { get; set; }
        public double TotalCita { get; set; }
        public string ZonaContatenada { get; set; }
    }

    public class CitaMaquinaDTO {
        public int Id { get; set; }
        public string Descripcion { get; set; }
    }

    public class CitaTotalDTO
    {
        public int IdSede { get; set; }
        public string Sede { get; set; }
        public DateTime FechaCita { get; set; }
        public int NumCitas { get; set; }
    }

    public class CitaExportarDTO
    {
        public int IdCita { get; set; }
        public string Sede { get; set; }
        public string Cliente { get; set; }
        public string FechaCita { get; set; }
        public string Zonas { get; set; }
        public string Promociones { get; set; }
        public string HoraInicio { get; set; }
        public string Estado { get; set; }
        public string Pagado { get; set; }
        public decimal Total { get; set; }
    }


    public class CitaPromocionDTO
    {
        public int IdCita { get; set; }
        public int IdSede { get; set; }
        public string Sede { get; set; }
        public int NumeroCita { get; set; }
        public string Cliente { get; set; }
        public DateTime FechaCita { get; set; }
        public string HoraCita { get; set; }
        public string Zona { get; set; }
        public int IdZona { get; set; }
        public int Sesion { get; set; }
        public int IdPromocion { get; set; }
        public string Promocion { get; set; }
        public DateTime PromoFechaIni { get; set; }
        public DateTime PromoFechaFin { get; set; }
        public decimal PrecioZona { get; set; }
        public decimal TotalCita { get; set; }
        public string Estado { get; set; }
    }

    public class CitaReporteDetalladoDTO
    {
        public int IdCita { get; set; }
        public int IdCliente { get; set; }
        public DateTime Fecha { get; set; }
        public int IdEstado { get; set; }
        public string Estado { get; set; }
        public string EstadoColor { get; set; }
        public int IdTipoCita { get; set; }
        public string TipoCita { get; set; }
        public string Cliente { get; set; }
        public string Telefono { get; set; }
        public string TipoCliente { get; set; }
        public string DocumentoIdentidad { get; set; }
        public int IdServicio { get; set; }
        public string Servicio { get; set; }
        public string ServicioColor { get; set; }
        public int IdSede { get; set; }
        public string Sede { get; set; }
        public string Zona { get; set; }
        public int Sesion { get; set; }
        public decimal Precio { get; set; }
        public string Promocion { get; set; }
        public string Origen { get; set; }
        public string AgendadoPor { get; set; }
        public string UsuarioRegistro { get; set; }
        public string Genero { get; set; }
        public string Alias { get; set; }
        public decimal Total { get; set; }
    }


    public class CitaReporteDTO
    {
        public DateTime FechaRegistro { get; set; }
        public int IdCita { get; set; }
        public int IdCliente { get; set; }
        public DateTime Fecha { get; set; }
        public int IdEstado { get; set; }
        public string Estado { get; set; }
        public string EstadoColor { get; set; }
        public int IdTipoCita { get; set; }
        public string TipoCita { get; set; }
        public string Cliente { get; set; }
        public string Distrito { get; set; }
        public string Telefono { get; set; }
        public string TipoCliente { get; set; }
        public string DocumentoIdentidad { get; set; }
        public int IdServicio { get; set; }
        public string Servicio { get; set; }
        public string ServicioColor { get; set; }
        public int IdSede { get; set; }
        public string Sede { get; set; }
        public string Zonas { get; set; }
        public string Genero { get; set; }
        public string Alias { get; set; }
        public decimal Total { get; set; }

        public string? AtendidoPor { get; set; }
        public string? UtmTerm { get; set; }
        public string? UtmSource { get; set; }
        public string? UtmCampaign { get; set; }
        public string? UtmCont { get; set; }
        public string? MedioContacto { get; set; }
        public string? UtmMedium { get; set; }
        public string? Motivo { get; set; }
        public string? UsuarioSeguimiento { get; set; }
    }


    public class CitaHistoriaMasivaDTO
    {
        public List<CitaHistoriaDTO> Registros {get;set;}
        public int NumeroRegistros { get; set; }
        public string NombreArchivo { get; set; }
        public int IdUsuarioRegistro { get; set; }
    }

    public class CitaHistoriaDTO
    {
        public int IdCita { get; set; }
        public string? HistoriaNota { get; set; }
        public string? HistoriaAviso { get; set; }
        public string? HistoriaDetalle { get; set; }
    }


    public class SiguienteCitaDTO
    {
        public int IdTipo { get; set; }
        public DateTime? Fecha { get; set; }
        public int IdCita { get; set; }
        public float NumeroMeses { get; set; }
        public int IdUsuarioRegistro { get; set; }
    }



    public class CitaTacoDTO { 
        public int IdCita { get; set; }
        public DateTime FechaHora { get; set; }
        public int IdCliente { get; set; }
        public string? TipoCita { get; set; }
        public string Cliente { get; set; }
        public string? ClienteDocumento { get; set; }
        public string? Especialista { get; set; }
        public string? Usuario { get; set; }

        public List<CitaTacoDetalleDTO> Detalle { get; set; }
        public List<CitaTacoNotasDTO> Notas { get; set; }
        public bool NuevoCliente { get; set; }
        public string? Telefonos { get; set; }
    }

    public class CitaTacoDetalleDTO { 
        public int Sesion { get; set; }
        public bool PagoWeb { get; set; }
        public decimal Precio { get; set; }
        public string Zona { get; set; }
    }

    public class CitaTacoNotasDTO { 
        public int Id { get; set; }
        public string Texto { get; set; }
    }

    public  class CitaSinSiguienteCitaDTO
    {
        public int IdCita { get; set; }
        public int IdCliente { get; set; }
        public string Cliente { get; set; }
        public string? TelefonoCliente { get; set; }
        public string Sede { get; set; }
        public string Servicio { get; set; }
        public string ColorServicio { get; set; }
        public DateTime FechaCita { get; set; }
        public string EstadoCita { get; set; }
        public string ColorEstadoCita { get; set; }
        public bool Pagado { get; set; }
    }


    public class CitaReporteAgendadoOperador { 
        public int IdCita { get; set; }
        public int IdCliente { get; set; }
        public string NombreCliente { get; set; }
        public string ApellidoCliente { get; set; }
        public string DocumentoCliente { get; set; }
        public string TelefonoCliente { get; set; }
        public string Zona { get; set; }
        public int Sesion { get; set; }
        public string Promocion { get; set; }
        public decimal Precio { get; set; }
        public int IdEstado { get; set; }
        public string Estado { get; set; }
        public string EstadoColor { get; set; }
        public int IdTipoCliente { get; set; }
        public string TipoCliente { get; set; }
        public int IdSede { get; set; }
        public string Sede { get; set; }
        public DateTime FechaCita { get; set; }
        public int IdServicio { get; set; }
        public string Servicio { get; set; }
        public string ServicioColor { get; set; }
        public int IdUsuarioAgendo { get; set; }
        public string UsuarioAgendo { get; set; }
        public int IdUsuarioRegistro { get; set; }
        public string UsuarioRegistro { get; set; }
        public DateTime FechaRegistro { get; set; }


    }


    public class CitaDatosDTO { 
    
        public int IdCita { get; set; }
        public DateTime FechaCita { get; set; }
        public int IdSede { get; set; }
        public string Sede { get; set; }
        public int IdServicio { get; set; }
        public string Servicio { get; set; }
        public string ServicioColor { get; set; }
        public int Duracion { get; set; }
        public string HoraInicio { get; set; }
        public string HoraTermino { get; set; }
        public int MinutoInicio { get; set; }
        public int MinutoTermino { get; set; }
        public int IdEstado { get; set; }
        public string Estado { get; set; }
        public string EstadoColor { get; set; }

    }



    public class CitaModificaMaquinaDTO
    {

        public int IdCita { get; set; }
        public int IdMaquina { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraTermino { get; set; }
        public int IdUsuarioRegistro { get; set; }


    }


    public class CitaReporteInfoClienteDTO
    {
        public int IdCita { get; set; }
        public string NumeroDocumento { get; set; }
        public string Cliente { get; set; }
        public string Telefono { get; set; }
        public string TipoCliente { get; set; }
        public string? FechaUltimaCita { get; set; }
        public string ZonasAtendidas { get; set; }
        public string PromocionesAdquiridas { get; set; }
        public string? UltimaCitaZonas { get; set; }
        public string Sede { get; set; }
        public string FechaCita { get; set; }
        public string ZonasCitaActual { get; set; }
        public string PromocionesActual { get; set; }
        public string HoraInicio { get; set; }
        public string Estado { get; set; }
        public string Pagado { get; set; }
        public decimal Total { get; set; }
    }

    public class CitaClienteDTO
    {
        public int Id { get; set; }
        public int? IdCronograma { get; set; }
        public string Cliente { get; set; }
        public int IdCliente { get; set; }
        public DateTime Fecha { get; set; }
        public string Telefono { get; set; }
        public string Servicio { get; set; }
        public string ServicioColor { get; set; }
        public int IdServicio { get; set; }
        public string Sede { get; set; }
        public int IdSede { get; set; }
        public string Estado { get; set; }
        public string EstadoColor { get; set; }
        public int IdEstado { get; set; }
    }

}
