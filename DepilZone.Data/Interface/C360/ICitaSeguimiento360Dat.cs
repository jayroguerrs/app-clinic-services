using DepilZone.Entidad.DTO.C360;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Data.Interface.C360
{
    public interface ICitaSeguimiento360Dat
    {
        Task<List<Cita360SeguimientoDTO>> BuscarByCita(int idCita);
    }
}
