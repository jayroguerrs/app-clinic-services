using DepilZone.Application.Interface;
using DepilZone.Data.Implement;
using DepilZone.Data.Interface;
using DepilZone.Domain.Interface;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement
{
    public class ClienteBusquedaCitasApp : IClienteBusquedaCitasApp
    {
        private readonly IClienteBusquedaCitasDom _ClienteBusquedaCitasDom;
        public ClienteBusquedaCitasApp(IClienteBusquedaCitasDom IClienteBusquedaCitasDom)
        {
            this._ClienteBusquedaCitasDom = IClienteBusquedaCitasDom;
        }
        public async Task<IEnumerable<ClienteResultDTO>> BusquedaCliente(string datoCliente)
        {
            return await _ClienteBusquedaCitasDom.BusquedaCliente(datoCliente);
        }
        public async Task<ResponseCitasClienteDTO> ObtenerClienteCitas(int IdCliente)
        {
            return await _ClienteBusquedaCitasDom.ObtenerClienteCitas(IdCliente);
        }
        public async Task<ResponseCitasClienteDTO> ObtenerCitasGlobales(DateTime fechaCita, int? Pagina, int? RowsPerPage, int? Sede, int? EstadoCita, int? Servicio, int? TipoCliente, int? TipoCita, string? HoraDesde, string? HoraHasta)
        {
            return await _ClienteBusquedaCitasDom.ObtenerCitasGlobales(fechaCita, Pagina, RowsPerPage, Sede, EstadoCita, Servicio, TipoCliente, TipoCita, HoraDesde, HoraHasta);
        }
        public async Task<IEnumerable<ResponseCitasClienteCcvoxDTO>> ObtenerClienteCitasCcvox(int[] ids)
        {
            return await _ClienteBusquedaCitasDom.ObtenerClienteCitasCcvox(ids);
        }
        public async Task<ResponseCitasBusquedaPorIdDTO> BusquedaCitaPorId(int IdCita)
        {
            return await _ClienteBusquedaCitasDom.BusquedaCitaPorId(IdCita);
        }

        public async Task<IEnumerable<VerTotalesDTO>> VerCitasTotales(DateTime fechaCita)
        {
            return await _ClienteBusquedaCitasDom.VerCitasTotales(fechaCita);
        }
    }
}
