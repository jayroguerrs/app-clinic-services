using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DepilZone.Data;
using DepilZone.Data.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;

namespace DepilZone.Domain.Implement
{
    public class DocumentoTipoDom : IDocumentoTipoDom
    {
        private readonly IDocumentoTipoDat _IDocumentoTipoDat;
        public DocumentoTipoDom(IDocumentoTipoDat IDocumentoTipoDat)
        {
            this._IDocumentoTipoDat = IDocumentoTipoDat;
        }
        public async Task<IEnumerable<DocumentoTipoDTO>> ObtenerListado()
        {
            return await _IDocumentoTipoDat.ObtenerListado();
        }

        public async Task<bool> Insertar(DocumentoTipoDTO model)
        {
            return await _IDocumentoTipoDat.Insertar(model);
        }

        public async Task<DocumentoTipoEnt> ObtenerById(int Id)
        {
            return await _IDocumentoTipoDat.ObtenerById(Id);
        }

        public async Task<bool> Modificar(DocumentoTipoDTO model)
        {
            return await _IDocumentoTipoDat.Modificar(model);
        }

        public async Task<IEnumerable<DocumentoTipoPerfilDTO>> ObtenerPerfilesById(int Id)
        {
            return await _IDocumentoTipoDat.ObtenerPerfilesById(Id);
        }

        public async Task<Respuesta<DocumentoTipoEnt>> AsignarPerfiles(int id, int[] perfiles)
        {
            return await _IDocumentoTipoDat.AsignarPerfiles(id, perfiles);
        }

        public async Task<List<DocumentoTipoEnt>> ListarByServicio(int idServicio)
        {
            return await _IDocumentoTipoDat.ListarByServicio(idServicio);
        }
        public async Task<GeneralResponse<bool>> UpdateAllDocumentStatus(DocumentStatusDTO[] docuemntIds)
        {
            return await _IDocumentoTipoDat.UpdateAllDocumentStatus(docuemntIds);
        }
    }
}