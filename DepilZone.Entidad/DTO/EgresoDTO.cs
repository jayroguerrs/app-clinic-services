using System;
using System.Collections.Generic;
using System.Text;

namespace DepilZone.Entidad.DTO
{
    public class EgresoDTO
    {
		public int Id { get; set; }
		public decimal Monto { get; set; }
		public string MontoStr
		{
			get
			{
				return Monto.ToString("S/ 0.00");
			}
		}
		public int IdCaja { get; set; }
        public string Caja { get; set; }
        public string ResponsableCaja { get; set; }
        public DateTime Fecha { get; set; }
		public string FechaStr 
		{
			get
			{
				return Fecha.ToString("dd-MM-yyyy HH:mm:ss");
			}
		}

		public int IdSede { get; set; }
        public string Sede { get; set; }
        public int IdEstado { get; set; }

		public string Concepto { get; set; }
		public string Observacion { get; set; }
		public string Beneficiario { get; set; }
		public string UsuarioRegistra { get; set; }
		public DateTime FechaRegistra { get; set; }
	}
}
