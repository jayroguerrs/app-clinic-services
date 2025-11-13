using System;
using System.Collections.Generic;
using System.Text;

namespace DepilZone.Entidad
{
	public class FacturacionElectronicaEnt
	{
		public int IdVenta { get; set; }
		public int IdCita { get; set; }
		public string Cita { get; set; }
		public int IdCaja { get; set; }
		public string Caja { get; set; }
		public string NumeroDocumento { get; set; }
		public int IdTipoDocumento { get; set; }
		public string TipoDocumento { get; set; }
		public string Serie { get; set; }
		public string Numero { get; set; }
		//public int IdCliente { get; set; }
		public string Cliente { get; set; }
		public int IdMoneda { get; set; }
		public string Moneda { get; set; }
		//public int IdEstadoDocumento { get; set; }
		public string EstadoDocumento { get; set; }
		public int IdFormulario { get; set; }
		public string Formulario { get; set; }
		//public int IdEstadoFE { get; set; }
		public string EstadoFE { get; set; }
		public string FechaRegistro { get; set; }
		public decimal pVenta { get; set; }
		public decimal pDescuento { get; set; }
		public decimal pRecargo { get; set; }
		public decimal pPrecioBase { get; set; }
		public decimal pAbono { get; set; }
		public decimal pVuelto { get; set; }
		public decimal pTotal { get; set; }
		public decimal pEfectivos { get; set; }
		public decimal pSuttotal { get; set; }
		public decimal pIgv { get; set; }
		public int IdTipoPago { get; set; }
		public string TipoPago { get; set; }
		public string CodigoOperacion { get; set; }
		public DateTime FechaPago { get; set; }
		public int IdUsuarioRegistra { get; set; }
		public string UsuarioRegistra { get; set; }
	}
}
