using System;
using System.Collections.Generic;

namespace DepilZone.Entidad.DTO
{
    public class ZonaCorporalGridDTO
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string DescripcionLarga { get; set; }
        public int Duracion { get; set; }
        public decimal IGV { get; set; }
        public string Genero { get; set; }
        public int IdEstado { get; set; }
        public int IdTipo { get; set; }
        public int Sesion { get; set; }
        public List<SubZonaCorporalDTO> SubZonas { get; set; }

        public string? UrlWeb { get; set; }
        public string? Imagen { get; set; }
        public string? ZonasRel { get; set; }

        public decimal PrecioBase { get; set; }
        public decimal PrecioDescuento { get; set; }
        public string UsuarioRegistro { get; set; }
        public DateTime FechaRegistro { get; set; }

        public int? IdServicio { get; set; }
        public int? IdUnidadMedida { get; set; }

        // Secondary
        public string? Servicio { get; set; }
        public string? ServicioColor { get; set; }
        public List<SubZonaCorporalDTO> ZonasRelArray { get; set; }
        public string? UnidadMedida { get; set; }
    }

    public class ZonaCorporalDTO
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string DescripcionLarga { get; set; }
        public decimal Duracion { get; set; }
        public string Detalle { get; set; }
        public decimal Igv { get; set; }
        public int IdGenero { get; set; }
        public int IdTipo { get; set; }
        public string Genero { get; set; }
        public int IdEstado { get; set; }
        public decimal PrecioBase { get; set; }
        public decimal PrecioDescuento { get; set; }
        public string UsuarioRegistra { get; set; }
        public string UsuarioEdita { get; set; }
        public DateTime FechaRegistra { get; set; }
        public DateTime FechaEdita { get; set; }
        public string ZonaCorporal { get; set; }
        public List<SubZonaCorporalDTO> SubZonas{ get; set; }
        public string? UrlWeb { get; set; }
        public string? Imagen { get; set; }
        public string? ZonasRel { get; set; }

        public int? IdServicio { get; set; }
        public int? IdUnidadMedida { get; set; }

        // secondary
        public string? Servicio { get; set; }
        public string? UnidadMedida { get; set; }

    }

    public class SubZonaCorporalDTO
    {
        public int Id { get; set;  }
        public string Descripcion { get; set; }
    }

    public class SubZonaRelacionDTO
    {
        public int Id { get; set; }
        public int IdZona { get; set; }
        public int IdSubZona { get; set; }
    }

    public class ZonaCantidad
    {
        public int Id { get; set; }
        public string Zona { get; set; }
        public string Genero { get; set; }
        public int Cantidad { get; set; }
        public decimal Total { get; set; }
    }
    public class ZonaServicio {
        public int IdServicio { get; set; }
        public string Servicio { get; set; }
        public int IdZona { get; set; }
        public string Zona { get; set; }
        public int IdGenero { get; set; }
        public string Genero { get; set; }
    }
}
