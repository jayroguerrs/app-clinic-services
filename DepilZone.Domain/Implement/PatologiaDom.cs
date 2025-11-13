using DepilZone.Data.Interface;
using DepilZone.Domain.Interface;
using DepilZone.Entidad;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Domain.Implement
{
    public class PatologiaDom : IPatologiaDom
    {
        private readonly IPatologiaDat _IPatologiaDat;
        public PatologiaDom(IPatologiaDat IPatologiaDat)
        {
            this._IPatologiaDat = IPatologiaDat;
        }
       
        public async Task<IEnumerable<PatologiaEnt>> ObtenerListado()
        {
            return await _IPatologiaDat.ObtenerListado();
        }

        
    }
}
