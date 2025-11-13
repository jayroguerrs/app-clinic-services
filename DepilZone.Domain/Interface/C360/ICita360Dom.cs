using DepilZone.Entidad.DTO.C360;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Domain.Interface.C360
{
    public interface ICita360Dom
    {
        Task<bool> Insertar(Cita360DTO model);
        Task<bool> Modificar(int idCita, Cita360DTO model);
        Task<List<Cita360DTO>> BuscarByCronograma(int idCronograma);
        Task<Cita360DTO> BuscarById(int idCita);
        Task<bool> Cancelar(Cita360DTO model);
        Task<bool> Pendiente(Cita360DTO model);
        Task<bool> Anular(Cita360DTO model);
        Task<bool> Confirmar(Cita360DTO model);
        Task<bool> ConfirmarAsistencia(Cita360DTO model);
        Task<bool> Atender(Cita360DTOAtender model);
        Task<bool> NoLlamar(Cita360DTO model);
    }
}
