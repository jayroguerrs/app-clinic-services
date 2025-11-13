using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DepilZone.Data;
using DepilZone.Data.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;

namespace DepilZone.Domain
{
    public class ZonaCorporalDom : IZonaCorporalDom
    {
        private readonly IZonaCorporalDat _IZonaCorporalDat;
        public ZonaCorporalDom(IZonaCorporalDat IUsuarioDat)
        {
            this._IZonaCorporalDat = IUsuarioDat;
        }
        public async Task<IEnumerable<ZonaCorporalGridDTO>> Obtener()
        {
            return await _IZonaCorporalDat.Obtener();
        }
        public async Task<IEnumerable<ZonaCorporalGridDTO>> ObtenerListado()
        {
            return await _IZonaCorporalDat.ObtenerListado();
        }
        public async Task<IEnumerable<ZonaServicio>> ObtenerListadoZonaCorporalServicio()
        {
            return await _IZonaCorporalDat.ObtenerListadoZonaCorporalServicio();
        }        
        public async Task<List<ZonaCorporalGridDTO>> ObtenerListadoByServicio(int idServicio)
        {
            return await _IZonaCorporalDat.ObtenerListadoByServicio(idServicio);
        }
        public async Task<IEnumerable<ZonaCorporalGridDTO>> ObtenerByNombre(string nombre)
        {
            return await _IZonaCorporalDat.ObtenerByNombre(nombre);
        }
        
        public async Task<Respuesta<ZonaCorporalDTO>> Insertar(ZonaCorporalDTO model)
        {
            return await _IZonaCorporalDat.Insertar(model);
        }
        public async Task<Respuesta<ZonaCorporalDTO>> Modificar(ZonaCorporalDTO model)
        {
            return await _IZonaCorporalDat.Modificar(model);
        }

        public async Task<ZonaCorporalEnt> ObtenerById(int Id)
        {
            return await _IZonaCorporalDat.ObtenerById(Id);
        }
        public async Task<IEnumerable<ZonaCorporalDTO>> ObtenerByGenero(int id)
        {
            return await _IZonaCorporalDat.ObtenerByGenero(id);
        }
        public async Task<IEnumerable<ZonaCorporalDTO>> ObtenerByGeneroByServicio(int idGenero, int idServicio)
        {
            return await _IZonaCorporalDat.ObtenerByGeneroByServicio(idGenero, idServicio);
        }
        public async Task<IEnumerable<ZonaCorporalDTO>> ObtenerByGeneroByPromocion(int id, int idpromocion)
        {
            return await _IZonaCorporalDat.ObtenerByGeneroByPromocion(id,idpromocion);
        }
        public async Task<IEnumerable<ZonaCorporalDTO>> ObtenerByGeneroByPromocionByServicio(int id, int idpromocion, int idServicio)
        {
            return await _IZonaCorporalDat.ObtenerByGeneroByPromocionByServicio(id, idpromocion, idServicio);
        }
        public async Task<IEnumerable<ZonaPromocionEnt>> ObtenerZonas_PromocionByIdZona(int id)
        {
            return await _IZonaCorporalDat.ObtenerZonas_PromocionByIdZona(id);
        }
        public async Task<IEnumerable<ZonaCitaEnt>> ObtenerZonaByCita(int idcita)
        {
            return await _IZonaCorporalDat.ObtenerZonaByCita(idcita);
        }

        public async Task<IEnumerable<ZonaPromocionEnt>> Obtener_PromocionesPorZonasCorporales(string idsZonas)
        {
            return await _IZonaCorporalDat.Obtener_PromocionesPorZonasCorporales(idsZonas);
        }

        public async Task<IEnumerable<ZonaCorporalDTO>> ObtenerZonasParaSubZonaByGenero(int IdZona)
        {
            return await _IZonaCorporalDat.ObtenerZonasParaSubZonaByGenero(IdZona);
        }

        public async Task<Respuesta<ZonaCorporalDTO>> AsignarSubZones(int id, int[] idZones)
        {
            return await _IZonaCorporalDat.AsignarSubZonas(id, idZones);
        }

        public async Task<IEnumerable<ZonaCorporalDTO>> ObtenerSubZonasById(int Id)
        {
            return await _IZonaCorporalDat.ObtenerSubZonasById(Id);
        }

        public async Task<List<ZonaCantidad>> ObtenerCantidad(DateTime fechaInicio, DateTime fechaFin, int idSede, int idGenero,  int numeroSesion, int idTipo)
        {
            return await _IZonaCorporalDat.ObtenerCantidad(fechaInicio, fechaFin, idSede, idGenero, numeroSesion, idTipo);
        }

        public async Task<List<ZonaCantidad>> ObtenerTop10Cantidad(DateTime fechaInicio, DateTime fechaFin, int idSede, int idGenero, int numeroSesion, int idTipo)
        {
            return await _IZonaCorporalDat.ObtenerTop10Cantidad(fechaInicio, fechaFin, idSede, idGenero, numeroSesion, idTipo);
        }

    }
}
