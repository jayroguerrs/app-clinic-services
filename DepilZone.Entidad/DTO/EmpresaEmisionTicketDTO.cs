using System;
using System.Collections.Generic;
using System.Text;

namespace DepilZone.Entidad.DTO
{
    public class EmpresaEmisionTicketDTO
    {
        public string RazonSocial { get; set; }
        public string RUC { get; set; }
        public string Descripcion { get; set; }
        public string DireccionBySede { get; set; }
        public string Telefonos { get; set; }
        public string NombreTipoComprobante { get; set; }
        public string SerieNumeroComprobante { get; set; }
        public string Sede { get; set; }
        public string Cliente { get; set; }
        public string Documento { get; set; }
        public decimal Total { get; set; }
        public decimal Vuelto { get; set; }
        public int IdTipoComprobante { get; set; }
        public string BoletaPdfBase64 { get; set; }
        public IEnumerable<DetalleTicketEmisionDTO> Detalle { get; set;  }

        public string? SunatUrlPdf { get; set; }
        public string? SunatUrlXml { get; set; }
        public string? SunatUrlCdr { get; set; }

    }

    public class DetalleTicketEmisionDTO
    {
        public string ZonaCorporal { get; set; }
        public int Sesion { get; set; }
        public decimal Precio { get; set; }
    }
}
