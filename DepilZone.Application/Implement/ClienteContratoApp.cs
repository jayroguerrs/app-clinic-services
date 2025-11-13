using DepilZone.Application.Interface;
using DepilZone.Data.Interface;
using DepilZone.Domain.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using DepilZone.Entidad.Exceptions;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace DepilZone.Application.Implement
{
    public class ClienteContratoApp : IClienteContratoApp
    {
        private readonly IClienteContratoDom _IClienteContratoDom;
        private readonly IClienteDom _IClienteDom;
        private readonly IParametroSistemaDom _IParametroSistemaDom;
        private readonly IEmailDom _IEmailDom;

        public ClienteContratoApp(IClienteContratoDom IClienteContratoDom, IEmailDom IEmailDom, IClienteDom IClienteDom, IParametroSistemaDom IParametroSistemaDom)
        {
            _IClienteContratoDom = IClienteContratoDom;
            _IEmailDom = IEmailDom;
            _IClienteDom = IClienteDom;
            _IParametroSistemaDom = IParametroSistemaDom;
        }

        public async Task<Respuesta<ClienteContratoDTO>> GuardarContrato(ClienteContratoDTO model)
        {
            Respuesta<ClienteContratoDTO> Contrato = await _IClienteContratoDom.GuardarContrato(model);
            if (Contrato.Exito)
            {
                //if (model.EnviarCorreo) {
                    if (Contrato.Response.ClienteEmail != "")
                    {
                        EmailEnvioDTO envioEmail = new EmailEnvioDTO
                        {
                            //Asunto = Contrato.Response.TituloContrato,
                            Asunto = "Confirmar Acta de entrega de Documentos del Contrato N° #" + Contrato.Response.Id.ToString().PadLeft(6, '0'),
                            Contenido = "Estimado Cliente se envia una copia de su " + Contrato.Response.TituloContrato,
                            EmailCopiaOculta = Contrato.Response.EmailCC,
                            EmailDestino = Contrato.Response.ClienteEmail,
                            DocumentosRenderizados = model.DocumentosRenderizados,
                            IdContrato = Contrato.Response.Id
                        };
                        bool enviado = await _IEmailDom.SendEmailAsync(envioEmail);
                        if (enviado)
                        {
                            Contrato.Response.Observacion = "Email enviado al cliente";
                            Contrato.Response.EmailEnviado = true;

                            await _IClienteContratoDom.SeEnvioContrato(Contrato.Response.Id);
                        }
                        else
                        {
                            Contrato.Response.Observacion = "No se pudo enviar el email";
                            Contrato.Response.EmailEnviado = false;
                        }
                    }
                    else
                    {
                        Contrato.Response.Observacion = "Cliente no tiene email registrado";
                        Contrato.Response.EmailEnviado = false;
                    }
                //}
            }

            return Contrato;
        }

        public async Task<Respuesta<bool>> AnularContrato(int id, ClienteContratoDTO model)
        {
            return await _IClienteContratoDom.AnularContrato(id, model);
        }

        public async Task<List<ClienteContratoDTO>> ListarByIdCliente(int id)
        {
            return await _IClienteContratoDom.ListarByIdCliente(id);
        }

        public async Task<List<ClienteContratoDTO>> ListarByIdClientePorServicio(int id, int idServicio)
        {
            return await _IClienteContratoDom.ListarByIdClientePorServicio(id, idServicio);
        }

        public async Task<ClienteContratoDTO> verContrato(int idContrato)
        {
            return await _IClienteContratoDom.verContrato(idContrato);
        }

        public async Task<bool> EnviarContratoPorCorreo(ClienteContratoDTO model)
        {
            ClienteDTO cliente = await _IClienteDom.ObtenerById(model.IdCliente);
            Respuesta<ParametroSistemaEnt> emailCC = await _IParametroSistemaDom.ObtenerById(10);

            if (cliente.Correo == "" || cliente.Correo == null)
            {
                throw new AlertException("El cliente no tiene correo registrado.");
            }

            if(model.IdEstado == 0)
            {
                throw new AlertException("El contrato se encuentra anulado.");
            }

            EmailEnvioDTO envioEmail = new EmailEnvioDTO
            {
                Asunto = "Confirmar Acta de entrega de Documentos del Contrato N° #" + model.Id.ToString().PadLeft(6, '0'),
                Contenido = "Estimado Cliente se envia una copia del Acta de entrega de Documentos del Contrato N° #" + model.Id.ToString().PadLeft(6, '0'),
                EmailCopiaOculta = emailCC.Response.Valor,
                EmailDestino = cliente.Correo,
                DocumentosRenderizados = model.DocumentosRenderizados,
                IdContrato = model.Id
            };

            bool enviado = await _IEmailDom.SendEmailAsync(envioEmail);
            if (enviado)
            {
                await _IClienteContratoDom.SeEnvioContrato(model.Id);
                return true;
            }
            else
            {
                return false;
            }

            //await _IClienteContratoDom.SeEnvioContrato(model.Id);

            //return true;
        }

        public async Task<ClienteContratoConfirmadoDTO> BuscarContratoConfirmado(string idContrato)
        {
            return await _IClienteContratoDom.BuscarContratoConfirmado(idContrato);
        }

        public async Task<bool> ConfirmarContrato(string idContrato, int idCliente)
        {

            bool output =  await _IClienteContratoDom.ConfirmarContrato(idContrato, idCliente);

            if (output)
            {
                ClienteContratoDTO contrato = await _IClienteContratoDom.DatosContrato(idContrato);

                ClienteDTO cliente = await _IClienteDom.ObtenerById(idCliente);
                if (cliente.Correo == "" || cliente.Correo == null)
                {
                    throw new AlertException("El cliente no tiene correo registrado.");
                }

                Respuesta<ParametroSistemaEnt> emailCC = await _IParametroSistemaDom.ObtenerById(10);
                EmailEnvioDTO envioEmail = new EmailEnvioDTO
                {
                    Asunto = "Confirmación Exitosa - Acta de entrega del Documentos del Contrato N° #" + contrato.Id.ToString().PadLeft(6, '0'),
                    MensajeCliente = "Por medio de la presente, confirmo la recepción del acta de entrega de los documentos correspondientes al Contrato N° " + contrato.Id.ToString().PadLeft(6, '0') + ". Declaro que he revisado y leído detenidamente cada uno de los documentos proporcionados. Después de dicha revisión, manifiesto estar de acuerdo con todos los términos y condiciones establecidos en el mencionado contrato.",
                    Contenido = "Gracias por confirmar la recepción de los documentos del contrato N° #" + contrato.Id.ToString().PadLeft(6, '0'),
                    EmailCopiaOculta = emailCC.Response.Valor,
                    EmailDestino = cliente.Correo,
                    IdContrato = contrato.Id
                };
                bool enviado = await _IEmailDom.SendEmailAsync(envioEmail);

                if (!enviado)
                {
                    throw new AlertException("No se pudo enviar el email" + cliente.Correo);
                }
            }

            return output;
        }
    }
}