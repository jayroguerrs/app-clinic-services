using System;
using System.Collections.Generic;
using System.Text;

namespace DepilZone.Entidad
{
    public class DocumentoEnt
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public int IdDocumentoTipo { get; set; }
        #nullable enable
        public int? IdPromocion { get; set; }
        public string IdsZonas { get; set; }
        #nullable enable
        public int? IdPatologia { get; set; }


        public int SesionesAdicionales { get; set; }
        public int IntervaloMantenimiento { get; set; }
        public int ConsultaMantenimientoEn{ get; set; }
        public string DescripcionComentario { get; set; }
        #nullable enable
        public int? IdDoctora { get; set; }

        public int IdEstado { get; set; }
        public string Observacion { get; set; }
        public DateTime FechaRegistra { get; set; }
        public string UsuarioRegistra { get; set; }
        public string Documento { get; set; }

        public bool EnviarCorreo { get; set; }
        #nullable enable
        public string? DniApoderado { get; set; }
        #nullable enable
        public string? NombreApoderado { get; set; }
    }
}
