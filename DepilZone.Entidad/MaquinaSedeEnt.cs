using System;
using System.Collections.Generic;
using System.Text;

namespace DepilZone.Entidad
{
    public class MaquinaSedeEnt
    {
        public int Id { get; set; }
        public int IdMaquina { get; set; }
        public int IdSede { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFin { get; set; }
        public string Descripcion { get; set; }
        public int IdEstado { get; set; }
        public int IdFicticio { get; set; }
        public string UsuarioRegistra { get; set; }
        public DateTime FechaRegistra { get; set; }
        public string UsuarioEdita { get; set; }
        public DateTime? FechaEdita { get; set; }
        public int? IdServicio { get; set; }
        public string? Servicio { get; set; }
    }
}
