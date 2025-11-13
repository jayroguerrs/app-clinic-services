using System;
using System.Collections.Generic;
using System.Text;

namespace DepilZone.Entidad
{
    public class PreferenteObservacionEnt
    {
        public int Id { get; set; }
        public int IdPreferente { get; set; }
        public string Observacion { get; set; }
        public string UsuarioRegistra { get; set; }
        public DateTime FechaRegistra { get; set; }
    }
}
