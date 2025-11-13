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
    public class DocumentoDom : IDocumentoDom
    {
        private readonly IDocumentoDat _IDocumentoDat;
        public DocumentoDom(IDocumentoDat IDocumentoDat)
        {
            this._IDocumentoDat = IDocumentoDat;
        }

        public async Task<IEnumerable<DocumentoTipoEnt>> ObtenerTipoDocumento()
        {
            return await _IDocumentoDat.ObtenerTipoDocumento();
        }  
        public async Task<IEnumerable<DocumentoTipoEnt>> ObtenerTipoDocumentoByPerfil(int idPerfil)
        {
            return await _IDocumentoDat.ObtenerTipoDocumentoByPerfil(idPerfil);
        }
        
        public async Task<DocumentoPlantillaDTO> ObtenerPlantilla(int idPlantilla)
        {
            return await _IDocumentoDat.ObtenerPlantilla(idPlantilla);
        }
        public async Task<Respuesta<DocumentoDTO>> Insertar(DocumentoEnt model)
        {
            return await _IDocumentoDat.Insertar(model);
        }
        public async Task<IEnumerable<DocumentoDTO>> ObtenerListado()
        {
            return await _IDocumentoDat.ObtenerListado();
        }

        public async Task<IEnumerable<DocumentoDTO>> ObtenerListadoByCliente( int idCliente )
        {
            return await _IDocumentoDat.ObtenerListadoByCliente(idCliente);
        }

        public async Task<Respuesta<DocumentoDTO>> AnularDocumento(int id)
        {
            return await _IDocumentoDat.AnularDocumento(id);
        }
    }
}