using DepilZone.Application.Interface;
using DepilZone.Data.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement
{
    public class ZonaCorporalApp: IZonaCorporalApp
    {
        private readonly IZonaCorporalDom _IZonaCorporalDom;
        public ZonaCorporalApp(IZonaCorporalDom IZonaDom)
        {
            this._IZonaCorporalDom = IZonaDom;
        }

        public async Task<IEnumerable<ZonaCorporalGridDTO>> Obtener()
        {
            return await _IZonaCorporalDom.Obtener();
        }
        public async Task<List<ZonaCorporalGridDTO>> ObtenerListadoByServicio(int idServicio)
        {
            return await _IZonaCorporalDom.ObtenerListadoByServicio(idServicio);
        }
        public async Task<IEnumerable<ZonaCorporalGridDTO>> ObtenerListado()
        {
            return await _IZonaCorporalDom.ObtenerListado();
        }
        public async Task<IEnumerable<ZonaServicio>> ObtenerListadoZonaCorporalServicio()
        {
            return await _IZonaCorporalDom.ObtenerListadoZonaCorporalServicio();
        }
        public async Task<IEnumerable<ZonaCorporalGridDTO>> ObtenerByNombre(string nombre)
        {
            return await _IZonaCorporalDom.ObtenerByNombre(nombre);
        }

        public async Task<ZonaCorporalEnt> ObtenerById(int Id)
        {
            return await _IZonaCorporalDom.ObtenerById(Id);
        }
        public async Task<IEnumerable<ZonaCorporalDTO>> ObtenerByGenero(int id)
        {
            return await _IZonaCorporalDom.ObtenerByGenero(id);
        }
        public async Task<IEnumerable<ZonaCorporalDTO>> ObtenerByGeneroByServicio(int idGenero, int idServicio)
        {
            return await _IZonaCorporalDom.ObtenerByGeneroByServicio(idGenero, idServicio);
        }
        public async Task<IEnumerable<ZonaCorporalDTO>> ObtenerByGeneroByPromocion(int id, int idpromocion)
        {
            return await _IZonaCorporalDom.ObtenerByGeneroByPromocion(id,idpromocion);
        }
        public async Task<IEnumerable<ZonaCorporalDTO>> ObtenerByGeneroByPromocionByServicio(int id, int idpromocion, int idServicio)
        {
            return await _IZonaCorporalDom.ObtenerByGeneroByPromocionByServicio(id, idpromocion, idServicio);
        }

        public async Task<IEnumerable<ZonaCitaEnt>> ObtenerZonaByCita(int idcita)
        {
            return await _IZonaCorporalDom.ObtenerZonaByCita(idcita);
        }

        public async Task<Respuesta<ZonaCorporalDTO>> Insertar(ZonaCorporalDTO model)
        {
            return await _IZonaCorporalDom.Insertar(model);
        }

        public async Task<Respuesta<ZonaCorporalDTO>> Modificar(ZonaCorporalDTO model)
        {
            return await _IZonaCorporalDom.Modificar(model);
        }
        
        public async Task<IEnumerable<ZonaPromocionEnt>> ObtenerZonas_PromocionByIdZona(int Id)
        {
            return await _IZonaCorporalDom.ObtenerZonas_PromocionByIdZona(Id);
        }

        public async Task<IEnumerable<ZonaPromocionEnt>> Obtener_PromocionesPorZonasCorporales(string idsZonas)
        {
            return await _IZonaCorporalDom.Obtener_PromocionesPorZonasCorporales(idsZonas);
        }

        public async Task<IEnumerable<ZonaCorporalDTO>> ObtenerZonasParaSubZonaByGenero(int IdZona)
        {
            return await _IZonaCorporalDom.ObtenerZonasParaSubZonaByGenero(IdZona);
        }

        public async Task<Respuesta<ZonaCorporalDTO>> AsignarSubZonas(int Id, int[] idsZonas)
        {
            return await _IZonaCorporalDom.AsignarSubZones(Id, idsZonas);
        }

        public async Task<IEnumerable<ZonaCorporalDTO>> ObtenerSubZonasById(int Id)
        {
            return await _IZonaCorporalDom.ObtenerSubZonasById(Id);
        }

        public async Task<List<ZonaCantidad>> ObtenerCantidad(DateTime fechaInicio, DateTime fechaFin, int idSede, int idGenero, int numeroSesion, int idTipo)
        {
            return await _IZonaCorporalDom.ObtenerCantidad(fechaInicio, fechaFin, idSede, idGenero, numeroSesion, idTipo);
        }

        public async Task<List<ZonaCantidad>> ObtenerTop10Cantidad(DateTime fechaInicio, DateTime fechaFin, int idSede, int idGenero,  int numeroSesion, int idTipo)
        {
            return await _IZonaCorporalDom.ObtenerTop10Cantidad(fechaInicio, fechaFin, idSede, idGenero, numeroSesion, idTipo);
        }        
    }
}
