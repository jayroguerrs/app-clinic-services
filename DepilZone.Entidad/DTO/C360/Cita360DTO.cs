using System;
using System.Collections.Generic;
using System.Text;

namespace DepilZone.Entidad.DTO.C360
{
    public class Cita360DTO
    {
        public int IdCita { get; set; }
        public int IdTipoCita { get; set; }
        #nullable enable
        public int? IdCronograma { get; set; }
        public int IdCliente { get; set; }
        public int IdTipoCliente { get; set; }
        public int IdUsuario { get; set; }
        public int IdMaquina { get; set; }
        public int IdMedioContacto { get; set; }
        public int IdSede { get; set; }
        public int IdEstado { get; set; }
        public DateTime FechaCita { get; set; }
        #nullable disable
        public string HoraInicio { get; set; }
        public string HoraTermino { get; set; }
        public decimal Total { get; set; }
        public string UsuarioRegistra { get; set; }
        public int IdDescuento { get; set; }
        public string DescuentoAplicaA { get; set; }
        #nullable enable
        public string? CuponDescuento { get; set; }
        #nullable enable
        public int? IdServicio { get; set; }
        #nullable disable
        public List<Cita360DetallesDTO> Detalles { get; set; }
        public List<Cita360MensajeAvisosDTO> MensajeAvisos { get; set; }
        public List<Cita360MensajeDetallesDTO> MensajeDetalles { get; set; }
        public List<Cita360MensajeNotasDTO> MensajeNotas { get; set; }
        public int NumeroBox { get; set; }
        public int? IdMaquinaMarca { get; set; }



        // secondary


        public string? AtendidoPor { get; set; }
        #nullable enable
        public string? Servicio { get; set; }
        #nullable enable
        public string? ServicioColor { get; set; }
        #nullable enable
        public string? Maquina { get; set; }
        #nullable enable
        public string? Sede { get; set; }
        #nullable enable
        public string? TipoCita { get; set; }
        public int IdPreferente { get; set; }

    }

    public class Cita360DTOAtender
    {
        public int IdCita { get; set; }
        public int IdUsuario { get; set; }
        public int IdUsuarioAtendidoPor { get; set; }
        public int IdMaquina { get; set; }
        public int NumeroBox { get; set; }
        public int? IdMaquinaMarca { get; set; }
    }

        public class Cita360DetallesDTO
    {
        public int Id { get; set; }
        public int IdCita { get; set; }
        public int IdZona { get; set; }
        public int Sesion { get; set; }
        public decimal Precio { get; set; }
        #nullable enable
        public int? IdUsuarioAgendado { get; set; }
        public int IdPromocionPrecio { get; set; }
        public int IdPromocion { get; set; }
        #nullable enable
        public int? IdTecnologia { get; set; }
        public int Minutos { get; set; }
        public decimal PrecioDescuento { get; set; }

        // secondary
        #nullable enable
        public string? Tecnologia { get; set; }
        #nullable enable
        public string? TecnologiaNombreCorto { get; set; }
        public string Zona { get; set; }
        #nullable enable
        public string? Promocion { get; set; }
        #nullable enable
        public string? UsuarioAgendado { get; set; }
        #nullable enable
        public int? IdMedioContactoOrigen { get; set; }
    }

    public class Cita360MensajeAvisosDTO
    {
        public int Id { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int IdUsuarioRegistro { get; set; }
#nullable disable
        public string Texto { get; set; }
        public Boolean Destacado { get; set; }
    }
    public class Cita360MensajeDetallesDTO
    {
        public int Id { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int IdUsuarioRegistro { get; set; }
        public string Texto { get; set; }
        public Boolean Destacado { get; set; }
        public string UsuarioRegistro { get; set; }
    }
    public class Cita360MensajeNotasDTO
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int IdUsuarioRegistro { get; set; }
        public string Texto { get; set; }
        public Boolean Destacado { get; set; }
        public string UsuarioRegistro { get; set; }
    }

    public class Cita360SeguimientoDTO
    {
        public int Id { get; set; }
        public int IdCita { get; set; }
        public int IdCitaSeguimientoConcepto { get; set; }
        public string Descripcion { get; set; }
        public int IdUsuarioRegistro { get; set; }
        public DateTime FechaRegistro { get; set; }
#nullable disable
        public string? ValorAnterior { get; set; }
#nullable disable
        public string? ValorActual { get; set; }



        // secondary
        public DateTime FechaCita {get;set;}
        public string UsuarioRegistro { get; set; }
        public string Detalle { get; set; }
    }

}
