using DepilZone.Application.Interface;
using DepilZone.Domain.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement
{
    public class PromocionApp: IPromocionApp
    {
        private readonly IPromocionDom _IPromocionDom;
        public PromocionApp(IPromocionDom IPromocionDom)
        {
            this._IPromocionDom = IPromocionDom;
        }

        public async Task<IEnumerable<PromocionGrillaDTO>> Obtener(int activo)
        {
            return await _IPromocionDom.Obtener(activo);
        }

        public async Task<IEnumerable<PromocionGrillaDTO>> ObtenerParaModulo(int activo)
        {
            return await _IPromocionDom.ObtenerParaModulo(activo);
        }

        public async Task<IEnumerable<PromocionGrillaDTO>> ObtenerParaModuloByServicio(int activo, int idServicio)
        {
            return await _IPromocionDom.ObtenerParaModuloByServicio(activo, idServicio);
        }

        public async Task<IEnumerable<PromocionGrillaDTO>> ObtenerPorServicio(int activo, int idServicio)
        {
            return await _IPromocionDom.ObtenerPorServicio(activo, idServicio);
        }

        public async Task<IEnumerable<PromocionGrillaDTO>> ObtenerPorCategoria(int idCategoria, int activo)
        {
            return await _IPromocionDom.ObtenerPorCategoria(idCategoria, activo);
        }
        public async Task<IEnumerable<PromocionVistaDetalleDTO>> ObtenerPromocionVistaDetalle(int idPromocion)
        {
            return await _IPromocionDom.ObtenerPromocionVistaDetalle(idPromocion);
        }
        public async Task<IEnumerable<PromocionVistaDatosPlantillaDTO>> ObtenerPromocionVistaPlantilla(int idPromocion)
        {
            return await _IPromocionDom.ObtenerPromocionVistaPlantilla(idPromocion);
        }
        public async Task<PromocionVistaDatosCondicionadoDTO> ObtenerPromocionVistaCondicionado(int idPromocion)
        {
            return await _IPromocionDom.ObtenerPromocionVistaCondicionado(idPromocion);
        }


        public async Task<PromocionDTO> ObtenerById(int idpromocion)
        {
            return await _IPromocionDom.ObtenerById(idpromocion);
        }

        public async Task<IEnumerable<PromocionGrillaDTO>> ObtenerByLikeNombre(string Nombre)
        {
            return await _IPromocionDom.ObtenerByLikeNombre(Nombre);
        }

        public async Task<Respuesta<PromocionEnt>> Insertar(PromocionEnt model)
        {
            return await _IPromocionDom.Insertar(model);
        }

        public async Task<Respuesta<PromocionEnt>> Modificar(PromocionEnt model)
        {
            return await _IPromocionDom.Modificar(model);
        }

        public async Task<List<PromocionRanking>> ObtenerRanking(DateTime fechaInicio, DateTime fechaFin, int idSede, int idPromocion)
        {
            return await _IPromocionDom.ObtenerRanking( fechaInicio,  fechaFin,  idSede, idPromocion);
        }


        public async Task<List<PromocionRanking>> ObtenerRankingVenta(DateTime fechaInicio, DateTime fechaFin, int idSede, int idPromocion)
        {
            return await _IPromocionDom.ObtenerRankingVenta(fechaInicio, fechaFin, idSede, idPromocion);
        }

        public async Task<List<PromocionRanking>> ObtenerRankingAtendido(DateTime fechaInicio, DateTime fechaFin, int idSede, int idPromocion)
        {
            return await _IPromocionDom.ObtenerRankingAtendido(fechaInicio, fechaFin, idSede, idPromocion);
        }


        public async Task<List<PromocionZonaRanking>> ObtenerTop10Zonas(DateTime fechaInicio, DateTime fechaFin, int idSede, int idTipoZona, int idPromocion)
        {
            return await _IPromocionDom.ObtenerTop10Zonas(fechaInicio, fechaFin, idSede,  idTipoZona, idPromocion);
        }

        public async Task<List<PromocionZonaRanking>> ObtenerBottom10Zonas(DateTime fechaInicio, DateTime fechaFin, int idSede, int idTipoZona, int idPromocion)
        {
            return await _IPromocionDom.ObtenerBottom10Zonas(fechaInicio, fechaFin, idSede, idTipoZona, idPromocion);
        }

        public async Task<List<PromocionZonaRanking>> ObtenerZonasRanking(DateTime fechaInicio, DateTime fechaFin, int idSede, int idTipoZona, int idPromocion)
        {
            return await _IPromocionDom.ObtenerZonasRanking(fechaInicio, fechaFin, idSede, idTipoZona, idPromocion);
        }

        public async Task<bool> Clonar(int idPromocion, int idUsuario)
        {
            return await _IPromocionDom.Clonar(idPromocion, idUsuario);
        }

        public async Task<GeneralResponse<bool>> UpdateAllPromotionStatus(PromocionStatusDTO[] promotionIds)
        {
            return await _IPromocionDom.UpdateAllPromotionStatus(promotionIds);
        }

    }
}
