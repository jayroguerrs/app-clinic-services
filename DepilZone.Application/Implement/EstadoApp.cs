using DepilZone.Application.Interface;
using DepilZone.Domain.Interface;
using DepilZone.Entidad;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement
{
    public class EstadoApp : IEstadoApp
    {
        private readonly IEstadoDom _IEstadoDom;
        public EstadoApp(IEstadoDom IEstadoDom)
        {
            _IEstadoDom = IEstadoDom;
        }
        public async Task<IEnumerable<EstadoEnt>> Obtener()
        {
            return await _IEstadoDom.Obtener();
        }

        public async Task<IEnumerable<EstadoEnt>> ObtenerByEntidad(string entidad)
        {
            return await _IEstadoDom.ObtenerByEntidad(entidad);
        }

        public async Task<IEnumerable<EstadoEnt>> selStateByFather(string entidad, int idEstPadr)
        {
            return await _IEstadoDom.selStateByFather(entidad, idEstPadr);
        }
    }
}
