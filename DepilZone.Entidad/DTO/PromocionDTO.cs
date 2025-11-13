using System;
using System.Collections.Generic;

namespace DepilZone.Entidad.DTO
{
    public class PromocionDTO
    {
        public int IdPromocion { get; set; }
        public string Descripcion { get; set; }
        public int? RefPrecio { get; set; }
        public string Condicion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public bool Lu { get; set; }
        public bool Ma { get; set; }
        public bool Mi { get; set; }
        public bool Ju { get; set; }
        public bool Vi { get; set; }
        public bool Sa { get; set; }
        public bool Do { get; set; }
        public int? ZonaUsar { get; set; }
        public int? IdPerfil { get; set; }
        public int Activo { get; set; }
        public string UsuarioRegistra { get; set; }
        public DateTime FechaRegistra { get; set; }
        public string UsuarioModifica { get; set; }
        public DateTime? FechaModifica { get; set; }
        public virtual ICollection<PromocionBloqueEnt> PromocionBloques { get; set; }

        public int? IdPromocionCategoria { get; set; }
        public string? PromocionCategoria { get; set; }

        public int? IdServicio { get; set; }
        // secondary
        public string? Servicio { get; set; }
        public string? ServicioColor { get; set; }
        public bool Vigente { get; set; }

    }


    public class PromocionRanking
    {
        public int IdPromocion { get; set; }
        public string Promocion { get; set; }
        public DateTime FechaCita { get; set; }
        public decimal Total { get; set; }
        public int NumZonas { get; set; }
        public int IdSede { get; set; }
        public string Sede { get; set; }
        public int Cantidad { get; set; }
    }

    public class PromocionZonaRanking
    {
        public int IdZona { get; set; }
        public string Zona { get; set; }
        public int Cantidad { get; set; }
        public decimal Total { get; set; }
    }



    public class PromocionCategoriaDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int IdUsuarioRegistro { get; set; }
        public int? IdUsuarioModifico { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaModifico { get; set; }
        public int IdEstado { get; set; }

        // secondary
        public string UsuarioRegistro { get; set; }
        public string? UsuarioModifico { get; set; }
     }

    public class PromocionStatusDTO
    {
        public int Id { get; set; }
        public int Status { get; set; }
    }
}
