using DepilZone.Data.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Application.Interface
{
    public interface IClienteDocumentoApp
    {
        Task<ClienteDocumentoDTO> AnularDocumento(int id, ClienteDocumentoDTO model);
        Task<ClienteDocumentoDTO> RestaurarDocumento(int id, ClienteDocumentoDTO model);
        Task<ClienteDocumentoDTO> EnviarDocumentoPorCorreo(ClienteDocumentoDTO model);
        Task<ClienteDocumentoDTO> ObtenerDocumentoById(int id);
        Task<ClienteDocumentoDTO> InsertarDocumento(ClienteDocumentoDTO model);

        Task<List<ClienteDocumentoDTO>> obtenerListado();

        Task<List<ClienteDocumentoDTO>> obtenerListadoByCliente(int idCliente);
        Task<List<ClienteDocumentoDTO>> obtenerListadoByClientePorServicio(int idCliente, int idServicio);
        Task<List<ClienteDocumentoDTO>> obtenerListadoByIdClienteByFecha(int idCLiente, DateTime fecha);
        Task<List<ClienteDocumentoDTO>> obtenerListadoByIdClienteByFechaPorServicio(int idCLiente, DateTime fecha, int idServicio);
       

    }
}