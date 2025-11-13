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
    public class UbicacionDom : IUbicacionDom
    {
        private readonly IUbicacionDat _IUbicacionDat;
        public UbicacionDom(IUbicacionDat IPerfilDat)
        {
            this._IUbicacionDat = IPerfilDat;
        }

        public async Task<IEnumerable<UbicacionEnt>> Obtener()
        {
            return await _IUbicacionDat.Obtener();
        }

        public async Task<IEnumerable<CiudadDTO>> ObtenerCiudad_ByDepartamento(string iddepartamento)
        {
            return await _IUbicacionDat.ObtenerCiudad_ByDepartamento(iddepartamento);
        }

        public async Task<IEnumerable<DepartamentoDTO>> ObtenerDepartamento()
        {
            return await _IUbicacionDat.ObtenerDepartamento();
        }

        public async Task<IEnumerable<DistritoDTO>> ObtenerDistrito_ByCiudad_ByDepartamento(string idciudad, string iddepartamento)
        {
            return await  _IUbicacionDat.ObtenerDistrito_ByCiudad_ByDepartamento(idciudad, iddepartamento);
        }

    }
}
