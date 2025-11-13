using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace DepilZone.Data.Interface
{
    public interface IDocumentoDat
    {
        Task<IEnumerable<DocumentoTipoEnt>> ObtenerTipoDocumento();
        Task<IEnumerable<DocumentoTipoEnt>> ObtenerTipoDocumentoByPerfil(int idPerfil);
        
        Task<DocumentoPlantillaDTO> ObtenerPlantilla(int idPlantilla);
        Task<Respuesta<DocumentoDTO>> Insertar(DocumentoEnt model);
        Task<IEnumerable<DocumentoDTO>> ObtenerListado();

        Task<IEnumerable<DocumentoDTO>> ObtenerListadoByCliente( int idCliente );
        Task<Respuesta<DocumentoDTO>> AnularDocumento( int id );
    }
}