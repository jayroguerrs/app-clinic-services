using System;

namespace DepilZone.Entidad
{
    public class CitaMensajeDetalleEnt
	{
		public int Id { get; set; }
		public int IdCita { get; set; }
		public int IdUsuario { get; set; }
		public string Detalle { get; set; }
		public DateTime FechaRegistra { get; set; }
		public bool Destacado { get; set; }
    }
}
