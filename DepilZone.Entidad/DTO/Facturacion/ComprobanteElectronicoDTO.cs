using System;
using System.Collections.Generic;

namespace DepilZone.Entidad.DTO.Facturacion
{

    public class ComprobanteElectronicoConsultaDTO
    {
        public int IdTipoComprobante { get; set; }
        public int Numero { get; set; }
        public string Serie { get; set; }
        public int IdEstadoSunat { get; set; }
        public string EstadoSunat { get; set; }
        public string EstadoSunatColor { get; set; }


        /*model.SunatAcepto = respuestaSunat.aceptada_por_sunat;
        model.SunatDescripcion = respuestaSunat.sunat_description;
        model.SunatNota = respuestaSunat.sunat_note;
        model.SunatTicketNumero = respuestaSunat.GetType().GetProperty("sunat_ticket_numero") != null ? respuestaSunat.sunat_ticket_numero : null;
        model.SunatCodigoRespuesta = respuestaSunat.sunat_responsecode;
        model.SunatSoapError = respuestaSunat.sunat_soap_error;*/
    }

    public class ComprobanteElectronicoResultadoConsultaDTO {
        public string Serie { get; set; }
        public int Numero { get; set; }
        public int IdEstadoSunat { get; set; }
        public string EstadoSunat { get; set; }
    }

    public class ComprobanteElectronicoAnularDTO
    {
        public int IdUsuario { get; set; }
        public int IdSede { get; set; }
        public int IdVenta { get; set; }
        public int IdTipoComprobante { get; set; }
        public string Serie { get; set; }
        public string Numero { get; set; }
        public string Motivo { get; set; }
        public int Codigo { get; set; }



        public string SunatTicketNumero { get; set; }
        public bool SunatAcepto { get; set; }
        public string? SunatKey { get; set; }
        public string? SunatDescripcion { get; set; }
        public string? SunatNota { get; set; }
        public string? SunatCodigoRespuesta { get; set; }
        public string? SunatSoapError { get; set; }
        public string? SunatUrlPdf { get; set; }
        public string? SunatUrlXml { get; set; }
        public string? SunatUrlCdr { get; set; }

    }


    public class ComprobanteElectronicoMotivoAnuladoDTO
    {
        public int Id { get; set; }
        public int IdVenta { get; set; }
        public string Motivo { get; set; }
        public int IdUsuarioRegistro { get; set; }
        public string UsuarioRegistro { get; set; }
        public DateTime FechaRegistro { get; set; }

    }


    public class ComprobanteElectronicoDTO
    {
        public int Id { get; set; }
        public int IdVenta { get; set; }
        public int IdCliente { get; set; }
        public int IdCita { get; set; }
        public int IdSede { get; set; }

        public bool SiguienteCita { get; set; }
        public int NumeroMeses { get; set; }

        public int IdAtendidoPor { get; set; }
        public int NumeroBox { get; set; }
        public int IdMaquinaMarca { get; set; }
        public int IdTipoComprobante { get; set; }
        public int IdTipoComprobanteValor { get; set; }
        public string TipoComprobante { get; set; }
        public int? IdSerieComprobante { get; set; }
        public string? SerieComprobante { get; set; }
        public string NumeroComprobante { get; set; }

        public int? IdPorcentajeIgv { get; set; }
        public decimal? PorcentajeIgv { get; set; }

        public decimal DescuentoGlobal { get; set; }
        public decimal TotalDescuento { get; set; }
        public decimal TotalAnticipo { get; set; }
        public decimal TotalOtros { get; set; }
        public decimal TotalIsc { get; set; }

        public int? IdSunatTransaccion { get; set; }
        public string? SunatTransaccion { get; set; }
        public string? SunatTransaccionValor { get; set; }

        public int IdTipoMoneda { get; set; }
        public string TipoMoneda { get; set; }
        public string TipoMonedaValor { get; set; }
        public string TipoMonedaSimbolo { get; set; }
        public decimal? TipoCambio { get; set; }
        public int IdTipoPago { get; set; }
        public string TipoPago { get; set; }
        public string TipoPagoValor { get; set; }

        public string CodigoOperacion { get; set; }
        public int? IdEntidadTipoPago { get; set; }
        public string? EntidadTipoPago { get; set; }


        public decimal TotalGratuita { get; set; }
        public decimal TotalInafecta { get; set; }
        public decimal TotalExonerada { get; set; }
        public decimal TotalIgv { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Descuento { get; set; }
        public decimal Total { get; set; }


        public int? IdTipoPercepcion { get; set; }
        public decimal? PercepcionBaseImponible { get; set; }


        public decimal PagoEfectivo { get; set; }
        public decimal PagoTarjeta { get; set; }
        public decimal Recibido { get; set; }


        public decimal Vuelto { get; set; }
        public List<ComprobanteElectronicoDetalleDTO> Detalles { get; set; }

        public string UsuarioRegistro { get; set; }
        public string UsuarioRegistroNombre { get; set; }

        
        // respuesta sunat
        public string? SunatTicketNumero { get; set; }
        public string? SunatKey { get; set; }
        public string? SunatUrlPdf { get; set; }
        public string? SunatUrlXml { get; set; }
        public string? SunatUrlCdr { get; set; }
        public string? SunatCadenaQr { get; set; }
        public string? SunatCadenaBarra { get; set; }
        public string? SunatHash { get; set; }
        public string? SunatZipPdfBase64 { get; set; }


        public string? BoletaPdfBase64 { get; set; }

        // si hay siguiente cita
        public int? IdSiguienteCita { get; set; }

        // si hay detalles eliminados
        public List<int> IdDetallesEliminados { get; set; }



        // secondary

        public string Cliente { get; set; }
        public string ClienteDocumento { get; set; }
        public string? Sede { get; set; }
        public string AtendidoPor { get; set; }
        public string MaquinaMarca { get; set; }
        public int IdUsuarioRegistro { get; set; }
        public DateTime FechaEmision { get; set; }
        public DateTime? FechaVencimiento { get; set; }


        // inicio - datos cliente para el comprobante
        public int? IdClienteComprobante { get; set; }
        public string? ClienteDocumentoComprobante { get; set; }
        public string? ClienteDenominacionComprobante { get; set; }
        public string? ClienteDireccionComprobante { get; set; }
        public string? TipoDocumentoClienteValorComprobante { get; set; }
        // fin - datos cliente para el comprobante


        public string EmisorRazonSocial { get; set; }
        public string EmisorTelefonos { get; set; }
        public string EmisorDireccion { get; set; }
        public string EmisorRuc { get; set; }
        public string EmisorDescripcion { get; set; }



        public int Turno { get; set; }

        public string Observaciones { get; set; }
        public string Formato { get; set; }


        public ComprobanteElectronicoClienteDTO ComprobanteCliente { get; set; }


        public int? IdTipoComprobanteModifica { get; set; }
        public string? TipoComprobanteModifica { get; set; }
        public string? TipoComprobanteModificaValor { get; set; }
        public string? SerieComprobanteModifica { get; set; }
        public string? NumeroComprobanteModifica { get; set; }
        public int? IdTipoNotaCredito { get; set; }
        public string? TipoNotaCredito { get; set; }
        public string? TipoNotaCreditoValor { get; set; }
        public int? IdTipoNotaDebito { get; set; }
        public int? TipoNotaDebitoValor { get; set; }


        public bool SunatAnulado { get; set; }
        public bool SunatAcepto { get; set; }
        public string? SunatDescripcion { get; set; }
        public string? SunatNota { get; set; }
        public string? SunatCodigoRespuesta { get; set; }
        public string? SunatSoapError { get; set; }


        public string? SunatEstado { get; set; }


        public int IdEstadoSunat { get; set; }
        public string EstadoSunat { get; set; }
        public string EstadoSunatColor { get; set; }



        public Invoice crearComprobanteElectronico(ComprobanteElectronicoDTO model)
        {
            ///CREAMOS EL JSON
            Invoice invoice = new Invoice();
            invoice.operacion = "generar_comprobante";
            invoice.tipo_de_comprobante = model.IdTipoComprobanteValor;
            invoice.serie = model.SerieComprobante;
            invoice.numero = Convert.ToInt32(model.NumeroComprobante);
            invoice.sunat_transaction = (int)model.IdSunatTransaccion;
            invoice.cliente_tipo_de_documento = model.TipoDocumentoClienteValorComprobante;
            invoice.cliente_numero_de_documento = model.ClienteDocumentoComprobante;
            invoice.cliente_denominacion = model.ClienteDenominacionComprobante;
            invoice.cliente_direccion = model.ClienteDireccionComprobante;
            invoice.cliente_email = "";
            invoice.cliente_email_1 = "";
            invoice.cliente_email_2 = "";
            invoice.fecha_de_emision = DateTime.Now;
            invoice.fecha_de_vencimiento = DateTime.Now;
            invoice.moneda = Convert.ToInt32(model.TipoMonedaValor);
            invoice.tipo_de_cambio = model.TipoCambio == null ? "" : model.TipoCambio.ToString();
            invoice.porcentaje_de_igv = model.PorcentajeIgv == null ? 00.00 : Math.Round(Convert.ToDouble(model.PorcentajeIgv), 2);
            invoice.descuento_global = "";
            invoice.total_descuento = "";
            invoice.total_anticipo = "";
            invoice.total_gravada = Math.Round(model.SubTotal, 2);
            invoice.total_inafecta = Math.Round(model.TotalInafecta, 2);
            invoice.total_exonerada = Math.Round(model.TotalExonerada, 2);
            invoice.total_igv = Math.Round(Convert.ToDouble(model.TotalIgv), 2);
            invoice.total_gratuita = Math.Round(model.TotalGratuita, 2);
            invoice.total_otros_cargos = "";
            invoice.total = Math.Round(Convert.ToDouble(model.Total), 2);
            invoice.percepcion_tipo = "";
            invoice.percepcion_base_imponible = "";
            invoice.total_percepcion = "";
            invoice.detraccion = false;
            invoice.observaciones = model.Observaciones;
            invoice.documento_que_se_modifica_tipo = "";
            invoice.documento_que_se_modifica_serie = "";
            invoice.documento_que_se_modifica_numero = "";
            invoice.tipo_de_nota_de_credito = "";
            invoice.tipo_de_nota_de_debito = "";
            invoice.enviar_automaticamente_a_la_sunat = true;
            invoice.enviar_automaticamente_al_cliente = false;
            invoice.codigo_unico = "";
            invoice.condiciones_de_pago = "";
            invoice.medio_de_pago = model.TipoPagoValor + ": " + model.TipoMonedaSimbolo + model.Recibido ;
            invoice.placa_vehiculo = "";
            invoice.orden_compra_servicio = "";
            invoice.tabla_personalizada_codigo = "";
            invoice.formato_de_pdf = model.Formato;
            invoice.items = new List<Items>();
            model.Detalles.ForEach(x =>
            {
                invoice.items.Add(
                    new Items()
                    {
                        unidad_de_medida = x.UnidadMedidaValor,
                        codigo = Convert.ToString(x.IdZona),
                        descripcion = x.Zona + '\n' + ((x.Detalle is null) ? "" : x.Detalle),
                        cantidad = x.Cantidad ,
                        //valor_unitario = Math.Round(Convert.ToDouble(x.ValorUnitario), 2),
                        //precio_unitario = Math.Round(Convert.ToDouble(x.Precio), 2),
                        valor_unitario = Convert.ToDouble(x.ValorUnitario),
                        precio_unitario = Convert.ToDouble(x.Precio),
                        //descuento = "",
                        subtotal = ( Convert.ToDouble(x.ValorUnitario) * x.Cantidad ),
                        tipo_de_igv = x.IdTipoIgv,
                        igv = Convert.ToDouble(x.Igv),
                        total = Convert.ToDouble(x.Precio),
                        anticipo_regularizacion = false,
                        anticipo_comprobante_serie = "",
                        anticipo_comprobante_numero = "",

                        impuesto_bolsas = Convert.ToDouble(x.ImpBolsaTotal)
                    });
            });

            return invoice;
        }

        public Invoice crearComprobanteNotaCredito(ComprobanteElectronicoDTO model)
        {
            ///CREAMOS EL JSON
            Invoice invoice = new Invoice();
            invoice.operacion = "generar_comprobante";
            invoice.tipo_de_comprobante = 3; // NOTA DE CRÉDITO
            invoice.serie = model.SerieComprobante;
            invoice.numero = Convert.ToInt32(model.NumeroComprobante);
            invoice.sunat_transaction = Convert.ToInt32( model.SunatTransaccionValor );
            invoice.cliente_tipo_de_documento = model.ComprobanteCliente.TipoDocumentoValor;
            invoice.cliente_numero_de_documento = model.ComprobanteCliente.NumeroDocumento;
            invoice.cliente_denominacion = model.ComprobanteCliente.Nombre;
            invoice.cliente_direccion = model.ComprobanteCliente.Direccion == null ? "" : model.ComprobanteCliente.Direccion;
            invoice.cliente_email = "";
            invoice.cliente_email_1 = "";
            invoice.cliente_email_2 = "";
            invoice.fecha_de_emision = DateTime.Now;
            invoice.fecha_de_vencimiento = DateTime.Now;
            invoice.moneda = Convert.ToInt32(model.TipoMonedaValor);
            invoice.tipo_de_cambio = model.TipoCambio == null ? "" : model.TipoCambio.ToString();
            invoice.porcentaje_de_igv = model.PorcentajeIgv == null ? 00.00 : Math.Round(Convert.ToDouble(model.PorcentajeIgv), 2);
            invoice.descuento_global = model.DescuentoGlobal;
            invoice.total_descuento = model.TotalDescuento;
            invoice.total_anticipo = model.TotalAnticipo;
            invoice.total_gravada = Math.Round(model.SubTotal, 2);
            invoice.total_inafecta = Math.Round(model.TotalInafecta, 2);
            invoice.total_exonerada = Math.Round(model.TotalExonerada, 2);
            invoice.total_igv = Math.Round(Convert.ToDouble(model.TotalIgv), 2);
            invoice.total_gratuita = Math.Round(model.TotalGratuita, 2);
            invoice.total_otros_cargos = model.TotalOtros;
            invoice.total = Math.Round(Convert.ToDouble(model.Total), 2);
            invoice.percepcion_tipo = "";
            invoice.percepcion_base_imponible = "";
            invoice.total_percepcion = "";
            invoice.detraccion = false;
            invoice.observaciones = model.Observaciones;
            invoice.documento_que_se_modifica_tipo = model.TipoComprobanteModificaValor;
            invoice.documento_que_se_modifica_serie = model.SerieComprobanteModifica;
            invoice.documento_que_se_modifica_numero = model.NumeroComprobanteModifica;
            invoice.tipo_de_nota_de_credito = model.TipoNotaCreditoValor;
            invoice.tipo_de_nota_de_debito = "";
            invoice.enviar_automaticamente_a_la_sunat = true;
            invoice.enviar_automaticamente_al_cliente = false;
            invoice.codigo_unico = "";
            invoice.condiciones_de_pago = "";
            invoice.medio_de_pago = "";
            invoice.placa_vehiculo = "";
            invoice.orden_compra_servicio = "";
            invoice.tabla_personalizada_codigo = "";
            invoice.formato_de_pdf = model.Formato;
            invoice.items = new List<Items>();
            model.Detalles.ForEach(x =>
            {
                invoice.items.Add(
                    new Items()
                    {
                        unidad_de_medida = x.UnidadMedidaValor,
                        codigo = Convert.ToString(x.IdZona),
                        descripcion = x.Zona + '\n' + ((x.Detalle is null) ? "" : x.Detalle),
                        cantidad = x.Cantidad,
                        //valor_unitario = Math.Round(Convert.ToDouble(x.ValorUnitario), 2),
                        //precio_unitario = Math.Round(Convert.ToDouble(x.Precio), 2),
                        valor_unitario = Convert.ToDouble(x.ValorUnitario),
                        precio_unitario = Convert.ToDouble(x.Precio),
                        //descuento = "",
                        subtotal = (Convert.ToDouble(x.ValorUnitario) * x.Cantidad),
                        tipo_de_igv = Convert.ToInt32(x.TipoIgvValor),
                        igv = Convert.ToDouble(x.Igv),
                        total = Convert.ToDouble(x.Precio),
                        anticipo_regularizacion = false,
                        anticipo_comprobante_serie = "",
                        anticipo_comprobante_numero = "",

                        impuesto_bolsas = Convert.ToDouble(x.ImpBolsaTotal)
                    });
            });

            return invoice;
        }


        public Invoice crearConsultaComprobante(string tipoComprobante, string serie, string numero) 
        {
            ///CREAMOS EL JSON
            Invoice invoice = new Invoice();
            invoice.operacion = "consultar_comprobante";
            invoice.tipo_de_comprobante = Convert.ToInt32(tipoComprobante);
            invoice.serie = serie;
            invoice.numero = Convert.ToInt32(numero);

            return invoice;
        }

        public Invoice crearAnulacionComprobante(string tipoComprobante, string serie, string numero, string motivo)
        {
            ///CREAMOS EL JSON
            Invoice invoice = new Invoice();
            invoice.operacion = "generar_anulacion";
            invoice.tipo_de_comprobante = Convert.ToInt32(tipoComprobante);
            invoice.serie = serie;
            invoice.numero = Convert.ToInt32(numero);
            invoice.motivo = motivo;

            return invoice;
        }

        public Invoice crearConsultaAnulacionComprobante(string tipoComprobanteValor, string serie, string numero)
        {
            ///CREAMOS EL JSON
            Invoice invoice = new Invoice();
            invoice.operacion = "consultar_anulacion";
            invoice.tipo_de_comprobante = Convert.ToInt32(tipoComprobanteValor);
            invoice.serie = serie;
            invoice.numero = Convert.ToInt32(numero);

            return invoice;
        }
    }


    public class ComprobanteElectronicoClienteDTO { 
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string? Direccion { get; set; }
        public string NumeroDocumento { get; set; }
        public int IdTipoDocumento { get; set; }
        public string TipoDocumento { get; set; }
        public string TipoDocumentoValor { get; set; }
        public string? Email { get; set; }
        public string? Email1 { get; set; }
        public string? Email2 { get; set; }
    }


    public class ComprobanteElectronicoDetalleDTO
    {
        public int Id { get; set; }
        public int IdCitaDetalle { get; set; }
        public int Cantidad { get; set; }
        public int IdCita { get; set; }
        public int IdVenta { get; set; }
        public int Sesion { get; set; }
        public int IdZona { get; set; }
       
        public string UsuarioRegistra { get; set; }
        public DateTime FechaRegistra { get; set; }

        // secondary
        public int? IdUnidadMedida { get; set; }
        public string? UnidadMedida { get; set; }
        public string? UnidadMedidaValor { get; set; }
        public string Zona { get; set; }

        public decimal Precio { get; set; }
        public decimal Importe { get; set; }
        public decimal ValorUnitario { get; set; }
        public int IdTipoIgv { get; set; }
        public string TipoIgvValor { get; set; }
        public Decimal Igv { get; set; }
        public Decimal SubTotal { get; set; }
        public Decimal Total { get; set; }
        public string? Detalle { get; set; }
        public bool ImpBolsa { get; set; }
        public Decimal ImpBolsaTotal { get; set; }

        // tipos igv
        public decimal GratuitaTotal { get; set; }
        public decimal InafectaTotal { get; set; }
        public decimal ExoneradaTotal { get; set; }

    }


    public class ComprobanteElectronicoReporteDTO
    {
        public int Id { get; set; }
        public int IdEstado { get; set; }
        public int IdCita { get; set; }
        public string Serie { get; set; }
        public string Numero { get; set; }
        public int IdCliente { get; set; }
        public string Cliente { get; set; }
        public int IdTipoComprobante { get; set; }
        public string TipoComprobante { get; set; }
        public int IdSede { get; set; }
        public string Sede { get; set; }
        public decimal Total { get; set; }
        public string UsuarioRegistro { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public DateTime FechaPago{ get; set; }
        public DateTime FechaEmision { get; set; }
        public string? UsuarioModifico { get; set; }
        public DateTime? FechaModifico { get; set; }

        public int IdEstadoSunat { get; set; }
        public string EstadoSunat { get; set; }
        public string EstadoSunatColor { get; set; }
        public bool AnuladoSunat { get; set; }

    }


    public class ComprobanteElectronicoReporteVentaDTO
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int Local { get; set; }
        public string Tipo { get; set; }
        public string Serie { get; set; }
        public int Numero { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string M { get; set; }
        public decimal BaseImp { get; set; }
        public decimal Impuesto { get; set; }
        public decimal Total { get; set; }

    }


    public class ComprobanteElectronicoReportePagoDTO
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public string Serie { get; set; }
        public int Numero { get; set; }
        public DateTime Fecha { get; set; }
        public string M { get; set; }
        public string Tc { get; set; }
        public int? Dias { get; set; }
        public Decimal? Propina { get; set; }
        public decimal Total { get; set; }
        public int IdTipoPago { get; set; }
        public string TipoPago { get; set; }
        public string NumeroOperacion { get; set; }
        public int E { get; set; }
        public string ObservacionFormaPago { get; set; }
        public string DocumentoCliente { get; set; }
        public string NombreCliente { get; set; }
        public string Usuario { get; set; }
        public string Caja { get; set; }
        public int Turno { get; set; }
        public string ObservacionComprobante { get; set; }
    }

    public class ComprobanteElectronicoReporteVentaClienteDTO
    {
        public int IdVenta { get; set; }
        public int IdVentaDetalle { get; set; }
        public int IdCliente { get; set; }
        public string? DocumentoCliente { get; set; }
        public string NombreCliente { get; set; }
        public string ApellidoCliente { get; set; }
        public int IdProducto { get; set; }
        public string Producto { get; set; }
        public string? Unidad { get; set; }
        public int Factor { get; set; }
        public int Cantidad { get; set; }
        public Decimal Total { get; set; }
        public Decimal Costo { get; set; }
        public Decimal Ganancia { get; set; }
        public string Moneda { get; set; }
    }

    public class ComprobanteElectronicoReporteVentaProductoDTO
    {
        public int IdVenta { get; set; }
        public int IdVentaDetalle { get; set; }
        public int IdProducto { get; set; }
        public string Producto { get; set; }
        public int IdTipoComprobante { get; set; }
        public string SerieComprobante { get; set; }
        public int NumeroComprobante { get; set; }
        public int IdCliente { get; set; }
        public string DocumentoCliente { get; set; }
        public string NombreCliente { get; set; }
        public string ApellidoCliente { get; set; }
        public DateTime Fecha { get; set; }
        public string? UnidadMedida { get; set; }
        public int Factor { get; set; }
        public int Cantidad { get; set; }
        public Decimal Precio { get; set; }
        public Decimal Total { get; set; }
        public string Moneda { get; set; }
        public string Usuario { get; set; }
        public string Caja { get; set; }
        public int Turno { get; set; }
        public string Estado { get; set; }
        public Decimal Comision { get; set; }
        public Decimal TotalComision { get; set; }

        public string TipoIgv { get; set; }

    }



    /// CREAMOS LAS CLASES PARA CONSTRUIR EL JSON Y LEER LA RESPUESTA EN JSON PARA EL COMPROBANTE ELECTRÓNICO
    public class Invoice
    {
        public string operacion { get; set; }
        public int tipo_de_comprobante { get; set; }
        public string serie { get; set; }
        public int numero { get; set; }
        public int sunat_transaction { get; set; }
        public string cliente_tipo_de_documento { get; set; }
        public string cliente_numero_de_documento { get; set; }
        public string cliente_denominacion { get; set; }
        public string cliente_direccion { get; set; }
        public string cliente_email { get; set; }
        public string cliente_email_1 { get; set; }
        public string cliente_email_2 { get; set; }
        public DateTime fecha_de_emision { get; set; }
        public DateTime fecha_de_vencimiento { get; set; }
        public int moneda { get; set; }
        public dynamic tipo_de_cambio { get; set; } //? MAKES NATURAL TYPES NULLABLE
        public double porcentaje_de_igv { get; set; }
        public dynamic descuento_global { get; set; }
        public dynamic total_descuento { get; set; }
        public dynamic total_anticipo { get; set; }
        public dynamic total_gravada { get; set; }
        public dynamic total_inafecta { get; set; }
        public dynamic total_exonerada { get; set; }
        public double total_igv { get; set; }
        public dynamic total_gratuita { get; set; }
        public dynamic total_otros_cargos { get; set; }
        public double total { get; set; }
        public dynamic percepcion_tipo { get; set; }
        public dynamic percepcion_base_imponible { get; set; }
        public dynamic total_percepcion { get; set; }
        public dynamic total_incluido_percepcion { get; set; }
        public bool detraccion { get; set; }
        public string observaciones { get; set; }
        public dynamic documento_que_se_modifica_tipo { get; set; }
        public string documento_que_se_modifica_serie { get; set; }
        public dynamic documento_que_se_modifica_numero { get; set; }
        public dynamic tipo_de_nota_de_credito { get; set; }
        public dynamic tipo_de_nota_de_debito { get; set; }
        public bool enviar_automaticamente_a_la_sunat { get; set; }
        public bool enviar_automaticamente_al_cliente { get; set; }
        public string codigo_unico { get; set; }
        public string condiciones_de_pago { get; set; }
        public string medio_de_pago { get; set; }
        public string placa_vehiculo { get; set; }
        public string orden_compra_servicio { get; set; }
        public string tabla_personalizada_codigo { get; set; }
        public string formato_de_pdf { get; set; }
        public List<Items> items { get; set; }
        public List<Guias> guias { get; set; }
        

        // secondary
        public string motivo { get; set; }
    }

    public class Items
    {
        public string unidad_de_medida { get; set; }
        public string codigo { get; set; }
        public string descripcion { get; set; }
        public double cantidad { get; set; }
        public double valor_unitario { get; set; }
        public double precio_unitario { get; set; }
        public dynamic descuento { get; set; }
        public double subtotal { get; set; }
        public int tipo_de_igv { get; set; }
        public double igv { get; set; }
        public double total { get; set; }
        public bool anticipo_regularizacion { get; set; }
        public dynamic anticipo_comprobante_serie { get; set; }
        public dynamic anticipo_comprobante_numero { get; set; }
        public double impuesto_bolsas { get; set; }

    }

    public class Guias
    {
        public int guia_tipo { get; set; }
        public string guia_serie_numero { get; set; }
    }

    public class Respuesta
    {
        public string errors { get; set; }
        public int tipo { get; set; }
        public string serie { get; set; }
        public int numero { get; set; }
        public string url { get; set; }
        public bool aceptada_por_sunat { get; set; }
        public string sunat_description { get; set; }
        public string sunat_note { get; set; }
        public string sunat_responsecode { get; set; }
        public string sunat_soap_error { get; set; }
        public string pdf_zip_base64 { get; set; }
        public string xml_zip_base64 { get; set; }
        public string cdr_zip_base64 { get; set; }
        public string cadena_para_codigo_qr { get; set; }
        public string codigo_hash { get; set; }
        public string codigo_de_barras { get; set; }
        public string key { get; set; }
        public string enlace_del_pdf { get; set; }
        public string enlace_del_xml { get; set; }
        public string enlace_del_cdr { get; set; }

        //public Invoice invoice { get; set; }
    }

}