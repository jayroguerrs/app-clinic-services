using System;
using System.Collections.Generic;
using System.Text;

namespace DepilZone.Entidad
{
	public class MenuEnt
	{
		public int Id { get; set; }
		public int? IdPadre { get; set; }
        public string Descripcion { get; set; }
        public int IdMenuTipo { get; set; }
        public string Icono { get; set; }
        public string Ruta { get; set; }
        public string IdTexto { get; set; }
        public bool Visible { get; set; }
        public int Nivel { get; set; }
     
    }
}
