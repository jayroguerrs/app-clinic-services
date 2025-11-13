using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Domain.Interface
{
    public interface IEvolucionTratamientoDom
    {

        Task<EvolucionTratamientoDTO> GrabarHistoria(EvolucionTratamientoDTO historia);
        Task<EvolucionTratamientoDTO> ObtenerByCita(int idCita);
        Task<List<EvolucionTratamientoDTO>> ObtenerListadoByIdCliente(int idCliente);
        Task<EvolucionTratamientoDTO> ObtenerById(int idHistoria);
        Task<List<EvolucionTratamientoDosisDTO>> InsertarDosis(int idEvolucionTratamientoZona, List<EvolucionTratamientoDosisDTO> dosis);
        Task<List<EvolucionTratamientoDosisDTO>> ObtenerDosisByEvolucionTratamientoZona(int idEvolucionTratamientoZona);
        Task<ET_ZonaFotosDTO> ObtenerFotosById(int idEvolucionTratamiento);

    }
}
