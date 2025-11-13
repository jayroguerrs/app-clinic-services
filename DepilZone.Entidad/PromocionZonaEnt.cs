using System;
using System.Collections.Generic;
using System.Text;

namespace DepilZone.Entidad
{
    public class PromocionZonaEnt
    {
        public int IdPromocionZona { get; set; }
        public int IdPromocion { get; set; }
        public int IdZona { get; set; }
        public int? IdGenero { get; set; }
        public decimal PrecioBase { get; set; }
        public int Activo { get; set; }
        public string UsuarioRegistra { get; set; }
        public string FechaRegistra { get; set; }
        public string UsuarioEdita { get; set; }
        public string FechaEdita { get; set; }

        public IList<PromocionPrecioEnt> PromocionPrecios { get; set; }

    }

    public class PromocionDeleteIds { 
        public string Ids { get; set; }
    }

}
