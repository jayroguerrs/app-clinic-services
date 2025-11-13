using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Domain.Interface.C360
{
    public interface ICronogramaSeguimientoDom
    {

        Task<List<CronogramaSeguimientoDTO>> ObtenerByCronograma(int idCronograma);
    }
}
