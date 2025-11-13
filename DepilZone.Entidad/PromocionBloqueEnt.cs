namespace DepilZone.Entidad
{
    public class PromocionBloqueEnt
    {

        public int Id { get; set; }
        public string Plantilla { get; set; }
        public int IdPromocion { get; set; }
        public int RangoIni { get; set; }
        public int RangoFin { get; set; }
        public decimal DescuentoPorcentaje { get; set; }
        public decimal DescuentoFijo { get; set; }
        public decimal AumentFijo { get; set; }
        public string UsuarioRegistra { get; set; }

    }

}
