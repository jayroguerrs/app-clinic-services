using System;
using System.Collections.Generic;
using System.Text;

namespace DepilZone.Entidad.DTO
{
    public class CajaCuadreDTO
    {
        
        public List<CajaDiarioDTO> Aperturas { get; set; }
        public List<CajaCuadreTipoPagoDTO> Cuadres { get; set; }

    }


    public class CajaSeguimientoDiarioDTO
    {

        public List<CajaEntidadDTO> Cajas { get; set; }
        public List<CajaTipoPagoDTO> Ingresos { get; set; }

    }

    public class CajaEntidadDTO
    {

        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Total { get; set; }

    }

    public class CajaTipoPagoDTO
    {

        public int IdCaja { get; set; }
        public int IdTipoPago { get; set; }
        public string TipoPago { get; set; }
        public decimal Total { get; set; }
        public decimal PagoEfectivo { get; set; }
        public decimal PagoTarjeta { get; set; }

    }

    public class CajaDiarioDTO
    {
        public int Id { get; set; }
        public int IdCaja { get; set; }
        public DateTime FechaHoraApertura { get; set; }
        public DateTime? FechaHoraCierre { get; set; }
        public Decimal SaldoInicial { get; set; }
        public int IdUsuarioApertura { get; set; }
        public Decimal SaldoCierre { get; set; }
        public int IdUsuarioCierre { get; set; }
        public int Turno { get; set; }
        public string UsuarioApertura { get; set; }
        public string? UsuarioCierre { get; set; }
    }


    public class CajaCuadreTipoPagoDTO { 
        public int IdTipoPago { get; set; }
        public string TipoPago { get; set; }
        public decimal Total { get; set; }
        public decimal PagoEfectivo { get; set; }
        public decimal PagoTarjeta { get; set; }
        public int Turno { get; set; }
    }

    public class CajaCuadreTurnoDTO
    { 
        public int IdCajaDiario { get; set; }
        public int IdCaja { get; set; }
        public DateTime FechaHoraApertura { get; set; }
        public DateTime? FechaHoraCierre { get; set; }
        public decimal SaldoInicial { get; set; }
        public decimal? SaldoFinal { get; set; }
        public int Turno { get; set; }



        public int IdTipoPago { get; set; }
        public string TipoPago { get; set; }
        public decimal Total { get; set; }
       
        public decimal VentaTotal { get; set; }

        public decimal Efectivo { get; set; }
        public decimal TarjetaCredito { get; set; }
        public decimal Deposito { get; set; }
        public decimal Web { get; set; }
        public decimal Mixto { get; set; }
        public decimal MixtoEfectivo { get; set; }
        public decimal MixtoTarjetaCredito { get; set; }



    }
}
