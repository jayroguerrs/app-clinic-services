using System;
using System.Collections.Generic;
using System.Text;

namespace DepilZone.Entidad
{
	public class CitaSeguimientoEnt
	{
		public int IdSeguimientoCita { get; set; }
		public string Descripcion { get; set; }
		public string Nombre { get; set; }
		public string Fecha { get; set; }
		public int IdUsuario { get; set; }
	}
}
