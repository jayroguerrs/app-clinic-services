using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace DepilZone.Entidad.DTO
{
    public class PromocionZonaDTO
    {
        public int IdPromocionPrecio { get; set; } 
        public int IdPromocionZona { get; set; }
        public int IdPromocion { get; set; }
        public int IdZona { get; set; }
        public string Sexo { get; set; }
        public int IdGenero { get; set; }
        public string Descripcion { get; set; }
        public decimal PrecioBase { get; set; }
        public int Activo { get; set; }
        public decimal PrecioPromocion { get; set; }
        public int RangoIni { get; set;  }
        public int RangoFin { get; set; }

        

        public int Id { get; set; }
        public string Promocion { get; set; }

    }
}
