using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Domain.Interface
{
    public interface IClienteBusquedaCitasDom
    {
        Task<IEnumerable<ClienteResultDTO>> BusquedaCliente(string datoCliente);
        Task<ResponseCitasClienteDTO> ObtenerClienteCitas(int IdCliente);
        Task<ResponseCitasClienteDTO> ObtenerCitasGlobales(DateTime fechaCita, int? Pagina, int? RowsPerPage, int? Sede, int? EstadoCita, int? Servicio, int? TipoCliente, int? TipoCita, string? HoraDesde, string? HoraHasta);
        Task<IEnumerable<ResponseCitasClienteCcvoxDTO>> ObtenerClienteCitasCcvox(int[] ids);
        Task<ResponseCitasBusquedaPorIdDTO> BusquedaCitaPorId(int IdCita);
        Task<IEnumerable<VerTotalesDTO>> VerCitasTotales(DateTime fechaCita);

    }
}
