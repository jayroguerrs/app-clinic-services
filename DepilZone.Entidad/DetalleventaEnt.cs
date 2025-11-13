using System;
using System.Collections.Generic;
using System.Text;

namespace DepilZone.Entidad
{
	public class DetalleventaEnt
	{
		public int DVenta { get; set; }
		public string NumeroDocumento { get; set; }
		public string Serie { get; set; }
		public string Numero { get; set; }
		public DateTime FechaRegistro { get; set; }
		public int IdZona { get; set; }
		public string Descripcion { get; set; }
		public int Cantidad { get; set; }
		public decimal pImporte { get; set; }
		public decimal pTotal { get; set; }
		public int IdVenta { get; set; }
		public string consolidado {get; set; }

}
}
