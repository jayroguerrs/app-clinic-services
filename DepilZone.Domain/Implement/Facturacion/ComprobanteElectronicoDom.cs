
using DepilZone.Data.Interface.Facturacion;
using DepilZone.Entidad.DTO.Facturacion;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace DepilZone.Domain.Implement
{
    public class ComprobanteElectronicoDom: IComprobanteElectronicoDom
	{
		private readonly IComprobanteElectronicoDat _IComprobanteElectronicoDat;
		public ComprobanteElectronicoDom(IComprobanteElectronicoDat IComprobanteElectronicoDat)
		{
			this._IComprobanteElectronicoDat = IComprobanteElectronicoDat;
		}
        public async Task<ComprobanteElectronicoDTO> RegistrarVentaComprobante(ComprobanteElectronicoDTO model, int idCita)
        {

            return await _IComprobanteElectronicoDat.RegistrarVentaComprobante(model, idCita);
        }
        public async Task<ComprobanteElectronicoDTO> EmitirComprobante(ComprobanteElectronicoDTO model, int idCita) 
		{ 

            return await _IComprobanteElectronicoDat.EmitirComprobante(model, idCita);
        }
        public async Task<List<ComprobanteElectronicoReporteDTO>> ObtenerReporte(int IdUsuario, int idSede, int idTipoDocumento, DateTime fechaDesde, DateTime fechaHasta)
        {

            return await _IComprobanteElectronicoDat.ObtenerReporte( IdUsuario,  idSede,  idTipoDocumento,  fechaDesde,  fechaHasta);
        }

        public async Task<List<ComprobanteElectronicoReporteVentaDTO>> ObtenerReporteVenta(int IdUsuario, int idSede, int idTipoDocumento, DateTime fechaDesde, DateTime fechaHasta)
        {

            return await _IComprobanteElectronicoDat.ObtenerReporteVenta(IdUsuario, idSede, idTipoDocumento, fechaDesde, fechaHasta);
        }

        public async Task<List<ComprobanteElectronicoReporteVentaClienteDTO>> ObtenerReporteVentaCliente(int IdUsuario,  DateTime fechaDesde, DateTime fechaHasta)
        {

            return await _IComprobanteElectronicoDat.ObtenerReporteVentaCliente(IdUsuario,  fechaDesde, fechaHasta);
        }

        public async Task<List<ComprobanteElectronicoReporteVentaProductoDTO>> ObtenerReporteVentaProducto(int IdUsuario, DateTime fechaDesde, DateTime fechaHasta, int idUnidadMedida)
        {

            return await _IComprobanteElectronicoDat.ObtenerReporteVentaProducto(IdUsuario, fechaDesde, fechaHasta, idUnidadMedida);
        }

        public async Task<List<ComprobanteElectronicoReportePagoDTO>> ObtenerReportePago(int IdUsuario, int idSede, int idTipoDocumento, DateTime fechaDesde, DateTime fechaHasta)
        {

            return await _IComprobanteElectronicoDat.ObtenerReportePago(IdUsuario, idSede, idTipoDocumento, fechaDesde, fechaHasta);
        }

        public async Task<ComprobanteElectronicoConsultaDTO> ActualizarEstadoSunat(ComprobanteElectronicoDTO model)
        {
            return await _IComprobanteElectronicoDat.ActualizarEstadoSunat(model);
        }

        public async Task<ComprobanteElectronicoAnulacionDTO> ActualizarAnuladoSunat(ComprobanteElectronicoAnulacionDTO model)
        {
            return await _IComprobanteElectronicoDat.ActualizarAnuladoSunat(model);
        }

        public async Task<bool> AnularComprobanteSunat(ComprobanteElectronicoAnularDTO model)
        {
            return await _IComprobanteElectronicoDat.AnularComprobanteSunat(model);
        }

        public async Task<ComprobanteElectronicoDTO> BuscarComprobante(string serie, int numero, int idTipoComprobante)
        {
            return await _IComprobanteElectronicoDat.BuscarComprobante(serie, numero, idTipoComprobante);
        }

        public async Task<int> BuscarComprobanteModifica(string serie, int numero)
        {
            return await _IComprobanteElectronicoDat.BuscarComprobanteModifica(serie, numero);
        }

       
        public async Task<ComprobanteElectronicoDTO> EmitirNotaCredito(ComprobanteElectronicoDTO model)
        {
            return await _IComprobanteElectronicoDat.EmitirNotaCredito(model);
        }

        public async Task<List<ComprobanteElectronicoDTO>> ObtenerNotasCredito(DateTime fechaDesde, DateTime fechaHasta, int idTipoComprobante, int idSede)
        {
            return await _IComprobanteElectronicoDat.ObtenerNotasCredito(fechaDesde, fechaHasta, idTipoComprobante, idSede);
        }


        public async Task<string> VerPdf(int idUsuario, int idComprobante, int idTipoComprobante, string serie, int numero)
        {
            return await _IComprobanteElectronicoDat.VerPdf( idUsuario,  idComprobante, idTipoComprobante,  serie,  numero);
        }
    }
}
