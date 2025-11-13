using DepilZone.Data.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Application.Interface
{
    public interface IEmailApp
    {
        Task SendEmailAsync(EmailEnvioDTO model);
        Task<int> EnvioEmail(EmailEnvioDTO model);
    }
}
