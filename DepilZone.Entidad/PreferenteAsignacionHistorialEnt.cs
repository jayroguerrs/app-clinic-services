using System;
using System.Collections.Generic;
using System.Text;

namespace DepilZone.Entidad
{
    public class PreferenteAsignacionHistorialEnt
    {
        public int Id { get; set; }
        public int IdPreferente { get; set; }
        public int IdTeleoperador { get; set; }
        public string UsuarioRegistra { get; set; }
        public DateTime FechaRegistra { get; set; }

    }
}
