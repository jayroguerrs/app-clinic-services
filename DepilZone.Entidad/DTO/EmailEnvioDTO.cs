using System;
using System.Collections.Generic;
using System.Text;
namespace DepilZone.Entidad.DTO
{
    public class EmailEnvioDTO
    {
        public string EmailDestino { get; set; }
        public string EmailCopiaOculta { get; set; }
        public string Asunto { get; set; }
        public string Contenido { get; set; }
        public string MensajeCliente { get; set; }
        public string Adjunto { get; set; }
        public string NombreAdjunto { get; set; }

        public int? IdContrato { get; set; }

        public List<ArchivoPdfDTO> DocumentosRenderizados { get; set; }
    }

    public class ArchivoPdfDTO
    {
        public int Id { get; set; }
        public string titulo { get; set; }
        public string contenidoBase64 { get; set; }
    }
}