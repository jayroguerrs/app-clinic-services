using DepilZone.Application.Interface;
using DepilZone.Domain.Interface;
using DepilZone.Entidad;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement
{
    public class ComentarioApp: IComentarioApp
    {
        private readonly IComentarioDom _IComentarioDom;
        public ComentarioApp(IComentarioDom IComentarioDom)
        {
            this._IComentarioDom = IComentarioDom;
        }

        public async Task<IEnumerable<ComentarioEnt>> Obtener()
        {
            return await this._IComentarioDom.Obtener();
        }
    }
}
