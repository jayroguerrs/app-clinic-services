using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Entidad.DTO
{
    public class AprobarUsuarioDTO
    {
        public int IdUsuario { get; set; }
        public byte EstadoAprobacion { get; set; }
    }

    public class AccesoUsuarioDTO
    {
        public byte Privilegio { get; set; }
        public byte EstadoAprobacion { get; set; }
    }
}
