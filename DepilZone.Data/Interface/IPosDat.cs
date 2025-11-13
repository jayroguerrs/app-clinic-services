using DepilZone.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Data.Interface
{
    public interface IPosDat
    {
        Task<Boolean> insSale(PosSale model);
        Task<Boolean> insIzip(PosIzip model);
    }
}
