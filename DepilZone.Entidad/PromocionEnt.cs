using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace DepilZone.Entidad
{
    public class PromocionEnt
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

        //secondary
        public string? Servicio { get; set; }
        public string? ServicioColor { get; set; } 
        public bool Vigente { get; set; }
    }
}
