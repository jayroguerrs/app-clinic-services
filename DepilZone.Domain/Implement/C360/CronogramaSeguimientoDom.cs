using DepilZone.Data.Interface.C360;
using DepilZone.Domain.Interface.C360;
using DepilZone.Entidad.DTO;
using DepilZone.Entidad.DTO.C360;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Domain.Implement.C360
{
    public class CronogramaSeguimientoDom : ICronogramaSeguimientoDom
    {
        private readonly ICronogramaSeguimientoDat _ICronogramaSeguimientoDat;
        public CronogramaSeguimientoDom(ICronogramaSeguimientoDat ICronogramaSeguimientoDat)
        {
            _ICronogramaSeguimientoDat = ICronogramaSeguimientoDat;
        }
        public async Task<List<CronogramaSeguimientoDTO>> ObtenerByCronograma(int idCronograma)
        {
            return await _ICronogramaSeguimientoDat.ObtenerByCronograma(idCronograma);
        }

    }
}

