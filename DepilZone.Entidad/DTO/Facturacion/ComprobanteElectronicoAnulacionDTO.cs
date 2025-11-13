using System;

namespace DepilZone.Entidad.DTO.Facturacion
{

    public class ComprobanteElectronicoAnulacionDTO
    {   
        public int Id { get; set; }
        public string Motivo { get; set; }

        public int IdTipoComprobante { get; set; }
        public string TipoComprobante { get; set; }


        public int IdSede { get; set; }
        public string Sede { get; set; }

        public string Serie { get; set; }
        public int Numero { get; set; }

        public string Key { get; set; }
        public int Codigo { get; set; }
        public int IdEstadoSunat { get; set; }
        public string EstadoSunat { get; set; }
        public string EstadoSunatColor { get; set; }

        public bool SunatAcepto { get; set; }
        public string? SunatTicketNumero { get; set; }

        public string? SunatDescripcion { get; set; }
        public string? SunatNota { get; set; }
        public string? SunatCodigoRespuesta { get; set; }
        public string? SunatSoapError { get; set; }

        public string? SunatUrlPdf { get; set; }
        public string? SunatUrlXml { get; set; }
        public string? SunatUrlCdr { get; set; }
        public int IdUsuarioRegistro { get; set; }
        public int? IdUsuarioModifico { get; set; }

        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaModifico { get; set; }

        // Secundario
        public string UsuarioRegistro { get; set; }
        public string UsuarioModifico { get; set; }

    }


}