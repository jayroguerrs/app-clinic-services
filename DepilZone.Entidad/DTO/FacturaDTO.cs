using System;

namespace DepilZone.Entidad.DTO
{
    public class FacturaSerieDTO
    {
        public int Id { get; set; }
        public string Serie { get; set; }
        public int IdSede { get; set; }
        public int IdUsuarioRegistro { get; set; }
        public int? IdUsuarioModifico { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaModifico { get; set; }
        public int IdEstado { get; set; }

        // secondary
        public string Sede { get; set; }
        public string UsuarioRegistro { get; set; }
        public string? UsuarioModifico { get; set; }
        public string Estado { get; set; }
    }

}
