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
    public class UbicacionController : ControllerBase
    {
        private readonly IUbicacionApp _ubicacion;

        public UbicacionController(IUbicacionApp UbicacionApp)
        {
            this._ubicacion = UbicacionApp;
        }
        [HttpGet]
        [CustomFilter("000459")]
        public async Task<IEnumerable<UbicacionEnt>> Get()
        {
            return await _ubicacion.Obtener();
        }
        [HttpGet("departamento")]
        [CustomFilter("000460")]
        public async Task<IEnumerable<DepartamentoDTO>> Departamento()
        {
            return await _ubicacion.ObtenerDepartamento();
        }
        [HttpGet("ciudad/{iddepartamento}")]
        [CustomFilter("000461")]
        public async Task<IEnumerable<CiudadDTO>> ObtenerCiudad_ByDepartamento(string iddepartamento)
        {
            return await _ubicacion.ObtenerCiudad_ByDepartamento(iddepartamento);
        }
        [HttpGet("distrito/{idciudad}/{iddepartamento}")]
        [CustomFilter("000462")]
        public async Task<IEnumerable<DistritoDTO>> ObtenerDistrito_ByCiudad_ByDepartamento(string idciudad, string iddepartamento)
        {
            return await _ubicacion.ObtenerDistrito_ByCiudad_ByDepartamento(idciudad, iddepartamento);
        }
    }
}
