using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace DepilZone.Data.Interface
{
    public interface IUbicacionDat
    {
        Task<IEnumerable<UbicacionEnt>> Obtener();
        Task<IEnumerable<DepartamentoDTO>> ObtenerDepartamento();
        Task<IEnumerable<CiudadDTO>> ObtenerCiudad_ByDepartamento(string Departamento);
        Task<IEnumerable<DistritoDTO>> ObtenerDistrito_ByCiudad_ByDepartamento(string Ciudad, string Departamento);

    }
}
