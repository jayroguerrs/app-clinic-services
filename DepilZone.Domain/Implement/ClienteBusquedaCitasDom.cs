using DepilZone.Data.Interface;
using DepilZone.Domain.Interface;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Domain.Implement
{
    public class ClienteBusquedaCitasDom : IClienteBusquedaCitasDom
    {
        private readonly IClienteBusquedaCitasDat _ClienteBusquedaCitasDat;
        public ClienteBusquedaCitasDom(IClienteBusquedaCitasDat IClienteBusquedaCitas)
        {
            this._ClienteBusquedaCitasDat = IClienteBusquedaCitas;
        }

        public async Task<IEnumerable<ClienteResultDTO>> BusquedaCliente(string datoCliente)
        {
            return await _ClienteBusquedaCitasDat.BusquedaCliente(datoCliente);
        }

        public async Task<ResponseCitasClienteDTO> ObtenerClienteCitas(int IdCliente)
        {
            return await _ClienteBusquedaCitasDat.ObtenerClienteCitas(IdCliente);
        }
        public async Task<ResponseCitasClienteDTO> ObtenerCitasGlobales(DateTime fechaCita, int? Pagina, int? RowsPerPage, int? Sede, int? EstadoCita, int? Servicio, int? TipoCliente, int? TipoCita, string? HoraDesde, string? HoraHasta)
        {
            return await _ClienteBusquedaCitasDat.ObtenerCitasGlobales(fechaCita, Pagina, RowsPerPage, Sede, EstadoCita, Servicio, TipoCliente, TipoCita, HoraDesde, HoraHasta);
        }
        public async Task<IEnumerable<ResponseCitasClienteCcvoxDTO>> ObtenerClienteCitasCcvox(int[] ids)
        {
            return await _ClienteBusquedaCitasDat.ObtenerClienteCitasCcvox(ids);
        }
        public async Task<ResponseCitasBusquedaPorIdDTO> BusquedaCitaPorId(int IdCita)
        {
            return await _ClienteBusquedaCitasDat.BusquedaCitaPorId(IdCita);
        }

        public async Task<IEnumerable<VerTotalesDTO>> VerCitasTotales(DateTime fechaCita)
        {
            return await _ClienteBusquedaCitasDat.VerCitasTotales(fechaCita);
        }

    }
}
