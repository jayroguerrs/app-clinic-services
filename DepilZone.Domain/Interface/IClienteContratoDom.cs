using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Data.Interface
{
    public interface IClienteContratoDom
    {
        Task<Respuesta<ClienteContratoDTO>> GuardarContrato( ClienteContratoDTO model);
        Task<Respuesta<bool>> AnularContrato(int id, ClienteContratoDTO model);
        Task<bool> EnviarContratoPorCorreo(ClienteContratoDTO model);
        Task<List<ClienteContratoDTO>> ListarByIdCliente(int idCliente);
        Task<List<ClienteContratoDTO>> ListarByIdClientePorServicio(int idCliente, int idServicio);
        Task<ClienteContratoDTO> verContrato(int idContrato);

        Task<bool> SeEnvioContrato(int idContrato);
        Task<ClienteContratoConfirmadoDTO> BuscarContratoConfirmado(string idEncryptContrato);
        Task<bool> ConfirmarContrato(string idEncryptContrato, int idCliente);
        Task<ClienteContratoDTO> DatosContrato(string idEncryptContrato);
    }
}