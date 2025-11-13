using System;
using System.Collections.Generic;
using System.Text;

namespace DepilZone.Entidad
{
	public class VentaEnt
	{
		public int Id { get; set; }
		public int IdCita { get; set; }
		public int IdCaja { get; set; }
		public int IdCliente { get; set; }
		public int IdMoneda { get; set; }
        public int IdTipoPago { get; set; }
		public int IdTipoComprobante { get; set; }
		public string Serie { get; set; }
		public string Numero { get; set; }
		public decimal pSubTotal { get; set; }
		public decimal pDescuento { get; set; }
		public decimal pIgv { get; set; }
		public decimal pRecargo { get; set; }
		public decimal pEfectivo { get; set; }
		public decimal pVuelto { get; set; }
		public decimal pTotal { get; set; }
		public string CodigoOperacion { get; set; }
		public DateTime FechaPago { get; set; }
		public DateTime FechaEmision { get; set; }
		public int IdUsuarioRegistra { get; set; }
		public string UsuarioRegistra { get; set; }
		public string FechaRegistra { get; set; }
        public int IdEmpresa { get; set; }
        public int? IdUsuarioAtendidoPor{ get; set; }
        public bool SiguienteCita{ get; set; }

        public ICollection<VentaDetalleEnt> Detalles { get; set; }

		public string NumeroDocumentoIdentidad { get; set; }

		public int[] ZonasEliminadas { get; set; }	

		public int? NumeroBox { get; set; }

		public int? IdMaquinaMarca { get; set; }

    }
}
