using System;
using System.Collections.Generic;
using System.Text;

namespace DepilZone.Entidad
{
    public class PromocionPrecioEnt
    {
        public int IdPromocionPrecio { get; set; }
        public int IdPromocionZona { get; set; }
        public int IdPromocionBloque { get; set; }
        public decimal Precio { get; set; }
        public string UsuarioRegistra { get; set; }
        public DateTime FechaRegistra { get; set; }

    }
}
