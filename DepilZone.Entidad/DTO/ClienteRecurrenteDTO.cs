using System;
using System.Collections.Generic;
using System.Text;

namespace DepilZone.Entidad.DTO
{
	public class ClienteRecurrenteDTO
	{
		public int id { get; set; }
		public string Nombres { get; set; }
		public string Cliente { get; set; }
		public int CantidadCitas { get; set; }
		public int CantidadZonas { get; set; }
		public string Celular { get; set; }
		public string Documento { get; set; }
	}
}
