using DepilZone.Application.Interface;
using DepilZone.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement
{
    public class HlpReporteApp : IHlpReporteApp
    {
        private readonly IHlpReporteDom _IHlpReporteDom;
        public HlpReporteApp(IHlpReporteDom IHlpReporteDom)
        {
            this._IHlpReporteDom = IHlpReporteDom;
        }
        public async Task<List<Dictionary<string, object>>> lstTipRepo()
        {
            return await _IHlpReporteDom.lstTipRepo();
        }
    }
}
