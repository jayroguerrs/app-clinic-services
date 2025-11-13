using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Application.Interface
{
    public interface IUbicacionApp
    {
        Task<IEnumerable<UbicacionEnt>> Obtener();
        Task<IEnumerable<DepartamentoDTO>> ObtenerDepartamento();
        Task<IEnumerable<CiudadDTO>> ObtenerCiudad_ByDepartamento(string iddepartamento);
        Task<IEnumerable<DistritoDTO>> ObtenerDistrito_ByCiudad_ByDepartamento(string idciudad, string iddepartamento);
    }
}
