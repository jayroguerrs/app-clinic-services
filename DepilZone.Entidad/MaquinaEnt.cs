using System;

namespace DepilZone.Entidad
{
    public class MaquinaEnt
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Color { get; set; }
        public int IdEstado { get; set; }
        public string UsuarioRegistra { get; set; }
        public DateTime FechaRegistra { get; set; }
        public string UsuarioEdita { get; set; }
        public DateTime? FechaEdita { get; set; }
    }

    public class MaquinaMinutosEnt
    {
        public int Citas { get; set; }
        public int IdMaquina { get; set; }
        public string Sede { get; set; }
        public int Minutos { get; set; }
        public int Porcentaje { get; set; }
    }
}
