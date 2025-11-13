using DepilZone.Application.Interface;
using DepilZone.Data.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement
{
    public class VentaApp : IVentaApp
    {
        private readonly IVentaDom _IVentaDom;
        public VentaApp(IVentaDom IFacturacionDom)
        {
            this._IVentaDom = IFacturacionDom;
        }


        public async Task<UltimaSerieDTO> ObtenerNumeroSerie(int idTipoComprobante, int idSede)
        {
            return await _IVentaDom.ObtenerNumeroSerie(idTipoComprobante, idSede);
        }
        public async Task<IEnumerable<TipoPagoEnt>> ObtenerTipoPago()
        {
            return await _IVentaDom.ObtenerTipoPago();
        }
        public async Task<Respuesta<VentaEnt>> Insertar(VentaEnt model)
        {
            return await _IVentaDom.Insertar(model);
        }
        public async Task<Respuesta<CitaEnt>> ActualizarCitaPagada(VentaEnt model)
        {
            return await _IVentaDom.ActualizarCitaPagada(model);
        }
        public async Task<IEnumerable<VentaTicketDTO>> ObtenerTickets(int idSede, DateTime fechaInicio, DateTime fechaTermino)
        {
            return await _IVentaDom.ObtenerTickets(idSede, fechaInicio, fechaTermino);
        }
        public async Task<Respuesta<VentaEnt>> AnularVentaTicket(int idVenta, int idUsuarioModifica)
        {
            return await _IVentaDom.AnularVentaTicket(idVenta, idUsuarioModifica);
        }







        public async Task<IEnumerable<DetalleventaEnt>> Obtenerdetallefactura()
        {
            return await _IVentaDom.Obtenerdetallefactura();
        }
        public async Task<IEnumerable<DetalleventaEnt>> Obtenerdetallefacturaid(int idventa)
        {
            return await _IVentaDom.Obtenerdetallefacturaid(idventa);
        }
        public async Task<IEnumerable<DetalleCitaFacturacionEnt>> Obtenerdetallecita(int idcita)
        {
            return await _IVentaDom.Obtenerdetallecita(idcita);
        }
        public async Task<IEnumerable<AperturaEnd>> Validacionsedeusuariocita(int idusuario, int idcita)
        {
            return await _IVentaDom.Validacionsedeusuariocita(idusuario, idcita);
        }
        public async Task<IEnumerable<ReenvioDTO>> reenvio(string Documento, int tipooper, string fecha)
        {
            return await _IVentaDom.reenvio(Documento, tipooper, fecha);
        }
        public async Task<IEnumerable<VentaEnt>> Obtenerventaporid(int idventa)
        {
            return await _IVentaDom.Obtenerventaporid(idventa);
        }
        public async Task<IEnumerable<VentaEnt>> Obtenerventaporidnumerodocumento(string NumeroDocumento)
        {
            return await _IVentaDom.Obtenerventaporidnumerodocumento(NumeroDocumento);
        }
    
        public async Task<IEnumerable<VentaEnt>> Obtenerventaporidcita(int idcita)
        {
            return await _IVentaDom.Obtenerventaporidcita(idcita);
        }

        public async Task<List<VentaDTO>> ObtenerVentasTotales(DateTime fechaInicio, DateTime fechaFin, int idSede, int idGenero, int numeroSesion)
        {
            return await _IVentaDom.ObtenerVentasTotales( fechaInicio,  fechaFin,  idSede, idGenero, numeroSesion);
        }

        public async Task<List<VentaPotencialDTO>> ReportePotencialVenta(DateTime fechaInicio, DateTime fechaFin, int idSede, int idServicio)
        {
            return await _IVentaDom.ReportePotencialVenta(fechaInicio, fechaFin, idSede, idServicio);
        }

       


    }
}
