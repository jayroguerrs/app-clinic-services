using System;

namespace DepilZone.Entidad
{
    public class ZonaCorporalEnt
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string DescripcionLarga { get; set; }
        public int  Duracion { get; set; }
        public decimal Igv { get; set; }
        public decimal PrecioBase { get; set; }
        public decimal PrecioDescuento { get; set; }
        public string Detalle { get; set; }
        public string IdGenero { get; set; }
        public int IdTipo { get; set; }
        public int IdEstado { get; set; }
        public string UsuarioRegistra { get; set; }
        public DateTime FechaRegistra { get; set; }
        public string UsuarioEdita { get; set; }
        public DateTime FechaEdita { get; set; }
        public string? ZonasRel { get; set; }

        public int ZonaPadre { get; set; }

        public string? UrlWeb { get; set; }
        public string? Imagen { get; set; }
        public int? IdServicio { get; set; }

        public int? IdUnidadMedida { get; set; }

        // secondary
        public string? Servicio { get; set; }
        public string? UnidadMedida { get; set; }
    }
}
