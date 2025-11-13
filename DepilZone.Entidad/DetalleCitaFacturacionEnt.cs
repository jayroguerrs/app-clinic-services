namespace DepilZone.Entidad
{
    public class DetalleCitaFacturacionEnt
	{
		public int IdCliente { get; set; }
		public int IdCita { get; set; }
		public string Cliente { get; set; }
		public string Documento { get; set; }
		public decimal Total { get; set; }
		public int IdSede { get; set; }
		public string Sede { get; set; }
		public int IdCaja { get; set; }
		public string Caja { get; set; }
	}
}
