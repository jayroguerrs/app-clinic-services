using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Application.Interface
{
    public interface IHlpReporteApp
    {
        Task<List<Dictionary<string, object>>> lstTipRepo();
    }
}
