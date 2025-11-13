using System;
using System.Collections.Generic;
using System.Text;

namespace DepilZone.Entidad
{
   public class DetModUsuario
    {
        public int IdDetModUsuario { get; set; }
        public string Detalle { get; set; }
        public string FechaMod { get; set; }
        public int IDUsuarioMod { get; set; }
        public int IdUsuario { get; set; }

    }
}
