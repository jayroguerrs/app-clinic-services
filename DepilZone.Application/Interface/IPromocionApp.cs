using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Interface
{
    public interface IPromocionApp
    {
        Task<IEnumerable<PromocionGrillaDTO>> Obtener(int activo);
        Task<IEnumerable<PromocionGrillaDTO>> ObtenerParaModulo(int activo);
        Task<IEnumerable<PromocionGrillaDTO>> ObtenerParaModuloByServicio(int activo, int idServicio);
        Task<IEnumerable<PromocionGrillaDTO>> ObtenerPorServicio(int activo, int idServicio);
        Task<IEnumerable<PromocionGrillaDTO>> ObtenerPorCategoria(int idCategoria, int activo);
        Task<IEnumerable<PromocionGrillaDTO>> ObtenerByLikeNombre(string Nombre);

        Task<IEnumerable<PromocionVistaDetalleDTO>> ObtenerPromocionVistaDetalle(int idPromocion);
        Task<IEnumerable<PromocionVistaDatosPlantillaDTO>> ObtenerPromocionVistaPlantilla(int idPromocion);
        Task<PromocionVistaDatosCondicionadoDTO> ObtenerPromocionVistaCondicionado(int idPromocion);

        Task<Respuesta<PromocionEnt>> Insertar(PromocionEnt model);
        Task<Respuesta<PromocionEnt>> Modificar(PromocionEnt model);
        Task<PromocionDTO> ObtenerById(int idpromocion);

        Task<List<PromocionRanking>> ObtenerRanking(DateTime fechaInicio, DateTime fechaFin, int idSede, int idPromocion);

        Task<List<PromocionRanking>> ObtenerRankingVenta(DateTime fechaInicio, DateTime fechaFin, int idSede, int idPromocion);
        Task<List<PromocionRanking>> ObtenerRankingAtendido(DateTime fechaInicio, DateTime fechaFin, int idSede, int idPromocion);


        Task<List<PromocionZonaRanking>> ObtenerTop10Zonas(DateTime fechaInicio, DateTime fechaFin, int idSede, int idTipoZona, int idPromocion);

        Task<List<PromocionZonaRanking>> ObtenerBottom10Zonas(DateTime fechaInicio, DateTime fechaFin, int idSede, int idTipoZona, int idPromocion);

        Task<List<PromocionZonaRanking>> ObtenerZonasRanking(DateTime fechaInicio, DateTime fechaFin, int idSede, int idTipoZona, int idPromocion);

        Task<bool> Clonar(int idPromocion, int idUsuario);
        Task<GeneralResponse<bool>> UpdateAllPromotionStatus(PromocionStatusDTO[] promotionIds);
    }
}
