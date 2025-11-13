using System;

namespace DepilZone.Entidad.DTO
{
	public class ClienteCumpleaniosDTO
	{
		public int IdCliente { get; set; }
		public string Nombre { get; set; }
		public int Edad { get; set; }
		public DateTime? UltimaCita { get; set; }
		public int? IdUltimaCita { get; set; }
		public string? UltimaCitaColor { get; set; }
		public DateTime? ProximaCita { get; set; }
		public int? IdProximaCita { get; set; }
		public string? ProximaCitaColor { get; set; }
	}

}
