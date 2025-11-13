using System;

namespace DepilZone.Entidad.DTO
{
    public class PlantillaDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Plantilla { get; set; }
        public int IdUsuarioRegistro { get; set; }
        public int? IdUsuarioModifico { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaModifico { get; set; }
        public int IdEstado { get; set; }

        // secondary
        public string UsuarioRegistro { get; set; }
        public string? UsuarioModifico { get; set; }
        public string Estado { get; set; }
    }
}
