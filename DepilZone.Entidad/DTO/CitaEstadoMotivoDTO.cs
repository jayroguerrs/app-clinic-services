using System;
using System.Collections.Generic;
using System.Text;

namespace DepilZone.Entidad.DTO
{
	public class CitaEstadoMotivoDTO
	{
		public int Id { get; set; }
		public int IdCita { get; set; }
		public int IdMotivo { get; set; }
		public DateTime? FechaRegistro { get; set; }
		public string? UsuarioRegistro { get; set; }
		public DateTime? FechaModifico { get; set; }
		public string? UsuarioModifico { get; set; }
	}

	public class CitaEstado_ParametrosDTO
    {
		public int? IdSede { get; set; }
		public DateTime? Fdesde { get; set; }
		public DateTime? Fhasta { get; set; }
		public int? IdCitaEstado { get; set; }
    }



}
