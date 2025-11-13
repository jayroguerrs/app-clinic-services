using System;

namespace DepilZone.Entidad.DTO
{
    public class ClienteIncidenciaDTO
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int IdCliente { get; set; }
        public int IdCita { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaModifico { get; set; }
        public int IdUsuarioRegistro { get; set; }
        public int? IdUsuarioModifico { get; set; }



        // Secondary
        public string Sede { get; set; }
        public string Cliente { get; set; }
        public string UsuarioRegistro { get; set; }
        public string UsuarioModifico { get; set; }
    }
}
