using System;
using System.Collections.Generic;
using System.Text;

namespace DepilZone.Entidad.DTO
{
    public class CitaAsignadaGrillaDTO
    {
        public int Id { get; set; }
        public int IdCita { get; set; }
        public int IdCronograma { get; set; }
        public string IdCitaString
        {
            get
            {
                return IdCita.ToString("000000");
            }
        }
        public int IdCliente { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set;  }
        public string? Telefono { get; set; }
        public string Paciente
        {
            get
            {
                return Nombres + ' ' + Apellidos;
            }
        }
        public string Asignado { get; set; }
        public string AsignadoA { get; set; }
        public string FechaCitaString { get; set; }
        public DateTime FechaCita { get; set; }
        public DateTime? FechaConfirmacion { get; set; }
        public int Tipo { get; set; }
        public DateTime? FechaAsignacion { get; set; }
        public string AsignadoPor { get; set; }
        public int? IdUsuarioRegistra { get; set; }
        public int? IdEstadoAsignacion { get; set; }
        public string EstadoAsignacion { get; set; }
        public int? IdEstadoCita { get; set; }
        public string EstadoCita { get; set; }
        public string ColorEstadoCita { get; set; }
        public string HoraInicio { get; set; }
        public string? Motivo { get; set; }
        public string Sede { get; set; }

        public int IdServicio { get; set; }

        public string TipoCliente { get; set; }
        public string? Documento { get; set; }
        public string? NumeroDocumento { get; set; }

    }
}
