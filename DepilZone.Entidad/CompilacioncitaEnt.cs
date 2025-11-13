using System;
using System.Collections.Generic;
using System.Text;

namespace DepilZone.Entidad
{
	public class CompilacioncitaEnt
	{
		public int IdHorarioMinutos { get; set; }
		public int Id { get; set; }
		public string Fecha { get; set; }
		public int idmaquinacalendariosede { get; set; }
		public int idcalendariohorario { get; set; }
	}
}
