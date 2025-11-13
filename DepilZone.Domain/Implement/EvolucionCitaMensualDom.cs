using DepilZone.Data.Interface;
using DepilZone.Domain.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Domain.Implement
{
    public class EvolucionCitaMensualDom : IEvolucionCitaMensualDom
    {
        private readonly IEvolucionCitaMensualDat _IEvolucionCitaMensualDat;
        public EvolucionCitaMensualDom(IEvolucionCitaMensualDat IEvolucionCitaMensualDat)
        {
            this._IEvolucionCitaMensualDat = IEvolucionCitaMensualDat;
        }
        public async Task<Respuesta<EvolucionCitaMensualEnt>> Insertar(DateTime fecha)
        {
            return await _IEvolucionCitaMensualDat.Insertar(fecha);
        }
        public async Task<EvolucionCitaMensualDTO> Obtener(DateTime fecha, int idSede)
        {
            return await _IEvolucionCitaMensualDat.Obtener(fecha, idSede);
        }
    }
}
