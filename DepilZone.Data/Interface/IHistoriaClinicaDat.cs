using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Data.Interface
{
    public interface IHistoriaClinicaDat
    {
        Task<HistoriaClinicaDTO> ObtenerDetallesCliente(int idCliente);

        Task<HistoriaClinicaDTO> Insertar(HistoriaClinicaDTO model);

        Task<List<FichaAdmisionDTO>> ListarByCliente(int idCliente);
        Task<List<FichaAdmisionDTO>> ListarByClientePorServicio(int idCliente, int idServicio);

        Task<bool> Anular(int idHistoria, int idUsuario);

        Task<HistoriaClinicaDTO> ObtenerDetallesById(int idFichaAdmision);
    }
}