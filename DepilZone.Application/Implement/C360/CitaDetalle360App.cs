using DepilZone.Application.Interface.C360;
using DepilZone.Domain.Interface.C360;
using DepilZone.Entidad.DTO.C360;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace DepilZone.Application.Implement.C360
{
    public class CitaDetalle360App : ICitaDetalle360App
    {
        private readonly ICitaDetalle360Dom _ICitaDetalle360Dom;
        public CitaDetalle360App(ICitaDetalle360Dom ICitaDetalle360Dom)
        {
            _ICitaDetalle360Dom = ICitaDetalle360Dom;
        }

        public async Task<List<Cita360DetallesDTO>> BuscarByCita(int idCita)
        {
            return await _ICitaDetalle360Dom.BuscarByCita(idCita);
        }
    }
}