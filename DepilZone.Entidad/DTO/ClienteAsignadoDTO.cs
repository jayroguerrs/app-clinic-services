using System;
using System.Collections.Generic;

namespace DepilZone.Entidad.DTO
{
    public class ClienteAsignadoDTO
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public DateTime FechaCita { get; set; }
        public int IdUsuarioOperador { get; set; }
        public DateTime FechaAsignacion { get; set; }
        public DateTime FechaConfirmacion { get; set; }
        public int IdUsuarioRegistro { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int IdEstado { get; set; }
        public int IdTipo { get; set; }
        public DateTime? FechaEdito { get; set; }

        public string Telefono { get; set; }
        public int? IdEstadoCliente { get; set; }

        // secondary
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string UsuOperador { get; set; }
        public string UsuOperadorNombre { get; set; }
        public string UsuRegistro { get; set; }
        public string UsuRegistroNombre { get; set; }
        public string Estado { get; set; }
        public string EstadoColor { get; set; }
        public string Tipo { get; set; }

        public string TipoCliente { get; set; }
        public string Sede { get; set; }
        public string EstadoCliente { get; set; }
        public string EstadoClienteColor { get; set; }




        public List<ClientAsignadoCitaDTO> Citas { get; set; }
    }


    public class ClienteAsignarDTO
    {
        public int IdCliente { get; set; }
        public DateTime FechaCita { get; set; }
        public int IdUsuarioOperador { get; set; }
        public DateTime FechaConfirmacion { get; set; }
        public int IdUsuarioRegistra { get; set; }
        public int IdTipo { get; set; }
        public int Id { get; set; }
    }

    public class ClienteAsignarListaDTO
    {
        public List<ClienteAsignarDTO> ClientesAsignados { get; set; }
    }


    public class ClienteAsignadoEstadoDTO
    {
        public int Id { get; set; }
        public string Estado { get; set; }
        public string Color { get; set; }
    }

    public class ClientAsignadoCitaDTO { 
        public int IdCita { get; set; }
        public string? Detalle { get; set; }
        public int IdEstado { get; set; }
    }

    public class ClientAsignadoHistoriaDTO
    {
        public int Id { get; set; }
        public int IdClienteAsignado { get; set; }
        public string AsignadoPor { get; set; }
        public string AsignadoA { get; set; }
        public DateTime FechaRegistro { get; set; }
    }

}
