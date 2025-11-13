using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DepilZone.Api.CustomFilter;
using DepilZone.Application.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DepilZone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class EmailController : ControllerBase
    {
        private readonly IEmailApp _emailSender;
        public EmailController(IEmailApp emailSender)
        {
            this._emailSender = emailSender;
        }
        //[HttpOptions("{email},{subject},{message}")]
        //public async Task<EmailSenderCuerpoEnt> SendEmailAsync(string email, string subject, string message, EmailSenderCuerpoEnt View)
        //{


        //    await _emailSender
        //     .SendEmailAsync(email, subject, message)
        //     .ConfigureAwait(false);
        //    return View;
        //}

        [HttpPost("EmailEnvio")]
        [CustomFilter("000375")]
        public async Task<int> EnvioEmail(EmailEnvioDTO model)
        {
            return await _emailSender.EnvioEmail(model);
        }
    }
}
