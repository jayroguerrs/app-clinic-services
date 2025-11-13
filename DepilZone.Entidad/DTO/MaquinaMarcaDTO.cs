using System;
using System.Collections.Generic;

namespace DepilZone.Entidad.DTO
{
    public class MaquinaMarcaDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string NombreCorto { get; set; }
        public int IdUsuarioRegistro { get; set; }
        public int? IdUsuarioModifico { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaModifico { get; set; }
        public int IdEstado { get; set; }

        public List<int> IdServicios { get; set; }

        // secondary
        public List<ServicioSDTO> Servicios { get; set; }
        public string UsuarioRegistro { get; set; }
        public string? UsuarioModifico { get; set; }
    }

    public class MaquinaMarcaSDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string NombreCorto { get; set; }
        public int IdEstado { get; set; }
    }
}
