using System;
using System.Collections.Generic;
using System.Text;

namespace DepilZone.Entidad.DTO
{
    public class PreferenteDTO
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }
        public string Promocion { get; set; }
        public int IdEstado { get; set; }
        public int? IdEstadoAtencion { get; set; }
        public string? EstadoAtencion { get; set; }
        public string IdUbicacion { get; set; }
        public string Direccion { get; set; }
        public int? IdTeleoperador { get; set; }
        public int? IdComentario { get; set; }
        public int IdMedioContacto { get; set; }
        public int? IdMedioContactoCierre { get; set; }
        public string OtroMedioContacto { get; set; }
        public DateTime? FechaAsignacion { get; set; }
        public string UsuarioRegistra { get; set; }
        public DateTime FechaRegistra { get; set; }
        public string UsuarioEdita { get; set; }
        public DateTime? FechaEdita { get; set; }

        public string Distrito { get; set; }
        public string Provincia { get; set; }
        public string Departamento { get; set; }

        public string Telefono { get; set; }

        public string? UsuFacebook { get; set; }
        public string? UsuInstagram { get; set; }
        public string? Teleoperador { get; set; }

        public List<int> Ids { get; set; }
        public List<PreferenteTelefonoEnt> PreferenteTelefono { get; set; }
        public List<PreferenteZonaCorporalEnt> PreferenteZonaCorporal { get; set; }
        public List<PreferenteObservacionDTO> PreferenteObservacion { get; set; }


        public int EsCliente { get; set; }
        public int IdCliente { get; set; }
        public List<string> Observacion { get; set; }

        public string? ClienteNombre { get; set; }
        public string? ClienteApellido { get; set; }
        public string? ClienteCorreo { get; set; }
        public string? ClienteTelefono { get; set; }
        public string? ClienteTelefonoPais { get; set; }

        public int? IdPreferenteAtencion { get; set; }
        public DateTime? FechaPreferenteAtencion { get; set; }
        public string? EstadoPreferenteAtencion { get; set; }

        public string? UtmSource { get; set; }
        public string? UtmMedium { get; set; }
        public string? UtmCampaign { get; set; }
        public string? UtmId { get; set; }
        public string? UtmTerm { get; set; }
        public string? CodAtencion { get; set; }
    }

    public class PreferenteImportarDTO
    {
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string UsuarioRegistra { get; set; }
        public int IdMedioContacto { get; set; }

        public string Observacion { get; set; }
    }
    

    public class PreferenteAsignarListaDTO
    {
        public int IdPreferente { get; set; }
        public int IdUsuarioOperador { get; set; }
        public int IdUsuarioRegistra { get; set; }
    }


    public class PreferenteReporteMedioContactoDTO
    {
        public DateTime Fecha { get; set; }
        public int TotalPreferentes { get; set; }
        public int TotalAsignados { get; set; }
        public int TotalAgendados { get; set; }
        public int TotalEfectivos { get; set; }
        public int TotalEfectivosNuevos { get; set; }
        public int TotalEfectivosAntiguos { get; set; }
        public int? IdMedioContacto { get; set; }
        public string? MedioContacto { get; set; }
    }


    public class PreferenteReporteTotalDTO
    {
        public int TotalPreferentes { get; set; }
        public int TotalAsignados { get; set; }
        public int TotalAgendados { get; set; }
        public int TotalEfectivos { get; set; }
        public int TotalEfectivosNuevos { get; set; }
        public int TotalEfectivosAntiguos { get; set; }
    }


    public class FormularioWebDTO
    {
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Telefono { get; set; }        
        public string Documento { get; set; }
        public List<string> Observacion { get; set; }
    }
    public class FormularioWebLandingDTO
    {
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Telefono { get; set; }
        public string? Correo { get; set; }
        public string Documento { get; set; }
        public string UtmSource { get; set; }
        public string UtmMedium { get; set; }
        public string UtmCampaign { get; set; }
        public string UtmId { get; set; }
        public string UtmTerm { get; set; }
        public string UtmContent { get; set; }
        public string Tag { get; set; }
        public List<string> Observacion { get; set; }
    }

    public class PreferenteAtencionCategoriaDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int IdEstado { get; set; }
    }

    public class PreferenteAtencionOpcionDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int IdCategoria { get; set; }
        public int IdEstado { get; set; }
    }



    public class PreferenteHistoriaDTO
    {
        public int Id { get; set; }
        public int IdPreferente { get; set; }
        public string AsignadoA { get; set; }
        public string AsignadoPor { get; set; }
        public DateTime FechaRegistro { get; set; }
    }

    public class PreferenteReasignarDTO
    {
        public int IdPreferente { get; set; }
        public int AsignadoA { get; set; }
        public int IdUsuario { get; set; }

        public List<PreferenteObservacionDTO> Observaciones { get; set; }
    }


    public class PreferenteHistorialDTO
    {
        public int Id { get; set; }
        public int IdPreferente { get; set; }
        public int IdEstado { get; set; }
        //public int? IdEstadoAtencion { get; set; }
        public int IdUsuarioRegistro { get; set; }
        public int? IdTeleoperador { get; set; }
        public DateTime FechaRegistro { get; set; }
        public List<string> Observacion { get; set; }

        // 

        public string Estado { get; set; }
        public string? EstadoAtencion { get; set; }
        public string? ComentarioAtencion { get; set; }
        public string UsuarioRegistro { get; set; }
        public string? Teleoperador { get; set; }
        public string? DatosModificados { get; set; }
    }


}