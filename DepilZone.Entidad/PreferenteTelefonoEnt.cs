using System;
using System.Collections.Generic;
using System.Text;

namespace DepilZone.Entidad
{
    public class PreferenteTelefonoEnt
    {
        public int Id { get; set; }
        public int IdPreferente { get; set; }
        public string Prefijo { get; set; }
        public string Numero { get; set; }
        public DateTime FechaRegistra { get; set; }
    }
}
