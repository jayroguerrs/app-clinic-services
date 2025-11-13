using DepilZone.Application.Interface;
using DepilZone.Entidad;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using DepilZone.Entidad.DTO;
using System;
using Microsoft.AspNetCore.Authorization;
using DepilZone.Api.CustomFilter;

namespace DepilZone.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
    [Authorize]

    public class EmpresaController : Controller
	{
		private readonly IEmpresaApp _EmpresaApp;
		public EmpresaController(IEmpresaApp IEmpresaApp)
		{
			this._EmpresaApp = IEmpresaApp;
		}
		[HttpGet("dasdasdas")]
		[CustomFilter("000376")]
		public async Task<IEnumerable<EmpresaEnt>> Get()
		{
			return await _EmpresaApp.Obtener();
		}
		[HttpGet("ticket/{idCita}")]
		//[CustomFilter("000377")]
		public async Task<EmpresaEmisionTicketDTO> ObtenerEmpresaEmisionTicketByCita(int idCita)
		{
			try
			{
                return await _EmpresaApp.ObtenerEmpresaEmisionTicketByCita(idCita);
            }
			catch (Exception E)
			{
				throw E;
			}
			
		}
	}
	
}
