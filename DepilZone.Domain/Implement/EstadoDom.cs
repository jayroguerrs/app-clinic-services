using DepilZone.Data.Interface;
using DepilZone.Domain.Interface;
using DepilZone.Entidad;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Domain.Implement
{
    public class EstadoDom: IEstadoDom
    {
        private readonly IEstadoDat _IEstadoDat;
        public EstadoDom(IEstadoDat IEstadoDat)
        {
            _IEstadoDat = IEstadoDat;
        }
        public async Task<IEnumerable<EstadoEnt>> Obtener()
        {
            return await _IEstadoDat.Obtener();
        }

        public async Task<IEnumerable<EstadoEnt>> ObtenerByEntidad(string entidad)
        {
            return await _IEstadoDat.ObtenerByEntidad(entidad);
        }

        public async Task<IEnumerable<EstadoEnt>> selStateByFather(string entidad, int idEstPadr)
        {
            return await _IEstadoDat.selStateByFather(entidad,idEstPadr);
        }
    }
}
