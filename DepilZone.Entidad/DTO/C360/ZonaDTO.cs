using System;
using System.Collections.Generic;
using System.Text;

namespace DepilZone.Entidad.DTO.C360
{
    public class ZonaDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int IdUsuarioRegistro { get; set; }
        public int? IdUsuarioModifico { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaModifico { get; set; }
        public int IdGenero { get; set; }
        public int IdEstado { get; set; }

        // secondary
        public string UsuarioRegistro { get; set; }
        public string? UsuarioModifico { get; set; }
        public string Genero { get; set; }
        public string Estado { get; set; }

        public List<ZonaServicioSDTO> Servicios { get; set; }
    }


    public class ZonaServicioSDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string NombreCorto { get; set; }
        public int Duracion { get; set; }
    }
}
