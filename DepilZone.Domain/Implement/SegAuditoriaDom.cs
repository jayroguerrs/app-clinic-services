using DepilZone.Data.Interface;
using DepilZone.Domain.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Domain.Implement
{
    public class SegAuditoriaDom : ISegAuditoriaDom
    {
        private readonly ISegAuditoriaDat _segAuditoriaDat;
        public SegAuditoriaDom(ISegAuditoriaDat segAuditoriaDat)
        {
            _segAuditoriaDat = segAuditoriaDat;
        }
        public async Task<bool> Insertar(SegAuditoriaDTO model)
        {
            return await _segAuditoriaDat.Insertar(model);
        }
    }
}
