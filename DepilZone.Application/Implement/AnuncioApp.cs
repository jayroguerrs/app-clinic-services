using DepilZone.Application.Interface;
using DepilZone.Domain.Interface;
using DepilZone.Entidad;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement
{
    public class AnuncioApp: IAnuncioApp
    {
        private readonly IAnuncioDom _IAnuncioDom;
        public AnuncioApp(IAnuncioDom IAnuncioDom)
        {
            this._IAnuncioDom = IAnuncioDom;
        }

        public async Task<Respuesta<AnuncioEnt>> Insertar(AnuncioEnt model)
        {
            return await _IAnuncioDom.Insertar(model);
        }

        public async Task<Respuesta<AnuncioEnt>> Modificar(AnuncioEnt model)
        {
            return await _IAnuncioDom.Modificar(model);
        }

        public async Task<IEnumerable<AnuncioEnt>> Obtener()
        {
            return await _IAnuncioDom.Obtener();
        }

        public async Task<AnuncioEnt> ObtenerById(int id)
        {
            return await _IAnuncioDom.ObtenerById(id);
        }
    }
}
