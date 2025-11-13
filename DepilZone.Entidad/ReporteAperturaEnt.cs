using System;
using System.Collections.Generic;
using System.Text;

namespace DepilZone.Entidad
{
	public class ReporteAperturaEnt
	{
		public int IdVenta { get; set; }
		public string NumeroDocumento { get; set; }
		public int IdCita { get; set; }
		public string Caja { get; set; }
		public int IdCaja { get; set; }
		public string Usuario { get; set; }
		public string Cliente { get; set; }
		public int IdCliente { get; set; }
		public int IdDocumento { get; set; }
		public string Documento { get; set; }
		public int IdTipoPago { get; set; }
		public string TipodePago { get; set; }
		public string Pagado { get; set; }
		public string Fecha { get; set; }
		public string hora { get; set; }
		public string usuarioregistro { get; set; }
		public string Efectivo { get; set; }
		public string Tarjetadecredito { get; set; }
		public string Deposito { get; set; }
	}
}
