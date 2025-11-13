using DepilZone.Application.Interface;
using DepilZone.Data.Interface;
using DepilZone.Domain.Interface;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement
{
    public class SegAuditoriaApp : ISegAuditoriaApp
    {
        private readonly ISegAuditoriaDom _segAuditoriaDom;

        public SegAuditoriaApp(ISegAuditoriaDom segAuditoriaDom)
        {
            this._segAuditoriaDom = segAuditoriaDom;
        }
        public async Task<bool> Insertar(SegAuditoriaDTO model)
        {
            return await _segAuditoriaDom.Insertar(model);
        }
    }
}
