using DepilZone.Application.Interface;
using DepilZone.Domain.Interface;
using DepilZone.Entidad;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement
{
    public class SedeApp: ISedeApp
    {

        private readonly ISedeDom _ISedeDom;
        public SedeApp(ISedeDom ISedeDom)
        {
            this._ISedeDom = ISedeDom;
        }
        public async Task<IEnumerable<SedeEnt>> Obtener()
        {
            return await _ISedeDom.Obtener();
        }
        public async Task<IEnumerable<SedeEnt>> ObtenerByLikeNombre(string Nombre)
        {
            return await _ISedeDom.ObtenerByLikeNombre(Nombre);
        }

        public async Task<Respuesta<SedeEnt>> Insertar(SedeEnt model)
        {
            return await _ISedeDom.Insertar(model);
        }

        public async Task<Respuesta<SedeEnt>> Modificar(SedeEnt model)
        {
            return await _ISedeDom.Modificar(model);
        }

        public async Task<SedeEnt> ObtenerById(int IdSede)
        {
            return await _ISedeDom.ObtenerById(IdSede);
        }


    }
}
