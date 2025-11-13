using System;

namespace DepilZone.Entidad
{
    public class CitaMensajeNotaEnt
	{
		public int Id { get; set; }
		public int IdCita { get; set; }
		public int IdUsuario { get; set; }

		public int IdCliente { get; set; }
		public string Nota { get; set; }
		public DateTime FechaRegistra { get; set; }

		public bool Destacado { get; set; }
	}
}
