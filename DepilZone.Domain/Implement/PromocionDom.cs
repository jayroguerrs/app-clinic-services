using DepilZone.Data.Interface;
using DepilZone.Domain.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Domain.Implement
{
    public class PromocionDom: IPromocionDom
    {
        private readonly IPromocionDat _IPromocionDat;
        public PromocionDom(IPromocionDat IPromocionDat)
        {
            this._IPromocionDat = IPromocionDat;
        }
        public async Task<IEnumerable<PromocionGrillaDTO>> Obtener(int activo)
        {
            return await _IPromocionDat.Obtener(activo);
        }

        public async Task<IEnumerable<PromocionGrillaDTO>> ObtenerParaModulo(int activo)
        {
            return await _IPromocionDat.ObtenerParaModulo(activo);
        }

        public async Task<IEnumerable<PromocionGrillaDTO>> ObtenerParaModuloByServicio(int activo, int idServicio)
        {
            return await _IPromocionDat.ObtenerParaModuloByServicio(activo, idServicio);
        }

        public async Task<IEnumerable<PromocionGrillaDTO>> ObtenerPorServicio(int activo, int idServicio)
        {
            return await _IPromocionDat.ObtenerPorServicio(activo, idServicio);
        }

        public async Task<IEnumerable<PromocionGrillaDTO>> ObtenerPorCategoria(int idCategoria, int activo)
        {
            return await _IPromocionDat.ObtenerPorCategoria(idCategoria, activo);
        }
        public async Task<PromocionDTO> ObtenerById(int id)
        {
            return await _IPromocionDat.ObtenerById(id);
        }
        public async Task<IEnumerable<PromocionVistaDetalleDTO>> ObtenerPromocionVistaDetalle(int idPromocion)
        {
            return await _IPromocionDat.ObtenerPromocionVistaDetalle(idPromocion);
        }
        public async Task<IEnumerable<PromocionVistaDatosPlantillaDTO>> ObtenerPromocionVistaPlantilla(int idPromocion)
        {
            return await _IPromocionDat.ObtenerPromocionVistaPlantilla(idPromocion);
        }
        public async Task<PromocionVistaDatosCondicionadoDTO> ObtenerPromocionVistaCondicionado(int idPromocion)
        {
            return await _IPromocionDat.ObtenerPromocionVistaCondicionado(idPromocion);
        }


        public async Task<IEnumerable<PromocionGrillaDTO>> ObtenerByLikeNombre(string Nombre)
        {
            return await _IPromocionDat.ObtenerByLikeNombre(Nombre);
        }

        public async Task<Respuesta<PromocionEnt>> Insertar(PromocionEnt model)
        {
            return await _IPromocionDat.Insertar(model);
        }
        public async Task<Respuesta<PromocionEnt>> Modificar(PromocionEnt model)
        {
            return await _IPromocionDat.Modificar(model);
        }

        public async Task<List<PromocionRanking>> ObtenerRanking(DateTime fechaInicio, DateTime fechaFin, int idSede, int idPromocion)
        {
            return await _IPromocionDat.ObtenerRanking( fechaInicio,  fechaFin,  idSede, idPromocion);
        }


        public async Task<List<PromocionRanking>> ObtenerRankingAtendido(DateTime fechaInicio, DateTime fechaFin, int idSede, int idPromocion)
        {
            return await _IPromocionDat.ObtenerRankingAtendido(fechaInicio, fechaFin, idSede, idPromocion);
        }

        public async Task<List<PromocionRanking>> ObtenerRankingVenta(DateTime fechaInicio, DateTime fechaFin, int idSede, int idPromocion)
        {
            return await _IPromocionDat.ObtenerRankingVenta(fechaInicio, fechaFin, idSede, idPromocion);
        }


        public async Task<List<PromocionZonaRanking>> ObtenerTop10Zonas(DateTime fechaInicio, DateTime fechaFin, int idSede, int idTipoZona, int idPromocion)
        {
            return await _IPromocionDat.ObtenerTop10Zonas(fechaInicio, fechaFin, idSede, idTipoZona, idPromocion);
        }

        public async Task<List<PromocionZonaRanking>> ObtenerBottom10Zonas(DateTime fechaInicio, DateTime fechaFin, int idSede, int idTipoZona, int idPromocion)
        {
            return await _IPromocionDat.ObtenerBottom10Zonas(fechaInicio, fechaFin, idSede, idTipoZona, idPromocion);
        }

        public async Task<List<PromocionZonaRanking>> ObtenerZonasRanking(DateTime fechaInicio, DateTime fechaFin, int idSede, int idTipoZona, int idPromocion)
        {
            return await _IPromocionDat.ObtenerZonasRanking(fechaInicio, fechaFin, idSede, idTipoZona, idPromocion);
        }

        public async Task<bool> Clonar(int idPromocion, int idUsuario)
        {
            return await _IPromocionDat.Clonar(idPromocion, idUsuario);
        }
        public async Task<GeneralResponse<bool>> UpdateAllPromotionStatus(PromocionStatusDTO[] promotionIds)
        {
            return await _IPromocionDat.UpdateAllPromotionStatus(promotionIds);
        }
    }
}
