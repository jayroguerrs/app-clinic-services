using DepilZone.Data.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Application.Interface
{
    public interface IDocumentoApp
    {
        Task<IEnumerable<DocumentoTipoEnt>> ObtenerTipoDocumento();
        Task<IEnumerable<DocumentoTipoEnt>> ObtenerTipoDocumentoByPerfil(int idPerfil);
        
        Task<Respuesta<DocumentoDTO>> Insertar(DocumentoEnt model);
        Task<DocumentoPlantillaDTO> ObtenerPlantilla(int idPlantilla);
        Task<IEnumerable<DocumentoDTO>> ObtenerListado();

        Task<IEnumerable<DocumentoDTO>> ObtenerListadoByCliente(int idCliente);
        Task<Respuesta<DocumentoDTO>> AnularDocumento(int id);
    }
}