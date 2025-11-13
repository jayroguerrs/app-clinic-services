using System;
using System.Collections.Generic;
using System.Text;

namespace DepilZone.Entidad.DTO
{
    public class PreferenteGrillaDTO
    {
        public int Id { get; set; }
        public string X { get; set; }
        public string Nombres { get; set; }
        public string Teleoperadora { get; set; }
        public string NombreTeleoperador { get; set; }
        public string? Comentario { get; set; }
        //public string Observacion { get; set; }
        public DateTime FechaRegistra { get; set; }
        public string FechaAsignacion { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string Distrito { get; set; }
        public string ZonaCorporal { get; set; }
        public string MedioContacto { get; set; }
        public string? MedioContactoCierre { get; set; }
        public int IdEstado { get; set; }
        public string EstadoAtencion { get; set; }
        public string? Promocion { get; set; }
        public int EsCliente { get; set; }
        public int IdCliente { get; set; }
        public List<string> Observacion { get; set; }



        public string? UsuFacebook { get; set; }
        public string? UsuInstagram { get; set; }




        public string? UtmSource { get; set; }
        public string? UtmMedium { get; set; }
        public string? UtmCampaign { get; set; }
        public string? UtmId { get; set; }
        public string? UtmTerm { get; set; }
        public string? UtmCont { get; set; }


        public string? UsuarioRegistro { get; set; }


        public string? AtencionCategoria { get; set; }
        public string? AtencionOpcion { get; set; }

        public DateTime? Agendo { get; set; }


    }

    public class PreferenteMobileGrillaDTO
    {
        public string Nombre { get; set; }
        public string Celular1 { get; set; }
        public string Celular2 { get; set; }
        public string HoraInicio { get; set; }
        public string FechaCita { get; set; }
        public string Estado { get; set; }
        public string Dni { get; set; }
        public bool PagoRealizado { get; set; }
        public string Servicio { get; set; }
        public int IdCita { get; set; }
        public string NombreTratamiento { get; set; }

    }

    public class PreferenteMobileResponseDTO
    {
        public int EstadoId { get; set; }
        public int IdCita { get; set; }
    }

    public class BuscarPreferenteDTO
    {
        public int DateTipo { get; set; }
        public DateTime? FechaDesde { get; set; }
        public DateTime? FechaHasta { get; set; }
        public int Tipo { get; set; }
        public string Usuario { get; set; }
    }
}
