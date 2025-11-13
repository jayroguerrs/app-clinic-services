using System;

namespace DepilZone.Entidad
{
    public class UsuarioEnt
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Usuario { get; set; }
        public string Clave { get; set; }
        public int Genero { get; set; }
        public int IdEstado { get; set; }
        public int IdPerfil { get; set; }
        public int IdSede { get; set; }
        public int IdCaja { get; set; }
        public string Foto { get; set; }
        public string UsuarioRegistra { get; set; }
        public DateTime FechaRegistra { get; set; }
        public string UsuarioEdita { get; set; }
        public DateTime? FechaEdita { get; set; }
        public int TotalAsignados { get; set; }
    }
}