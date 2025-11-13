using DepilZone.Application.Interface;
using DepilZone.Domain.Interface;
using DepilZone.Entidad;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement
{
    public class DocumentoIdentidadTipoApp : IDocumentoIdentidadTipoApp
    {
        private readonly IDocumentoIdentidadTipoDom _IDocumentoIdentidadTipoDom;
        public DocumentoIdentidadTipoApp(IDocumentoIdentidadTipoDom IDocumentoIdentidadTipoDom)
        {
            _IDocumentoIdentidadTipoDom = IDocumentoIdentidadTipoDom;
        }
        public async Task<IEnumerable<DocumentoIdentidadTipoEnt>> Obtener()
        {
            return await _IDocumentoIdentidadTipoDom.Obtener();
        }
    }
}
