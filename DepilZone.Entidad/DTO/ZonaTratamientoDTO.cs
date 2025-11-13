using System;

namespace DepilZone.Entidad.DTO
{
    public class ZonaTratamientoDTO
    {
        public int Id { get; set; }
        public int IdServicio { get; set; }
        public string Nombre { get; set; }
        public string? Descripcion { get; set; }
        public int IdEstado { get; set; }
        public int IdUsuarioRegistro { get; set; }
        public int? IdUsuarioModifico { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaModifico { get; set; }



        // secondary
        public string Servicio { get; set; }
        public string ServicioColor { get; set; }
        public string UsuarioRegistro { get; set; }
        public string? UsuarioModifico { get; set; }
    }

}
