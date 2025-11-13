using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Entidad.DTO
{
    public class ConfirmarSupervisorDTO
    {
        public int IdUsuario { get; set; }
        public string UsuarioSupervisor { get; set; }
    }
    public class RespuestaConfirmarSupervisorDTO
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public int IdSupervisor { get; set; }
    }
}
