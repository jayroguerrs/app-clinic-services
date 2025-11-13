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
    public class DocumentoApp : IDocumentoApp
    {
        private readonly IDocumentoDom _IDocumentoDom;
        private readonly IEmailDom _IEmailDom;
        public DocumentoApp(IDocumentoDom IDocumentoDom)
        {
            this._IDocumentoDom = IDocumentoDom;
        }
        public DocumentoApp(IDocumentoDom IDocumentoDom, IEmailDom IEmailDom, IParametroSistemaDom IParametroSistemaDom)
        {
            _IDocumentoDom = IDocumentoDom;
            _IEmailDom = IEmailDom;
        }
        public async Task<IEnumerable<DocumentoTipoEnt>> ObtenerTipoDocumento()
        {
            return await _IDocumentoDom.ObtenerTipoDocumento();
        }
        public async Task<IEnumerable<DocumentoTipoEnt>> ObtenerTipoDocumentoByPerfil(int idPerfil)
        {
            return await _IDocumentoDom.ObtenerTipoDocumentoByPerfil(idPerfil);
        }
        
        public async Task<DocumentoPlantillaDTO> ObtenerPlantilla(int idPlantilla)
        {
            return await _IDocumentoDom.ObtenerPlantilla(idPlantilla);
        }
        public async Task<IEnumerable<DocumentoDTO>> ObtenerListado()
        {
            return await _IDocumentoDom.ObtenerListado();
        }
        public async Task<Respuesta<DocumentoDTO>> Insertar(DocumentoEnt model)
        {
            try
            {
                Respuesta<DocumentoDTO> Documento = await _IDocumentoDom.Insertar(model);
                if (Documento.Exito)
                {
                    if (model.EnviarCorreo) {
                    
                        if (Documento.Response.ClienteEmail != "")
                        {
                            EmailEnvioDTO envioEmail = new EmailEnvioDTO
                            {
                                Asunto = Documento.Response.TituloDocumento,
                                Contenido = "Estimado Cliente se envia una copia de su " + Documento.Response.TituloDocumento,
                                EmailCopiaOculta = Documento.Response.EmailCC,
                                EmailDestino = Documento.Response.ClienteEmail,
                                Adjunto = model.Documento,
                                NombreAdjunto = Documento.Response.TituloDocumento.Replace(" ", "_") + ".pdf"
                            };
                            bool enviado =  await _IEmailDom.SendEmailAsync(envioEmail);
                            if (enviado)
                            {
                                Documento.Response.Mensaje = "Email enviado al cliente";
                                Documento.Response.EmailEnviado = true;
                            }
                            else
                            {
                                Documento.Response.Mensaje = "No se pudo enviar el email";
                                Documento.Response.EmailEnviado = true;
                            }
                        }
                        else
                        {
                            Documento.Response.Mensaje = "Cliente no tiene email registrado";
                            Documento.Response.EmailEnviado = false;
                        }
                    
                    }
                    
                }
                return Documento;
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }
        
        public async Task<IEnumerable<DocumentoDTO>> ObtenerListadoByCliente( int idCliente )
        {
            return await _IDocumentoDom.ObtenerListadoByCliente( idCliente );
        }
        public async Task<Respuesta<DocumentoDTO>> AnularDocumento(int id)
        {
            return await _IDocumentoDom.AnularDocumento(id);
        }
    }
}