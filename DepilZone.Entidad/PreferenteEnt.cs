using System;
using System.Collections.Generic;
using System.Text;

namespace DepilZone.Entidad
{
    public class PreferenteEnt
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }
        public string? Promocion { get; set; }
        public int IdEstadoPadre { get; set; }
        public int IdEstado { get; set; }
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
        public  int IdEstadoAtencion { get; set; }
        public string Comentario { get; set; }
        public string? UsuFacebook { get; set; }
        public string? UsuInstagram { get; set; }
        public string? UtmSource { get; set; }
        public string? UtmMedium { get; set; }
        public string? UtmCampaign { get; set; }
        public string? UtmId { get; set; }
        public string? UtmTerm { get; set; }
        public string? CodAtencion { get; set; }
        public List<PreferenteTelefonoEnt> PreferenteTelefono { get; set; }
        public List<PreferenteZonaCorporalEnt> PreferenteZonaCorporal { get; set; }
        public List<PreferenteObservacionEnt> PreferenteObservacion { get; set; }

        public int EsCliente { get; set; }
        public int IdCliente { get; set; }

        public int IdAtencionCategoria { get; set; }
        public int IdAtencionOpcion { get; set; }

        public string AtencionCategoria { get; set; }
        public string AtencionOpcion { get; set; }

        public int IdUsuarioRegistro { get; set; }
        public int IdUsuarioModifico { get; set; }
    }
}
