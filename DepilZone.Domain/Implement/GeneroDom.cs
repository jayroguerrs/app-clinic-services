using DepilZone.Data.Interface;
using DepilZone.Domain.Interface;
using DepilZone.Entidad;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Domain.Implement
{
    public class GeneroDom : IGeneroDom
    {
        private readonly IGeneroDat _IGeneroDat;

        public GeneroDom(IGeneroDat IGeneroDat)
        {
            _IGeneroDat = IGeneroDat;
        }
        public Task<IEnumerable<GeneroEnt>> Obtener()
        {
            return _IGeneroDat.Obtener();
        }
    }
}
