using System;

namespace DepilZone.Entidad
{
    public class SedeEnt
    {
        public SedeEnt()
        {
            this.Ubicacion = new Ubicacion();
        }
        public int IdSede { get; set; }
        public string Nombre { get; set; }
        public int Estado { get; set; }
        public string Direccion { get; set; }
        public string UsuarioRegistra { get; set; }
        public DateTime FechaRegistra { get; set; }
        public string UsuarioEdita { get; set; }
        public DateTime FechaEdita { get; set; }
        public string IdUbicacion { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFin { get; set; }
        public virtual Ubicacion Ubicacion { get; set; }

    }
}
