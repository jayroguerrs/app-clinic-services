using System;
using System.Collections.Generic;
using System.Text;

namespace DepilZone.Entidad.DTO
{
    public class CitaMensajeDetalleDTO
    {
        public int Id { get; set; }
        public int IdCita { get; set; }
        public int IdUsuario { get; set; }
        public string Detalle { get; set; }
        public DateTime FechaRegistra { get; set; }
        public string  InicialesUsuario { get; set; }
        public string UsuarioRegistra { get; set; }


        public string Texto { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int IdUsuarioRegistro { get; set; }
        public string UsuarioRegistro { get; set; }
        public bool Destacado { get; set; }
    }
}
