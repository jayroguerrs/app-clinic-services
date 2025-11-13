using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Domain.Interface
{
    public interface IHlpReporteDom
    {
        Task<List<Dictionary<string, object>>> lstTipRepo();
    }
}
