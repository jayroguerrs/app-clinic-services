using System;
using System.Collections.Generic;
using System.Text;

namespace DepilZone.Entidad
{
	public class EgresoEnt
	{
		public int Id { get; set; }
		public decimal Monto { get; set; }
		public int IdCaja { get; set; }
		public DateTime Fecha { get; set; }
		
		public string FechaStr { get; set; }
		public int IdSede { get; set; }
		public int IdEstado { get; set; }
		public string Concepto { get; set; }
		public string Observacion { get; set; }
		public string Beneficiario { get; set; }
		public string UsuarioRegistra { get; set; }
        public DateTime FechaRegistra { get; set; }
		
	}
}
