
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace DepilZone.Data.Interface
{
    public interface IClienteDocumentoDat
    {
        Task<ClienteDocumentoDTO> AnularDocumento( int id, ClienteDocumentoDTO model );
        Task<ClienteDocumentoDTO> RestaurarDocumento( int id, ClienteDocumentoDTO model);
        Task<ClienteDocumentoDTO> EnviarDocumentoPorCorreo(ClienteDocumentoDTO model);
        Task<ClienteDocumentoDTO> ObtenerDocumentoById(int id);
        Task<ClienteDocumentoDTO> InsertarDocumento(ClienteDocumentoDTO model);
        Task<List<ClienteDocumentoDTO>> obtenerListado();

        Task<List<ClienteDocumentoDTO>> obtenerListadoByCliente(int idCliente);
        Task<List<ClienteDocumentoDTO>> obtenerListadoByClientePorServicio(int idCliente, int idServicio);

        Task<List<ClienteDocumentoDTO>> obtenerListadoByIdClienteByFecha(int idCLiente, DateTime fecha);
        Task<List<ClienteDocumentoDTO>> obtenerListadoByIdClienteByFechaPorServicio(int idCLiente, DateTime fecha, int idServicio);

        Task<bool> SeEnvioCorreo(int idDocumento);

    }
}