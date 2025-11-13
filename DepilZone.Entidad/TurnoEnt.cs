using System;
using System.Collections.Generic;
using System.Text;

namespace DepilZone.Entidad
{
	public class TurnoEnt
	{
		public int idturno { get; set; }
		public string Descripcion { get; set; }
		public string HoraInicio { get; set; }
		public string HoraFin { get; set; }
		public Boolean Estado { get; set; }
	}
}