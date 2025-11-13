using DepilZone.Data.Interface;
using DepilZone.Domain.Interface;
using DepilZone.Entidad;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Domain.Implement
{
    public class ComentarioDom : IComentarioDom
    {
        private readonly IComentarioDat _IComentarioDat;
        public ComentarioDom(IComentarioDat IComentarioDat)
        {
            _IComentarioDat = IComentarioDat;
        }

        public async Task<IEnumerable<ComentarioEnt>> Obtener()
        {
            return await _IComentarioDat.Obtener();
        }
    }
}
