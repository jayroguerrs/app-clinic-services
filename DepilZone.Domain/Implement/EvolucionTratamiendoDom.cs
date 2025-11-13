using DepilZone.Data.Interface;
using DepilZone.Domain.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Domain.Implement
{
    public class EvolucionTratamientoDom : IEvolucionTratamientoDom
    {
        private readonly IEvolucionTratamientoDat _IEvolucionTratamientoDat;
        public EvolucionTratamientoDom(IEvolucionTratamientoDat IEvolucionTratamientoDat)
        {
            this._IEvolucionTratamientoDat = IEvolucionTratamientoDat;
        }

        public async Task<EvolucionTratamientoDTO> GrabarHistoria(EvolucionTratamientoDTO historia)
        {
            return await _IEvolucionTratamientoDat.GrabarHistoria(historia);
        }

        public async Task<EvolucionTratamientoDTO> ObtenerByCita(int idCita)
        {
            return await _IEvolucionTratamientoDat.ObtenerByCita(idCita);
        }

        public async Task<EvolucionTratamientoDTO> ObtenerById(int idHistoria)
        {
            return await _IEvolucionTratamientoDat.ObtenerById(idHistoria);
        }

        public async Task<ET_ZonaFotosDTO> ObtenerFotosById(int idEvolucionTratamiento)
        {
            return await _IEvolucionTratamientoDat.ObtenerFotosById(idEvolucionTratamiento);
        }

        public async Task<List<EvolucionTratamientoDosisDTO>> InsertarDosis(int idEvolucionTratamientoZona, List<EvolucionTratamientoDosisDTO> dosis)
        {
            return await _IEvolucionTratamientoDat.InsertarDosis(idEvolucionTratamientoZona, dosis);
        }

        public async Task<List<EvolucionTratamientoDosisDTO>> ObtenerDosisByEvolucionTratamientoZona(int idEvolucionTratamientoZona)
        {
            return await _IEvolucionTratamientoDat.ObtenerDosisByEvolucionTratamientoZona(idEvolucionTratamientoZona);
        }

        public async Task<List<EvolucionTratamientoDTO>> ObtenerListadoByIdCliente(int idCliente)
        {
            return await _IEvolucionTratamientoDat.ObtenerListadoByIdCliente(idCliente);
        }


    }
}
