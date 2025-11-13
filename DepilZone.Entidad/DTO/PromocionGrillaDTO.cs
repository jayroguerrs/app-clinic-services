using System;

namespace DepilZone.Entidad.DTO
{
    public class PromocionGrillaDTO
    {
        public int IdPromocion { get; set; }
        public string Descripcion { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }
        public int? IdPerfil { get; set; }
        public string PerfilDes { get; set; }
        public int? RefPrecio { get; set; }
        public string RefDescrip { get; set; }
        public string ZonaUsarDes { get; set; }
        public int Activo { get; set; }
        public string UsuarioRegistra { get; set; }
        public DateTime FechaRegistra { get; set; }
        public string UsuarioModifica { get; set; }
        public DateTime? FechaModifica { get; set; }

        public int? IdPromocionCategoria { get; set; }
        public string? PromocionCategoria { get; set; }
        public int? IdServicio { get; set; }

        // secondary
        public string? Servicio { get; set; }
        public string? ServicioColor { get; set; }
        public bool Vigente { get; set; }
        public int proStatus { get; set; }
    }

}
