using DepilZone.Application.Interface;
using DepilZone.Domain.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement
{

    public class UbicacionApp : IUbicacionApp
    {
        private readonly IUbicacionDom _IUbicacionDom;
        public UbicacionApp(IUbicacionDom IUbicacionDom)
        {
            this._IUbicacionDom = IUbicacionDom;
        }

        public async Task<IEnumerable<UbicacionEnt>> Obtener()
        {
            return await _IUbicacionDom.Obtener();
        }

        public async Task<IEnumerable<CiudadDTO>> ObtenerCiudad_ByDepartamento(string iddepartamento)
        {
            return await _IUbicacionDom.ObtenerCiudad_ByDepartamento(iddepartamento);
        }

        public async Task<IEnumerable<DepartamentoDTO>> ObtenerDepartamento()
        {
            return await _IUbicacionDom.ObtenerDepartamento();
        }

        public async Task<IEnumerable<DistritoDTO>> ObtenerDistrito_ByCiudad_ByDepartamento(string idciudad, string iddepartamento)
        {
            return await _IUbicacionDom.ObtenerDistrito_ByCiudad_ByDepartamento(idciudad, iddepartamento);
        }

    }
}
