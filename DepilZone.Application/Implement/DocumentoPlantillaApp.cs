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
    public class DocumentoPlantillaApp : IDocumentoPlantillaApp
    {
        private readonly IDocumentoPlantillaDom _IDocumentoPlantillaDom;

        public DocumentoPlantillaApp(IDocumentoPlantillaDom IDocumentoPlantillaDom)
        {
            this._IDocumentoPlantillaDom = IDocumentoPlantillaDom;
        }
      
        public async Task<IEnumerable<DocumentoPlantillaDTO>> ObtenerListado()
        {
            return await _IDocumentoPlantillaDom.ObtenerListado();
        }

        public async Task<Respuesta<DocumentoPlantillaEnt>> ObtenerById(int Id)
        {
            return await _IDocumentoPlantillaDom.ObtenerById(Id);
        }

        public async Task<Respuesta<DocumentoPlantillaEnt>> Insertar(DocumentoPlantillaDTO model)
        {
            return await _IDocumentoPlantillaDom.Insertar(model);
        }

        public async Task<Respuesta<DocumentoPlantillaEnt>> Modificar(DocumentoPlantillaDTO model)
        {
            return await _IDocumentoPlantillaDom.Modificar(model);
        }


    }
}