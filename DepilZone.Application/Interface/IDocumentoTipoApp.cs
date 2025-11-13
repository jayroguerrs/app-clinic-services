using DepilZone.Data.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Application.Interface
{
    public interface IDocumentoTipoApp
    {
        Task<IEnumerable<DocumentoTipoDTO>> ObtenerListado();

        Task<bool> Insertar(DocumentoTipoDTO model);

        Task<DocumentoTipoEnt>  ObtenerById(int Id);

        Task<bool> Modificar(DocumentoTipoDTO model);

        Task<IEnumerable<DocumentoTipoPerfilDTO>> ObtenerPerfilesById( int Id );

        Task<Respuesta<DocumentoTipoEnt>> AsignarPerfiles(int Id, int[] perfiles);

        Task<List<DocumentoTipoEnt>> ListarByServicio(int idServicio);
        Task<GeneralResponse<bool>> UpdateAllDocumentStatus(DocumentStatusDTO[] docuemntIds);
    }
}