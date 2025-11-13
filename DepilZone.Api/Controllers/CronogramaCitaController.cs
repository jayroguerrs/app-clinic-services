using DepilZone.Api.Hubs;
using DepilZone.Application.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using System;
using DepilZone.Entidad.DTO;
using Microsoft.AspNetCore.Http;
using DepilZone.Entidad.Exceptions;
using Microsoft.AspNetCore.Authorization;
using DepilZone.Api.CustomFilter;

namespace DepilZone.Api.Controllers
{
	[Route("api/360/[controller]")]
	[ApiController]
    [Authorize]
    public class CronogramaCitaController : ControllerBase
	{
		private readonly ICronogramaCitaApp _CronogramaCita;
		private readonly IHubContext<SignalHub> _hubContext;

		public CronogramaCitaController(ICronogramaCitaApp CronogramaCitaApp, IHubContext<SignalHub> hubContext)
		{
			_CronogramaCita = CronogramaCitaApp;
			_hubContext = hubContext;
		}

		[HttpPost]
        [CustomFilter("000341")]
		public async Task<ActionResult> Post(CronogramaCitaDTO model)
		{
            try
            {
                int idCronograma = await _CronogramaCita.Insertar(model);
                return Ok(new
                {
                    data = idCronograma,
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
		[HttpPut("{id}")]
        [CustomFilter("000342")]
		public async Task<ActionResult> Put(CronogramaCitaDTO model)
		{
            try
            {
                await _CronogramaCita.Modificar(model);
                return Ok(new
                {
                    data = new { },
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
		[HttpGet("{id}")]
        [CustomFilter("000343")]
		public async Task<ActionResult> Find(int id)
		{
            try
            {
                var data = await _CronogramaCita.BuscarCronograma(id);
                return Ok(new
                {
                    data = data,
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
        /*[HttpGet("semanas/{uuid}/{id}")]
        public async Task<ActionResult> GetWeeks(string uuid, int id)
        {
            try
            {
                var data = await _CronogramaCita.ListarSemanas(uuid, id);
                return Ok(new
                {
                    data = data,
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

        }*/
        [HttpGet("cliente/{idCliente}/{idServicio}")]
        [CustomFilter("000344")]
        public async Task<ActionResult> Collection(int idCliente, int idServicio)
        {
            try
            {
                var data = await _CronogramaCita.ListarPorCliente(idCliente, idServicio);
                return Ok(new
                {
                    data = data,
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
        [HttpGet("{idCronograma}/citas")]
        [CustomFilter("000345")]
        public async Task<ActionResult> ListCitas(int idCronograma)
        {
            try
            {
                var data = await _CronogramaCita.ListarCitas(idCronograma);
                return Ok(new
                {
                    data = data,
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
    }
}