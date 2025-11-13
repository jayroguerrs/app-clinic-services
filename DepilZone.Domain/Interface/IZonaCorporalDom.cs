using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Data.Interface
{
    public interface IZonaCorporalDom
    {
        Task<IEnumerable<ZonaCorporalGridDTO>> Obtener();
        Task<IEnumerable<ZonaCorporalGridDTO>> ObtenerListado();
        Task<IEnumerable<ZonaServicio>> ObtenerListadoZonaCorporalServicio();        
        Task<List<ZonaCorporalGridDTO>> ObtenerListadoByServicio(int idServicio);
        Task<IEnumerable<ZonaCorporalGridDTO>> ObtenerByNombre(string Nombre);
        Task<ZonaCorporalEnt> ObtenerById(int Id);
        Task<IEnumerable<ZonaCorporalDTO>> ObtenerByGenero(int Id);
        Task<IEnumerable<ZonaCorporalDTO>> ObtenerByGeneroByServicio(int idGenero, int idServicio);
        Task<IEnumerable<ZonaCorporalDTO>> ObtenerByGeneroByPromocion(int Id, int IdPromocion);
        Task<IEnumerable<ZonaCorporalDTO>> ObtenerByGeneroByPromocionByServicio(int Id, int IdPromocion, int idServicio);
        Task<IEnumerable<ZonaCorporalDTO>> ObtenerZonasParaSubZonaByGenero(int IdZona);
        Task<Respuesta<ZonaCorporalDTO>> Insertar(ZonaCorporalDTO model);
        Task<Respuesta<ZonaCorporalDTO>> Modificar(ZonaCorporalDTO model);
        Task<IEnumerable<ZonaPromocionEnt>> ObtenerZonas_PromocionByIdZona(int id);
        Task<IEnumerable<ZonaCitaEnt>> ObtenerZonaByCita(int idcita);
        Task<IEnumerable<ZonaPromocionEnt>> Obtener_PromocionesPorZonasCorporales(string idsZonas);
        Task<Respuesta<ZonaCorporalDTO>> AsignarSubZones(int id, int[] idZones);
        Task<IEnumerable<ZonaCorporalDTO>> ObtenerSubZonasById(int Id);


        Task<List<ZonaCantidad>>  ObtenerTop10Cantidad(DateTime fechaInicio, DateTime fechaFin, int idSede, int idGenero, int numeroSesion, int idTipo);
        Task<List<ZonaCantidad>>  ObtenerCantidad(DateTime fechaInicio, DateTime fechaFin, int idSede, int idGenero, int numeroSesion, int idTipo);
    }
}
