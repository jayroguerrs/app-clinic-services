using DepilZone.Application.Interface;
using DepilZone.Data.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement
{
    public class TurnoApp : ITurnoApp
    {
        private readonly ITurnoDom _ITurnoDom;
        public TurnoApp(ITurnoDom ITurnoDom)
        {
            this._ITurnoDom = ITurnoDom;
        }

        public async Task<IEnumerable<TurnoEnt>> Obtener()
        {
            return await _ITurnoDom.Obtener();
        }
        public async Task<TurnoEnt> ObtenerById(int IdTurno)
        {
            return await _ITurnoDom.ObtenerById(IdTurno);
        }
    }
}
