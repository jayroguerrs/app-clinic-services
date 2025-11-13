using DepilZone.Api.CustomFilter;
using DepilZone.Api.Hubs;
using DepilZone.Application.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace DepilZone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class PerfilController : ControllerBase
    {
        private readonly IPerfilApp _perfil;
        private readonly IHubContext<SignalHub> _hubContext;

        public PerfilController(IPerfilApp PerfilApp, IHubContext<SignalHub> hubContext)
        {
            this._perfil = PerfilApp;
            _hubContext = hubContext;
        }

        [HttpGet]
        //[CustomFilter("000416")]
        public async Task<IEnumerable<PerfilEnt>> Get()
        {
            return await _perfil.Obtener();
        }
        [HttpGet("{idPerfil}")]
        [CustomFilter("000417")]
        public async Task<PerfilConfiguracionDTO> GetById(int idPerfil)
        {
            return await _perfil.ObtenerById(idPerfil);
        }
        [HttpPost]
        [CustomFilter("000418")]
        public async Task<Respuesta<PerfilEnt>> Insertar(PerfilDTO perfil)
        {
            return await _perfil.Insertar(perfil);
        }
        [HttpPut]
        [CustomFilter("000419")]
        public async Task<Respuesta<PerfilEnt>> Modificar(PerfilDTO perfil)
        {
            try
            {
                var output =  await _perfil.Modificar(perfil);

                MensajeSignalR mensajeSignalR = new MensajeSignalR()
                {
                    Exito = true,
                    IdPerfil = perfil.IdPerfil,
                    Mensaje = TipoAlerta.MenuActualizado.ToString(),
                    DatosJSON = JsonSerializer.Serialize(new { IdPerfil = perfil.IdPerfil, Mensaje = "Se acaba de actualizar "}),
                    Tipo = TipoAlerta.MenuActualizado
                };
                await _hubContext.Clients.All.SendAsync("mensajeroSignal", mensajeSignalR);

                return output;
            }
            catch (Exception e)
            {
                throw e;
            }
            
        }
    }
}
