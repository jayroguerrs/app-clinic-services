using DepilZone.Application.Interface;
using DepilZone.Domain.Interface.C360;
using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace DepilZone.Application.Implement.C360
{
    public class CronogramaSeguimientoApp : ICronogramaSeguimientoApp
    {
        private readonly ICronogramaSeguimientoDom _ICronogramaSeguimientoDom;
        public CronogramaSeguimientoApp(ICronogramaSeguimientoDom ICronogramaSeguimientoDom)
        {
            _ICronogramaSeguimientoDom = ICronogramaSeguimientoDom;
        }

        public async Task<List<CronogramaSeguimientoDTO>> ObtenerByCronograma(int idCronograma)
        {
            return await _ICronogramaSeguimientoDom.ObtenerByCronograma(idCronograma);
        }
    }
}