using System;
using System.Collections.Generic;
using System.Text;

namespace DepilZone.Entidad.DTO
{
    public class UsuarioCambiarClaveDTO
    {
        public int IdUsuario { get; set; }
        public string ClaveActual { get; set; }
        public string ClaveNueva { get; set; }
    }
}
