using System;

namespace DepilZone.Entidad
{
    public class CitaTipoEnt
    {
        public int IdTipoCita { get; set; }
        public string Nombre { get; set; }
        public int IdEstado { get; set; }
        public string UsuarioEdita { get; set; }
        public DateTime FechaEdita { get; set; }
        public string UsuarioRegistra { get; set; }
        public DateTime FechaRegistra { get; set; }
    }
}
