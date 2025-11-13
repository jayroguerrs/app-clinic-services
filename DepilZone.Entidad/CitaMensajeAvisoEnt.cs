using System;

namespace DepilZone.Entidad
{
    public class CitaMensajeAvisoEnt
	{
		public int Id { get; set; }
		public int IdCita { get; set; }
		public int IdUsuario { get; set; }
		public string Aviso { get; set; }
		public DateTime FechaRegistra { get; set; }

		// secondary
		public string UsuarioRegistro { get; set; }
		public bool Destacado { get; set; }
    }
}