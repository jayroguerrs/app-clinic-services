using DepilZone.Data.Interface;
using DepilZone.Domain.Interface;
using DepilZone.Entidad;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Domain.Implement
{
    public class DocumentoIdentidadTipoDom : IDocumentoIdentidadTipoDom
    {
        private readonly IDocumentoIdentidadTipoDat _IDocumentoIdentidadTipoDat;

        public DocumentoIdentidadTipoDom(IDocumentoIdentidadTipoDat IDocumentoIdentidadTipoDat)
        {
            _IDocumentoIdentidadTipoDat = IDocumentoIdentidadTipoDat;
        }
        public async Task<IEnumerable<DocumentoIdentidadTipoEnt>> Obtener()
        {
            return await _IDocumentoIdentidadTipoDat.Obtener();
        }
    }
}
