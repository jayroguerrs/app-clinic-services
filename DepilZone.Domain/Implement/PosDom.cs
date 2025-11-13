using DepilZone.Data.Interface;
using DepilZone.Domain.Interface;
using DepilZone.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Domain.Implement
{
    public class PosDom : IPosDom
    {
        private readonly IPosDat _IPosDat;
        public PosDom(IPosDat IPosDat)
        {
            this._IPosDat = IPosDat;
        }
        public async Task<bool> insSale(PosSale model)
        {
            return await _IPosDat.insSale(model);
        }
        public async Task<bool> insIzip(PosIzip model)
        {
            return await _IPosDat.insIzip(model);
        }
    }
}
