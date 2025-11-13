using DepilZone.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Domain.Interface
{
    public interface IPosDom
    {
        Task<Boolean> insSale(PosSale model);
        Task<Boolean> insIzip(PosIzip model);
    }
}
