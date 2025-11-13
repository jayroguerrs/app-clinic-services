using DepilZone.Data.Interface.C360;
using DepilZone.Domain.Interface.C360;
using DepilZone.Entidad.DTO.C360;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Domain.Implement.C360
{
    public class CitaSeguimiento360Dom : ICitaSeguimiento360Dom
    {
        private readonly ICitaSeguimiento360Dat _ICitaSeguimiento360Dat;
        public CitaSeguimiento360Dom(ICitaSeguimiento360Dat ICitaSeguimiento360Dat)
        {
            _ICitaSeguimiento360Dat = ICitaSeguimiento360Dat;
        }
        public async Task<List<Cita360SeguimientoDTO>> BuscarByCita(int idCita)
        {
            return await _ICitaSeguimiento360Dat.BuscarByCita(idCita);
        }

    }
}

