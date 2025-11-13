using DepilZone.Application.Interface;
using DepilZone.Domain.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement
{
    public class EvolucionTratamientoApp : IEvolucionTratamientoApp
    {
        private readonly IEvolucionTratamientoDom _IEvolucionTratamientoDom;
        public EvolucionTratamientoApp(IEvolucionTratamientoDom IEvolucionTratamientoDom)
        {
            this._IEvolucionTratamientoDom = IEvolucionTratamientoDom;
        }



        public async Task<EvolucionTratamientoDTO> GrabarHistoria(EvolucionTratamientoDTO historia)
        {
            return await _IEvolucionTratamientoDom.GrabarHistoria(historia);
        }
        public async Task<EvolucionTratamientoDTO> ObtenerByCita(int idCita)
        {
            return await _IEvolucionTratamientoDom.ObtenerByCita(idCita);
        }
        public async Task<EvolucionTratamientoDTO> ObtenerById(int idHistoria)
        {
            return await _IEvolucionTratamientoDom.ObtenerById(idHistoria);
        }
        public async Task<List<EvolucionTratamientoDTO>> ObtenerListadoByIdCliente(int idCliente)
        {
            return await _IEvolucionTratamientoDom.ObtenerListadoByIdCliente(idCliente);
        }
        public async Task<List<EvolucionTratamientoDosisDTO>> InsertarDosis(int idEvolucionTratamientoZona, List<EvolucionTratamientoDosisDTO> dosis)
        {
            return await _IEvolucionTratamientoDom.InsertarDosis(idEvolucionTratamientoZona, dosis);
        }
        public async Task<List<EvolucionTratamientoDosisDTO>> ObtenerDosisByEvolucionTratamientoZona(int idEvolucionTratamientoZona)
        {
            return await _IEvolucionTratamientoDom.ObtenerDosisByEvolucionTratamientoZona(idEvolucionTratamientoZona);
        }
        public async Task<ET_ZonaFotosDTO> ObtenerFotosById(int idEvolucionTratamiento)
        {
            return await _IEvolucionTratamientoDom.ObtenerFotosById(idEvolucionTratamiento);
        }

    }
}
