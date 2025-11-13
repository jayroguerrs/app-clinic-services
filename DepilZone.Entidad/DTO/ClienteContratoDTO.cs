using System;
using System.Collections.Generic;
using System.Text;

namespace DepilZone.Entidad.DTO
{
    public class ClienteContratoDTO
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public string IdDocumentos { get; set; }
        public int IdUsuarioRegistro { get; set; }
        public int? IdUsuarioModifico { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaModifico { get; set; }
        public string Contrato { get; set; }
        public int IdEstado { get; set; }
        public bool EnviarCorreo { get; set; }

        public string? Observacion { get; set; }
        public int? IdServicio {get; set;}

        // Salida
        public string? NombreCliente { get; set; }
        public string? TipoDocumentoIdentidad { get; set; }
        public string? DocumentoIdentidad { get; set; }
        public List<CC_DocumentoDTO> Documentos { get; set; }
        public List<ArchivoPdfDTO> DocumentosRenderizados { get; set; }
        public int Confirmado { get; set; }
        public DateTime? FechaConfirmo { get; set; }



        // Alternativos
        public string UsuarioRegistro { get; set; }
        public string? UsuarioModifico { get; set; }
        public string ClienteEmail { get; set; }
        public string EmailCC { get; set; }
        public string TituloContrato { get; set; }
        public bool EmailEnviado { get; set; }
        public int IdPlantilla { get; set; }
        public string? ListaDocumentos { get; set; }
        public string? Servicio { get; set; }
        public string? ServicioColor { get; set; }
    }

    public class CC_DocumentoDTO
    {
        public int Id { set; get; }
        public string Nombre { set; get; }
        public string? Zonas { get; set; }
        public string? Promocion { get; set; }
    }

    public class ClienteContratoConfirmadoDTO
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public string? Correo { get; set; }
        public DateTime FechaContrato { get; set; }
        public DateTime? FechaConfirmacion { get; set; }
        public string Cliente { get; set; }
    }

}