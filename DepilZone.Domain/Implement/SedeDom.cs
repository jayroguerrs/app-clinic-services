using DepilZone.Data.Interface;
using DepilZone.Domain.Interface;
using DepilZone.Entidad;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Domain.Implement
{
    public class SedeDom: ISedeDom
    {
        private readonly ISedeDat _ISedeDat;
        public SedeDom(ISedeDat ISedeDat)
        {
            this._ISedeDat = ISedeDat;
        }

        public async Task<IEnumerable<SedeEnt>> Obtener()
        {
            return await _ISedeDat.Obtener();
        }

        public async Task<IEnumerable<SedeEnt>> ObtenerByLikeNombre(string Nombre)
        {
            return await _ISedeDat.ObtenerByLikeNombre(Nombre);
        }
        public async Task<Respuesta<SedeEnt>> Insertar(SedeEnt model)
        {
            return await _ISedeDat.Insertar(model);
        }

        public async Task<SedeEnt> ObtenerById(int idsede)
        {
            return await _ISedeDat.ObtenerById(idsede);
        }

        public async Task<Respuesta<SedeEnt>> Modificar(SedeEnt model)
        {
            return await _ISedeDat.Modificar(model);
        }

    }
}
