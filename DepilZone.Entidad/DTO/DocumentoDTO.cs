using System;
using System.Collections.Generic;
using System.Text;

namespace DepilZone.Entidad.DTO
{
    public class DocumentoDTO
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public string ClienteEmail { get; set; }
        public string EmailCC { get; set; }
        public int IdDocumentoTipo { get; set; }
        public int? IdPromocion { get; set; }
        public string IdsZonas { get; set; }
        public int IdEstado { get; set; }
        public string Observacion { get; set; }
        public DateTime FechaRegistra { get; set; }
        public string UsuarioRegistra { get; set; }
        //public string Archivo { get; set; }
        public string TituloDocumento { get; set; }

        public string Cliente { get; set; }
        public string? Promocion { get; set; }
        public string Documento { get; set; }
        public string Mensaje { get; set; }
        public bool EmailEnviado { get; set; }
        public string Pdf64 { get; set; }

        public DocumentoPromocionDTO? DocumentoPromocion { get; set; }


        public string? DniApoderado { get; set; }
        public string? NombreApoderado { get; set; }
    }

    public class DocumentoPromocionDTO
    {
        public int? Id { get; set; }
        public string? Nombre { get; set; }
    }
}