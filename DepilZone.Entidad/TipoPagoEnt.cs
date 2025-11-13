using System;
using System.Collections.Generic;
using System.Text;

namespace DepilZone.Entidad
{
	public class TipoPagoEnt
	{
		public int IdTipoPago { get; set; }
		public string Descripcion { get; set; }
		public int Estado { get; set; }
		public string Valor { get; set; }
		public bool Entidad { get; set; }
		public bool NumOperacion { get; set; }

    }
}
