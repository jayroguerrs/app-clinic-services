using System;

namespace DepilZone.Entidad.DTO.Facturacion
{
    public class CitaDatosComprobanteDTO
    {
        public int IdCita { get; set; }
        public int IdSede { get; set; }
        public int IdServicio { get; set; }
        public DateTime FechaCita { get; set; }
        public int NumeroBox { get; set; }
        public int? IdMaquinaMarca { get; set; }
        public string? MaquinaMarca { get; set; }
        public int? IdAtendidoPor { get; set; }
        public string? AtendidoPor { get; set; }
        public int IdCliente { get; set; }
        public string NombreCliente { get; set; }
        public int? IdTipoDocumentoCliente { get; set; }
        public string? TipoDocumentoCliente { get; set; }
        public string? DocumentoCliente { get; set; }
    }


    public class CitaDetalleDatosComprobanteDTO
    {
        public int Id { get; set; }
        public int IdCita { get; set; }
        public int IdZona { get; set; }
        public string Zona { get; set; }
        public int? IdUnidadMedida { get; set; }
        public string? UnidadMedida { get; set; }
        public string? UnidadMedidaValor { get; set; }
        public string? DescripcionUnidadMedida { get; set; }
        public int Sesion { get; set; }
        public decimal Precio { get; set; }
    }

}
