using System;
using System.Collections.Generic;
using System.Text;

namespace DepilZone.Entidad.DTO
{
    public class ClienteDocumentoDTO
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public int IdDocumentoTipo { get; set; }
        public int? IdPromocion { get; set; }
        public string? IdsZonas { get; set; }
        public string? IdPatologia { get; set; }
        public int? SesionesAdicionales { get; set; }
        public int? IntervaloMantenimiento { get; set; }
        public int? ConsultaMantenimientoEn { get; set; }
        public string? DescripcionComentario { get; set; }
        public int? IdDoctora { get; set; }
        public int IdEstado { get; set; }
        public string? Observacion { get; set; }
        public DateTime FechaRegistra { get; set; }
        public string? MotivoAnulacion { get; set; }
        public string? DniApoderado { get; set; }
        public string? NombreApoderado { get; set; }
        public int? IdUsuarioModifico { get; set; }
        public int IdUsuarioRegistro { get; set; }
        public DateTime? FechaModifico { get; set; }
        public int Version { get; set; }
        public int? NumeroSesionesRetroceder { get; set; }
        public int? NumeroSesiones { get; set; }
        public DateTime? FechaDocumento { get; set; }
        public string? Condiciones { get; set; }
        public bool EmailEnviado { get; set; }
        public int Confirmado { get; set; }
        public DateTime? FechaConfirmo { get; set; }



        // Secundarios entrada
        public bool EnviarCorreo { get; set; }
        public string Documento { get; set; }



        // Secundarios salida
        public string UsuarioRegistro { get; set; }
        public string UsuarioModifico { get; set; }
        public string NombreCliente { get; set; }
        public string? TipoDocumentoIdentidad { get; set; }
        public string? DocumentoIdentidad { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string NombreDoctora { get; set; }
        public string? NombreDocumento { get; set; }
        public string? Promocion { get; set; }

        public string? Direccion { get; set; }
        public string? Distrito { get; set; }



        public string ClienteEmail { get; set; }
        public string EmailCC { get; set; }
        //public string Archivo { get; set; }
        public string TituloDocumento { get; set; }

        public string Cliente { get; set; }
        public string Mensaje { get; set; }

        public string? Plantilla { get; set; }

        public ClienteDocumentoPromocionDTO DocumentoPromocion { get; set; }

        public CD_ClienteDocumentoTipoDTO DocumentoTipo { get; set; }

        public List<CD_Zonas> Zonas { get; set; }
        public List<CD_Patologias> Patologias { get; set; }

        public string? ListaZonas { get; set; }

    }

    public class ClienteDocumentoPromocionDTO
    {
        public int? Id { get; set; }
        public string? Nombre { get; set; }
    }

    public class CD_ClienteDocumentoTipoDTO
    {
        public int? Id { get; set; }
        public string? Nombre { get; set; }
    }

    public class CD_Zonas
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }

    public class CD_Patologias
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}