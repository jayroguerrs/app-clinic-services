using System;
using System.Collections.Generic;
using System.Text;

namespace DepilZone.Entidad.DTO
{
	public class EquipoLaserDTO
	{
		public int Id { get; set; }
		public string Nombre { get; set; }
		public string? Descripcion { get; set; }
		public int Estado { get; set; }
	}
}