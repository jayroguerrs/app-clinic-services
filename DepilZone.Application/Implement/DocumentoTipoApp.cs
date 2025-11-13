using DepilZone.Application.Interface;
using DepilZone.Data.Interface;
using DepilZone.Domain.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace DepilZone.Application.Implement
{
    public class DocumentoTipoApp : IDocumentoTipoApp
    {
        private readonly IDocumentoTipoDom _IDocumentoTipoDom;

        public DocumentoTipoApp(IDocumentoTipoDom IDocumentoTipoDom)
        {
            this._IDocumentoTipoDom = IDocumentoTipoDom;
        }
      
        public async Task<IEnumerable<DocumentoTipoDTO>> ObtenerListado()
        {
            return await _IDocumentoTipoDom.ObtenerListado();
        }

        public async Task<bool> Insertar(DocumentoTipoDTO model)
        {
            return await _IDocumentoTipoDom.Insertar(model);
        }

        public async Task<DocumentoTipoEnt> ObtenerById(int Id)
        {
            return await _IDocumentoTipoDom.ObtenerById(Id);
        }

        public async Task<bool> Modificar(DocumentoTipoDTO model)
        {
            return await _IDocumentoTipoDom.Modificar(model);
        }

        public async Task<IEnumerable<DocumentoTipoPerfilDTO>> ObtenerPerfilesById(int Id)
        {
            return await _IDocumentoTipoDom.ObtenerPerfilesById( Id );
        }

        public async Task<Respuesta<DocumentoTipoEnt>> AsignarPerfiles(int id, int[] perfiles)
        {
            return await _IDocumentoTipoDom.AsignarPerfiles(id, perfiles);
        }

        public async Task<List<DocumentoTipoEnt>> ListarByServicio(int idServicio)
        {
            return await _IDocumentoTipoDom.ListarByServicio(idServicio);
        }
        public async Task<GeneralResponse<bool>> UpdateAllDocumentStatus(DocumentStatusDTO[] docuemntIds)
        {
            return await _IDocumentoTipoDom.UpdateAllDocumentStatus(docuemntIds);
        }
    }
}