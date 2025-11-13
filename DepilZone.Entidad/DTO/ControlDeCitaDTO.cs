using System;
using System.Collections.Generic;

namespace DepilZone.Entidad.DTO
{
    public class ControlDeCitaDTO
    {
        public string FechaCita { get; set; }

    }

    public class ControlDeCitasByUserResponseDTO
    {
        public IList<ControlDeCitasByUserDTO> Citas { get; set; }
        public int Total { get; set; }
        public decimal MontoTotal { get; set; }
        public decimal PorcentajeSobreMontoTotal { get; set; }

        public decimal MontoPrimeraComisionTotal { get; set; }
        public decimal PorcentajeSobreMontoPrimeraComisionTotal { get; set; }
        public decimal MontoSegundaComisionTotal { get; set; }
        public decimal PorcentajeSobreMontoSegundaComisionTotal { get; set; }
        public decimal MontoTercerComisionTotal { get; set; }
        public decimal PorcentajeSobreMontoTercerComisionTotal { get; set; }
    }


    public class ControlDeCitasByUserDTO
    {
        public string FechaCita { get; set; }
        public int IdCita { get; set; }
        public string Paciente { get; set; }
        public string ClienteNuevo { get; set; }
        public string Celular { get; set; }
        public decimal Total { get; set; }
        public string NombreSede { get; set; }
        public string Estado { get; set; }
        public string MedioDeContacto { get; set; }
        public decimal PagoFinal { get; set; }
        public decimal ?PrecioDePagoFinal { get; set; }
        public int IdCliente { get; set; }
        public int IdPreferente { get; set; }
        public int IdServicio { get; set; }
        public bool Abonado { get; set; }
        public int Id { get; set; }
        public bool Habilitado { get; set; }
        public string FechaPagado { get; set; }
        public IList<ControlDeCitasByUserDTO> Children { get; set; }
        public int IdTipoComision { get; set; }
        public int SesionInicial { get; set; }
        public int SesionFinal { get; set; }
        public bool Notificado { get; set; }
        public int IdSede { get; set; }
        public string TipoCita { get; set; }
        public int IdTipoCita { get; set; }
        public string EstadoCliente { get; set; }
        public string UsuarioRegistra { get; set; }

}

    public class ControlDeCitasByUserExcelDTO
    {
        public string FechaCita { get; set; }
        public int IdCita { get; set; }
        public string Paciente { get; set; }
        public string ClienteNuevo { get; set; }
        public string Celular { get; set; }
        public decimal Total { get; set; }
        public string NombreSede { get; set; }
        public string Estado { get; set; }
        public string MedioDeContacto { get; set; }
        public decimal? PrecioDePagoFinal { get; set; }
        public string TipoCita { get; set; }
        public string EstadoCliente { get; set; }
        public string UsuarioRegistra { get; set; }

    }

    public class UpdateFinalPaymentDTO
    {
        public int IdCita { get; set; }
        public decimal PrecioDePagoFinal { get; set; }
    }

    public class totalNotificaionPorSede
    {
        public int CantidadSurco { get; set; }
        public int CantidadMegaplaza { get; set; }
        public int CantidadPueblolibre { get; set; }
        public int IdSedeNotifiacion { get; set; }
    }

    public class Notificacion
    {
        public string NombreOperador { get; set; }
        public int IdCita { get; set; }
        public string CelularCliente { get; set; }
        public string FechaCita { get; set; }
        public int IdNotificacion { get; set; }
    }
}
