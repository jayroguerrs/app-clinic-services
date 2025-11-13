using DepilZone.Application.Interface;
using DepilZone.Domain.Interface;
using DepilZone.Entidad;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement
{
    public class GeneroApp : IGeneroApp
    {
        private readonly IGeneroDom _IGeneroDom;

        public GeneroApp(IGeneroDom IGeneroDom)
        {
            _IGeneroDom = IGeneroDom;
        }
        public Task<IEnumerable<GeneroEnt>> Obtener()
        {
            return _IGeneroDom.Obtener();
        }
    }
}
