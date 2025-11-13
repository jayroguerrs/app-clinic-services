using System;
using System.Collections.Generic;
using System.Text;

namespace DepilZone.Entidad.DTO
{
    public class CitaDetalleZonaDTO
    {
        public string Descripcion { get; set; }

        public int Id { get; set; }
        public int IdCita { get; set; }
        public int IdZona { get; set; }
        public int Sesion { get; set; }
        public int? IdPromocionPrecio { get; set; }
        public decimal Precio { get; set; }
        //public string HoraInicio { get; set; }
        //public string HoraTermino { get; set; }
        public int? IdUsuarioAgendado { get; set; }
        public string IdUsuarioAgendadoStr {
            get
            {
                string idUsuarioAgendadoStr = "";
                if(IdUsuarioAgendado != null)
                    idUsuarioAgendadoStr = IdUsuarioAgendado.ToString();

                return idUsuarioAgendadoStr;
            }
        }

        public string UsuarioAgendado { get; set; }
        public int Duracion { get; set; }
        public IList<PromocionZonaDTO> Promociones { get; set; }

        public CD_Zona Zona { get; set; }
        public bool RetroTratam { get; set; }
        public bool PagoWeb { get; set; }
        public decimal PrecioDescuento { get; set; }
        public int? IdMedioContactoOrigen { get; set; }

        public bool Estado { get; set; }
        public bool Duplicado { get; set; }
        public string Parametros { get; set; }
        public bool? TratamientoRealizado { get; set; }
        public int? SesionFinal { get; set; }
        public List<ZonaTratamientoDTO> Tratamientos { get; set; }

        public CitaDetalleZonaDTO()
        {
            this.Tratamientos = new List<ZonaTratamientoDTO>();
        }

    }

    public class CD_Zona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }

    public class CitaNoDisponibleDTO
    {
        public int IdCita { get; set; }
        public DateTime FechaCita { get; set; }
        public string HoraInicio{ get; set; }
        public int MinutoInicio { get; set; }
        public string HoraTermino { get; set; }
        public int MinutoTermino { get; set; }
        public int IdUsuario { get; set; }

        /// <summary>
        /// Tipo no disponible
        /// 1: registrada
        /// 2: reservado por otro
        /// 3: reservado por uno
        /// </summary>
        public int TipoNoDisponible { get; set; }
        public string ColorFondo { get; set; }
        public string ColorTexto { get; set; }

    }



    public class CitaNuevoDetalle {
          public int IdCita {get;set;}
          public int IdSede {get;set;}
          public int IdServicio {get;set;}
          public int IdZona {get;set;}
          public string Zona {get;set;}
          public int? IdTecnologia {get;set;}
          public string? Tecnologia {get;set;}
          public int IdPromocionPrecio {get;set;}
          public string Promocion {get;set;}
          public int Sesion {get;set;}
          public decimal Precio {get;set;}
          public int Duracion {get;set;}
          public int? IdAgendadoPor {get;set;}
          public string ?AgendadoPor {get;set;}
          public int? IdOrigenMedio {get;set;}
          public string? OrigenMedio {get;set;}
          public bool Retroceso { get;set;}
          public bool PagoWeb {get;set;}
          public int IdUsuarioModifico {get;set;}
    }

}
