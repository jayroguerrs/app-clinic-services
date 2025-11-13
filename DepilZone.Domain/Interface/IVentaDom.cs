using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Data.Interface
{
	public interface IVentaDom
	{
		Task<UltimaSerieDTO> ObtenerNumeroSerie(int idTipoComprobante, int idSede);
		Task<IEnumerable<TipoPagoEnt>> ObtenerTipoPago();
		Task<Respuesta<VentaEnt>> Insertar(VentaEnt model);
		Task<Respuesta<CitaEnt>> ActualizarCitaPagada(VentaEnt model);
		Task<IEnumerable<VentaTicketDTO>> ObtenerTickets(int idSede, DateTime fechaInicio, DateTime fechaTermino);
		Task<Respuesta<VentaEnt>> AnularVentaTicket(int idVenta, int idUsuarioModifica);




		Task<IEnumerable<DetalleCitaFacturacionEnt>> Obtenerdetallecita(int idcita);
		Task<IEnumerable<AperturaEnd>> Validacionsedeusuariocita(int idusuario, int idcita);
		Task<IEnumerable<DetalleventaEnt>> Obtenerdetallefactura();
		Task<IEnumerable<DetalleventaEnt>> Obtenerdetallefacturaid(int idventa);
		Task<IEnumerable<VentaEnt>> Obtenerventaporid(int idventa);
		Task<IEnumerable<VentaEnt>> Obtenerventaporidnumerodocumento(string NumeroDocumento);

		Task<IEnumerable<VentaEnt>> Obtenerventaporidcita(int idcita);
		Task<IEnumerable<ReenvioDTO>> reenvio(string Documento, int tipooper, string fecha);

		Task<List<VentaDTO>> ObtenerVentasTotales(DateTime fechaInicio, DateTime fechaFin, int idSede, int idGenero, int numeroSesion);


		Task<List<VentaPotencialDTO>> ReportePotencialVenta(DateTime fechaInicio, DateTime fechaFin, int idSede, int idServicio);



	
	}
}
