using DepilZone.Api.CustomFilter;
using DepilZone.Application.Implement;
using DepilZone.Application.Interface;
using DepilZone.Entidad.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DepilZone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ClienteBusquedaCitasController : ControllerBase
    {
        private readonly IClienteBusquedaCitasApp _ClienteBusquedaCitasApp;

        public ClienteBusquedaCitasController(IClienteBusquedaCitasApp ClienteBusquedaCitasApp)
        {
            this._ClienteBusquedaCitasApp = ClienteBusquedaCitasApp;
        }

        [HttpGet("BusquedaCliente/{DatoCliente}")]
        public async Task<IEnumerable<ClienteResultDTO>> BusquedaCliente(string DatoCliente)
        {
            return await _ClienteBusquedaCitasApp.BusquedaCliente(DatoCliente);
        }


        [HttpGet("listadoByCliente/{IdCliente}")]
        public async Task<ResponseCitasClienteDTO> ObtenerListadoCitas(int IdCliente)
        {
            return await _ClienteBusquedaCitasApp.ObtenerClienteCitas(IdCliente);
        }
        [HttpGet("listadoGlobal/{fechaCita}")]
        public async Task<ResponseCitasClienteDTO> ObtenerCitasGlobales(DateTime fechaCita, [FromQuery] int? Pagina, [FromQuery] int? RowsPerPage, [FromQuery] int? Sede, [FromQuery] int? EstadoCita, [FromQuery] int? Servicio, [FromQuery] int? TipoCliente, [FromQuery] int? TipoCita, [FromQuery] string? HoraDesde, [FromQuery] string? HoraHasta)
        {
            return await _ClienteBusquedaCitasApp.ObtenerCitasGlobales(fechaCita, Pagina, RowsPerPage, Sede, EstadoCita, Servicio, TipoCliente, TipoCita, HoraDesde, HoraHasta);
        }
        [HttpGet("verTotales/{fechaCita}")]
        public async Task<IEnumerable<VerTotalesDTO>> VerCitasTotales(DateTime fechaCita)
        {
            return await _ClienteBusquedaCitasApp.VerCitasTotales(fechaCita);
        }
        [HttpGet("listadoCitasClienteCcvox")]
        public async Task<IEnumerable<ResponseCitasClienteCcvoxDTO>> ObtenerClienteCitasCcvox([FromQuery] string ids)
        {
            int[] idsArray = ids.Split('-').Select(int.Parse).ToArray();

            return await _ClienteBusquedaCitasApp.ObtenerClienteCitasCcvox(idsArray);
        }
        [HttpGet("busquedaCitaPorId/{IdCita}")]
        public async Task<ResponseCitasBusquedaPorIdDTO> BusquedaCitaPorId(int IdCita)
        {
            return await _ClienteBusquedaCitasApp.BusquedaCitaPorId(IdCita);
        }
        
    }
}
