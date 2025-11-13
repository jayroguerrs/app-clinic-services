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
	public class CitaDetalleController : Controller
	{
		private readonly ICitaDetalleApp _citaDetalle;

		public CitaDetalleController(ICitaDetalleApp DetalleCitaApp)
		{
			this._citaDetalle = DetalleCitaApp;
		}

		[HttpGet("horarioNoDisponible/{fecha},{idMaquina},{idSede},{idUsuario},{idAccion}, {idCita}")]
		[CustomFilter("000267")]
		public async Task<IEnumerable<CitaNoDisponibleDTO>> GetHorarioNoDisponible(DateTime fecha, int idMaquina, int idSede, int idUsuario,int idAccion, int idCita)
		{
            try
            {
				return await _citaDetalle.GetHorarioNoDisponible(fecha, idMaquina, idSede, idUsuario, idAccion, idCita);
			}
            catch (Exception ex)
            {
                throw ex;
            }
		}
		[HttpGet("cita/{idCita}")]
        [CustomFilter("000268")]
        public async Task<IEnumerable<CitaDetalleZonaDTO>> ObtenerDetalleCitaByCita( int idCita )
        {
            try
            {
				return await _citaDetalle.ObtenerDetallesCitaByCita(idCita);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
