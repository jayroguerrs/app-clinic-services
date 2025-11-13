using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Data.Interface
{
    public interface IDocumentoPlantillaDom
    {
        Task<IEnumerable<DocumentoPlantillaDTO>> ObtenerListado();

        Task<Respuesta<DocumentoPlantillaEnt>> ObtenerById(int Id);

        Task<Respuesta<DocumentoPlantillaEnt>> Insertar(DocumentoPlantillaDTO model);

        Task<Respuesta<DocumentoPlantillaEnt>> Modificar(DocumentoPlantillaDTO model);

    }
}