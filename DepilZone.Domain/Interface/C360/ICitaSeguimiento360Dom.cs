using DepilZone.Entidad.DTO.C360;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Domain.Interface.C360
{
    public interface ICitaSeguimiento360Dom
    {

        Task<List<Cita360SeguimientoDTO>> BuscarByCita(int idCita);
    }
}
