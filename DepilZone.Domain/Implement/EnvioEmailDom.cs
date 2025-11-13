using DepilZone.Data.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace DepilZone.Domain.Implement
{
    public class EmailDom : IEmailDom
    {
        private readonly IEmailDat _IEnvioEmailDat;
        private readonly IParametroSistemaDat _IParametroSistemaDat;
        private readonly IUtilitarioDat _IUtilitarioDat;
        public EmailDom(IEmailDat IEnvioEmailDat, IParametroSistemaDat IParametroSistemaDat, IUtilitarioDat IUtilitarioDat)
        {
            _IEnvioEmailDat = IEnvioEmailDat;
            _IParametroSistemaDat = IParametroSistemaDat;
            _IUtilitarioDat = IUtilitarioDat;
        }
        public async Task<int> EnvioEmail(EmailEnvioDTO model)
        {
            return await _IEnvioEmailDat.EnvioEmail(model);
        }

        public async Task<bool> SendEmailAsync(EmailEnvioDTO model)
        {
            try
            {
                List<ParametroSistemaEnt> parametros = (List<ParametroSistemaEnt>)await _IParametroSistemaDat.ObtenerParametrosEmail();
                Respuesta<ParametroSistemaEnt> _parametro =  await _IParametroSistemaDat.ObtenerById(13);
                List<ParametroSistemaEnt> listaParametros = await _IParametroSistemaDat.ObtenerParametros();

                string EmailRemitente = parametros.Where(x => x.Parametro == "EmailRemitente").FirstOrDefault().Valor;
                string PasswordMail = parametros.Where(x => x.Parametro == "EmailPassword").FirstOrDefault().Valor;
                string UrlConfirmarRecepcionDocumento = _parametro.Response.Valor;
                string  EmailCopiaConfirmacion = listaParametros.Where(x => x.Parametro == "EmailCCConfirmacionContrato").FirstOrDefault().Valor;


                /*SmtpClient Cliente = new SmtpClient()
                {
                    Host = parametros.Where(x => x.Parametro == "EmailHost").FirstOrDefault().Valor,
                    Port = int.Parse(parametros.Where(x => x.Parametro == "EmailPort").FirstOrDefault().Valor),
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(EmailRemitente, PasswordMail),
                    EnableSsl = parametros.Where(x => x.Parametro == "EmailPort").FirstOrDefault().Valor == "1" ? true : false,
                };*/
                string emailCorregido = CorregirEmail(model.EmailDestino);
                if (string.IsNullOrEmpty(emailCorregido))
                {
                    Console.WriteLine("Correo inválido o no corregible: " + model.EmailDestino);
                    return false;
                }
                model.EmailDestino = emailCorregido;

                MailAddress de = new MailAddress(EmailRemitente, "DEPILZONE - Documentos");
                MailAddress para = new MailAddress(model.EmailDestino);
                using (MailMessage correo = new MailMessage(de, para))
                {
                    correo.Subject = model.Asunto;
                    correo.Body = model.Contenido;
                    correo.BodyEncoding = System.Text.ASCIIEncoding.GetEncoding("ISO-8859-1");
                    correo.IsBodyHtml = true;
                    correo.Bcc.Add(model.EmailCopiaOculta);


                    if(model.Asunto.Contains("Confirmar Acta de entrega de Documentos"))
                    {
                        string idEncriptado = await _IUtilitarioDat.Encriptar(model.IdContrato.ToString());

                        if (model.DocumentosRenderizados?.Count > 0)
                        {
                            correo.Body = @"
                                        <!DOCTYPE html>
                                        <html lang='en'>
                                        <head>
                                            <meta content='text/html; charset=utf-8' http-equiv='Content-Type'>
                                            <title>Documentos Recibidos</title>
                                            <style>
                                                HTML{background-color: #e8e8e8;font-family: Arial, sans-serif}
                                                ._b{
                                                    padding: 0;
                                                    margin: 0;
                                                }
                                                ._b *{box-sizing: border-box;padding: 0;}
                                                ._table{
                                                    background-color: #e8e8e8;
                                                    margin: 2rem auto;
                                                    width: 100%;
                                                    border-spacing: 0;
                                                    padding: 5rem 1rem;
                                                }
                                                ._table td{
                                                    padding-bottom: .5rem;
                                                }
                                                ._table td > div{
                                                    width: 100%;
                                                    max-width: 900px;
                                                    margin: auto;
                                                }
                                                ._title{
                                                    text-align: center;
                                                    padding: 1rem 2rem;
                                                    color: #ffffff;
                                                    font-weight: 500;
                                                    border-radius: 1rem 1rem 0 0;
                                                    font-size: 1.8rem;
                                                }
                                                ._logo{
                                                    text-align: center;
                                                    padding: 1rem 2rem;
                                                    color: #ffffff;
                                                    font-weight: 500;
                                                    border-radius: 1rem;
                                                    font-size: 3.2rem;
                                                }
                                                ._blue{
                                                    background-color: #04a9f5;
                                                }
                                                ._body{
                                                    background-color: #ffffff;
                                                    padding: 2rem;
                                                    border-radius: 0 0 1rem 1rem;
                                                }
                                                ._text{
                                                    font-size: 18px;
                                                    color: #929292;
                                                    margin: 0;
                                                }
                                                ._info{
                                                    font-size: 18px;
                                                    color: #6d6d6d;
                                                }
                                                ._lista{
                                                    padding-left: 1rem;
                                                    font-size: 14px;
                                                    color: #6d6d6d;
                                                    font-weight: 600;
                                                }
                                                ._btn{
                                                    display: inline-block;
                                                    padding: 1rem 2rem;
                                                    border-radius: 1rem;
                                                    color: #ffffff !important;
                                                    background-color: #04a9f5;
                                                    margin: 1rem auto auto auto;
                                                    font-size: 18px;
                                                    text-decoration: none;
                                                }
                                                ._btn:hover{
                                                    background-color: #038fcf;
                                                }
                                            </style>
                                        </head>
                                        <body class='_b'>
                                            <table class='_table'>
                                                <thead>
                                                    <tr>
                                                        <td><div class='_logo _blue'>Depilzone</div></td>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <tr>
                                                        <td>
                                                            <div>
                                                            <div class='_title _blue'>
                                                                <p>Acta de entrega de documentos</p>";
                            correo.Body += @"<b>N° #" + model.IdContrato.ToString().PadLeft(6, '0') + "</b>";

                            correo.Body += @"</div>
                                                            <div class='_body'>
                                                                <p class='_text'>Mediante el presente, se lista los documentos digitales enviados al correo electrónico:</p>
                                                                ";

                            correo.Body += @"<ul class='_lista'>";
                            model.DocumentosRenderizados.ForEach((ArchivoPdfDTO x) =>
                            {
                                correo.Body += @"<li>" + Convert.ToString(x.titulo) + "</li>";
                            });
                            correo.Body += @"</ul>";

                            correo.Body += @"<p class='_info'>Favor de confirmar la entrega en el siguiente enlace</p>
                                                                <div style='text-align: center'>
                                                                    <a class='_btn' href='" + UrlConfirmarRecepcionDocumento + idEncriptado + @"'>Confirmar entrega</a>
                                                                </div>
                                                            </div>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </body>
                                        </html>
                                        ";

                            model.DocumentosRenderizados.ForEach((ArchivoPdfDTO x) =>
                            {
                                Stream content = new MemoryStream(Convert.FromBase64String(x.contenidoBase64));
                                correo.Attachments.Add(new Attachment(content, x.titulo, "application/pdf"));
                            });

                        }
                    }
                    else if (model.Asunto.Contains("Confirmación Exitosa - Acta de entrega del Documentos"))
                    {
                        correo.Bcc.Add(EmailCopiaConfirmacion);
                        correo.Body = @"
                                        <!DOCTYPE html>
                                        <html lang='en'>
                                        <head>
                                            <meta content='text/html; charset=utf-8' http-equiv='Content-Type'>
                                            <title>Documentos Recibidos</title>
                                            <style>
                                                HTML{background-color: #e8e8e8;font-family: Arial, sans-serif}
                                                ._b{
                                                    padding: 0;
                                                    margin: 0;
                                                }
                                                ._b *{box-sizing: border-box;padding: 0;}
                                                ._table{
                                                    background-color: #e8e8e8;
                                                    margin: 2rem auto;
                                                    width: 100%;
                                                    border-spacing: 0;
                                                    padding: 5rem 1rem;
                                                }
                                                ._table td{
                                                    padding-bottom: .5rem;
                                                }
                                                ._table td > div{
                                                    width: 100%;
                                                    max-width: 900px;
                                                    margin: auto;
                                                }
                                                ._title{
                                                    text-align: center;
                                                    padding: 1rem 2rem;
                                                    color: #ffffff;
                                                    font-weight: 500;
                                                    border-radius: 1rem 1rem 0 0;
                                                    font-size: 1.8rem;
                                                }
                                                ._logo{
                                                    text-align: center;
                                                    padding: 1rem 2rem;
                                                    color: #ffffff;
                                                    font-weight: 500;
                                                    border-radius: 1rem;
                                                    font-size: 3.2rem;
                                                }
                                                ._blue{
                                                    background-color: #04a9f5;
                                                }
                                                ._body{
                                                    background-color: #ffffff;
                                                    padding: 2rem;
                                                    border-radius: 0 0 1rem 1rem;
                                                }
                                                ._text{
                                                    font-size: 18px;
                                                    color: #929292;
                                                    margin: 0;
                                                }
                                                ._info{
                                                    font-size: 18px;
                                                    color: #6d6d6d;
                                                }
                                                ._lista{
                                                    padding-left: 1rem;
                                                    font-size: 14px;
                                                    color: #6d6d6d;
                                                    font-weight: 600;
                                                }
                                                ._btn{
                                                    display: inline-block;
                                                    padding: 1rem 2rem;
                                                    border-radius: 1rem;
                                                    color: #ffffff !important;
                                                    background-color: #04a9f5;
                                                    margin: 1rem auto auto auto;
                                                    font-size: 18px;
                                                    text-decoration: none;
                                                }
                                                ._btn:hover{
                                                    background-color: #038fcf;
                                                }
                                            </style>
                                        </head>
                                        <body class='_b'>
                                            <h1>"+ model.MensajeCliente + @"</h1>
                                            <table class='_table'>
                                                <thead>
                                                    <tr>
                                                        <td><div class='_logo _blue'>Depilzone</div></td>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <tr>
                                                        <td>
                                                            <div>
                                                                <div class='_body'>
                                                                <h1><center>";
                                               correo.Body += model.Contenido;
                                               correo.Body += @" </center></h1>
                                                                </div>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </body>
                                        </html>
                                        ";
                    }
                    else
                    {
                        Stream content = new MemoryStream(Convert.FromBase64String(model.Adjunto));
                        correo.Attachments.Add(new Attachment(content, model.NombreAdjunto, "application/pdf"));
                    }


                        SmtpClient Cliente = new SmtpClient()
                    {
                        Host = parametros.Where(x => x.Parametro == "EmailHost").FirstOrDefault().Valor,
                        Port = int.Parse(parametros.Where(x => x.Parametro == "EmailPort").FirstOrDefault().Valor),
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(EmailRemitente, PasswordMail),
                        EnableSsl = parametros.Where(x => x.Parametro == "EmailPort").FirstOrDefault().Valor == "1" ? true : false,
                    };
                    await Cliente.SendMailAsync(correo);
                };

                //Stream content = new MemoryStream(Convert.FromBase64String(model.Adjunto));
                //Attachment adjunto = new Attachment(content, model.NombreAdjunto + "dd", "application/pdf");
                //correo.Attachments.Add(adjunto);
                //correo.Attachments.Add(adjunto);
                //await Cliente.SendMailAsync(correo);
                return true;
            }
            catch (Exception ex)
            {
                var e = ex;
                return false;
            }
        }

        private string CorregirEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
                return null;

            var partes = email.Split('@');
            if (partes.Length != 2)
                return null;

            string usuario = partes[0];
            string dominio = partes[1].ToLower();

            // Correcciones comunes de dominio
            var dominiosValidos = new List<string>
            {
                "gmail.com", "gmail.pe", "gmail.es", "gmail.net",
                "hotmail.com", "hotmail.pe", "hotmail.es",
                "outlook.com", "outlook.pe", "outlook.es",
                "yahoo.com", "yahoo.es", "yahoo.pe"
            };

            // Corregir dominios sin punto
            if (!dominio.Contains("."))
            {
                if (dominio.StartsWith("gmail")) dominio = "gmail.com";
                else if (dominio.StartsWith("hotmail")) dominio = "hotmail.com";
                else if (dominio.StartsWith("outlook")) dominio = "outlook.com";
                else if (dominio.StartsWith("yahoo")) dominio = "yahoo.com";
                else return null; // no se puede corregir
            }

            // Correcciones de errores comunes
            dominio = dominio
                .Replace("gmal", "gmail")
                .Replace("hotmial", "hotmail")
                .Replace("outlok", "outlook")
                .Replace("yahho", "yahoo");

            // Validar contra lista
            if (!dominiosValidos.Contains(dominio))
                return null;

            return $"{usuario}@{dominio}";
        }

    }
}