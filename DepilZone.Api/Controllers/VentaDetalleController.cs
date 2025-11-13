using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DepilZone.Api.CustomFilter;
using DepilZone.Application.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DepilZone.Api.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
    [Authorize]
    public class VentaDetalleController : Controller
	{
		private readonly IVentaApp _VentaApp;
		public VentaDetalleController(IVentaApp IVentaApp)
		{
			this._VentaApp = IVentaApp;
		}
		[HttpGet("numeroSerie/{idTipoComprobante},{idSede}")]
		[CustomFilter("000496")]
		public async Task<UltimaSerieDTO> ObtenerNumeroSerie(int idTipoComprobante, int idSede)
		{
			return await _VentaApp.ObtenerNumeroSerie(idTipoComprobante, idSede);
		}
		[HttpGet("tipoPago")]
		[CustomFilter("000497")]
		public async Task<IEnumerable<TipoPagoEnt>> ObtenerTipoPago()
		{
			return await _VentaApp.ObtenerTipoPago();
		}
		[HttpPost]
        [CustomFilter("000498")]
		public async Task<Respuesta<VentaEnt>> Post(VentaEnt model)
		{
			return await _VentaApp.Insertar(model);
		}	
		[HttpGet("detallefactura/")]
        [CustomFilter("000499")]
		public async Task<IEnumerable<DetalleventaEnt>> Obtenerdetallefactura()
		{
			return await _VentaApp.Obtenerdetallefactura();
		}
		[HttpGet("detallefacturaid/{idventa}")]
        [CustomFilter("000500")]
		public async Task<IEnumerable<DetalleventaEnt>> Obtenerdetallefacturaid(int idventa)
		{
			return await _VentaApp.Obtenerdetallefacturaid(idventa);
		}
		[HttpGet("detallecita/{idcita}")]
        [CustomFilter("000501")]
		public async Task<IEnumerable<DetalleCitaFacturacionEnt>> Obtenerdetallecita(int IdCita)
		{
			return await _VentaApp.Obtenerdetallecita(IdCita);
		}
		//[HttpGet("anularticket/{Documento}")]
		//public async Task<IEnumerable<FactuaEliminaEnt>> AnularTicket(string Documento)
		//{
		//	return await _VentaApp.AnularTicket(Documento);
		//}
		[HttpGet("reenvio/{Documento},{tipooper},{fecha}")]
        [CustomFilter("000502")]
		public async Task<IEnumerable<ReenvioDTO>> reenvio(string Documento,int tipooper,string fecha)
		{
			return await _VentaApp.reenvio(Documento, tipooper, fecha);
		}
		[HttpGet("venta/{idventa}")]
		[CustomFilter("000503")]
		public async Task<IEnumerable<VentaEnt>> Obtenerventaporid(int idventa)
		{
			return await _VentaApp.Obtenerventaporid(idventa);
		}
		[HttpGet("numerodocumento/{NumeroDocumento}")]
        [CustomFilter("000504")]
		public async Task<IEnumerable<VentaEnt>> Obtenerventaporidnumerodocumento(string NumeroDocumento)
		{
			return await _VentaApp.Obtenerventaporidnumerodocumento(NumeroDocumento);
		}
		[HttpGet("ventaporcita/{idcita}")]
        [CustomFilter("000505")]
		public async Task<IEnumerable<VentaEnt>> Obtenerventaporidcita(int idcita)
		{
			return await _VentaApp.Obtenerventaporidcita(idcita);
		}
		[HttpGet("validacionsedeusuariocita/{idusuario}/{idcita}")]
        [CustomFilter("000506")]
		public async Task<IEnumerable<AperturaEnd>> Validacionsedeusuariocita(int idusuario, int idcita)
		{
			return await _VentaApp.Validacionsedeusuariocita(idusuario,idcita);
		}
	}
}
