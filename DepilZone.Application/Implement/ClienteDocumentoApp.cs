using DepilZone.Application.Interface;
using DepilZone.Data.Interface;
using DepilZone.Domain.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace DepilZone.Application.Implement
{
    public class ClienteDocumentoApp : IClienteDocumentoApp
    {
        private readonly IClienteDocumentoDom _IClienteDocumentoDom;
        private readonly IEmailDom _IEmailDom;

        public ClienteDocumentoApp(IClienteDocumentoDom IClienteDocumentoDom, IEmailDom IEmailDom)
        {
            _IClienteDocumentoDom = IClienteDocumentoDom;
            _IEmailDom = IEmailDom;
        }

        public async Task<ClienteDocumentoDTO> AnularDocumento(int id, ClienteDocumentoDTO model)
        {
            try
            {
                ClienteDocumentoDTO documento =  await _IClienteDocumentoDom.AnularDocumento(id, model);

                if (model.EnviarCorreo)
                {

                    if (documento.ClienteEmail != "")
                    {
                        if (model.Documento != "")
                        {
                            EmailEnvioDTO envioEmail = new EmailEnvioDTO
                            {
                                Asunto = model.NombreDocumento + " (ANULADO)",
                                Contenido = "Estimado Cliente se envia una copia del documento anulado " + "D-" + Convert.ToString(documento.Id).PadLeft(8, '0') + " - " + model.NombreDocumento,
                                EmailCopiaOculta = documento.EmailCC,
                                EmailDestino = documento.ClienteEmail,
                                Adjunto = model.Documento,
                                NombreAdjunto = "D-" + Convert.ToString(documento.Id).PadLeft(8, '0') + " - " + model.NombreDocumento.Replace(" ", "_") + " (ANULADO)" +".pdf"
                            };
                            bool enviado = await _IEmailDom.SendEmailAsync(envioEmail);
                            if (enviado)
                            {
                                bool seEnvio = await _IClienteDocumentoDom.SeEnvioCorreo(documento.Id);

                                documento.Mensaje = "Documento anulado fue enviado al cliente";
                                documento.EmailEnviado = true;
                            }
                            else
                            {
                                //throw new SystemException("No se pudo enviar el email");
                                documento.Mensaje = "No se pudo enviar el documento anulado al email";
                                documento.EmailEnviado = true;
                            }
                            documento.EmailEnviado = false;
                        }
                        else
                        {
                            documento.Mensaje = "El documento adjunto esta vacio";
                        }
                    }
                    else
                    {
                        documento.Mensaje = "Cliente no tiene email registrado";
                        documento.EmailEnviado = false;
                        //throw new SystemException("Cliente no tiene email registrado");
                    }

                }

                return documento;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ClienteDocumentoDTO> RestaurarDocumento(int id, ClienteDocumentoDTO model)
        {
            ClienteDocumentoDTO documento =  await _IClienteDocumentoDom.RestaurarDocumento(id, model);

            if (model.EnviarCorreo)
            {

                if (documento.ClienteEmail != "")
                {
                    if (model.Documento != "")
                    {
                        EmailEnvioDTO envioEmail = new EmailEnvioDTO
                        {
                            Asunto = model.NombreDocumento + " (RESTAURADO)",
                            Contenido = "Estimado Cliente se envia una copia del documento restaurado " + "D-" + Convert.ToString(documento.Id).PadLeft(8, '0') + " - " + model.NombreDocumento,
                            EmailCopiaOculta = documento.EmailCC,
                            EmailDestino = documento.ClienteEmail,
                            Adjunto = model.Documento,
                            NombreAdjunto = "D-" + Convert.ToString(documento.Id).PadLeft(8, '0') + " - " + model.NombreDocumento.Replace(" ", "_") + ".pdf"
                        };
                        bool enviado = await _IEmailDom.SendEmailAsync(envioEmail);
                        if (enviado)
                        {
                            bool seEnvio = await _IClienteDocumentoDom.SeEnvioCorreo(documento.Id);

                            documento.Mensaje = "Documento restaurado fue enviado al cliente";
                            documento.EmailEnviado = true;
                        }
                        else
                        {
                            //throw new SystemException("No se pudo enviar el email");
                            documento.Mensaje = "No se pudo enviar el documento restaurado al email";
                            documento.EmailEnviado = true;
                        }
                        documento.EmailEnviado = false;
                    }
                    else
                    {
                        documento.Mensaje = "El documento adjunto esta vacio";
                    }
                }
                else
                {
                    documento.Mensaje = "Cliente no tiene email registrado";
                    documento.EmailEnviado = false;
                    //throw new SystemException("Cliente no tiene email registrado");
                }

            }

            return documento;
        }

        public async Task<ClienteDocumentoDTO> EnviarDocumentoPorCorreo(ClienteDocumentoDTO model)
        {
            try
            {
                ClienteDocumentoDTO ClienteDocumento = await _IClienteDocumentoDom.EnviarDocumentoPorCorreo(model);


                if (ClienteDocumento.ClienteEmail != "")
                {
                    EmailEnvioDTO envioEmail = new EmailEnvioDTO
                    {
                        Asunto = model.NombreDocumento + (model.IdEstado == 0 ? " (ANULADO)" : ""),
                        Contenido = "Estimado Cliente se envia una copia del documento " + "D-" + Convert.ToString(model.Id).PadLeft(8, '0') + " - " + model.NombreDocumento,
                        EmailCopiaOculta = ClienteDocumento.EmailCC,
                        EmailDestino = ClienteDocumento.ClienteEmail,
                        Adjunto = model.Documento,
                        NombreAdjunto = "D-" + Convert.ToString(model.Id).PadLeft(8, '0') + " - " + model.NombreDocumento.Replace(" ", "_") + (model.IdEstado == 0 ? " (ANULADO)" : "") + ".pdf"
                    };
                    bool enviado = await _IEmailDom.SendEmailAsync(envioEmail);
                    if (enviado)
                    {
                        bool seEnvio = await _IClienteDocumentoDom.SeEnvioCorreo(model.Id);

                        ClienteDocumento.Mensaje = "Documento enviado al cliente";
                        ClienteDocumento.EmailEnviado = true;
                    }
                    else
                    {
                        throw new SystemException("No se pudo enviar el email");
                        // ClienteDocumento.Mensaje = "No se pudo enviar el email";
                        // ClienteDocumento.EmailEnviado = true;
                    }
                }
                else
                {
                    // ClienteDocumento.Mensaje = "Cliente no tiene email registrado";
                    // ClienteDocumento.EmailEnviado = false;
                    throw new SystemException("Cliente no tiene email registrado");
                }

                return ClienteDocumento;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ClienteDocumentoDTO> ObtenerDocumentoById(int id)
        {
            return await _IClienteDocumentoDom.ObtenerDocumentoById(id);
        }

        public async Task<ClienteDocumentoDTO> InsertarDocumento(ClienteDocumentoDTO model)
        {
            try
            {
                ClienteDocumentoDTO clienteDocumento = await _IClienteDocumentoDom.InsertarDocumento(model);

                if (model.EnviarCorreo)
                {

                    if (clienteDocumento.ClienteEmail != "")
                    {
                        if (model.Documento != "")
                        {
                            EmailEnvioDTO envioEmail = new EmailEnvioDTO
                            {
                                Asunto = clienteDocumento.NombreDocumento,
                                Contenido = "Estimado Cliente se envia una copia del documento " + "D-" + Convert.ToString(clienteDocumento.Id).PadLeft(8, '0') + " - " + clienteDocumento.NombreDocumento,
                                EmailCopiaOculta = clienteDocumento.EmailCC,
                                EmailDestino = clienteDocumento.ClienteEmail,
                                Adjunto = model.Documento,
                                NombreAdjunto = "D-" + Convert.ToString(clienteDocumento.Id).PadLeft(8, '0') + " - " + clienteDocumento.NombreDocumento.Replace(" ", "_") + ".pdf"
                            };
                            bool enviado = await _IEmailDom.SendEmailAsync(envioEmail);
                            if (enviado)
                            {
                                bool seEnvio = await _IClienteDocumentoDom.SeEnvioCorreo(clienteDocumento.Id);

                                clienteDocumento.Mensaje = "Documento enviado al cliente";
                                clienteDocumento.EmailEnviado = true;
                            }
                            else
                            {
                                //throw new SystemException("No se pudo enviar el email");
                                clienteDocumento.Mensaje = "No se pudo enviar el email";
                                clienteDocumento.EmailEnviado = true;
                            }
                            clienteDocumento.EmailEnviado = false;
                        }
                        else
                        {
                            clienteDocumento.Mensaje = "El documento adjunto esta vacio";
                        }
                    }
                    else
                    {
                        clienteDocumento.Mensaje = "Cliente no tiene email registrado";
                        clienteDocumento.EmailEnviado = false;
                        //throw new SystemException("Cliente no tiene email registrado");
                    }
                    

                }

                return clienteDocumento;
            }
            catch (Exception e)
            {

                throw e;
            }
            


        }

        public async Task<List<ClienteDocumentoDTO>> obtenerListado()
        {
            return await _IClienteDocumentoDom.obtenerListado();
        }

        public async Task<List<ClienteDocumentoDTO>> obtenerListadoByCliente(int idCliente)
        {
            return await _IClienteDocumentoDom.obtenerListadoByCliente(idCliente);
        }

        public async Task<List<ClienteDocumentoDTO>> obtenerListadoByClientePorServicio(int idCliente, int idServicio)
        {
            return await _IClienteDocumentoDom.obtenerListadoByClientePorServicio(idCliente, idServicio);
        }

        public async Task<List<ClienteDocumentoDTO>> obtenerListadoByIdClienteByFecha(int idCLiente, DateTime fecha)
        {
            return await _IClienteDocumentoDom.obtenerListadoByIdClienteByFecha(idCLiente, fecha);
        }

        public async Task<List<ClienteDocumentoDTO>> obtenerListadoByIdClienteByFechaPorServicio(int idCLiente, DateTime fecha, int idServicio)
        {
            return await _IClienteDocumentoDom.obtenerListadoByIdClienteByFechaPorServicio(idCLiente, fecha, idServicio);
        }

        
    }
}