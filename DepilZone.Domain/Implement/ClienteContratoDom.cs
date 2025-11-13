
using System.Collections.Generic;
using System.Threading.Tasks;
using DepilZone.Data.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;

namespace DepilZone.Domain.Implement
{
    public class ClienteContratoDom : IClienteContratoDom
    {
        private readonly IClienteContratoDat _IClienteContratoDat;
        public ClienteContratoDom(IClienteContratoDat IClienteContratoDat)
        {
            this._IClienteContratoDat = IClienteContratoDat;
        }
        public async Task<Respuesta<ClienteContratoDTO>> GuardarContrato(ClienteContratoDTO model)
        {
            return await _IClienteContratoDat.GuardarContrato(model);
        }
        public async Task<Respuesta<bool>> AnularContrato(int id, ClienteContratoDTO model)
        {
            return await _IClienteContratoDat.AnularContrato(id, model);
        }

        
        public async Task<List<ClienteContratoDTO>> ListarByIdCliente(int idCliente)
        {
            return await _IClienteContratoDat.ListarByIdCliente(idCliente);
        }

        public async Task<List<ClienteContratoDTO>> ListarByIdClientePorServicio(int idCliente, int idServicio)
        {
            return await _IClienteContratoDat.ListarByIdClientePorServicio(idCliente, idServicio);
        }

        public async Task<ClienteContratoDTO> verContrato(int idContrato)
        {
            return await _IClienteContratoDat.verContrato(idContrato);
        }

        public async Task<bool> EnviarContratoPorCorreo(ClienteContratoDTO model)
        {
            return await _IClienteContratoDat.EnviarContratoPorCorreo(model);
        }

        public async Task<bool> SeEnvioContrato(int idContrato)
        {
            return await _IClienteContratoDat.SeEnvioContrato(idContrato);
        }

        public async Task<ClienteContratoConfirmadoDTO> BuscarContratoConfirmado(string idContrato)
        {
            return await _IClienteContratoDat.BuscarContratoConfirmado(idContrato);
        }

        public async Task<bool> ConfirmarContrato(string idContrato, int idCliente)
        {
            return await _IClienteContratoDat.ConfirmarContrato(idContrato, idCliente);
        }

        public async Task<ClienteContratoDTO> DatosContrato(string idEncryptContrato)
        {
            return await _IClienteContratoDat.DatosContrato( idEncryptContrato);
        }
    }
}