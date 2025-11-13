using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace DepilZone.Entidad
{
    public class Respuesta<T>
    {
        public Boolean Exito { get; set; }
        public string Mensaje { get; set; }
        public int ErrorNumero { get; set; }
        public string ErrorDetalle { get; set; }

        public int IdCita { get; set; }
        public int IdServicio { get; set; }
        public int? IdCronograma { get; set; }
        public T Response { get; set; }
    }

    public class GeneralResponse<T>
    {
        public int Status { get; set; } 
        public string Message { get; set; } 
        public T Data { get; set; }
    }

    public class MensajeSignalR
    {
        public Boolean Exito { get; set; }
        public string Mensaje { get; set; }
        public string DatosJSON { get; set; }
        public int IdPerfil { get; set; }
        public TipoAlerta Tipo { get; set; }
    }

    public class EventoSignalR
    {
        public int IdUsuario { get; set; }
        public int IdUsuarioActual { get; set; }
        public TipoEvento Tipo { get; set; }
    }

    public class ResponseTipRepo
    {
        public int Id { get; set; }
        public string DesRepo { get; set; }
        public string ColRepo { get; set; }
    }

    public enum TipoAlerta
    {
        Actividad = 1,
        RespuestaActividad = 2,
        PreferenteAsignado = 3,
        RetornoPreferente = 4,
        ConnectionId = 5,
        ConexionNueva = 6,
        ConexionRechazada = 7,
        ConexionListaUsuario = 8,
        DesconexionUsuario = 9,
        NuevoMensaje = 10,
        CitaReservada = 11,
        ReservaEliminada = 12,
        AvisoGeneral = 13,
        MenuActualizado = 14,
        CerrarSesion = 15,
        ActualizarSistema = 16,
        PreferenteCambioEstado = 17,
        PreferentesAsignados = 18,
        AtendiendoPreferente = 19,
        PreferenteAtendido = 20,
        NuevoPreferente = 21,
        NotificacionDePago = 22,
        CitaPagada = 23
    }

    public enum TipoEvento
    {
        CerrarSesion = 1,
        ActualizarSistema = 2
    }

    public enum TipoComprobante: int
    {
        Factura = 1,
        Ticket = 2,
        Boleta = 3
    }

    public enum EnumTipoDocumento : int { 
        Dni = 1,
        Ruc = 2,
        Varios = 3,
        CarnetExtranjeria = 4,
        Pasaporte = 5
    }

}
