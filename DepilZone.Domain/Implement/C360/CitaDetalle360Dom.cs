using DepilZone.Data.Interface;
using DepilZone.Data.Interface.C360;
using DepilZone.Domain.Interface.C360;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO.C360;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Domain.Implement.C360
{
    public class CitaDetalle360Dom : ICitaDetalle360Dom
    {
        private readonly ICitaDetalle360Dat _ICitaDetalle360Dat;
        public CitaDetalle360Dom(ICitaDetalle360Dat ICitaDetalle360Dat)
        {
            _ICitaDetalle360Dat = ICitaDetalle360Dat;
        }
        public async Task<List<Cita360DetallesDTO>> BuscarByCita(int idCita)
        {
            return await _ICitaDetalle360Dat.BuscarByCita(idCita);
        }

    }
}

