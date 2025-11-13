using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DepilZone.Data;
using DepilZone.Data.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;

namespace DepilZone.Domain.Implement
{
    public class DocumentoPlantillaDom : IDocumentoPlantillaDom
    {
        private readonly IDocumentoPlantillaDat _IDocumentoPlantillaDat;
        public DocumentoPlantillaDom(IDocumentoPlantillaDat IDocumentoPlantillaDat)
        {
            this._IDocumentoPlantillaDat = IDocumentoPlantillaDat;
        }
        public async Task<IEnumerable<DocumentoPlantillaDTO>> ObtenerListado()
        {
            return await _IDocumentoPlantillaDat.ObtenerListado();
        }
        public async Task<Respuesta<DocumentoPlantillaEnt>> ObtenerById(int Id)
        {
            return await _IDocumentoPlantillaDat.ObtenerById(Id);
        }

        public async Task<Respuesta<DocumentoPlantillaEnt>> Insertar(DocumentoPlantillaDTO model)
        {
            return await _IDocumentoPlantillaDat.Insertar(model);
        }

        public async Task<Respuesta<DocumentoPlantillaEnt>> Modificar(DocumentoPlantillaDTO model)
        {
            return await _IDocumentoPlantillaDat.Modificar(model);
        }

    }
}