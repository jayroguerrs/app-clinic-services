using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Data.Interface
{
    public interface IHlpReporteDat
    {
        Task<List<Dictionary<string, object>>> lstTipRepo();
    }
}
