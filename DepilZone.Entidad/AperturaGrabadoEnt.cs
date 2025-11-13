using System;
using System.Collections.Generic;
using System.Text;

namespace DepilZone.Entidad
{
	public class AperturaGrabadoEnt
	{
		public int IdApertura { get; set; }
		public int idcaja { get; set; }
		public int idusuario { get; set; }
		public int idturno { get; set; }
		public string FechaApertura { get; set; }
		public string HoraApertura { get; set; }
		public string FechaCierre { get; set; }
	}
}
