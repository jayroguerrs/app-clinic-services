using System;
using System.Collections.Generic;
using System.Text;

namespace DepilZone.Entidad.DTO
{
    public class DocumentoPlantillaDTO
    {
        public int Id { get; set; }
        public int IdDocumentoTipo { get; set; }
        public string Plantilla { get; set; }
        public string ImagenCabeceraDocumento { get; set; }
        public string ImagenPieDocumento { get; set; }
        public int Version { get; set; }
        public int IdEstado { get; set; }
        public DateTime FechaRegistra { get; set; }
        public string UsuarioRegistra { get; set; }
        public DP_DocumentoDTO Documento { get; set; }
        public string Html { get; set; }

        public string Margin { get; set; }
    }

    public class DP_DocumentoDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

    }
}
