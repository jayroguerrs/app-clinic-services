using System;
using System.Collections.Generic;
using System.Text;

namespace DepilZone.Entidad
{
    public class PreferenteZonaCorporalEnt
    {
        public int Id { get; set; }
        public int IdPreferente { get; set; }
        public int IdZonaCorporal { get; set; }

        public string  Descripcion { get; set; }
    }
}
