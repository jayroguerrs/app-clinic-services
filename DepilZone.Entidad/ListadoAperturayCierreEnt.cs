using System;
using System.Collections.Generic;
using System.Text;

namespace DepilZone.Entidad
{
	public class ListadoAperturayCierreEnt
	{
		public int IdApertura { get; set; }
		public int IdCaja { get; set; }
		public string descripcion { get; set; }
		public int IdUsuario { get; set; }
		public string Nombre { get; set; }
		public int IdTurno { get; set; }
		public string Turno { get; set; }
		public DateTime? FechaApertura { get; set; }
		public string HoraApertura { get; set; }
		public DateTime? FechaCierre { get; set; }
		public Boolean ischeckapertura { get; set; }
		public Boolean ischeckcierre { get; set; }
	}
}
