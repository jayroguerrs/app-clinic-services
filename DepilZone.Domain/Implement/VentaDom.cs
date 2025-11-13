using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DepilZone.Data;
using DepilZone.Data.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
namespace DepilZone.Domain.Implement
{
	public class VentaDom : IVentaDom
	{
		private readonly IVentaDat _IVentaDat;
		public VentaDom(IVentaDat IFacturacionDat)
		{
			this._IVentaDat = IFacturacionDat;
		}


		public async Task<UltimaSerieDTO> ObtenerNumeroSerie(int idTipoDocumento, int idcita)
		{
			return await _IVentaDat.ObtenerNumeroSerie(idTipoDocumento, idcita);
		}
		public async Task<IEnumerable<TipoPagoEnt>> ObtenerTipoPago()
		{
			return await _IVentaDat.ObtenerTipoPago();
		}
		public async Task<Respuesta<VentaEnt>> Insertar(VentaEnt model)
		{
			return await _IVentaDat.Insertar(model);
		}
		public async Task<Respuesta<CitaEnt>> ActualizarCitaPagada(VentaEnt model)
		{
			return await _IVentaDat.ActualizarCitaPagada(model);
		}
		public async Task<IEnumerable<VentaTicketDTO>> ObtenerTickets(int idSede, DateTime fechaInicio, DateTime fechaTermino)
		{
			return await _IVentaDat.ObtenerTickets(idSede, fechaInicio, fechaTermino);
		}
		public async Task<Respuesta<VentaEnt>> AnularVentaTicket(int idVenta, int idUsuarioModifica)
		{
			return await _IVentaDat.AnularVentaTicket(idVenta, idUsuarioModifica);
		}





		public async Task<IEnumerable<DetalleventaEnt>> Obtenerdetallefactura()
		{
			return await _IVentaDat.Obtenerdetallefactura();
		}
		public async Task<IEnumerable<DetalleventaEnt>> Obtenerdetallefacturaid(int idventa)
		{
			return await _IVentaDat.Obtenerdetallefacturaid(idventa);
		}
		public async Task<IEnumerable<VentaEnt>> Obtenerventaporidnumerodocumento(string NumeroDocumento)
		{
			return await _IVentaDat.Obtenerventaporidnumerodocumento(NumeroDocumento);
		}
		public async Task<IEnumerable<AperturaEnd>> Validacionsedeusuariocita(int idusuario, int idcita)
		{
			return await _IVentaDat.Validacionsedeusuariocita(idusuario, idcita);
		}
		public async Task<IEnumerable<VentaEnt>> Obtenerventaporidcita(int idcita)
		{
			return await _IVentaDat.Obtenerventaporidcita(idcita);
		}
		public async Task<IEnumerable<DetalleCitaFacturacionEnt>> Obtenerdetallecita(int idcita)
		{
			return await _IVentaDat.Obtenerdetallecita(idcita);
		}
		public async Task<IEnumerable<VentaEnt>> Obtenerventaporid(int idventa)
		{
			return await _IVentaDat.Obtenerventaporid(idventa);
		}
		public async Task<IEnumerable<ReenvioDTO>> reenvio(string Documento, int tipooper, string fecha)
		{
			return await _IVentaDat.reenvio(Documento, tipooper, fecha);
		}

		public async Task<List<VentaDTO>> ObtenerVentasTotales(DateTime fechaInicio, DateTime fechaFin, int idSede, int idGenero, int numeroSesion)
		{
			return await _IVentaDat.ObtenerVentasTotales(fechaInicio, fechaFin, idSede, idGenero, numeroSesion);
		}

		public async Task<List<VentaPotencialDTO>> ReportePotencialVenta(DateTime fechaInicio, DateTime fechaFin, int idSede, int idServicio)
		{
			return await _IVentaDat.ReportePotencialVenta(fechaInicio, fechaFin, idSede, idServicio);
		}

		
	}
}
