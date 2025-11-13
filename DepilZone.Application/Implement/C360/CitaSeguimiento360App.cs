using DepilZone.Application.Interface.C360;
using DepilZone.Domain.Interface.C360;
using DepilZone.Entidad.DTO.C360;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace DepilZone.Application.Implement.C360
{
    public class CitaSeguimiento360App : ICitaSeguimiento360App
    {
        private readonly ICitaSeguimiento360Dom _ICitaSeguimiento360Dom;
        public CitaSeguimiento360App(ICitaSeguimiento360Dom ICitaSeguimiento360Dom)
        {
            _ICitaSeguimiento360Dom = ICitaSeguimiento360Dom;
        }

        public async Task<List<Cita360SeguimientoDTO>> BuscarByCita(int idCita)
        {
            return await _ICitaSeguimiento360Dom.BuscarByCita(idCita);
        }
    }
}