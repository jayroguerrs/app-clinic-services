using System;
using System.Collections.Generic;
using System.Text;

namespace DepilZone.Entidad
{
    public class AnuncioEnt
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Informacion { get; set; }
        public string Imagen { get; set; }
        public string UsuarioRegistra { get; set; }
        public DateTime FechaRegistra { get; set; }
        public string UsuarioEdita { get; set; }
        public DateTime FechaEdita { get; set; }
    }
}
