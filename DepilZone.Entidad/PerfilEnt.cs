using System;
using System.Collections.Generic;
using System.Text;

namespace DepilZone.Entidad
{
    public class PerfilEnt
    {
        public int IdPerfil { get; set; }
        public string  Nombre { get; set; }
        public IEnumerable<PerfilDetalleEnt> PerfilDetalle { get; set; }
    }
}
