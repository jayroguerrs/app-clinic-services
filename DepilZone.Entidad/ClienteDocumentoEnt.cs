using System;
using System.Collections.Generic;
using System.Text;

namespace DepilZone.Entidad
{
    public class ClienteDocumentoEnt
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
        public int? IdDoctora { get; set; }

        public int IdEstado { get; set; }
        public string Observacion { get; set; }
        public DateTime FechaRegistra { get; set; }
        public string UsuarioRegistra { get; set; }
        public string Documento { get; set; }

        public string MotivoAnulacion { get; set; }

        public ClienteDocumentoPromocionEnt DocumentoPromocion { get; set; }
    }

    public class ClienteDocumentoPromocionEnt
    {
        public int? Id { get; set; }
        #nullable enable
        public string? Nombre { get; set; }
    }
}
