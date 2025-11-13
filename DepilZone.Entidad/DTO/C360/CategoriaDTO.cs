using System;
using System.Collections.Generic;
using System.Text;

namespace DepilZone.Entidad.DTO.C360
{
    public class CategoriaDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int IdUsuarioRegistro { get; set; }
        #nullable enable
        public int? IdUsuarioModifico { get; set; }
        public DateTime FechaRegistro { get; set; }
        #nullable enable
        public DateTime? FechaModifico { get; set; }
        public int IdServicio { get; set; }
        public int IdEstado { get; set; }

        // secondary
        public string UsuarioRegistro { get; set; }
        #nullable enable
        public string? UsuarioModifico { get; set; }
        public string Servicio { get; set; }
        public string Estado { get; set; }
    }
}
