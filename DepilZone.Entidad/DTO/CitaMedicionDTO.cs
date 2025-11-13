using System;

namespace DepilZone.Entidad.DTO
{
    public class CitaMedicionDTO
    {
        public int Id { get; set; }
        public int IdCita { get; set; }
        public int? SiguienteCita { get; set; }
        public int IdTipoMedicion { get; set; }
        public int IdAlternativaMedicion { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string UsuarioRegistro { get; set; }
        public string? UsuarioAtendio { get; set; }

        public DateTime? FechaModifico { get; set; }
        public string? UsuarioModifico { get; set; }


        public int IdUsuarioRegistro { get; set; }
        public int? IdUsuarioModifico { get; set; }

        public string Cliente { get; set; }
        public int IdCliente { get; set; }
        public int IdSede { get; set; }
        public int IdEstado { get; set; }
        public string EstadoColor { get; set; }
        public string Genero { get; set; }
        public string Estado { get; set; }
        public string TipoMedicion { get; set; }
        public string Alternativa { get; set; }

        public int IdServicio { get; set; }
        public string? Servicio { get; set; }
        public string? ServicioColor { get; set; }
    }


    public class CitaMedicion_ParametrosDTO
    {
        public int? IdSede { get; set; }
        public DateTime? Fdesde { get; set; }
        public DateTime? Fhasta { get; set; }
        public int? IdTipoMedicion { get; set; }
        public int? IdServicio { get; set; }
    }

    public class CitasEncuestadasDTO
    {
        public int TotalCitas { get; set; }
        public int TotalCitasPagadas { get; set; }
        public int TotalSatisfaccion { get; set; }
        public int TotalEfectividad { get; set; }
    }
}
