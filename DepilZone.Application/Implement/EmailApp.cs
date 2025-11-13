using DepilZone.Application.Interface;
using DepilZone.Data.Interface;
using DepilZone.Domain.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Linq;

namespace DepilZone.Application.Implement
{
    public class EmailApp: IEmailApp
    {
        private readonly IEmailDom _IEmailDom;
        private readonly IParametroSistemaDom _IParametroSistemaDom;
        public EmailApp(IEmailDom IEmailDom, IParametroSistemaDom IParametroSistemaDom)
        {
            _IEmailDom = IEmailDom;
            _IParametroSistemaDom = IParametroSistemaDom;
        }

        public async Task<int> EnvioEmail(EmailEnvioDTO model)
        {
            return await _IEmailDom.EnvioEmail(model);
        }

        public async Task SendEmailAsync(EmailEnvioDTO model)
        {
            await _IEmailDom.SendEmailAsync(model);
        }
    }
}
