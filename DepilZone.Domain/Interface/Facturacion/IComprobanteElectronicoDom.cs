using DepilZone.Entidad.DTO.Facturacion;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Data.Interface.Facturacion
{
	public interface IComprobanteElectronicoDom
	{
        Task<ComprobanteElectronicoDTO> RegistrarVentaComprobante(ComprobanteElectronicoDTO model, int idCita);
        Task<ComprobanteElectronicoDTO> EmitirComprobante(ComprobanteElectronicoDTO model, int idCita);
        Task<List<ComprobanteElectronicoReporteDTO>> ObtenerReporte(int IdUsuario, int idSede, int idTipoDocumento, DateTime fechaDesde, DateTime fechaHasta);
        Task<List<ComprobanteElectronicoReporteVentaDTO>> ObtenerReporteVenta(int IdUsuario, int idSede, int idTipoDocumento, DateTime fechaDesde, DateTime fechaHasta);
        Task<List<ComprobanteElectronicoReportePagoDTO>> ObtenerReportePago(int IdUsuario, int idSede, int idTipoDocumento, DateTime fechaDesde, DateTime fechaHasta);
        Task<List<ComprobanteElectronicoReporteVentaClienteDTO>> ObtenerReporteVentaCliente(int IdUsuario, DateTime fechaDesde, DateTime fechaHasta);
        Task<List<ComprobanteElectronicoReporteVentaProductoDTO>> ObtenerReporteVentaProducto(int IdUsuario, DateTime fechaDesde, DateTime fechaHasta, int idUnidadMedida);
        Task<ComprobanteElectronicoConsultaDTO> ActualizarEstadoSunat(ComprobanteElectronicoDTO model);
        Task<ComprobanteElectronicoAnulacionDTO> ActualizarAnuladoSunat(ComprobanteElectronicoAnulacionDTO model);
        Task<bool> AnularComprobanteSunat(ComprobanteElectronicoAnularDTO model);

        Task<ComprobanteElectronicoDTO> BuscarComprobante(string serie, int numero, int idTipoComprobante);

        Task<int> BuscarComprobanteModifica(string serie, int numero);

        Task<ComprobanteElectronicoDTO> EmitirNotaCredito(ComprobanteElectronicoDTO model);

        Task<List<ComprobanteElectronicoDTO>> ObtenerNotasCredito(DateTime fechaDesde, DateTime fechaHasta, int idTipoComprobante, int idSede);

        Task<string> VerPdf(int idUsuario, int idComprobante, int idTipoComprobante, string serie, int numero);
    }
}
