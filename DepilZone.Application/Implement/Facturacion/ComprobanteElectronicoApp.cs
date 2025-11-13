
using DepilZone.Application.Interface.Facturacion;
using DepilZone.Data.Interface.Facturacion;
using DepilZone.Domain.Implement;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO.Facturacion;
using System;
using System.Collections.Generic;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement.Facturacion
{
	public class ComprobanteElectronicoApp : IComprobanteElectronicoApp
	{
		private readonly IComprobanteElectronicoDom _IComprobanteElectronicoDom;
        public ComprobanteElectronicoApp(IComprobanteElectronicoDom IComprobanteElectronicoDom)
        {
            this._IComprobanteElectronicoDom = IComprobanteElectronicoDom;
        }


        public async Task<ComprobanteElectronicoDTO> RegistrarVentaComprobante(ComprobanteElectronicoDTO model, int idCita)
        {
            ComprobanteElectronicoDTO output = await _IComprobanteElectronicoDom.RegistrarVentaComprobante(model, idCita);

            using (WebClient client = new WebClient())
            {
                var bytes = client.DownloadData(output.SunatUrlPdf);
                output.BoletaPdfBase64 = Convert.ToBase64String(bytes);
            }

            return output;
        }

        public async Task<ComprobanteElectronicoDTO> EmitirComprobante(ComprobanteElectronicoDTO model, int idCita)
        {
            ComprobanteElectronicoDTO output = await _IComprobanteElectronicoDom.EmitirComprobante(model, idCita);

            using (WebClient client = new WebClient())
            {
                var bytes = client.DownloadData(output.SunatUrlPdf);
                output.BoletaPdfBase64 = Convert.ToBase64String(bytes);
            }

            return output;
        }

        public async Task<List<ComprobanteElectronicoReporteDTO>> ObtenerReporte(int IdUsuario, int idSede, int idTipoDocumento, DateTime fechaDesde, DateTime fechaHasta)
        {
            return await _IComprobanteElectronicoDom.ObtenerReporte( IdUsuario,  idSede,  idTipoDocumento,  fechaDesde,  fechaHasta);
        }

        public async Task<List<ComprobanteElectronicoReporteVentaDTO>> ObtenerReporteVenta(int IdUsuario, int idSede, int idTipoDocumento, DateTime fechaDesde, DateTime fechaHasta)
        {
            return await _IComprobanteElectronicoDom.ObtenerReporteVenta(IdUsuario, idSede, idTipoDocumento, fechaDesde, fechaHasta);
        }

        public async Task<List<ComprobanteElectronicoReporteVentaClienteDTO>> ObtenerReporteVentaCliente(int IdUsuario, DateTime fechaDesde, DateTime fechaHasta)
        {
            return await _IComprobanteElectronicoDom.ObtenerReporteVentaCliente(IdUsuario, fechaDesde, fechaHasta);
        }

        public async Task<List<ComprobanteElectronicoReporteVentaProductoDTO>> ObtenerReporteVentaProducto(int IdUsuario, DateTime fechaDesde, DateTime fechaHasta, int idUnidadMedida)
        {
            return await _IComprobanteElectronicoDom.ObtenerReporteVentaProducto(IdUsuario, fechaDesde, fechaHasta, idUnidadMedida);
        }

        public async Task<List<ComprobanteElectronicoReportePagoDTO>> ObtenerReportePago(int IdUsuario, int idSede, int idTipoDocumento, DateTime fechaDesde, DateTime fechaHasta)
        {
            return await _IComprobanteElectronicoDom.ObtenerReportePago(IdUsuario, idSede, idTipoDocumento, fechaDesde, fechaHasta);
        }

        public async Task<ComprobanteElectronicoConsultaDTO> ActualizarEstadoSunat(ComprobanteElectronicoDTO model)
        {
            return await _IComprobanteElectronicoDom.ActualizarEstadoSunat(model);
        }

        public async Task<ComprobanteElectronicoAnulacionDTO> ActualizarAnuladoSunat(ComprobanteElectronicoAnulacionDTO model)
        {
            return await _IComprobanteElectronicoDom.ActualizarAnuladoSunat(model);
        }


        public async Task<bool> AnularComprobanteSunat(ComprobanteElectronicoAnularDTO model)
        {
            return await _IComprobanteElectronicoDom.AnularComprobanteSunat(model);
        }

        public async Task<ComprobanteElectronicoDTO> BuscarComprobante(string serie, int numero, int idTipoComprobante)
        {
            return await _IComprobanteElectronicoDom.BuscarComprobante(serie, numero, idTipoComprobante);
        }



        public async Task<int> BuscarComprobanteModifica(string serie, int numero)
        {
            return await _IComprobanteElectronicoDom.BuscarComprobanteModifica(serie, numero);
        }


        public async Task<ComprobanteElectronicoDTO> EmitirNotaCredito(ComprobanteElectronicoDTO model)
        {
            return await _IComprobanteElectronicoDom.EmitirNotaCredito(model);
        }

        public async Task<List<ComprobanteElectronicoDTO>> ObtenerNotasCredito(DateTime fechaDesde, DateTime fechaHasta, int idTipoComprobante, int idSede)
        {
            return await _IComprobanteElectronicoDom.ObtenerNotasCredito(fechaDesde, fechaHasta, idTipoComprobante, idSede);
        }


        public async Task<string> VerPdf(int idUsuario, int idComprobante, int idTipoComprobante, string serie, int numero)
        {
            return await _IComprobanteElectronicoDom.VerPdf( idUsuario,  idComprobante, idTipoComprobante,  serie,  numero);
        }

    }
}
