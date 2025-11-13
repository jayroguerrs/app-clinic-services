using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Entidad.DTO
{
    public class PermisosDTO
    {
        public int IdUsuario { get; set; }
        public string Permisos { get; set; }
        public string Opcion { get; set; }
        public string Accion { get; set; }
    }
    public class ResponsePermisoDTO
    {
        public string Res { get; set; }
        public string Msg { get; set; }
    }
}
