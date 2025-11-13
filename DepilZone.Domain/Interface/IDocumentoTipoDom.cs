using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Data.Interface
{
    public interface IDocumentoTipoDom
    {
        Task<IEnumerable<DocumentoTipoDTO>> ObtenerListado();

        Task<bool> Insertar(DocumentoTipoDTO model);

        Task<DocumentoTipoEnt> ObtenerById(int Id);

        Task<bool> Modificar(DocumentoTipoDTO model);

        Task<IEnumerable<DocumentoTipoPerfilDTO>> ObtenerPerfilesById(int Id);

        Task<Respuesta<DocumentoTipoEnt>> AsignarPerfiles(int id, int[] perfiles);

        Task<List<DocumentoTipoEnt>> ListarByServicio(int idServicio);
        Task<GeneralResponse<bool>> UpdateAllDocumentStatus(DocumentStatusDTO[] docuemntIds);
    }
}