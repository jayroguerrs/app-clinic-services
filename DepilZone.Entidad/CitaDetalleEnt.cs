using System;

namespace DepilZone.Entidad
{
    public class CitaDetalleEnt
	{
		public int Id { get; set; }
		public int IdCita { get; set; }
		public int IdZona { get; set; }
		public int Sesion { get; set; }
		public int IdPromocionPrecio { get; set; }
		public decimal Precio { get; set; }
        public int Duracion { get; set; }
        public int? IdUsuarioAgendado { get; set; }

		public bool RetroTratam { get; set; }
		public bool PagoWeb { get; set; }
		public decimal PrecioDescuento { get; set; }

		public int? IdMedioContactoOrigen { get; set; }
		public int Estado { get; set; }
        public int Duplicado { get; set; }
		public string? Parametros { get; set; }
        public int? SesionFinal { get; set; }
        public int? TratamientoRealizado { get; set; }

    }
}
