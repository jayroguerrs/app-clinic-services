
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Interface
{
    public interface IClienteContratoApp
    {
        Task<Respuesta<ClienteContratoDTO>> GuardarContrato(ClienteContratoDTO model);
        Task<Respuesta<bool>> AnularContrato(int id, ClienteContratoDTO model);
        Task<bool> EnviarContratoPorCorreo(ClienteContratoDTO model);
        Task<List<ClienteContratoDTO>> ListarByIdCliente(int idCliente);
        Task<List<ClienteContratoDTO>> ListarByIdClientePorServicio(int idCliente, int idServicio);

        Task<ClienteContratoDTO> verContrato(int idContrato);
        Task<ClienteContratoConfirmadoDTO> BuscarContratoConfirmado(string idContrato);
        Task<bool> ConfirmarContrato(string idContrato, int idCliente);
    }
}