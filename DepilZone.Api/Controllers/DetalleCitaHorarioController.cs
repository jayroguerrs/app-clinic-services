using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DepilZone.Api.CustomFilter;
using DepilZone.Application.Interface;
using DepilZone.Entidad;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DepilZone.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
    [Authorize]

    public class DetalleCitaHorarioController : Controller
	{
		private readonly IDetalleCitaHorarioApp _detalleCitaHorario;
	
		public DetalleCitaHorarioController(IDetalleCitaHorarioApp DetalleCitaHorarioApp)
		{
			this._detalleCitaHorario = DetalleCitaHorarioApp;
		}
		[HttpGet]
		[CustomFilter("000348")]
		public async Task<IEnumerable<DetalleCitaHorarioEnt>> Get()
		{
			return await _detalleCitaHorario.Obtener();
		}
		[HttpPost]
        [CustomFilter("000349")]
		public async Task<Respuesta<DetalleCitaHorarioEnt>> Post(DetalleCitaHorarioEnt model)
		{
			return await _detalleCitaHorario.Insertar(model);
		}
		[HttpPut("{id}")]
        [CustomFilter("000350")]
		public async Task<Respuesta<DetalleCitaHorarioEnt>> Put(DetalleCitaHorarioEnt model)
		{
			return await _detalleCitaHorario.Modificar(model);
		}
		[HttpGet("{id}")]
        [CustomFilter("000351")]
		public async Task<DetalleCitaHorarioEnt> Get(int id)
		{
			return await _detalleCitaHorario.ObtenerById(id);
		}
		[HttpGet("{horainicio},{horafin},{IdMaquina},{IdSede}")]
        [CustomFilter("000352")]
		public async Task<IEnumerable<RangoHorarioEnt>> Obteneridhorariocita(string horainicio, string horafin, int IdMaquina,int IdSede)
		{
			return await _detalleCitaHorario.Obteneridhorariocita(horainicio, horafin, IdMaquina , IdSede);
		}
	}
}
