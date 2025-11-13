using System;
using System.Collections.Generic;
using System.Text;

namespace DepilZone.Entidad.DTO
{
    public class PreferenteObservacionDTO
    {
        public int Id { get; set; }
        public int IdPreferente { get; set; }
        public string Observacion { get; set; }
        public DateTime FechaRegistra { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string InicialesUsuario { get; set; }
        public string UsuarioRegistra { get; set; }
        public string UsuarioRegistro { get; set; }
        public int IdUsuarioRegistro { get; set; }
    }
}
