using DepilZone.Data.Interface;
using DepilZone.Domain.Interface;
using DepilZone.Entidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Domain.Implement
{
    public class HlpReporteDom : IHlpReporteDom
    {
        private readonly IHlpReporteDat _IHlpReporteDat;
        public HlpReporteDom(IHlpReporteDat IHlpReporteDat)
        {
            this._IHlpReporteDat = IHlpReporteDat;
        }

        public async Task<List<Dictionary<string, object>>> lstTipRepo()
        {
            return await _IHlpReporteDat.lstTipRepo();
        }
    }
}
