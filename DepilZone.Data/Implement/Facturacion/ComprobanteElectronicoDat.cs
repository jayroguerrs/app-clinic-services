
using DepilZone.Data.Interface.Facturacion;
using DepilZone.Entidad.DTO.Facturacion;
using DepilZone.Entidad.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace DepilZone.Data.Implement.Facturacion
{
    public class ComprobanteElectronicoDat : IComprobanteElectronicoDat
    {
        private readonly string _connectionString;

        public ComprobanteElectronicoDat(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
        public async Task<ComprobanteElectronicoDTO> RegistrarVentaComprobante(ComprobanteElectronicoDTO model, int idCita)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_ComprobanteElectronico_RegistrarVenta", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdCliente", model.IdCliente);
                cmd.Parameters.AddWithValue("pIdCita", idCita);
                cmd.Parameters.AddWithValue("pIdSede", model.IdSede);
                cmd.Parameters.AddWithValue("pIdAtendidoPor", model.IdAtendidoPor);
                cmd.Parameters.AddWithValue("pNumeroBox", model.NumeroBox);
                cmd.Parameters.AddWithValue("pIdMaquinaMarca", model.IdMaquinaMarca);
                cmd.Parameters.AddWithValue("pSiguienteCita", model.SiguienteCita);
                cmd.Parameters.AddWithValue("pNumeroMeses", model.NumeroMeses);
                cmd.Parameters.AddWithValue("pIdTipoComprobante", model.IdTipoComprobante);
                cmd.Parameters.AddWithValue("pSerieComprobante", model.SerieComprobante);
                cmd.Parameters.AddWithValue("pNumeroComprobante", model.NumeroComprobante);
                cmd.Parameters.AddWithValue("pPorcentajeIgv", model.PorcentajeIgv);
                cmd.Parameters.AddWithValue("pIdSunatTransaccion", model.IdSunatTransaccion);
                cmd.Parameters.AddWithValue("pIdTipoMoneda", model.IdTipoMoneda);
                cmd.Parameters.AddWithValue("pTipoCambio", model.TipoCambio);
                cmd.Parameters.AddWithValue("pIdTipoPago", model.IdTipoPago);
                cmd.Parameters.AddWithValue("pCodigoOperacion", model.CodigoOperacion);
                cmd.Parameters.AddWithValue("pIdEntidadTipoPago", model.IdEntidadTipoPago);
                cmd.Parameters.AddWithValue("pTotal", model.Total);

                cmd.Parameters.AddWithValue("pPagoEfectivo", model.PagoEfectivo);
                cmd.Parameters.AddWithValue("pPagoTarjeta", model.PagoTarjeta);
                cmd.Parameters.AddWithValue("pRecibido", model.Recibido);

                cmd.Parameters.AddWithValue("pVuelto", model.Vuelto);
                cmd.Parameters.AddWithValue("pDetalles", JsonSerializer.Serialize(model.Detalles));
                cmd.Parameters.AddWithValue("pIdUsuarioRegistro", model.IdUsuarioRegistro);


                cmd.Parameters.AddWithValue("pSunatAnulado", model.SunatAnulado);
                cmd.Parameters.AddWithValue("pSunatAcepto", model.SunatAcepto);
                cmd.Parameters.AddWithValue("pSunatDescripcion", model.SunatDescripcion);
                cmd.Parameters.AddWithValue("pSunatNota", model.SunatNota);
                cmd.Parameters.AddWithValue("pSunatRespuestaCodigo", model.SunatCodigoRespuesta);
                cmd.Parameters.AddWithValue("pSunatSoapError", model.SunatSoapError);
                cmd.Parameters.AddWithValue("pSunatKey", model.SunatKey);
                cmd.Parameters.AddWithValue("pSunatHash", model.SunatHash);

                cmd.Parameters.AddWithValue("pSunatUrlCdr", model.SunatUrlCdr);
                cmd.Parameters.AddWithValue("pSunatUrlPdf", model.SunatUrlPdf);
                cmd.Parameters.AddWithValue("pSunatUrlXml", model.SunatUrlXml);
                cmd.Parameters.AddWithValue("pSunatCadenaBarra", model.SunatCadenaBarra);
                cmd.Parameters.AddWithValue("pSunatCadenaQr", model.SunatCadenaQr);
                cmd.Parameters.AddWithValue("pBoletaPdfBase64", model.BoletaPdfBase64);

                cmd.Parameters.AddWithValue("pIdDetallesEliminados", JsonSerializer.Serialize(model.IdDetallesEliminados));


                cmd.Parameters.AddWithValue("pIdFacturacionCliente", model.IdClienteComprobante);

                cmd.Parameters.AddWithValue("pTurno", model.Turno);



                cmd.Parameters.AddWithValue("pSubTotal", model.SubTotal);
                cmd.Parameters.AddWithValue("pTotalIgv", model.TotalIgv);

                cmd.Parameters.AddWithValue("pTotalGratuita", model.TotalGratuita);
                cmd.Parameters.AddWithValue("pTotalInafecta", model.TotalInafecta);
                cmd.Parameters.AddWithValue("pTotalExonerada", model.TotalExonerada);


                cmd.Parameters.AddWithValue("pObservaciones", model.Observaciones);


                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadRegistrarVentaComprobante(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        public async Task<ComprobanteElectronicoDTO> EmitirComprobante(ComprobanteElectronicoDTO model, int idCita)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_ComprobanteElectronico_Emitir", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdCliente", model.IdCliente);
                cmd.Parameters.AddWithValue("pIdCita", idCita);
                cmd.Parameters.AddWithValue("pIdSede", model.IdSede);
                cmd.Parameters.AddWithValue("pIdAtendidoPor", model.IdAtendidoPor);
                cmd.Parameters.AddWithValue("pNumeroBox", model.NumeroBox);
                cmd.Parameters.AddWithValue("pIdMaquinaMarca", model.IdMaquinaMarca);
                cmd.Parameters.AddWithValue("pSiguienteCita", model.SiguienteCita);
                cmd.Parameters.AddWithValue("pNumeroMeses", model.NumeroMeses);
                cmd.Parameters.AddWithValue("pIdTipoComprobante", model.IdTipoComprobante);
                cmd.Parameters.AddWithValue("pSerieComprobante", model.SerieComprobante);
                cmd.Parameters.AddWithValue("pNumeroComprobante", model.NumeroComprobante);
                cmd.Parameters.AddWithValue("pPorcentajeIgv", model.PorcentajeIgv);
                cmd.Parameters.AddWithValue("pIdSunatTransaccion", model.IdSunatTransaccion);
                cmd.Parameters.AddWithValue("pIdTipoMoneda", model.IdTipoMoneda);
                cmd.Parameters.AddWithValue("pTipoCambio", model.TipoCambio);
                cmd.Parameters.AddWithValue("pIdTipoPago", model.IdTipoPago);
                cmd.Parameters.AddWithValue("pCodigoOperacion", model.CodigoOperacion);
                cmd.Parameters.AddWithValue("pIdEntidadTipoPago", model.IdEntidadTipoPago);
                cmd.Parameters.AddWithValue("pTotal", model.Total);

                cmd.Parameters.AddWithValue("pPagoEfectivo", model.PagoEfectivo);
                cmd.Parameters.AddWithValue("pPagoTarjeta", model.PagoTarjeta);
                cmd.Parameters.AddWithValue("pRecibido", model.Recibido);

                cmd.Parameters.AddWithValue("pVuelto", model.Vuelto);
                cmd.Parameters.AddWithValue("pDetalles", JsonSerializer.Serialize(model.Detalles));
                cmd.Parameters.AddWithValue("pIdUsuarioRegistro", model.IdUsuarioRegistro);


                cmd.Parameters.AddWithValue("pSunatAnulado", model.SunatAnulado);
                cmd.Parameters.AddWithValue("pSunatAcepto", model.SunatAcepto);
                cmd.Parameters.AddWithValue("pSunatDescripcion", model.SunatDescripcion);
                cmd.Parameters.AddWithValue("pSunatNota", model.SunatNota);
                cmd.Parameters.AddWithValue("pSunatRespuestaCodigo", model.SunatCodigoRespuesta);
                cmd.Parameters.AddWithValue("pSunatSoapError", model.SunatSoapError);
                cmd.Parameters.AddWithValue("pSunatKey", model.SunatKey);
                cmd.Parameters.AddWithValue("pSunatHash", model.SunatHash);

                cmd.Parameters.AddWithValue("pSunatUrlCdr", model.SunatUrlCdr);
                cmd.Parameters.AddWithValue("pSunatUrlPdf", model.SunatUrlPdf);
                cmd.Parameters.AddWithValue("pSunatUrlXml", model.SunatUrlXml);
                cmd.Parameters.AddWithValue("pSunatCadenaBarra", model.SunatCadenaBarra);
                cmd.Parameters.AddWithValue("pSunatCadenaQr", model.SunatCadenaQr);
                cmd.Parameters.AddWithValue("pBoletaPdfBase64", model.BoletaPdfBase64);

                cmd.Parameters.AddWithValue("pIdDetallesEliminados", JsonSerializer.Serialize(model.IdDetallesEliminados));


                cmd.Parameters.AddWithValue("pIdFacturacionCliente", model.IdClienteComprobante);

                cmd.Parameters.AddWithValue("pTurno", model.Turno);



                cmd.Parameters.AddWithValue("pSubTotal", model.SubTotal);
                cmd.Parameters.AddWithValue("pTotalIgv", model.TotalIgv);

                cmd.Parameters.AddWithValue("pTotalGratuita", model.TotalGratuita);
                cmd.Parameters.AddWithValue("pTotalInafecta", model.TotalInafecta);
                cmd.Parameters.AddWithValue("pTotalExonerada", model.TotalExonerada);


                cmd.Parameters.AddWithValue("pObservaciones", model.Observaciones);


                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadEmitirComprobante(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        public async Task<ComprobanteElectronicoDTO> EmitirNotaCredito(ComprobanteElectronicoDTO model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_ComprobanteElectronico_EmitirNotaCredito", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdCliente", model.IdCliente);
                cmd.Parameters.AddWithValue("pIdSede", model.IdSede);
                cmd.Parameters.AddWithValue("pIdTipoComprobante", model.IdTipoComprobante);
                cmd.Parameters.AddWithValue("pSerie", model.SerieComprobante);
                cmd.Parameters.AddWithValue("pNumero", model.NumeroComprobante);
                cmd.Parameters.AddWithValue("pIdSunatTransaccion", model.IdSunatTransaccion);

                cmd.Parameters.AddWithValue("pIdClienteTipoDocumento", model.ComprobanteCliente.IdTipoDocumento);
                cmd.Parameters.AddWithValue("pClienteNumeroDocumento", model.ComprobanteCliente.NumeroDocumento);
                cmd.Parameters.AddWithValue("pClienteDenominacion", model.ComprobanteCliente.Nombre);
                cmd.Parameters.AddWithValue("pClienteDireccion", model.ComprobanteCliente.Direccion);
                cmd.Parameters.AddWithValue("pClienteEmail", null);
                cmd.Parameters.AddWithValue("pClienteEmail1", null);
                cmd.Parameters.AddWithValue("pClienteEmail2", null);

                cmd.Parameters.AddWithValue("pFechaEmision", model.FechaEmision);
                cmd.Parameters.AddWithValue("pFechaVencimiento", model.FechaEmision);

                cmd.Parameters.AddWithValue("pIdMoneda", model.IdTipoMoneda);
                cmd.Parameters.AddWithValue("pTipoCambio", model.TipoCambio);
                cmd.Parameters.AddWithValue("pPorcentajeIgv", model.PorcentajeIgv);
                cmd.Parameters.AddWithValue("pTotalDescuento", model.TotalDescuento);
                cmd.Parameters.AddWithValue("pTotalAnticipo", model.TotalAnticipo);
                cmd.Parameters.AddWithValue("pTotalGravada", model.SubTotal);
                cmd.Parameters.AddWithValue("pTotalInafecta", model.TotalInafecta);
                cmd.Parameters.AddWithValue("pTotalExonerada", model.TotalExonerada);
                cmd.Parameters.AddWithValue("pTotalIgv", model.TotalIgv);
                cmd.Parameters.AddWithValue("pTotalGratuita", model.TotalGratuita);
                cmd.Parameters.AddWithValue("pTotalOtros", model.TotalOtros);
                cmd.Parameters.AddWithValue("pTotalIsc", model.TotalIsc);
                cmd.Parameters.AddWithValue("pTotal", model.Total);

                //cmd.Parameters.AddWithValue("pIdTipoPercepcion", model.IdTipoPercepcion);
                //cmd.Parameters.AddWithValue("pPercepcionBaseImponible", model.PercepcionBaseImponible);

                cmd.Parameters.AddWithValue("pObservaciones", model.Observaciones);

                cmd.Parameters.AddWithValue("pIdTipoComprobanteModifica", model.IdTipoComprobanteModifica);
                cmd.Parameters.AddWithValue("pSerieComprobanteModifica", model.SerieComprobanteModifica);
                cmd.Parameters.AddWithValue("pNumeroComprobanteModifica", model.NumeroComprobanteModifica);
                cmd.Parameters.AddWithValue("pIdTipoNotaCredito", model.IdTipoNotaCredito);


                cmd.Parameters.AddWithValue("pSunatAnulado", model.SunatAnulado);
                cmd.Parameters.AddWithValue("pSunatAcepto", model.SunatAcepto);
                cmd.Parameters.AddWithValue("pSunatDescripcion", model.SunatDescripcion);
                cmd.Parameters.AddWithValue("pSunatNota", model.SunatNota);
                cmd.Parameters.AddWithValue("pSunatRespuestaCodigo", model.SunatCodigoRespuesta);
                cmd.Parameters.AddWithValue("pSunatSoapError", model.SunatSoapError);
                cmd.Parameters.AddWithValue("pSunatKey", model.SunatKey);
                cmd.Parameters.AddWithValue("pSunatHash", model.SunatHash);

                cmd.Parameters.AddWithValue("pSunatUrlCdr", model.SunatUrlCdr);
                cmd.Parameters.AddWithValue("pSunatUrlPdf", model.SunatUrlPdf);
                cmd.Parameters.AddWithValue("pSunatUrlXml", model.SunatUrlXml);

                cmd.Parameters.AddWithValue("pSunatCadenaBarra", model.SunatCadenaBarra);
                cmd.Parameters.AddWithValue("pSunatCadenaQr", model.SunatCadenaQr);

                cmd.Parameters.AddWithValue("pIdVenta", model.IdVenta);

                cmd.Parameters.AddWithValue("pDetalles", JsonSerializer.Serialize(model.Detalles));
                cmd.Parameters.AddWithValue("pIdUsuarioRegistra", model.IdUsuarioRegistro);


                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadEmitirNotaCredito(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        public async Task<List<ComprobanteElectronicoDTO>> ObtenerNotasCredito(DateTime fechaDesde, DateTime fechaHasta, int idTipoComprobante, int idSede)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_ComprobanteElectronico_ObtenerNotasCredito", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                //cmd.Parameters.AddWithValue("pIdCliente", model.IdCliente);
                cmd.Parameters.AddWithValue("pFechaDesde", fechaDesde);
                cmd.Parameters.AddWithValue("pFechaHasta", fechaHasta);
                cmd.Parameters.AddWithValue("pIdTipoComprobanteModifica", idTipoComprobante);
                cmd.Parameters.AddWithValue("pIdSede", idSede);


                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadObtenerNotasCredito(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }


        public async Task<ComprobanteElectronicoDTO> BuscarComprobante(string serie, int numero, int idTipoComprobante)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_ComprobanteElectronico_Buscar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pSerie", serie);
                cmd.Parameters.AddWithValue("pNumero", numero);
                cmd.Parameters.AddWithValue("pIdTipoComprobante", idTipoComprobante);

                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadBuscarComprobante(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }


        public async Task<List<ComprobanteElectronicoReporteDTO>> ObtenerReporte(int idUsuario, int idSede, int idTipoDocumento, DateTime fechaDesde, DateTime fechaHasta)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_ComprobanteElectronico_Reporte", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdUsuario", idUsuario);
                cmd.Parameters.AddWithValue("pIdSede", idSede);
                cmd.Parameters.AddWithValue("pIdTipoComprobante", idTipoDocumento);
                cmd.Parameters.AddWithValue("pFechaDesde", fechaDesde);
                cmd.Parameters.AddWithValue("pFechaHasta", fechaHasta);

                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadObtenerReporte(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }


        public async Task<List<ComprobanteElectronicoReporteVentaDTO>> ObtenerReporteVenta(int idUsuario, int idSede, int idTipoDocumento, DateTime fechaDesde, DateTime fechaHasta)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_ComprobanteElectronico_ReporteVenta", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdUsuario", idUsuario);
                cmd.Parameters.AddWithValue("pIdSede", idSede);
                cmd.Parameters.AddWithValue("pIdTipoComprobante", idTipoDocumento);
                cmd.Parameters.AddWithValue("pFechaDesde", fechaDesde);
                cmd.Parameters.AddWithValue("pFechaHasta", fechaHasta);

                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadObtenerReporteVenta(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        public async Task<List<ComprobanteElectronicoReporteVentaClienteDTO>> ObtenerReporteVentaCliente(int idUsuario,  DateTime fechaDesde, DateTime fechaHasta)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_ComprobanteElectronico_ReporteVentaCliente", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdUsuario", idUsuario);
                cmd.Parameters.AddWithValue("pFechaDesde", fechaDesde);
                cmd.Parameters.AddWithValue("pFechaHasta", fechaHasta);

                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadObtenerReporteVentaCliente(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        public async Task<List<ComprobanteElectronicoReporteVentaProductoDTO>> ObtenerReporteVentaProducto(int idUsuario, DateTime fechaDesde, DateTime fechaHasta, int idUnidadMedida)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_ComprobanteElectronico_ReporteVentaProducto", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdUsuario", idUsuario);
                cmd.Parameters.AddWithValue("pFechaDesde", fechaDesde);
                cmd.Parameters.AddWithValue("pFechaHasta", fechaHasta);
                cmd.Parameters.AddWithValue("pIdUnidadMedida", idUnidadMedida);

                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadObtenerReporteVentaProducto(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        public async Task<List<ComprobanteElectronicoReportePagoDTO>> ObtenerReportePago(int idUsuario, int idSede, int idTipoDocumento, DateTime fechaDesde, DateTime fechaHasta)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_ComprobanteElectronico_ReportePago", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdUsuario", idUsuario);
                cmd.Parameters.AddWithValue("pIdSede", idSede);
                cmd.Parameters.AddWithValue("pIdTipoComprobante", idTipoDocumento);
                cmd.Parameters.AddWithValue("pFechaDesde", fechaDesde);
                cmd.Parameters.AddWithValue("pFechaHasta", fechaHasta);

                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadObtenerReportePago(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        public async Task<ComprobanteElectronicoConsultaDTO> ActualizarEstadoSunat(ComprobanteElectronicoDTO model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Venta_ActualizarEstadoSunat", conn)
                {
                CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdTipoComprobante", model.IdTipoComprobante);
                cmd.Parameters.AddWithValue("pSerie", model.SerieComprobante);
                cmd.Parameters.AddWithValue("pNumero", model.NumeroComprobante);
                cmd.Parameters.AddWithValue("pSunatAnulado", model.SunatAnulado);
                cmd.Parameters.AddWithValue("pSunatAcepto", model.SunatAcepto);
                cmd.Parameters.AddWithValue("pSunatDescripcion", model.SunatDescripcion);
                cmd.Parameters.AddWithValue("pSunatNota", model.SunatNota);
                cmd.Parameters.AddWithValue("pSunatRespuestaCodigo", model.SunatCodigoRespuesta);
                cmd.Parameters.AddWithValue("pSunatSoapError", model.SunatSoapError);

                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadActualizarEstadoSunat(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }



        public async Task<ComprobanteElectronicoAnulacionDTO> ActualizarAnuladoSunat(ComprobanteElectronicoAnulacionDTO model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Venta_ActualizarAnuladoSunat", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pSunatTicketNumero", model.SunatTicketNumero);
                cmd.Parameters.AddWithValue("pIdTipoComprobante", model.IdTipoComprobante);
                cmd.Parameters.AddWithValue("pSerie", model.Serie);
                cmd.Parameters.AddWithValue("pNumero", model.Numero);
                cmd.Parameters.AddWithValue("pCodigo", model.Codigo);
                cmd.Parameters.AddWithValue("pIdSede", model.IdSede);
                cmd.Parameters.AddWithValue("pSunatAcepto", model.SunatAcepto);
                cmd.Parameters.AddWithValue("pSunatDescripcion", model.SunatDescripcion);
                cmd.Parameters.AddWithValue("pSunatNota", model.SunatNota);
                cmd.Parameters.AddWithValue("pSunatRespuestaCodigo", model.SunatCodigoRespuesta);
                cmd.Parameters.AddWithValue("pSunatSoapError", model.SunatSoapError);

                cmd.Parameters.AddWithValue("pSunatUrlCdr", model.SunatUrlCdr);
                cmd.Parameters.AddWithValue("pSunatUrlPdf", model.SunatUrlPdf);
                cmd.Parameters.AddWithValue("pSunatUrlXml", model.SunatUrlXml);

                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadActualizarAnuladoSunat(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }



        public async Task<bool> AnularComprobanteSunat(ComprobanteElectronicoAnularDTO model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_ComprobanteElectronico_AnularSunat", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pMotivo", model.Motivo);
                cmd.Parameters.AddWithValue("pIdTipoComprobante", model.IdTipoComprobante);
                cmd.Parameters.AddWithValue("pIdSede", model.IdSede);
                cmd.Parameters.AddWithValue("pSerie", model.Serie);
                cmd.Parameters.AddWithValue("pNumero", Convert.ToInt32(model.Numero));

                cmd.Parameters.AddWithValue("pCodigo", model.Codigo);
                cmd.Parameters.AddWithValue("pSunatAcepto", model.SunatAcepto);
                cmd.Parameters.AddWithValue("pSunatDescripcion", model.SunatDescripcion);
                cmd.Parameters.AddWithValue("pSunatNota", model.SunatNota);
                cmd.Parameters.AddWithValue("pSunatTicketNumero", model.SunatTicketNumero);
                cmd.Parameters.AddWithValue("pSunatCodigoRespuesta", model.SunatCodigoRespuesta);
                cmd.Parameters.AddWithValue("pSunatSoapError", model.SunatSoapError);
                cmd.Parameters.AddWithValue("pSunatUrlCdr", model.SunatUrlCdr);
                cmd.Parameters.AddWithValue("pSunatUrlPdf", model.SunatUrlPdf);
                cmd.Parameters.AddWithValue("pSunatUrlXml", model.SunatUrlXml);

                cmd.Parameters.AddWithValue("pIdUsuarioRegistro", model.IdUsuario);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadAnularComprobanteSunat(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        public async Task<int> BuscarComprobanteModifica(string serie, int numero)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_ComprobanteNotaCredito_BuscarModificado", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pSerieComprobanteModifica", serie);
                cmd.Parameters.AddWithValue("pNumeroComprobanteModifica", numero);

                var reader = await cmd.ExecuteReaderAsync();
                int output = 0;
                while (await reader.ReadAsync())
                {
                    output = Convert.ToInt32(reader["Total"]);
                }
                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        public async Task<string> VerPdf(int idUsuario, int idComprobante, int idTipoComprobante, string serie, int numero)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_ComprobanteElectronico_VerPdf", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdUsuario", idUsuario);
                cmd.Parameters.AddWithValue("pIdComprobante", idComprobante);
                cmd.Parameters.AddWithValue("pIdTipoComprobante", idTipoComprobante);
                cmd.Parameters.AddWithValue("pSerie", serie);
                cmd.Parameters.AddWithValue("pNumero", numero);

                var reader = await cmd.ExecuteReaderAsync();
                string pdfBase64 = "";
                string url = "";

                bool exito = true;
                string mensaje = "";
                string detalle = "";
                int codigoError = 0;

                while (await reader.ReadAsync())
                {
                    exito = Convert.ToBoolean(reader["Exito"]);
                    if (!exito)
                    {
                        mensaje = Convert.ToString(reader["Mensaje"]);
                        codigoError = Convert.ToInt32(reader["ErrorNumero"]);
                        detalle = Convert.ToString(reader["ErrorDetalle"]);
                        throw new AlertException(mensaje);
                    }
                }

                if (reader.NextResult())
                {
                    while (await reader.ReadAsync())
                    {
                        url = Convert.ToString(reader["SunatUrlPdf"]);
                    }
                }

                conn.Close();

                using (WebClient client = new WebClient())
                {
                    var bytes = client.DownloadData(url);
                    pdfBase64 = Convert.ToBase64String(bytes);
                }

                return pdfBase64;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        // READERS


        static async Task<ComprobanteElectronicoDTO> ReadRegistrarVentaComprobante(DbDataReader reader)
        {
            try
            {
                bool exito = true;
                string mensaje = "";
                string detalle = "";
                int codigoError = 0;

                while (await reader.ReadAsync())
                {
                    exito = Convert.ToBoolean(reader["Exito"]);
                    if (!exito)
                    {
                        mensaje = Convert.ToString(reader["Mensaje"]);
                        codigoError = Convert.ToInt32(reader["ErrorNumero"]);
                        detalle = Convert.ToString(reader["ErrorDetalle"]);
                        throw new AlertException(mensaje);
                    }
                }


                ComprobanteElectronicoDTO model = new ComprobanteElectronicoDTO();
                if (reader.NextResult())
                {
                    while (await reader.ReadAsync())
                    {
                        model.IdVenta = Convert.ToInt32(reader["IdVenta"]);


                        model.IdCliente = Convert.ToInt32(reader["IdCliente"]);
                        model.Cliente = Convert.ToString(reader["Cliente"]);
                        model.ClienteDocumento = Convert.ToString(reader["ClienteDocumento"]);

                        model.IdSede = Convert.ToInt32(reader["IdSede"]);
                        model.Sede = Convert.ToString(reader["Sede"]);

                        model.IdCita = Convert.ToInt32(reader["IdCita"]);

                        model.IdAtendidoPor = Convert.ToInt32(reader["IdAtendidoPor"]);
                        model.AtendidoPor = Convert.ToString(reader["AtendidoPor"]);

                        model.NumeroBox = Convert.ToInt32(reader["NumeroBox"]);

                        model.IdMaquinaMarca = Convert.ToInt32(reader["IdMaquinaMarca"]);
                        model.MaquinaMarca = Convert.ToString(reader["MaquinaMarca"]);

                        model.SiguienteCita = Convert.ToBoolean(reader["SiguienteCita"]);

                        model.IdTipoComprobante = Convert.ToInt32(reader["IdTipoComprobante"]);
                        model.TipoComprobante = Convert.ToString(reader["TipoComprobante"]);

                        //model.IdSerieComprobante = Convert.ToInt32(reader["IdSerieComprobante"]);
                        model.SerieComprobante = Convert.ToString(reader["SerieComprobante"]);
                        model.NumeroComprobante = Convert.ToString(reader["NumeroComprobante"]);

                        model.PorcentajeIgv = Convert.ToDecimal(reader["PorcentajeIgv"]);
                        model.IdSunatTransaccion = reader["IdSunatTransaccion"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["IdSunatTransaccion"]);

                        model.IdTipoMoneda = Convert.ToInt32(reader["IdTipoMoneda"]);
                        model.TipoMoneda = Convert.ToString(reader["TipoMoneda"]);
                        model.TipoMonedaSimbolo = Convert.ToString(reader["TipoMonedaSimbolo"]);

                        model.TipoCambio = reader["TipoCambio"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(reader["TipoCambio"]);

                        model.IdTipoPago = Convert.ToInt32(reader["IdTipoPago"]);
                        model.TipoPago = Convert.ToString(reader["TipoPago"]);
                        //model.CodigoOperacion = DBNull.Value == reader["TipoPago"] ? null : Convert.ToString(reader["TipoPago"]);


                        model.IdEntidadTipoPago = reader["IdEntidadTipoPago"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["IdEntidadTipoPago"]);
                        model.EntidadTipoPago = reader["EntidadTipoPago"] == DBNull.Value ? null : Convert.ToString(reader["EntidadTipoPago"]);


                        model.Total = Convert.ToDecimal(reader["Total"]);

                        model.PagoEfectivo = Convert.ToDecimal(reader["PagoEfectivo"]);
                        model.PagoTarjeta = Convert.ToDecimal(reader["PagoTarjeta"]);
                        model.Recibido = Convert.ToDecimal(reader["Recibido"]);


                        model.Vuelto = Convert.ToDecimal(reader["Vuelto"]);

                        model.IdUsuarioRegistro = Convert.ToInt32(reader["IdUsuarioRegistro"]);
                        model.UsuarioRegistro = Convert.ToString(reader["UsuarioRegistro"]);
                        model.UsuarioRegistroNombre = Convert.ToString(reader["UsuarioRegistroNombre"]);


                        model.Detalles = new List<ComprobanteElectronicoDetalleDTO>(JsonSerializer.Deserialize<List<ComprobanteElectronicoDetalleDTO>>(Convert.ToString(reader["Detalles"])));

                        model.FechaEmision = Convert.ToDateTime(reader["FechaEmision"]);




                        model.SunatKey = reader["SunatKey"] == DBNull.Value ? null : Convert.ToString(reader["SunatKey"]);
                        model.SunatUrlPdf = reader["SunatUrlPdf"] == DBNull.Value ? null : Convert.ToString(reader["SunatUrlPdf"]);
                        model.SunatUrlXml = reader["SunatUrlXml"] == DBNull.Value ? null : Convert.ToString(reader["SunatUrlXml"]);
                        model.SunatUrlCdr = reader["SunatUrlCdr"] == DBNull.Value ? null : Convert.ToString(reader["SunatUrlCdr"]);
                        model.SunatCadenaQr = reader["SunatCadenaQr"] == DBNull.Value ? null : Convert.ToString(reader["SunatCadenaQr"]);
                        model.SunatCadenaBarra = reader["SunatCadenaBarra"] == DBNull.Value ? null : Convert.ToString(reader["SunatCadenaBarra"]);
                        model.SunatHash = reader["SunatHash"] == DBNull.Value ? null : Convert.ToString(reader["SunatHash"]);
                        model.BoletaPdfBase64 = reader["BoletaPdfBase64"] == DBNull.Value ? null : Convert.ToString(reader["BoletaPdfBase64"]);


                        model.IdSiguienteCita = reader["IdSiguienteCita"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["IdSiguienteCita"]);

                    }
                }

                if (reader.NextResult())
                {
                    while (await reader.ReadAsync())
                    {
                        model.EmisorRazonSocial = Convert.ToString(reader["EmisorRazonSocial"]);
                        model.EmisorTelefonos = Convert.ToString(reader["EmisorTelefonos"]);
                        model.EmisorDireccion = Convert.ToString(reader["EmisorDireccion"]);
                        model.EmisorRuc = Convert.ToString(reader["EmisorRuc"]);
                        model.EmisorDescripcion = Convert.ToString(reader["EmisorDescripcion"]);
                    }
                }

                return model;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }


        static async Task<ComprobanteElectronicoDTO> ReadEmitirComprobante(DbDataReader reader)
        {
            try
            {
                bool exito = true;
                string mensaje = "";
                string detalle = "";
                int codigoError = 0;

                while (await reader.ReadAsync())
                {
                    exito = Convert.ToBoolean(reader["Exito"]);
                    if (!exito)
                    {
                        mensaje = Convert.ToString(reader["Mensaje"]);
                        codigoError = Convert.ToInt32(reader["ErrorNumero"]);
                        detalle = Convert.ToString(reader["ErrorDetalle"]);
                        throw new AlertException(mensaje);
                    }
                }


                ComprobanteElectronicoDTO model = new ComprobanteElectronicoDTO();
                if (reader.NextResult())
                {
                    while (await reader.ReadAsync())
                    {
                        model.IdVenta = Convert.ToInt32(reader["IdVenta"]);


                        model.IdCliente = Convert.ToInt32(reader["IdCliente"]);
                        model.Cliente = Convert.ToString(reader["Cliente"]);
                        model.ClienteDocumento = Convert.ToString(reader["ClienteDocumento"]);

                        model.IdSede = Convert.ToInt32(reader["IdSede"]);
                        model.Sede = Convert.ToString(reader["Sede"]);

                        model.IdCita = Convert.ToInt32(reader["IdCita"]);

                        model.IdAtendidoPor = Convert.ToInt32(reader["IdAtendidoPor"]);
                        model.AtendidoPor = Convert.ToString(reader["AtendidoPor"]);

                        model.NumeroBox = Convert.ToInt32(reader["NumeroBox"]);

                        model.IdMaquinaMarca = Convert.ToInt32(reader["IdMaquinaMarca"]);
                        model.MaquinaMarca = Convert.ToString(reader["MaquinaMarca"]);

                        model.SiguienteCita = Convert.ToBoolean(reader["SiguienteCita"]);

                        model.IdTipoComprobante = Convert.ToInt32(reader["IdTipoComprobante"]);
                        model.TipoComprobante = Convert.ToString(reader["TipoComprobante"]);

                        //model.IdSerieComprobante = Convert.ToInt32(reader["IdSerieComprobante"]);
                        model.SerieComprobante = Convert.ToString(reader["SerieComprobante"]);
                        model.NumeroComprobante = Convert.ToString(reader["NumeroComprobante"]);

                        model.PorcentajeIgv = Convert.ToDecimal(reader["PorcentajeIgv"]);
                        model.IdSunatTransaccion = reader["IdSunatTransaccion"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["IdSunatTransaccion"]);

                        model.IdTipoMoneda = Convert.ToInt32(reader["IdTipoMoneda"]);
                        model.TipoMoneda = Convert.ToString(reader["TipoMoneda"]);
                        model.TipoMonedaSimbolo = Convert.ToString(reader["TipoMonedaSimbolo"]);

                        model.TipoCambio = reader["TipoCambio"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(reader["TipoCambio"]);

                        model.IdTipoPago = Convert.ToInt32(reader["IdTipoPago"]);
                        model.TipoPago = Convert.ToString(reader["TipoPago"]);
                        //model.CodigoOperacion = DBNull.Value == reader["TipoPago"] ? null : Convert.ToString(reader["TipoPago"]);


                        model.IdEntidadTipoPago = reader["IdEntidadTipoPago"] == DBNull.Value ? (int?)null :Convert.ToInt32(reader["IdEntidadTipoPago"]);
                        model.EntidadTipoPago = reader["EntidadTipoPago"] == DBNull.Value ? null : Convert.ToString(reader["EntidadTipoPago"]);


                        model.Total = Convert.ToDecimal(reader["Total"]);

                        model.PagoEfectivo = Convert.ToDecimal(reader["PagoEfectivo"]);
                        model.PagoTarjeta = Convert.ToDecimal(reader["PagoTarjeta"]);
                        model.Recibido = Convert.ToDecimal(reader["Recibido"]);


                        model.Vuelto = Convert.ToDecimal(reader["Vuelto"]);

                        model.IdUsuarioRegistro = Convert.ToInt32(reader["IdUsuarioRegistro"]);
                        model.UsuarioRegistro = Convert.ToString(reader["UsuarioRegistro"]);
                        model.UsuarioRegistroNombre = Convert.ToString(reader["UsuarioRegistroNombre"]);


                        model.Detalles = new List<ComprobanteElectronicoDetalleDTO>(JsonSerializer.Deserialize<List<ComprobanteElectronicoDetalleDTO>>(Convert.ToString(reader["Detalles"])));

                        model.FechaEmision = Convert.ToDateTime(reader["FechaEmision"]);




                        model.SunatKey = reader["SunatKey"] == DBNull.Value ? null : Convert.ToString(reader["SunatKey"]);
                        model.SunatUrlPdf = reader["SunatUrlPdf"] == DBNull.Value ? null : Convert.ToString(reader["SunatUrlPdf"]);
                        model.SunatUrlXml = reader["SunatUrlXml"] == DBNull.Value ? null : Convert.ToString(reader["SunatUrlXml"]);
                        model.SunatUrlCdr = reader["SunatUrlCdr"] == DBNull.Value ? null : Convert.ToString(reader["SunatUrlCdr"]);
                        model.SunatCadenaQr = reader["SunatCadenaQr"] == DBNull.Value ? null : Convert.ToString(reader["SunatCadenaQr"]);
                        model.SunatCadenaBarra = reader["SunatCadenaBarra"] == DBNull.Value ? null : Convert.ToString(reader["SunatCadenaBarra"]);
                        model.SunatHash = reader["SunatHash"] == DBNull.Value ? null : Convert.ToString(reader["SunatHash"]);
                        model.BoletaPdfBase64 = reader["BoletaPdfBase64"] == DBNull.Value ? null : Convert.ToString(reader["BoletaPdfBase64"]);


                        model.IdSiguienteCita = reader["IdSiguienteCita"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["IdSiguienteCita"]);

                    }
                }

                if (reader.NextResult())
                {
                    while (await reader.ReadAsync())
                    {
                        model.EmisorRazonSocial = Convert.ToString(reader["EmisorRazonSocial"]);
                        model.EmisorTelefonos = Convert.ToString(reader["EmisorTelefonos"]);
                        model.EmisorDireccion = Convert.ToString(reader["EmisorDireccion"]);
                        model.EmisorRuc = Convert.ToString(reader["EmisorRuc"]);
                        model.EmisorDescripcion = Convert.ToString(reader["EmisorDescripcion"]);
                    }
                }

                return model;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        static async Task<ComprobanteElectronicoDTO> ReadEmitirNotaCredito(DbDataReader reader)
        {
            try
            {
                bool exito = true;
                string mensaje = "";
                string detalle = "";
                int codigoError = 0;

                while (await reader.ReadAsync())
                {
                    exito = Convert.ToBoolean(reader["Exito"]);
                    if (!exito)
                    {
                        mensaje = Convert.ToString(reader["Mensaje"]);
                        codigoError = Convert.ToInt32(reader["ErrorNumero"]);
                        detalle = Convert.ToString(reader["ErrorDetalle"]);
                        throw new AlertException(mensaje);
                    }
                }


                ComprobanteElectronicoDTO model = new ComprobanteElectronicoDTO();
                /*if (reader.NextResult())
                {
                    while (await reader.ReadAsync())
                    {
                        model.IdVenta = Convert.ToInt32(reader["IdVenta"]);


                        model.IdCliente = Convert.ToInt32(reader["IdCliente"]);
                        model.Cliente = Convert.ToString(reader["Cliente"]);
                        model.ClienteDocumento = Convert.ToString(reader["ClienteDocumento"]);

                        model.IdSede = Convert.ToInt32(reader["IdSede"]);
                        model.Sede = Convert.ToString(reader["Sede"]);

                        model.IdCita = Convert.ToInt32(reader["IdCita"]);

                        model.IdAtendidoPor = Convert.ToInt32(reader["IdAtendidoPor"]);
                        model.AtendidoPor = Convert.ToString(reader["AtendidoPor"]);

                        model.NumeroBox = Convert.ToInt32(reader["NumeroBox"]);

                        model.IdMaquinaMarca = Convert.ToInt32(reader["IdMaquinaMarca"]);
                        model.MaquinaMarca = Convert.ToString(reader["MaquinaMarca"]);

                        model.SiguienteCita = Convert.ToBoolean(reader["SiguienteCita"]);

                        model.IdTipoComprobante = Convert.ToInt32(reader["IdTipoComprobante"]);
                        model.TipoComprobante = Convert.ToString(reader["TipoComprobante"]);

                        //model.IdSerieComprobante = Convert.ToInt32(reader["IdSerieComprobante"]);
                        model.SerieComprobante = Convert.ToString(reader["SerieComprobante"]);
                        model.NumeroComprobante = Convert.ToString(reader["NumeroComprobante"]);

                        model.PorcentajeIgv = Convert.ToDecimal(reader["PorcentajeIgv"]);
                        model.IdSunatTransaccion = reader["IdSunatTransaccion"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["IdSunatTransaccion"]);

                        model.IdTipoMoneda = Convert.ToInt32(reader["IdTipoMoneda"]);
                        model.TipoMoneda = Convert.ToString(reader["TipoMoneda"]);
                        model.TipoMonedaSimbolo = Convert.ToString(reader["TipoMonedaSimbolo"]);

                        model.TipoCambio = reader["TipoCambio"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(reader["TipoCambio"]);

                        model.IdTipoPago = Convert.ToInt32(reader["IdTipoPago"]);
                        model.TipoPago = Convert.ToString(reader["TipoPago"]);
                        //model.CodigoOperacion = DBNull.Value == reader["TipoPago"] ? null : Convert.ToString(reader["TipoPago"]);


                        model.IdEntidadTipoPago = reader["IdEntidadTipoPago"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["IdEntidadTipoPago"]);
                        model.EntidadTipoPago = reader["EntidadTipoPago"] == DBNull.Value ? null : Convert.ToString(reader["EntidadTipoPago"]);


                        model.Total = Convert.ToDecimal(reader["Total"]);

                        model.PagoEfectivo = Convert.ToDecimal(reader["PagoEfectivo"]);
                        model.PagoTarjeta = Convert.ToDecimal(reader["PagoTarjeta"]);
                        model.Recibido = Convert.ToDecimal(reader["Recibido"]);


                        model.Vuelto = Convert.ToDecimal(reader["Vuelto"]);

                        model.IdUsuarioRegistro = Convert.ToInt32(reader["IdUsuarioRegistro"]);
                        model.UsuarioRegistro = Convert.ToString(reader["UsuarioRegistro"]);
                        model.UsuarioRegistroNombre = Convert.ToString(reader["UsuarioRegistroNombre"]);


                        model.Detalles = new List<ComprobanteElectronicoDetalleDTO>(JsonSerializer.Deserialize<List<ComprobanteElectronicoDetalleDTO>>(Convert.ToString(reader["Detalles"])));

                        model.FechaEmision = Convert.ToDateTime(reader["FechaEmision"]);




                        model.SunatKey = reader["SunatKey"] == DBNull.Value ? null : Convert.ToString(reader["SunatKey"]);
                        model.SunatUrlPdf = reader["SunatUrlPdf"] == DBNull.Value ? null : Convert.ToString(reader["SunatUrlPdf"]);
                        model.SunatUrlXml = reader["SunatUrlXml"] == DBNull.Value ? null : Convert.ToString(reader["SunatUrlXml"]);
                        model.SunatUrlCdr = reader["SunatUrlCdr"] == DBNull.Value ? null : Convert.ToString(reader["SunatUrlCdr"]);
                        model.SunatCadenaQr = reader["SunatCadenaQr"] == DBNull.Value ? null : Convert.ToString(reader["SunatCadenaQr"]);
                        model.SunatCadenaBarra = reader["SunatCadenaBarra"] == DBNull.Value ? null : Convert.ToString(reader["SunatCadenaBarra"]);
                        model.SunatHash = reader["SunatHash"] == DBNull.Value ? null : Convert.ToString(reader["SunatHash"]);
                        model.BoletaPdfBase64 = reader["BoletaPdfBase64"] == DBNull.Value ? null : Convert.ToString(reader["BoletaPdfBase64"]);


                        model.IdSiguienteCita = reader["IdSiguienteCita"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["IdSiguienteCita"]);

                    }
                }

                if (reader.NextResult())
                {
                    while (await reader.ReadAsync())
                    {
                        model.EmisorRazonSocial = Convert.ToString(reader["EmisorRazonSocial"]);
                        model.EmisorTelefonos = Convert.ToString(reader["EmisorTelefonos"]);
                        model.EmisorDireccion = Convert.ToString(reader["EmisorDireccion"]);
                        model.EmisorRuc = Convert.ToString(reader["EmisorRuc"]);
                        model.EmisorDescripcion = Convert.ToString(reader["EmisorDescripcion"]);
                    }
                }*/

                return model;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        static async Task<ComprobanteElectronicoDTO> ReadBuscarComprobante(DbDataReader reader)
        {
            try
            {
                bool exito = true;
                string mensaje = "";
                string detalle = "";
                int codigoError = 0;

                while (await reader.ReadAsync())
                {
                    exito = Convert.ToBoolean(reader["Exito"]);
                    if (!exito)
                    {
                        mensaje = Convert.ToString(reader["Mensaje"]);
                        codigoError = Convert.ToInt32(reader["ErrorNumero"]);
                        detalle = Convert.ToString(reader["ErrorDetalle"]);
                        throw new AlertException(mensaje);
                    }
                }


                ComprobanteElectronicoDTO model = new ComprobanteElectronicoDTO();
                if (reader.NextResult())
                {
                    while (await reader.ReadAsync())
                    {
                        model.IdVenta = Convert.ToInt32(reader["IdVenta"]);


                        model.IdCliente = Convert.ToInt32(reader["IdCliente"]);
                        model.Cliente = Convert.ToString(reader["Cliente"]);
                        model.ClienteDocumento = Convert.ToString(reader["ClienteDocumento"]);

                        model.IdSede = Convert.ToInt32(reader["IdSede"]);
                        model.Sede = Convert.ToString(reader["Sede"]);

                        model.IdCita = Convert.ToInt32(reader["IdCita"]);

                        model.IdAtendidoPor = Convert.ToInt32(reader["IdAtendidoPor"]);
                        model.AtendidoPor = Convert.ToString(reader["AtendidoPor"]);

                        model.NumeroBox = Convert.ToInt32(reader["NumeroBox"]);

                        model.IdMaquinaMarca = Convert.ToInt32(reader["IdMaquinaMarca"]);
                        model.MaquinaMarca = Convert.ToString(reader["MaquinaMarca"]);

                        model.SiguienteCita = Convert.ToBoolean(reader["SiguienteCita"]);

                        model.IdTipoComprobante = Convert.ToInt32(reader["IdTipoComprobante"]);
                        model.TipoComprobante = Convert.ToString(reader["TipoComprobante"]);

                        //model.IdSerieComprobante = Convert.ToInt32(reader["IdSerieComprobante"]);
                        model.SerieComprobante = Convert.ToString(reader["SerieComprobante"]);
                        model.NumeroComprobante = Convert.ToString(reader["NumeroComprobante"]);

                        model.PorcentajeIgv = Convert.ToDecimal(reader["PorcentajeIgv"]);

                        model.DescuentoGlobal = Convert.ToDecimal(reader["DescuentoGlobal"]);
                        model.TotalDescuento = Convert.ToDecimal(reader["TotalDescuento"]);

                        model.TotalAnticipo = Convert.ToDecimal(reader["TotalAnticipo"]);

                        model.TotalOtros = Convert.ToDecimal(reader["TotalOtros"]);
                        model.TotalIsc = Convert.ToDecimal(reader["TotalIsc"]);

                        model.IdSunatTransaccion = reader["IdSunatTransaccion"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["IdSunatTransaccion"]);
                        model.SunatTransaccion = reader["SunatTransaccion"] == DBNull.Value ? null : Convert.ToString(reader["SunatTransaccion"]);
                        model.SunatTransaccionValor = reader["SunatTransaccionValor"] == DBNull.Value ? null : Convert.ToString(reader["SunatTransaccionValor"]);

                        model.IdTipoMoneda = Convert.ToInt32(reader["IdTipoMoneda"]);
                        model.TipoMoneda = Convert.ToString(reader["TipoMoneda"]);
                        model.TipoMonedaSimbolo = Convert.ToString(reader["TipoMonedaSimbolo"]);
                        model.TipoMonedaValor = Convert.ToString(reader["TipoMonedaValor"]);

                        model.TipoCambio = reader["TipoCambio"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(reader["TipoCambio"]);

                        model.IdTipoPago = Convert.ToInt32(reader["IdTipoPago"]);
                        model.TipoPago = Convert.ToString(reader["TipoPago"]);
                        //model.CodigoOperacion = DBNull.Value == reader["TipoPago"] ? null : Convert.ToString(reader["TipoPago"]);


                        model.IdEntidadTipoPago = reader["IdEntidadTipoPago"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["IdEntidadTipoPago"]);
                        model.EntidadTipoPago = reader["EntidadTipoPago"] == DBNull.Value ? null : Convert.ToString(reader["EntidadTipoPago"]);


                        model.Total = Convert.ToDecimal(reader["Total"]);

                        model.PagoEfectivo = Convert.ToDecimal(reader["PagoEfectivo"]);
                        model.PagoTarjeta = Convert.ToDecimal(reader["PagoTarjeta"]);
                        model.Recibido = Convert.ToDecimal(reader["Recibido"]);


                        model.Vuelto = Convert.ToDecimal(reader["Vuelto"]);

                        model.IdUsuarioRegistro = Convert.ToInt32(reader["IdUsuarioRegistro"]);
                        model.UsuarioRegistro = Convert.ToString(reader["UsuarioRegistro"]);
                        model.UsuarioRegistroNombre = Convert.ToString(reader["UsuarioRegistroNombre"]);


                        model.Detalles = new List<ComprobanteElectronicoDetalleDTO>(JsonSerializer.Deserialize<List<ComprobanteElectronicoDetalleDTO>>(Convert.ToString(reader["Detalles"])));
                       

                        model.FechaEmision = Convert.ToDateTime(reader["FechaEmision"]);




                        //model.SunatKey = reader["SunatKey"] == DBNull.Value ? null : Convert.ToString(reader["SunatKey"]);
                        //model.SunatUrlPdf = reader["SunatUrlPdf"] == DBNull.Value ? null : Convert.ToString(reader["SunatUrlPdf"]);
                        //model.SunatUrlXml = reader["SunatUrlXml"] == DBNull.Value ? null : Convert.ToString(reader["SunatUrlXml"]);
                        //model.SunatUrlCdr = reader["SunatUrlCdr"] == DBNull.Value ? null : Convert.ToString(reader["SunatUrlCdr"]);
                        //model.SunatCadenaQr = reader["SunatCadenaQr"] == DBNull.Value ? null : Convert.ToString(reader["SunatCadenaQr"]);
                        //model.SunatCadenaBarra = reader["SunatCadenaBarra"] == DBNull.Value ? null : Convert.ToString(reader["SunatCadenaBarra"]);
                        //model.SunatHash = reader["SunatHash"] == DBNull.Value ? null : Convert.ToString(reader["SunatHash"]);
                       // model.BoletaPdfBase64 = reader["BoletaPdfBase64"] == DBNull.Value ? null : Convert.ToString(reader["BoletaPdfBase64"]);


                        //model.IdSiguienteCita = reader["IdSiguienteCita"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["IdSiguienteCita"]);


                        List<ComprobanteElectronicoClienteDTO> cliente = new List<ComprobanteElectronicoClienteDTO>(JsonSerializer.Deserialize<List<ComprobanteElectronicoClienteDTO>>(Convert.ToString(reader["ComprobanteCliente"])));
                        if (cliente.Count > 0) {
                            model.ComprobanteCliente = cliente[0];
                        }

                        model.SubTotal = Convert.ToDecimal(reader["SubTotal"]);
                        model.Descuento = Convert.ToDecimal(reader["Descuento"]);
                        model.TotalIgv = Convert.ToDecimal(reader["TotalIgv"]);
                        model.TotalGratuita = Convert.ToDecimal(reader["TotalGratuita"]);
                        model.TotalInafecta = Convert.ToDecimal(reader["TotalInafecta"]);
                        model.TotalExonerada = Convert.ToDecimal(reader["TotalExonerada"]);

                    }
                }

                return model;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        static async Task<List<ComprobanteElectronicoReporteDTO>> ReadObtenerReporte(DbDataReader reader)
        {
            try
            {
                bool exito = true;
                string mensaje = "";
                string detalle = "";
                int codigoError = 0;

                while (await reader.ReadAsync())
                {
                    exito = Convert.ToBoolean(reader["Exito"]);
                    if (!exito)
                    {
                        mensaje = Convert.ToString(reader["Mensaje"]);
                        codigoError = Convert.ToInt32(reader["ErrorNumero"]);
                        detalle = Convert.ToString(reader["ErrorDetalle"]);
                        throw new AlertException(mensaje);
                    }
                }


                List<ComprobanteElectronicoReporteDTO> collection = new List<ComprobanteElectronicoReporteDTO>();
                if (reader.NextResult())
                {
                    while (await reader.ReadAsync())
                    {
                        ComprobanteElectronicoReporteDTO model = new ComprobanteElectronicoReporteDTO();

                        model.Id = Convert.ToInt32(reader["Id"]);
                        model.IdEstado = Convert.ToInt32(reader["IdEstado"]);
                        model.IdCita = Convert.ToInt32(reader["IdCita"]);
                        model.Serie = Convert.ToString(reader["Serie"]);
                        model.Numero = Convert.ToString(reader["Numero"]);
                        model.IdTipoComprobante = Convert.ToInt32(reader["IdTipoComprobante"]);
                        model.TipoComprobante = Convert.ToString(reader["TipoComprobante"]);
                        model.IdCliente = Convert.ToInt32(reader["IdCliente"]);
                        model.Cliente = Convert.ToString(reader["Cliente"]);
                        model.IdSede = Convert.ToInt32(reader["IdSede"]);
                        model.Sede = Convert.ToString(reader["Sede"]);
                        model.Total = Convert.ToDecimal(reader["Total"]);
                        model.FechaEmision =  Convert.ToDateTime(reader["FechaEmision"]);
                        model.FechaModifico = DBNull.Value == reader["FechaModifico"] ? (DateTime?)null : Convert.ToDateTime(reader["FechaModifico"]);
                        model.FechaRegistro = DBNull.Value == reader["FechaRegistro"] ? (DateTime?)null : Convert.ToDateTime(reader["FechaRegistro"]);
                        model.FechaPago = Convert.ToDateTime(reader["FechaPago"]);
                        model.UsuarioRegistro = Convert.ToString(reader["UsuarioRegistro"]);
                        model.UsuarioModifico = DBNull.Value == reader["UsuarioModifico"] ? null : Convert.ToString(reader["UsuarioModifico"]);

                        //model.EstadoSunat = DBNull.Value == reader["EstadoSunat"] ? null : Convert.ToString(reader["EstadoSunat"]);
                        model.AnuladoSunat = Convert.ToBoolean(reader["AnuladoSunat"]);

                        model.IdEstadoSunat = Convert.ToInt32(reader["IdEstadoSunat"]);
                        model.EstadoSunat = Convert.ToString(reader["EstadoSunat"]);
                        model.EstadoSunatColor = Convert.ToString(reader["EstadoSunatColor"]);

                        collection.Add(model);

                    }
                }


                return collection;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }


        static async Task<List<ComprobanteElectronicoReporteVentaDTO>> ReadObtenerReporteVenta(DbDataReader reader)
        {
            try
            {
                bool exito = true;
                string mensaje = "";
                string detalle = "";
                int codigoError = 0;

                while (await reader.ReadAsync())
                {
                    exito = Convert.ToBoolean(reader["Exito"]);
                    if (!exito)
                    {
                        mensaje = Convert.ToString(reader["Mensaje"]);
                        codigoError = Convert.ToInt32(reader["ErrorNumero"]);
                        detalle = Convert.ToString(reader["ErrorDetalle"]);
                        throw new AlertException(mensaje);
                    }
                }


                List<ComprobanteElectronicoReporteVentaDTO> collection = new List<ComprobanteElectronicoReporteVentaDTO>();
                if (reader.NextResult())
                {
                    while (await reader.ReadAsync())
                    {
                        ComprobanteElectronicoReporteVentaDTO model = new ComprobanteElectronicoReporteVentaDTO();

                        model.Id = Convert.ToInt32(reader["Id"]);
                        model.Fecha = Convert.ToDateTime(reader["Fecha"]);
                        model.Local = Convert.ToInt32(reader["Local"]);
                        model.Tipo = Convert.ToString(reader["Tipo"]);
                        model.Serie = Convert.ToString(reader["Serie"]);
                        model.Numero = Convert.ToInt32(reader["Numero"]);
                        model.Codigo = Convert.ToString(reader["Codigo"]);
                        model.Nombre = Convert.ToString(reader["Nombre"]);
                        model.M = Convert.ToString(reader["M"]);
                        model.BaseImp = Convert.ToDecimal(reader["BaseImp"]);
                        model.Impuesto = Convert.ToDecimal(reader["Impuesto"]);
                        model.Total = Convert.ToDecimal(reader["Total"]);

                        collection.Add(model);

                    }
                }

                return collection;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }


        static async Task<List<ComprobanteElectronicoReporteVentaClienteDTO>> ReadObtenerReporteVentaCliente(DbDataReader reader)
        {
            try
            {
                bool exito = true;
                string mensaje = "";
                string detalle = "";
                int codigoError = 0;

                while (await reader.ReadAsync())
                {
                    exito = Convert.ToBoolean(reader["Exito"]);
                    if (!exito)
                    {
                        mensaje = Convert.ToString(reader["Mensaje"]);
                        codigoError = Convert.ToInt32(reader["ErrorNumero"]);
                        detalle = Convert.ToString(reader["ErrorDetalle"]);
                        throw new AlertException(mensaje);
                    }
                }


                List<ComprobanteElectronicoReporteVentaClienteDTO> collection = new List<ComprobanteElectronicoReporteVentaClienteDTO>();
                if (reader.NextResult())
                {
                    while (await reader.ReadAsync())
                    {
                        ComprobanteElectronicoReporteVentaClienteDTO model = new ComprobanteElectronicoReporteVentaClienteDTO();

                        model.IdVenta = Convert.ToInt32(reader["IdVenta"]);
                        model.IdVentaDetalle = Convert.ToInt32(reader["IdVentaDetalle"]);
                        model.IdCliente = Convert.ToInt32(reader["IdCliente"]);
                        model.DocumentoCliente = DBNull.Value == reader["DocumentoCliente"] ? null : Convert.ToString(reader["DocumentoCliente"]);
                        model.NombreCliente = Convert.ToString(reader["NombreCliente"]);
                        model.ApellidoCliente = Convert.ToString(reader["ApellidoCliente"]);
                        model.IdProducto = Convert.ToInt32(reader["IdProducto"]);
                        model.Producto = Convert.ToString(reader["Producto"]);
                        model.Unidad = DBNull.Value == reader["Unidad"] ? null :Convert.ToString(reader["Unidad"]);
                        model.Factor = Convert.ToInt32(reader["Factor"]);
                        model.Cantidad = Convert.ToInt32(reader["Cantidad"]);
                        model.Total = Convert.ToDecimal(reader["Total"]);
                        model.Costo = Convert.ToDecimal(reader["Costo"]);
                        model.Ganancia = Convert.ToDecimal(reader["Ganancia"]);
                        model.Moneda = Convert.ToString(reader["Moneda"]);

                        collection.Add(model);

                    }
                }

                return collection;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        static async Task<List<ComprobanteElectronicoReporteVentaProductoDTO>> ReadObtenerReporteVentaProducto(DbDataReader reader)
        {
            try
            {
                bool exito = true;
                string mensaje = "";
                string detalle = "";
                int codigoError = 0;

                while (await reader.ReadAsync())
                {
                    exito = Convert.ToBoolean(reader["Exito"]);
                    if (!exito)
                    {
                        mensaje = Convert.ToString(reader["Mensaje"]);
                        codigoError = Convert.ToInt32(reader["ErrorNumero"]);
                        detalle = Convert.ToString(reader["ErrorDetalle"]);
                        throw new AlertException(mensaje);
                    }
                }


                List<ComprobanteElectronicoReporteVentaProductoDTO> collection = new List<ComprobanteElectronicoReporteVentaProductoDTO>();
                if (reader.NextResult())
                {
                    while (await reader.ReadAsync())
                    {
                        ComprobanteElectronicoReporteVentaProductoDTO model = new ComprobanteElectronicoReporteVentaProductoDTO();

                        model.IdVenta = Convert.ToInt32(reader["IdVenta"]);
                        model.IdVentaDetalle = Convert.ToInt32(reader["IdVentaDetalle"]);
                        model.IdProducto = Convert.ToInt32(reader["IdProducto"]);
                        model.Producto = Convert.ToString(reader["Producto"]);
                        model.IdTipoComprobante = Convert.ToInt32(reader["IdTipoComprobante"]);
                        model.SerieComprobante = Convert.ToString(reader["SerieComprobante"]);
                        model.NumeroComprobante = Convert.ToInt32(reader["NumeroComprobante"]);
                        model.IdCliente = Convert.ToInt32(reader["IdCliente"]);
                        model.DocumentoCliente = Convert.ToString(reader["DocumentoCliente"]);
                        model.NombreCliente = Convert.ToString(reader["NombreCliente"]);
                        model.ApellidoCliente = Convert.ToString(reader["ApellidoCliente"]);
                        model.Fecha = Convert.ToDateTime(reader["Fecha"]);
                        model.UnidadMedida = DBNull.Value == reader["UnidadMedida"] ? null : Convert.ToString(reader["UnidadMedida"]);
                        model.Factor = Convert.ToInt32(reader["Factor"]);
                        model.Cantidad = Convert.ToInt32(reader["Cantidad"]);
                        model.Precio = Convert.ToDecimal(reader["Precio"]);
                        model.Total = Convert.ToDecimal(reader["Total"]);
                        model.Moneda = Convert.ToString(reader["Moneda"]);
                        model.Usuario = Convert.ToString(reader["Usuario"]);
                        model.Caja = Convert.ToString(reader["Caja"]);
                        model.Turno = Convert.ToInt32(reader["Turno"]);
                        model.Estado = Convert.ToString(reader["Estado"]);
                        model.Comision = Convert.ToDecimal(reader["Comision"]);
                        model.TotalComision = Convert.ToDecimal(reader["TotalComision"]);

                        model.TipoIgv = Convert.ToString(reader["TipoIgv"]);


                        collection.Add(model);

                    }
                }

                return collection;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }


        static async Task<List<ComprobanteElectronicoReportePagoDTO>> ReadObtenerReportePago(DbDataReader reader)
        {
            try
            {
                bool exito = true;
                string mensaje = "";
                string detalle = "";
                int codigoError = 0;

                while (await reader.ReadAsync())
                {
                    exito = Convert.ToBoolean(reader["Exito"]);
                    if (!exito)
                    {
                        mensaje = Convert.ToString(reader["Mensaje"]);
                        codigoError = Convert.ToInt32(reader["ErrorNumero"]);
                        detalle = Convert.ToString(reader["ErrorDetalle"]);
                        throw new AlertException(mensaje);
                    }
                }


                List<ComprobanteElectronicoReportePagoDTO> collection = new List<ComprobanteElectronicoReportePagoDTO>();
                if (reader.NextResult())
                {
                    while (await reader.ReadAsync())
                    {
                        ComprobanteElectronicoReportePagoDTO model = new ComprobanteElectronicoReportePagoDTO();

                        model.Id = Convert.ToInt32(reader["Id"]);
                        model.Tipo = Convert.ToString(reader["Tipo"]);
                        model.Serie = Convert.ToString(reader["Serie"]);
                        model.Numero = Convert.ToInt32(reader["Numero"]);
                        model.Fecha = Convert.ToDateTime(reader["Fecha"]);
                        model.M = Convert.ToString(reader["M"]);
                        model.Tc = Convert.ToString(reader["TC"]);
                        model.Dias = DBNull.Value == reader["Dias"] ? (int?)null : Convert.ToInt32(reader["Dias"]);
                        model.Propina = DBNull.Value == reader["Propina"] ? (Decimal?)null : Convert.ToDecimal(reader["Propina"]);
                        model.Total = Convert.ToDecimal(reader["Total"]);
                        model.IdTipoPago = Convert.ToInt32(reader["IdTipoPago"]);
                        model.TipoPago = Convert.ToString(reader["TipoPago"]);
                        model.NumeroOperacion = Convert.ToString(reader["NumeroOperacion"]);
                        model.E = Convert.ToInt32(reader["E"]);
                        model.ObservacionFormaPago = Convert.ToString(reader["ObservacionFormaPago"]);
                        model.DocumentoCliente = Convert.ToString(reader["DocumentoCliente"]);
                        model.NombreCliente = Convert.ToString(reader["NombreCliente"]);
                        model.Usuario = Convert.ToString(reader["Usuario"]);
                        model.Caja = Convert.ToString(reader["Caja"]);
                        model.Turno = Convert.ToInt32(reader["Turno"]);
                        model.ObservacionComprobante = Convert.ToString(reader["ObservacionComprobante"]);

                        collection.Add(model);

                    }
                }

                return collection;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        static async Task<ComprobanteElectronicoConsultaDTO> ReadActualizarEstadoSunat(DbDataReader reader)
        {
            try
            {
                bool error = false;
                string errorMensaje = "";
                string errorDetalle = "";
                int errorCodigo = 0;

                ComprobanteElectronicoConsultaDTO obj = new ComprobanteElectronicoConsultaDTO();

                while (await reader.ReadAsync())
                {
                    obj.IdTipoComprobante = Convert.ToInt32(reader["IdTipoComprobante"]);
                    obj.Serie = Convert.ToString(reader["Serie"]);
                    obj.Numero = Convert.ToInt32(reader["Numero"]);
                    obj.IdEstadoSunat = Convert.ToInt32(reader["IdEstadoSunat"]);
                    obj.EstadoSunat = Convert.ToString(reader["EstadoSunat"]);
                    obj.EstadoSunatColor = Convert.ToString(reader["EstadoSunatColor"]);
                    obj.IdTipoComprobante = Convert.ToInt32(reader["IdTipoComprobante"]);

                    //return !error;
                    /*if (!error)
                    {
                        errorMensaje = Convert.ToString(reader["ErrorMensaje"]);
                        errorDetalle = Convert.ToString(reader["ErrorDetalle"]);
                        errorCodigo = Convert.ToInt32(reader["ErrorCodigo"]);
                        throw new AlertException(errorMensaje);
                    }*/
                }

                return obj;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        static async Task<ComprobanteElectronicoAnulacionDTO> ReadActualizarAnuladoSunat(DbDataReader reader)
        {
            try
            {
                bool error = false;
                string errorMensaje = "";
                string errorDetalle = "";
                int errorCodigo = 0;

                while (await reader.ReadAsync())
                {
                    error = Convert.ToBoolean(reader["Exito"]);
                    if (!error)
                    {
                        errorMensaje = Convert.ToString(reader["ErrorMensaje"]);
                        errorCodigo = Convert.ToInt32(reader["ErrorNumero"]);
                        errorDetalle = Convert.ToString(reader["ErrorDetalle"]);
                        throw new AlertException(errorMensaje);
                    }
                }

                ComprobanteElectronicoAnulacionDTO obj = new ComprobanteElectronicoAnulacionDTO();
                if (reader.NextResult())
                {
                    while (await reader.ReadAsync())
                    {
                        obj.IdTipoComprobante = Convert.ToInt32(reader["IdTipoComprobante"]);
                        obj.IdSede = Convert.ToInt32(reader["IdSede"]);
                        obj.Codigo = Convert.ToInt32(reader["Codigo"]);
                        obj.Serie = Convert.ToString(reader["Serie"]);
                        obj.Numero = Convert.ToInt32(reader["Numero"]);
                        obj.IdEstadoSunat = Convert.ToInt32(reader["IdEstadoSunat"]);
                        obj.EstadoSunat = Convert.ToString(reader["EstadoSunat"]);
                        obj.EstadoSunatColor = Convert.ToString(reader["EstadoSunatColor"]);
                    }
                }

                return obj;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }


        static async Task<bool> ReadAnularComprobanteSunat(DbDataReader reader)
        {
            try
            {
                bool error = false;
                string errorMensaje = "";
                string errorDetalle = "";
                int errorCodigo = 0;

                while (await reader.ReadAsync())
                {
                    error = Convert.ToBoolean(reader["Error"]);

                    return !error;
                    if (!error)
                    {
                        errorMensaje = Convert.ToString(reader["ErrorMensaje"]);
                        errorDetalle = Convert.ToString(reader["ErrorDetalle"]);
                        errorCodigo = Convert.ToInt32(reader["ErrorCodigo"]);
                        throw new AlertException(errorMensaje);
                    }
                }

                return error;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }


        static async Task<List<ComprobanteElectronicoDTO>> ReadObtenerNotasCredito(DbDataReader reader)
        {
            try
            {
                bool exito = true;
                string mensaje = "";
                string detalle = "";
                int codigoError = 0;

                while (await reader.ReadAsync())
                {
                    exito = Convert.ToBoolean(reader["Exito"]);
                    if (!exito)
                    {
                        mensaje = Convert.ToString(reader["Mensaje"]);
                        codigoError = Convert.ToInt32(reader["ErrorNumero"]);
                        detalle = Convert.ToString(reader["ErrorDetalle"]);
                        throw new AlertException(mensaje);
                    }
                }


                List<ComprobanteElectronicoDTO> collection = new List<ComprobanteElectronicoDTO>();
                if (reader.NextResult())
                {
                    while (await reader.ReadAsync())
                    {
                        ComprobanteElectronicoDTO model = new ComprobanteElectronicoDTO();

                        model.Id = Convert.ToInt32(reader["Id"]);
                        model.IdVenta = Convert.ToInt32(reader["IdVenta"]);
                        model.SerieComprobante = Convert.ToString(reader["Serie"]);
                        model.NumeroComprobante = Convert.ToString(reader["Numero"]);
                        model.IdTipoComprobante = Convert.ToInt32(reader["IdTipoComprobante"]);
                        model.TipoComprobante = Convert.ToString(reader["TipoComprobante"]);
                        model.TipoNotaCredito = Convert.ToString(reader["TipoNotaCredito"]);
                        model.IdCliente = Convert.ToInt32(reader["IdCliente"]);
                        model.IdSede = Convert.ToInt32(reader["IdSede"]);
                        model.Sede = Convert.ToString(reader["Sede"]);
                        model.Total = Convert.ToDecimal(reader["Total"]);
                        model.Observaciones = Convert.ToString(reader["Observaciones"]);


                        model.IdTipoComprobanteModifica = Convert.ToInt32(reader["IdTipoComprobanteModifica"]);
                        model.TipoComprobanteModifica = Convert.ToString(reader["TipoComprobanteModifica"]);
                        model.SerieComprobanteModifica = Convert.ToString(reader["SerieComprobanteModifica"]);
                        model.NumeroComprobanteModifica = Convert.ToString(reader["NumeroComprobanteModifica"]);


                        model.FechaEmision = Convert.ToDateTime(reader["FechaEmision"]);
                        model.UsuarioRegistro = Convert.ToString(reader["UsuarioRegistro"]);

                        model.SunatAnulado = Convert.ToBoolean(reader["SunatAnulado"]);

                        model.IdEstadoSunat = Convert.ToInt32(reader["IdEstadoSunat"]);
                        model.EstadoSunat = Convert.ToString(reader["EstadoSunat"]);
                        model.EstadoSunatColor = Convert.ToString(reader["EstadoSunatColor"]);

                        collection.Add(model);

                    }
                }


                return collection;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

    }
}
