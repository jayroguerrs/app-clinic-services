using System;
using System.Collections.Generic;

namespace DepilZone.Entidad.DTO
{
    public class PromocionVistaDetalleDTO
    {
        public string ZonaCorporal { get; set; }
        public decimal PrecioBase { get; set; }
        public IList<ColumnaPrecioBloque> PrecioBloques { get; set; }
        public int IdGenero { get; set; }
        public int IdPromocionZona { get; set; }
        public int IdZona { get; set; }
    }
    public class PromocionVistaDatosPlantillaDTO 
    {
        public int IdPromocionPrecio { get; set; }
        public int IdPromocionZona { get; set; }
        public int IdPromocionBloque { get; set; }
        public decimal Precio { get; set; }
        public string Plantilla { get; set; }
        public string DescripcionBloque { get; set; }
    }

    public class PromocionVistaDatosCondicionadoDTO
    {
        public int IdPromocion { get; set; }
        public string Condicion { get; set; }
        public string Periodo { get; set; }
        public string Dias { get; set; }
    }

    public class ColumnaPrecioBloque
    {
        public string ColumnaBloque { get; set; }
        public decimal PrecioBloque { get; set; }
    }
}
