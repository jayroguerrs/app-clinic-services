using DepilZone.Data.Interface;
using DepilZone.Domain.Interface;
using DepilZone.Entidad;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Domain.Implement
{
    public class AnuncioDom : IAnuncioDom
    {
        private readonly IAnuncioDat _IAnuncioDat;
        public AnuncioDom(IAnuncioDat IAnuncioDat)
        {
            this._IAnuncioDat = IAnuncioDat;
        }


        public async Task<Respuesta<AnuncioEnt>> Insertar(AnuncioEnt model)
        {
            return await _IAnuncioDat.Insertar(model);
        }

        public async Task<Respuesta<AnuncioEnt>> Modificar(AnuncioEnt model)
        {
            return await _IAnuncioDat.Modificar(model);
        }

        public async Task<IEnumerable<AnuncioEnt>> Obtener()
        {
            return await _IAnuncioDat.Obtener();
        }

        public async Task<AnuncioEnt> ObtenerById(int id)
        {
            return await _IAnuncioDat.ObtenerById(id);
        }
    }
}
