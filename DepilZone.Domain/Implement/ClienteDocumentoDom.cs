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
    public class ClienteDocumentoDom : IClienteDocumentoDom
    {
        private readonly IClienteDocumentoDat _IClienteDocumentoDat;
        public ClienteDocumentoDom(IClienteDocumentoDat IClienteDocumentoDat)
        {
            this._IClienteDocumentoDat = IClienteDocumentoDat;
        }
        public async Task<ClienteDocumentoDTO> AnularDocumento(int id, ClienteDocumentoDTO model)
        {
            return await _IClienteDocumentoDat.AnularDocumento(id, model);
        }
        public async Task<ClienteDocumentoDTO> RestaurarDocumento(int id, ClienteDocumentoDTO model)
        {
            return await _IClienteDocumentoDat.RestaurarDocumento(id, model);
        }

        public async Task<ClienteDocumentoDTO> EnviarDocumentoPorCorreo(ClienteDocumentoDTO model)
        {
            return await _IClienteDocumentoDat.EnviarDocumentoPorCorreo(model);
        }

        public async Task<ClienteDocumentoDTO> ObtenerDocumentoById(int id)
        {
            return await _IClienteDocumentoDat.ObtenerDocumentoById(id);
        }

        public async Task<ClienteDocumentoDTO> InsertarDocumento(ClienteDocumentoDTO model)
        {
            return await _IClienteDocumentoDat.InsertarDocumento(model);
        }

        public async Task<List<ClienteDocumentoDTO>> obtenerListado()
        {
            return await _IClienteDocumentoDat.obtenerListado();
        }

        public async Task<bool> SeEnvioCorreo(int idDocumento)
        {
            return await _IClienteDocumentoDat.SeEnvioCorreo(idDocumento);
        }

        public async Task<List<ClienteDocumentoDTO>> obtenerListadoByCliente(int idCliente)
        {
            return await _IClienteDocumentoDat.obtenerListadoByCliente(idCliente);
        }

        public async Task<List<ClienteDocumentoDTO>> obtenerListadoByClientePorServicio(int idCliente, int idServicio)
        {
            return await _IClienteDocumentoDat.obtenerListadoByClientePorServicio(idCliente, idServicio);
        }

        public async Task<List<ClienteDocumentoDTO>> obtenerListadoByIdClienteByFecha(int idCLiente, DateTime fecha)
        {
            return await _IClienteDocumentoDat.obtenerListadoByIdClienteByFecha(idCLiente, fecha);
        }

        public async Task<List<ClienteDocumentoDTO>> obtenerListadoByIdClienteByFechaPorServicio(int idCLiente, DateTime fecha, int idServicio)
        {
            return await _IClienteDocumentoDat.obtenerListadoByIdClienteByFechaPorServicio(idCLiente, fecha, idServicio);
        }
    }
}