using System;
using System.Collections.Generic;
using System.Text;

namespace DepilZone.Entidad
{
	public class VentaDetalleEnt
	{
        public int Id { get; set; }
        public int IdVenta { get; set; }
        public int IdZona { get; set; }
        public int Cantidad { get; set; }
		public decimal Precio { get; set; }
		public decimal Importe { get; set; }
		public string UsuarioRegistra { get; set; }
		public DateTime FechaRegistra { get; set; }
		public bool Estado { get; set; }

    }
}
