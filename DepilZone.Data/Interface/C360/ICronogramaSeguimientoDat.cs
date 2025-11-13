using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Data.Interface.C360
{
    public interface ICronogramaSeguimientoDat
    {
        Task<List<CronogramaSeguimientoDTO>> ObtenerByCronograma(int idCronograma);
    }
}
