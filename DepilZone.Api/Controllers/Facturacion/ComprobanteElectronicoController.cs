using DepilZone.Application.Interface;
using DepilZone.Application.Interface.Facturacion;
using DepilZone.Data.Response;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO.Facturacion;
using DepilZone.Entidad.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace DepilZone.Api.Controllers.Facturacion
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComprobanteElectronicoController : ControllerBase
    {

        private readonly IComprobanteElectronicoApp _IComprobanteElectronicoAp;
        private readonly IComprobanteSerieApp _IComprobanteSerieApp;
        private readonly IFacturaTokenApp _IFacturaTokenApp;
        private readonly ITipoComprobanteApp _ITipoComprobanteApp;
        private readonly IEmpresaApp _IEmpresaApp;
        public ComprobanteElectronicoController(IComprobanteElectronicoApp ComprobanteElectronicoApp, IFacturaTokenApp IFacturaTokenApp, IEmpresaApp IEmpresaApp, IComprobanteSerieApp IComprobanteSerieApp, ITipoComprobanteApp ITipoComprobanteApp)
        {
            _IComprobanteElectronicoAp = ComprobanteElectronicoApp;
            _IFacturaTokenApp = IFacturaTokenApp;
            _IEmpresaApp = IEmpresaApp;
            _IComprobanteSerieApp = IComprobanteSerieApp;
            _ITipoComprobanteApp = ITipoComprobanteApp;
        }



        [HttpPost("punto-venta/{idCita}")]
        public async Task<ActionResult> RegistrarVentaComprobante(ComprobanteElectronicoDTO model, int idCita)
        {

            try
            {
                FacturaTokenDTO facturaToken;
                List<EmpresaEnt> empresa;
                //Invoice invoice = null;
                ComprobanteElectronicoDTO comprobanteElectronicoDTO = new ComprobanteElectronicoDTO();


                ComprobanteElectronicoDTO venta = await _IComprobanteElectronicoAp.EmitirComprobante(model, idCita);


                if (model.IdTipoComprobante != (int)TipoComprobante.Ticket)
                {

                    facturaToken = await _IFacturaTokenApp.BuscarPorSede(model.IdUsuarioRegistro, model.IdSede);
                    /**var e = await _IEmpresaApp.Obtener();
                    empresa = e.ToList();
                    if (empresa.Count == 0) {
                        AlertException alerta = new AlertException("La empresa emisora no esta registrada");
                        throw alerta;
                    }**/

                    //model.EmisorDireccion = empresa[0].DireccionEmisor;
                    //model.EmisorDescripcion = "Somos DEPILZONE Centro especializado en Depilación Láser, con más de 8 años de experiencia";
                    //model.EmisorRazonSocial = empresa[0].RazonSocialEmisor;
                    //model.EmisorRuc = empresa[0].RucEmisor;
                    //model.EmisorTelefonos = "asdfasdfasd";

                    var invoice = comprobanteElectronicoDTO.crearComprobanteElectronico(model);

                    /// #########################################################
                    /// #### PASO 2: GENERAR EL ARCHIVO PARA ENVIAR A NUBEFACT ####
                    /// +++++++++++++++++++++++++++++++++++++++++++++++++++++++
                    /// # - MANUAL para archivo JSON en el link: https://goo.gl/WHMmSb
                    /// # - MANUAL para archivo TXT en el link: https://goo.gl/Lz7hAq
                    /// +++++++++++++++++++++++++++++++++++++++++++++++++++++++

                    string json = JsonSerializer.Serialize(invoice);
                    //Console.WriteLine(json);
                    byte[] bytes = Encoding.Default.GetBytes(json);
                    string json_en_utf_8 = Encoding.UTF8.GetString(bytes);

                    /// #########################################################
                    /// #### PASO 3: ENVIAR EL ARCHIVO A NUBEFACT ####
                    /// +++++++++++++++++++++++++++++++++++++++++++++++++++++++
                    /// # SI ESTÁS TRABAJANDO CON ARCHIVO JSON
                    /// # - Debes enviar en el HEADER de tu solicitud la siguiente lo siguiente:
                    /// # Authorization = Token token="8d19d8c7c1f6402687720eab85cd57a54f5a7a3fa163476bbcf381ee2b5e0c69"
                    /// # Content-Type = application/json
                    /// # - Adjuntar en el CUERPO o BODY el archivo JSON o TXT
                    /// # SI ESTÁS TRABAJANDO CON ARCHIVO TXT
                    /// # - Debes enviar en el HEADER de tu solicitud la siguiente lo siguiente:
                    /// # Authorization = Token token="8d19d8c7c1f6402687720eab85cd57a54f5a7a3fa163476bbcf381ee2b5e0c69"
                    /// # Content-Type = text/plain
                    /// # - Adjuntar en el CUERPO o BODY el archivo JSON o TXT
                    /// +++++++++++++++++++++++++++++++++++++++++++++++++++++++

                    string json_de_respuesta = SendJson(facturaToken.Ruta, json_en_utf_8, facturaToken.Token, "POST");
                    dynamic r = JsonSerializer.Deserialize<Respuesta>(json_de_respuesta);
                    string r2 = JsonSerializer.Serialize(r);
                    dynamic json_r_in = JsonSerializer.Deserialize<Respuesta>(r2);

                    ///#########################################################
                    ///#### PASO 4: LEER RESPUESTA DE NUBEFACT ####
                    ///+++++++++++++++++++++++++++++++++++++++++++++++++++++++
                    ///# Recibirás una respuesta de NUBEFACT inmediatamente lo cual se debe leer, verificando que no haya errores.
                    ///# Debes guardar en la base de datos la respuesta que te devolveremos.
                    ///# Escríbenos a soporte@nubefact.com o llámanos al teléfono: 01 468 3535 (opción 2) o celular (WhatsApp) 955 598762
                    ///# Puedes imprimir el PDF que nosotros generamos como también generar tu propia representación impresa previa coordinación con nosotros.
                    ///# La impresión del documento seguirá haciéndose desde tu sistema. Enviaremos el documento por email a tu cliente si así lo indicas en el archivo JSON o TXT.
                    ///+++++++++++++++++++++++++++++++++++++++++++++++++++++++

                    dynamic respuestaSunat = JsonSerializer.Deserialize<Respuesta>(json_de_respuesta);


                    /*return Ok(new
                    {
                        data = respuestaSunat,
                        message = respuestaSunat.errors,
                        status = StatusCodes.Status400BadRequest
                    });*/

                    if (respuestaSunat.errors != null)
                    {
                        return Ok(new
                        {
                            data = new { },
                            message = respuestaSunat.errors,
                            status = StatusCodes.Status400BadRequest
                        });
                    }

                    model.SunatAcepto = respuestaSunat.aceptada_por_sunat;
                    model.SunatDescripcion = respuestaSunat.sunat_description;
                    model.SunatNota = respuestaSunat.sunat_note;
                    model.SunatCodigoRespuesta = respuestaSunat.sunat_responsecode;
                    model.SunatSoapError = respuestaSunat.sunat_soap_error;
                    model.SunatAnulado = respuestaSunat.anulado;

                    model.SerieComprobante = respuestaSunat.serie;
                    model.SunatKey = respuestaSunat.key;
                    model.SunatUrlCdr = respuestaSunat.enlace_del_cdr;
                    model.SunatUrlPdf = respuestaSunat.enlace_del_pdf;
                    model.SunatUrlXml = respuestaSunat.enlace_del_xml;
                    model.SunatHash = respuestaSunat.codigo_hash;
                    model.SunatCadenaQr = respuestaSunat.cadena_para_codigo_qr;
                    model.SunatCadenaBarra = respuestaSunat.codigo_de_barras;
                    //model.SunatZipPdfBase64 = respuestaSunat.pdf_zip_base64;

                    using (HttpClient client = new HttpClient())
                    {
                        client.DefaultRequestHeaders
                              .Accept
                              .Add(new MediaTypeWithQualityHeaderValue("application/pdf"));
                        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 |
                                                               SecurityProtocolType.Tls12;

                        using (HttpResponseMessage response = await client.GetAsync(respuestaSunat.enlace_del_pdf))
                        {

                            byte[] dd = await response.Content.ReadAsByteArrayAsync();
                            model.BoletaPdfBase64 = Convert.ToBase64String(dd);
                        }
                    }

                    /*bool actualizarNumero = await _IComprobanteSerieApp.ActualizarNumero(Convert.ToInt32(model.IdSerieComprobante), (Convert.ToInt32(model.NumeroComprobante) + 1), model.IdUsuarioRegistro);

                    if (!actualizarNumero)
                    {
                        return Ok(new
                        {
                            data = new { },
                            message = "Se registro el comprobante " + model.SerieComprobante + "-" + model.NumeroComprobante + ", pero no se pudo actualizar el número de serie en el contador",
                            status = StatusCodes.Status400BadRequest
                        });
                    }*/

                    ComprobanteElectronicoDTO output = await _IComprobanteElectronicoAp.EmitirComprobante(model, idCita);


                    return Ok(new
                    {
                        data = output,
                        message = "",
                        status = StatusCodes.Status201Created
                    });


                    /*return Ok(new
                    {
                        data = respuestaSunat,
                        error = "",
                        status = StatusCodes.Status201Created
                    });*/

                }


                var d = await _IComprobanteElectronicoAp.EmitirComprobante(model, idCita);

                return Ok(new
                {
                    data = d,
                    message = "",
                    status = StatusCodes.Status201Created
                });
            }
            catch (AlertException ex)
            {
                return Ok(new
                {
                    data = new { },
                    message = ex.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    data = new { },
                    message = ex.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
        }



        [HttpPost("emitir-comprobante/{idCita}")]
        public async Task<ActionResult> EmitirComprobante(ComprobanteElectronicoDTO model, int idCita)
        {

            try
            {
                FacturaTokenDTO facturaToken;
                List<EmpresaEnt> empresa;
                //Invoice invoice = null;
                ComprobanteElectronicoDTO comprobanteElectronicoDTO = new ComprobanteElectronicoDTO();


                


                if (model.IdTipoComprobante != (int)TipoComprobante.Ticket)
                {

                    facturaToken = await _IFacturaTokenApp.BuscarPorSede(model.IdUsuarioRegistro, model.IdSede);
                    /**var e = await _IEmpresaApp.Obtener();
                    empresa = e.ToList();
                    if (empresa.Count == 0) {
                        AlertException alerta = new AlertException("La empresa emisora no esta registrada");
                        throw alerta;
                    }**/

                    //model.EmisorDireccion = empresa[0].DireccionEmisor;
                    //model.EmisorDescripcion = "Somos DEPILZONE Centro especializado en Depilación Láser, con más de 8 años de experiencia";
                    //model.EmisorRazonSocial = empresa[0].RazonSocialEmisor;
                    //model.EmisorRuc = empresa[0].RucEmisor;
                    //model.EmisorTelefonos = "asdfasdfasd";

                    var invoice = comprobanteElectronicoDTO.crearComprobanteElectronico(model);

                    /// #########################################################
                    /// #### PASO 2: GENERAR EL ARCHIVO PARA ENVIAR A NUBEFACT ####
                    /// +++++++++++++++++++++++++++++++++++++++++++++++++++++++
                    /// # - MANUAL para archivo JSON en el link: https://goo.gl/WHMmSb
                    /// # - MANUAL para archivo TXT en el link: https://goo.gl/Lz7hAq
                    /// +++++++++++++++++++++++++++++++++++++++++++++++++++++++

                    string json = JsonSerializer.Serialize(invoice);
                    //Console.WriteLine(json);
                    byte[] bytes = Encoding.Default.GetBytes(json);
                    string json_en_utf_8 = Encoding.UTF8.GetString(bytes);

                    /// #########################################################
                    /// #### PASO 3: ENVIAR EL ARCHIVO A NUBEFACT ####
                    /// +++++++++++++++++++++++++++++++++++++++++++++++++++++++
                    /// # SI ESTÁS TRABAJANDO CON ARCHIVO JSON
                    /// # - Debes enviar en el HEADER de tu solicitud la siguiente lo siguiente:
                    /// # Authorization = Token token="8d19d8c7c1f6402687720eab85cd57a54f5a7a3fa163476bbcf381ee2b5e0c69"
                    /// # Content-Type = application/json
                    /// # - Adjuntar en el CUERPO o BODY el archivo JSON o TXT
                    /// # SI ESTÁS TRABAJANDO CON ARCHIVO TXT
                    /// # - Debes enviar en el HEADER de tu solicitud la siguiente lo siguiente:
                    /// # Authorization = Token token="8d19d8c7c1f6402687720eab85cd57a54f5a7a3fa163476bbcf381ee2b5e0c69"
                    /// # Content-Type = text/plain
                    /// # - Adjuntar en el CUERPO o BODY el archivo JSON o TXT
                    /// +++++++++++++++++++++++++++++++++++++++++++++++++++++++

                    string json_de_respuesta = SendJson(facturaToken.Ruta, json_en_utf_8, facturaToken.Token, "POST");
                    dynamic r = JsonSerializer.Deserialize<Respuesta>(json_de_respuesta);
                    string r2 = JsonSerializer.Serialize(r);
                    dynamic json_r_in = JsonSerializer.Deserialize<Respuesta>(r2);

                    ///#########################################################
                    ///#### PASO 4: LEER RESPUESTA DE NUBEFACT ####
                    ///+++++++++++++++++++++++++++++++++++++++++++++++++++++++
                    ///# Recibirás una respuesta de NUBEFACT inmediatamente lo cual se debe leer, verificando que no haya errores.
                    ///# Debes guardar en la base de datos la respuesta que te devolveremos.
                    ///# Escríbenos a soporte@nubefact.com o llámanos al teléfono: 01 468 3535 (opción 2) o celular (WhatsApp) 955 598762
                    ///# Puedes imprimir el PDF que nosotros generamos como también generar tu propia representación impresa previa coordinación con nosotros.
                    ///# La impresión del documento seguirá haciéndose desde tu sistema. Enviaremos el documento por email a tu cliente si así lo indicas en el archivo JSON o TXT.
                    ///+++++++++++++++++++++++++++++++++++++++++++++++++++++++

                    dynamic respuestaSunat = JsonSerializer.Deserialize<Respuesta>(json_de_respuesta);


                    /*return Ok(new
                    {
                        data = respuestaSunat,
                        message = respuestaSunat.errors,
                        status = StatusCodes.Status400BadRequest
                    });*/

                    if (respuestaSunat.errors != null)
                    {
                        return Ok(new
                        {
                            data = new { },
                            message = respuestaSunat.errors,
                            status = StatusCodes.Status400BadRequest
                        });
                    }

                    model.SunatAcepto = respuestaSunat.aceptada_por_sunat;
                    model.SunatDescripcion = respuestaSunat.sunat_description;
                    model.SunatNota = respuestaSunat.sunat_note;
                    model.SunatCodigoRespuesta = respuestaSunat.sunat_responsecode;
                    model.SunatSoapError = respuestaSunat.sunat_soap_error;
                    model.SunatAnulado = respuestaSunat.anulado;

                    model.SerieComprobante = respuestaSunat.serie;
                    model.SunatKey = respuestaSunat.key;
                    model.SunatUrlCdr = respuestaSunat.enlace_del_cdr;
                    model.SunatUrlPdf = respuestaSunat.enlace_del_pdf;
                    model.SunatUrlXml = respuestaSunat.enlace_del_xml;
                    model.SunatHash = respuestaSunat.codigo_hash;
                    model.SunatCadenaQr = respuestaSunat.cadena_para_codigo_qr;
                    model.SunatCadenaBarra = respuestaSunat.codigo_de_barras;
                    //model.SunatZipPdfBase64 = respuestaSunat.pdf_zip_base64;

                    using (HttpClient client = new HttpClient())
                    {
                        client.DefaultRequestHeaders
                              .Accept
                              .Add(new MediaTypeWithQualityHeaderValue("application/pdf"));
                        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 |
                                                               SecurityProtocolType.Tls12;

                        using (HttpResponseMessage response = await client.GetAsync(respuestaSunat.enlace_del_pdf))
                        {

                            byte[] dd = await response.Content.ReadAsByteArrayAsync();
                            model.BoletaPdfBase64 = Convert.ToBase64String(dd);
                        }
                    }

                    /*bool actualizarNumero = await _IComprobanteSerieApp.ActualizarNumero(Convert.ToInt32(model.IdSerieComprobante), (Convert.ToInt32(model.NumeroComprobante) + 1), model.IdUsuarioRegistro);

                    if (!actualizarNumero)
                    {
                        return Ok(new
                        {
                            data = new { },
                            message = "Se registro el comprobante " + model.SerieComprobante + "-" + model.NumeroComprobante + ", pero no se pudo actualizar el número de serie en el contador",
                            status = StatusCodes.Status400BadRequest
                        });
                    }*/

                    ComprobanteElectronicoDTO output = await _IComprobanteElectronicoAp.EmitirComprobante(model, idCita);


                    return Ok(new
                    {
                        data = output,
                        message = "",
                        status = StatusCodes.Status201Created
                    });


                    /*return Ok(new
                    {
                        data = respuestaSunat,
                        error = "",
                        status = StatusCodes.Status201Created
                    });*/

                }

                //ComprobanteElectronicoDTO venta = await _IComprobanteElectronicoAp.EmitirComprobante(model, idCita);

                var d = await _IComprobanteElectronicoAp.EmitirComprobante(model, idCita);

                return Ok(new
                {
                    data = d,
                    message = "",
                    status = StatusCodes.Status201Created
                });
            }
            catch (AlertException ex)
            {
                return Ok(new
                {
                    data = new { },
                    message = ex.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    data = new { },
                    message = ex.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
        }


        [HttpPost("emitir-nota-credito-venta/{idVenta}")]
        public async Task<ActionResult> EmitirNotaCredito(ComprobanteElectronicoDTO model, int idVenta)
        {

            try
            {
                FacturaTokenDTO facturaToken;
                List<EmpresaEnt> empresa;
                //Invoice invoice = null;
                ComprobanteElectronicoDTO comprobanteElectronicoDTO = new ComprobanteElectronicoDTO();

                /*if (model.IdTipoComprobante != (int)TipoComprobante.Ticket)
                {*/
                    /// Obtener el token registrado para la sede de dicho comprobante a modificar

                    facturaToken = await _IFacturaTokenApp.BuscarPorSede(model.IdUsuarioRegistro, model.IdSede);
                    /**var e = await _IEmpresaApp.Obtener();
                    empresa = e.ToList();
                    if (empresa.Count == 0) {
                        AlertException alerta = new AlertException("La empresa emisora no esta registrada");
                        throw alerta;
                    }**/

                    //model.EmisorDireccion = empresa[0].DireccionEmisor;
                    //model.EmisorDescripcion = "Somos DEPILZONE Centro especializado en Depilación Láser, con más de 8 años de experiencia";
                    //model.EmisorRazonSocial = empresa[0].RazonSocialEmisor;
                    //model.EmisorRuc = empresa[0].RucEmisor;
                    //model.EmisorTelefonos = "asdfasdfasd";

                    /// Verificar si ya existe una nota de crédito para el comprobante a modificar o anular

                    int buscarComprobante = await _IComprobanteElectronicoAp.BuscarComprobanteModifica(model.SerieComprobanteModifica, Convert.ToInt32(model.NumeroComprobanteModifica));
                    if (buscarComprobante > 0)
                    {
                        return Ok(new JsonResponse()
                        {
                            Data = null,
                            Error = "Ya existe una nota de crédito para el comprobante " + model.SerieComprobanteModifica + "-" + model.NumeroComprobanteModifica,
                            Status = StatusCodes.Status400BadRequest
                        });
                    }

                    /// Crear el comprobante con su clase para enviar al proveedor

                    var invoice = comprobanteElectronicoDTO.crearComprobanteNotaCredito(model);


                    /*return Ok(new JsonResponse()
                    {
                        Data = invoice,
                        Error = null,
                        Status = StatusCodes.Status200OK
                    });*/

                    /// #########################################################
                    /// #### PASO 2: GENERAR EL ARCHIVO PARA ENVIAR A NUBEFACT ####
                    /// +++++++++++++++++++++++++++++++++++++++++++++++++++++++
                    /// # - MANUAL para archivo JSON en el link: https://goo.gl/WHMmSb
                    /// # - MANUAL para archivo TXT en el link: https://goo.gl/Lz7hAq
                    /// +++++++++++++++++++++++++++++++++++++++++++++++++++++++

                    string json = JsonSerializer.Serialize(invoice);
                    //Console.WriteLine(json);
                    byte[] bytes = Encoding.Default.GetBytes(json);
                    string json_en_utf_8 = Encoding.UTF8.GetString(bytes);

                    /// #########################################################
                    /// #### PASO 3: ENVIAR EL ARCHIVO A NUBEFACT ####
                    /// +++++++++++++++++++++++++++++++++++++++++++++++++++++++
                    /// # SI ESTÁS TRABAJANDO CON ARCHIVO JSON
                    /// # - Debes enviar en el HEADER de tu solicitud la siguiente lo siguiente:
                    /// # Authorization = Token token="8d19d8c7c1f6402687720eab85cd57a54f5a7a3fa163476bbcf381ee2b5e0c69"
                    /// # Content-Type = application/json
                    /// # - Adjuntar en el CUERPO o BODY el archivo JSON o TXT
                    /// # SI ESTÁS TRABAJANDO CON ARCHIVO TXT
                    /// # - Debes enviar en el HEADER de tu solicitud la siguiente lo siguiente:
                    /// # Authorization = Token token="8d19d8c7c1f6402687720eab85cd57a54f5a7a3fa163476bbcf381ee2b5e0c69"
                    /// # Content-Type = text/plain
                    /// # - Adjuntar en el CUERPO o BODY el archivo JSON o TXT
                    /// +++++++++++++++++++++++++++++++++++++++++++++++++++++++

                    string json_de_respuesta = SendJson(facturaToken.Ruta, json_en_utf_8, facturaToken.Token, "POST");
                    dynamic r = JsonSerializer.Deserialize<Respuesta>(json_de_respuesta);
                    string r2 = JsonSerializer.Serialize(r);
                    dynamic json_r_in = JsonSerializer.Deserialize<Respuesta>(r2);

                    ///#########################################################
                    ///#### PASO 4: LEER RESPUESTA DE NUBEFACT ####
                    ///+++++++++++++++++++++++++++++++++++++++++++++++++++++++
                    ///# Recibirás una respuesta de NUBEFACT inmediatamente lo cual se debe leer, verificando que no haya errores.
                    ///# Debes guardar en la base de datos la respuesta que te devolveremos.
                    ///# Escríbenos a soporte@nubefact.com o llámanos al teléfono: 01 468 3535 (opción 2) o celular (WhatsApp) 955 598762
                    ///# Puedes imprimir el PDF que nosotros generamos como también generar tu propia representación impresa previa coordinación con nosotros.
                    ///# La impresión del documento seguirá haciéndose desde tu sistema. Enviaremos el documento por email a tu cliente si así lo indicas en el archivo JSON o TXT.
                    ///+++++++++++++++++++++++++++++++++++++++++++++++++++++++

                    dynamic respuestaSunat = JsonSerializer.Deserialize<Respuesta>(json_de_respuesta);

                    if (respuestaSunat.errors != null)
                    {
                        return Ok(new
                        {
                            data = new {},
                            error = respuestaSunat.errors,
                            status = StatusCodes.Status400BadRequest
                        });
                    }

                    model.SunatAnulado = respuestaSunat.anulado;
                    model.SunatAcepto = respuestaSunat.aceptada_por_sunat;
                    model.SunatDescripcion = respuestaSunat.sunat_description;
                    model.SunatNota = respuestaSunat.sunat_note;
                    model.SunatCodigoRespuesta = respuestaSunat.sunat_responsecode;
                    model.SunatSoapError = respuestaSunat.sunat_soap_error;


                    model.SerieComprobante = respuestaSunat.serie;
                    model.SunatKey = respuestaSunat.key;
                    model.SunatUrlCdr = respuestaSunat.enlace_del_cdr;
                    model.SunatUrlPdf = respuestaSunat.enlace_del_pdf;
                    model.SunatUrlXml = respuestaSunat.enlace_del_xml;
                    model.SunatHash = respuestaSunat.codigo_hash;
                    model.SunatCadenaQr = respuestaSunat.cadena_para_codigo_qr;
                    model.SunatCadenaBarra = respuestaSunat.codigo_de_barras;
                    //model.SunatZipPdfBase64 = respuestaSunat.pdf_zip_base64;


                    using (HttpClient client = new HttpClient())
                    {
                        client.DefaultRequestHeaders
                              .Accept
                              .Add(new MediaTypeWithQualityHeaderValue("application/pdf"));
                        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 |
                                                               SecurityProtocolType.Tls12;

                        using (HttpResponseMessage response = await client.GetAsync(respuestaSunat.enlace_del_pdf))
                        {

                            byte[] dd = await response.Content.ReadAsByteArrayAsync();
                            model.BoletaPdfBase64 = Convert.ToBase64String(dd);
                        }
                    }

                    /*bool actualizarNumero = await _IComprobanteSerieApp.ActualizarNumero(Convert.ToInt32(model.IdSerieComprobante), (Convert.ToInt32(model.NumeroComprobante) + 1), model.IdUsuarioRegistro);

                    if (!actualizarNumero)
                    {
                        return Ok(new
                        {
                            data = new { },
                            message = "Se registro el comprobante " + model.SerieComprobante + "-" + model.NumeroComprobante + ", pero no se pudo actualizar el número de serie en el contador",
                            status = StatusCodes.Status400BadRequest
                        });
                    }*/

                    ComprobanteElectronicoDTO output = await _IComprobanteElectronicoAp.EmitirNotaCredito(model);


                    return Ok(new
                    {
                        data = output,
                        error = "",
                        status = StatusCodes.Status201Created
                    });


                    return Ok(new
                    {
                        data = respuestaSunat,
                        error = "",
                        status = StatusCodes.Status201Created
                    });

                //}


                //var d = await _IComprobanteElectronicoAp.EmitirComprobante(model, idCita);

                return Ok(new
                {
                    //data = d,
                    message = "",
                    status = StatusCodes.Status201Created
                });
            }
            catch (AlertException ex)
            {
                return Ok(new
                {
                    data = new { },
                    error = ex.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    data = new { },
                    error = ex.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
        }

        [HttpGet("obtener-notas-credito/{fechaDesde}/{fechaHasta}/{idTipoComprobante}/{idSede}")]
        public async Task<ActionResult> ObtenerNotasCredito(DateTime fechaDesde, DateTime fechaHasta, int idTipoComprobante, int idSede)
        {
            try
            {
                List<ComprobanteElectronicoDTO> collection = await _IComprobanteElectronicoAp.ObtenerNotasCredito(fechaDesde, fechaHasta, idTipoComprobante, idSede);
                return Ok(new JsonResponse()
                {
                    Data = collection,
                    Error = null,
                    Status = StatusCodes.Status200OK
                });
            }
            catch (AlertException ex)
            {
                return Ok(new JsonResponse()
                {
                    Data = null,
                    Error = ex.Message,
                    Status = StatusCodes.Status400BadRequest
                });
            }
            catch (Exception ex)
            {
                return Ok(new JsonResponse()
                {
                    Data = null,
                    Error = ex.Message,
                    Status = StatusCodes.Status400BadRequest
                });
            }
        }

        [HttpGet("reporte/{idUsuario}/{idSede}/{idTipoDocumento}/{fechaDesde}/{fechaHasta}")]
        public async Task<ActionResult> ObtenerReporte(int IdUsuario, int idSede, int idTipoDocumento, DateTime fechaDesde, DateTime fechaHasta)
        {
            try
            {
                var lista = await _IComprobanteElectronicoAp.ObtenerReporte(IdUsuario, idSede, idTipoDocumento, fechaDesde, fechaHasta);
                return Ok(new
                {
                    data = lista,
                    message = "",
                    status = StatusCodes.Status200OK
                });
            }
            catch (AlertException ex)
            {
                return Ok(new
                {
                    data = new { },
                    message = ex.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    data = new { },
                    message = ex.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
        }


        [HttpGet("reporte-venta/{idUsuario}/{idSede}/{idTipoDocumento}/{fechaDesde}/{fechaHasta}")]
        public async Task<ActionResult> ObtenerReporteVenta(int IdUsuario, int idSede, int idTipoDocumento, DateTime fechaDesde, DateTime fechaHasta)
        {
            try
            {
                var lista = await _IComprobanteElectronicoAp.ObtenerReporteVenta(IdUsuario, idSede, idTipoDocumento, fechaDesde, fechaHasta);
                return Ok(new
                {
                    data = lista,
                    message = "",
                    status = StatusCodes.Status200OK
                });
            }
            catch (AlertException ex)
            {
                return Ok(new
                {
                    data = new { },
                    message = ex.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    data = new { },
                    message = ex.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
        }


        [HttpGet("reporte-pago/{idUsuario}/{idSede}/{idTipoDocumento}/{fechaDesde}/{fechaHasta}")]
        public async Task<ActionResult> ObtenerReportePago(int IdUsuario, int idSede, int idTipoDocumento, DateTime fechaDesde, DateTime fechaHasta)
        {
            try
            {
                var lista = await _IComprobanteElectronicoAp.ObtenerReportePago(IdUsuario, idSede, idTipoDocumento, fechaDesde, fechaHasta);
                return Ok(new
                {
                    data = lista,
                    message = "",
                    status = StatusCodes.Status200OK
                });
            }
            catch (AlertException ex)
            {
                return Ok(new
                {
                    data = new { },
                    message = ex.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    data = new { },
                    message = ex.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
        }


        [HttpGet("reporte-venta-cliente/{idUsuario}/{fechaDesde}/{fechaHasta}")]
        public async Task<ActionResult> ObtenerReporteVentaCliente(int IdUsuario, DateTime fechaDesde, DateTime fechaHasta)
        {
            try
            {
                var lista = await _IComprobanteElectronicoAp.ObtenerReporteVentaCliente(IdUsuario, fechaDesde, fechaHasta);
                return Ok(new
                {
                    data = lista,
                    message = "",
                    status = StatusCodes.Status200OK
                });
            }
            catch (AlertException ex)
            {
                return Ok(new
                {
                    data = new { },
                    message = ex.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    data = new { },
                    message = ex.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
        }


        [HttpGet("reporte-venta-producto/{idUsuario}/{fechaDesde}/{fechaHasta}/{idUnidadMedida}")]
        public async Task<ActionResult> ObtenerReporteVentaProducto(int IdUsuario, DateTime fechaDesde, DateTime fechaHasta, int idUnidadMedida)
        {
            try
            {
                var lista = await _IComprobanteElectronicoAp.ObtenerReporteVentaProducto(IdUsuario, fechaDesde, fechaHasta, idUnidadMedida);
                return Ok(new
                {
                    data = lista,
                    message = "",
                    status = StatusCodes.Status200OK
                });
            }
            catch (AlertException ex)
            {
                return Ok(new
                {
                    data = new { },
                    message = ex.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    data = new { },
                    message = ex.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
        }


        [HttpPost("anular-comprobante")]
        public async Task<ActionResult> AnularComprobante(ComprobanteElectronicoAnularDTO model)
        {
            try
            {
                FacturaTokenDTO facturaToken;
                TipoComprobanteEnt tipoComprobante;

                ComprobanteElectronicoDTO comprobanteElectronicoDTO = new ComprobanteElectronicoDTO();

                if (model.IdTipoComprobante != (int)TipoComprobante.Ticket)
                {
                    facturaToken = await _IFacturaTokenApp.BuscarPorSede(model.IdUsuario, model.IdSede);
                    tipoComprobante = await _ITipoComprobanteApp.ObtenerById(model.IdTipoComprobante);

                    var invoice = comprobanteElectronicoDTO.crearAnulacionComprobante(tipoComprobante.Valor, model.Serie, model.Numero, model.Motivo);
                    string json = JsonSerializer.Serialize(invoice);
                    byte[] bytes = Encoding.Default.GetBytes(json);
                    string json_en_utf_8 = Encoding.UTF8.GetString(bytes);

                    string json_de_respuesta = SendJson(facturaToken.Ruta, json_en_utf_8, facturaToken.Token, "POST");
                    dynamic respuestaSunat = JsonSerializer.Deserialize<Respuesta>(json_de_respuesta);


                    if (respuestaSunat.errors != null)
                    {
                        return Ok(new
                        {
                            data = new { },
                            error = respuestaSunat.errors,
                            status = StatusCodes.Status400BadRequest
                        });
                    }

                    model.Codigo = respuestaSunat.numero;
                    model.SunatKey = respuestaSunat.key;
                    model.SunatAcepto = respuestaSunat.aceptada_por_sunat;
                    model.SunatDescripcion = respuestaSunat.sunat_description;
                    model.SunatNota = respuestaSunat.sunat_note;
                    model.SunatTicketNumero = respuestaSunat.GetType().GetProperty("sunat_ticket_numero") != null ? respuestaSunat.sunat_ticket_numero : null;
                    model.SunatCodigoRespuesta = respuestaSunat.sunat_responsecode;
                    model.SunatSoapError = respuestaSunat.sunat_soap_error;
                    model.SunatUrlCdr = respuestaSunat.enlace_del_cdr;
                    model.SunatUrlPdf = respuestaSunat.enlace_del_pdf;
                    model.SunatUrlXml = respuestaSunat.enlace_del_xml;





                    try
                    {
                        bool estadoActualizado = await _IComprobanteElectronicoAp.AnularComprobanteSunat(model);
                        if (!estadoActualizado)
                        {
                            return BadRequest(new
                            {
                                data = new { },
                                error = "No se pudo actualizar el estado de la anulación del comprobante",
                                status = StatusCodes.Status400BadRequest
                            });
                        }
                    }
                    catch (Exception ee)
                    {
                        return BadRequest(new
                        {
                            data = new { },
                            error = ee.Message,
                            status = StatusCodes.Status400BadRequest
                        });
                    }



                    return Ok(new JsonResponse() {
                        Data = null,
                        Error = null,
                        Status = StatusCodes.Status201Created
                    });

                }

                return BadRequest(new
                {
                    data = new { },
                    error = "Solo es para Facturas y Boletas",
                    status = StatusCodes.Status400BadRequest
                });

            }
            catch (AlertException ex)
            {
                return Ok(new
                {
                    data = new { },
                    error = ex.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
            catch (Exception e)
            {
                return BadRequest(new
                {
                    data = new { },
                    error = e.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
        }


        [HttpGet("buscar-comprobante/{serie}/{numero}/{idTipoComprobante}")]
        public async Task<ActionResult> BuscarComprobante(string serie, int numero, int idTipoComprobante)
        {
            try
            {

                ComprobanteElectronicoDTO data = await _IComprobanteElectronicoAp.BuscarComprobante(serie, numero, idTipoComprobante);

                return Ok(new JsonResponse()
                {
                    Data = data,
                    Error = null,
                    Status = StatusCodes.Status200OK
                });

            }
            catch (AlertException ex)
            {
                return Ok(new
                {
                    data = new { },
                    message = ex.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
            catch (Exception e)
            {
                return BadRequest(new
                {
                    data = new { },
                    message = e.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
        }


        [HttpGet("consultar-comprobante/{idVenta}/{idTipoComprobante}/{serie}/{numero}/{idSede}/{idUsuario}")]
        public async Task<ActionResult> ConsultarComprobante(int idVenta, int idTipoComprobante, string serie, string numero, int idSede, int idUsuario)
        {

            try
            {
                FacturaTokenDTO facturaToken;
                TipoComprobanteEnt tipoComprobante;

                ComprobanteElectronicoDTO comprobanteElectronicoDTO = new ComprobanteElectronicoDTO();

                if (idTipoComprobante != (int)TipoComprobante.Ticket)
                {
                    facturaToken = await _IFacturaTokenApp.BuscarPorSede(idUsuario, idSede);
                    tipoComprobante = await _ITipoComprobanteApp.ObtenerById(idTipoComprobante);

                    var invoice = comprobanteElectronicoDTO.crearConsultaComprobante(tipoComprobante.Valor, serie, numero);
                    string json = JsonSerializer.Serialize(invoice);
                    byte[] bytes = Encoding.Default.GetBytes(json);
                    string json_en_utf_8 = Encoding.UTF8.GetString(bytes);

                    string json_de_respuesta = SendJson(facturaToken.Ruta, json_en_utf_8, facturaToken.Token, "POST");
                    dynamic respuestaSunat = JsonSerializer.Deserialize<Respuesta>(json_de_respuesta);


                    if (respuestaSunat.errors != null)
                    {
                        return Ok(new
                        {
                            data = new { },
                            error = respuestaSunat.errors,
                            status = StatusCodes.Status400BadRequest
                        });
                    }

                    comprobanteElectronicoDTO.IdTipoComprobante = idTipoComprobante;
                    comprobanteElectronicoDTO.SerieComprobante = serie;
                    comprobanteElectronicoDTO.NumeroComprobante = numero;
                    comprobanteElectronicoDTO.SunatAnulado = respuestaSunat.anulado;
                    comprobanteElectronicoDTO.SunatCodigoRespuesta = respuestaSunat.sunat_responsecode;
                    comprobanteElectronicoDTO.SunatAcepto = respuestaSunat.aceptada_por_sunat;
                    comprobanteElectronicoDTO.SunatSoapError = respuestaSunat.sunat_soap_error;
                    comprobanteElectronicoDTO.SunatNota = respuestaSunat.sunat_note;
                    comprobanteElectronicoDTO.SunatDescripcion = respuestaSunat.sunat_description;


                    ComprobanteElectronicoConsultaDTO comprobanteConsulta;

                    try
                    {
                        comprobanteConsulta = await _IComprobanteElectronicoAp.ActualizarEstadoSunat(comprobanteElectronicoDTO);
                        /*if (estadoActualizado)
                        {
                            return BadRequest(new
                            {
                                data = new { },
                                error = "No se pudo actualizar el estado del comprobante",
                                status = StatusCodes.Status400BadRequest
                            });
                        }*/
                    }
                    catch (Exception ee)
                    {
                        return BadRequest(new
                        {
                            data = new { },
                            error = ee.Message,
                            status = StatusCodes.Status400BadRequest
                        });
                    }


                    /*try
                    {
                        bool estadoActualizado = await _IComprobanteElectronicoAp.ActualizarAnuladoSunat(idVenta, false);
                        if (!estadoActualizado)
                        {
                            return BadRequest(new
                            {
                                data = new { },
                                error = "No se pudo actualizar el estado de la anulación del comprobante",
                                status = StatusCodes.Status400BadRequest
                            });
                        }
                    }
                    catch (Exception ee)
                    {
                        return BadRequest(new
                        {
                            data = new { },
                            error = ee.Message,
                            status = StatusCodes.Status400BadRequest
                        });
                    }*/




                    return Ok(new
                    {
                        data = comprobanteConsulta,
                        error = respuestaSunat.errors,
                        status = StatusCodes.Status200OK
                    });

                }

                return BadRequest(new
                {
                    data = new { },
                    error = "Solo es para Facturas y Boletas",
                    status = StatusCodes.Status400BadRequest
                });

            }
            catch (AlertException ex)
            {
                return Ok(new
                {
                    data = new { },
                    message = ex.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
            catch (Exception e)
            {
                return BadRequest(new
                {
                    data = new { },
                    message = e.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
        }


        [HttpGet("consultar-anulacion/{idTipoComprobante}/{serie}/{numero}/{idSede}/{idUsuario}")]
        public async Task<ActionResult> ConsultarAnulacion(int idTipoComprobante, string serie, string numero, int idSede, int idUsuario)
        {
            try
            {
                FacturaTokenDTO facturaToken;
                TipoComprobanteEnt tipoComprobante;

                ComprobanteElectronicoDTO comprobanteElectronicoDTO = new ComprobanteElectronicoDTO();
                ComprobanteElectronicoAnulacionDTO comprobanteElectronicoAnulacionDTO = new ComprobanteElectronicoAnulacionDTO();

                if (idTipoComprobante != (int)TipoComprobante.Ticket)
                {
                    facturaToken = await _IFacturaTokenApp.BuscarPorSede(idUsuario, idSede);
                    tipoComprobante = await _ITipoComprobanteApp.ObtenerById(idTipoComprobante);

                    var invoice = comprobanteElectronicoDTO.crearConsultaAnulacionComprobante(tipoComprobante.Valor, serie, numero);
                    string json = JsonSerializer.Serialize(invoice);
                    byte[] bytes = Encoding.Default.GetBytes(json);
                    string json_en_utf_8 = Encoding.UTF8.GetString(bytes);

                    string json_de_respuesta = SendJson(facturaToken.Ruta, json_en_utf_8, facturaToken.Token, "POST");
                    dynamic respuestaSunat = JsonSerializer.Deserialize<Respuesta>(json_de_respuesta);

                    if (respuestaSunat.errors != null)
                    {
                        return Ok(new
                        {
                            data = new { },
                            error = respuestaSunat.errors,
                            status = StatusCodes.Status400BadRequest
                        });
                    }




                    comprobanteElectronicoAnulacionDTO.IdTipoComprobante = idTipoComprobante;
                    comprobanteElectronicoAnulacionDTO.Serie = serie;
                    comprobanteElectronicoAnulacionDTO.Numero = Convert.ToInt32(numero);
                    comprobanteElectronicoAnulacionDTO.IdSede = idSede;

                    comprobanteElectronicoAnulacionDTO.Codigo = respuestaSunat.numero;
                    comprobanteElectronicoAnulacionDTO.SunatAcepto = respuestaSunat.aceptada_por_sunat;
                    comprobanteElectronicoAnulacionDTO.SunatDescripcion = respuestaSunat.sunat_description;
                    comprobanteElectronicoAnulacionDTO.SunatNota = respuestaSunat.sunat_note;
                    comprobanteElectronicoAnulacionDTO.SunatTicketNumero = respuestaSunat.GetType().GetProperty("sunat_ticket_numero") != null ? respuestaSunat.sunat_ticket_numero : null;
                    comprobanteElectronicoAnulacionDTO.SunatCodigoRespuesta = respuestaSunat.sunat_responsecode;
                    comprobanteElectronicoAnulacionDTO.SunatSoapError = respuestaSunat.sunat_soap_error;
                    comprobanteElectronicoAnulacionDTO.SunatUrlCdr = respuestaSunat.enlace_del_cdr;
                    comprobanteElectronicoAnulacionDTO.SunatUrlPdf = respuestaSunat.enlace_del_pdf;
                    comprobanteElectronicoAnulacionDTO.SunatUrlXml = respuestaSunat.enlace_del_xml;



                    ComprobanteElectronicoAnulacionDTO respuesta = new ComprobanteElectronicoAnulacionDTO();
                    try
                    {
                        respuesta = await _IComprobanteElectronicoAp.ActualizarAnuladoSunat(comprobanteElectronicoAnulacionDTO);
                        /*if (estadoActualizado)
                        {
                            return BadRequest(new
                            {
                                data = new { },
                                error = "No se pudo actualizar el estado del comprobante",
                                status = StatusCodes.Status400BadRequest
                            });
                        }*/
                    }
                    catch (Exception ee)
                    {
                        return BadRequest(new
                        {
                            data = new { },
                            error = ee.Message,
                            status = StatusCodes.Status400BadRequest
                        });
                    }


                    /*try
                    {
                        bool estadoActualizado = await _IComprobanteElectronicoAp.ActualizarAnuladoSunat(idVenta, false);
                        if (!estadoActualizado)
                        {
                            return BadRequest(new
                            {
                                data = new { },
                                error = "No se pudo actualizar el estado de la anulación del comprobante",
                                status = StatusCodes.Status400BadRequest
                            });
                        }
                    }
                    catch (Exception ee)
                    {
                        return BadRequest(new
                        {
                            data = new { },
                            error = ee.Message,
                            status = StatusCodes.Status400BadRequest
                        });
                    }*/

                    return Ok(new JsonResponse()
                    {
                        Data = respuesta,
                        Error = null,
                        Status = StatusCodes.Status200OK
                    });

                }

                return BadRequest(new
                {
                    data = new { },
                    error = "Solo es para Facturas y Boletas",
                    status = StatusCodes.Status400BadRequest
                });

            }
            catch (AlertException ex)
            {
                return Ok(new
                {
                    data = new { },
                    message = ex.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
            catch (Exception e)
            {
                return BadRequest(new
                {
                    data = new { },
                    message = e.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
        }


        [HttpGet("ver-pdf/{idUsuario}/{idComprobante}/{idTipoComprobante}/{serie}/{numero}")]
        public async Task<ActionResult> VerPdf(int idUsuario, int idComprobante, int idTipoComprobante, string serie, int numero)
        {
            try
            {

                string pdfBase64 = await _IComprobanteElectronicoAp.VerPdf( idUsuario,  idComprobante, idTipoComprobante,  serie,  numero);

                return Ok(new JsonResponse()
                {
                    Data = pdfBase64,
                    Error = null,
                    Status = StatusCodes.Status200OK
                });

            }
            catch (AlertException ex)
            {
                return Ok(new
                {
                    data = new { },
                    error = ex.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
            catch (Exception e)
            {
                return BadRequest(new
                {
                    data = new { },
                    error = e.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
        }



        static string SendJson(string ruta, string json, string token, string method)
        {
            try
            {
                using (var client = new WebClient())
                {
                    /// ESPECIFICAMOS EL TIPO DE DOCUMENTO EN EL ENCABEZADO
                    client.Headers[HttpRequestHeader.ContentType] = "application/json; charset=utf-8";
                    /// ASI COMO EL TOKEN UNICO
                    client.Headers[HttpRequestHeader.Authorization] = "Token token=" + token;
                    /// OBTENEMOS LA RESPUESTA
                    string respuesta = client.UploadString(ruta, method, json);
                    /// Y LA 'RETORNAMOS'
                    return respuesta;
                }
            }
            catch (WebException ex)
            {
                /// EN CASO EXISTA ALGUN ERROR, LO TOMAMOS
                var respuesta = new StreamReader(ex.Response.GetResponseStream()).ReadToEnd();
                /// Y LO 'RETORNAMOS'
                return respuesta;
            }
        }
    }
}