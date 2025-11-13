using System;
using System.Collections.Generic;
using System.Text;

namespace DepilZone.Entidad
{
    public class CitaEstadoMotivoEnt
    {
		public int Id { get; set; }
		public int IdCita { get; set; }
		public int IdMotivo { get; set; }
		public DateTime? FechaRegistro { get; set; }
		#nullable enable
		public string? UsuarioRegistro { get; set; }
		#nullable enable
		public DateTime? FechaModifico { get; set; }
		#nullable enable
		public string? UsuarioModifico { get; set; }
	}

	public class CitaEstadoMotivoRespuestaEnt
    {
		public int IdCita { get; set; }
        public int IdCliente { get; set; }
        public int IdSede { get; set; }
		public string Cliente { get; set; }
		public string Genero { get; set; }
		public string Estado { get; set; }
		public int IdEstado { get; set; }
		public string? EstadoColor { get; set; }
		public string Motivo { get; set; }
		public DateTime FechaRegistro { get; set; }
		public string UsuarioRegistro { get; set; }
    }
}
