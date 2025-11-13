using DepilZone.Application.Interface;
using DepilZone.Domain.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement
{
    public class EvolucionCitaMensualApp: IEvolucionCitaMensualApp
    {
        private readonly IEvolucionCitaMensualDom _IEvolucionCitaMensualDom;
        public EvolucionCitaMensualApp(IEvolucionCitaMensualDom IEvolucionCitaMensualDom)
        {
            this._IEvolucionCitaMensualDom = IEvolucionCitaMensualDom;
        }

        public async Task<Respuesta<EvolucionCitaMensualEnt>> Insertar(DateTime fecha)
        {
            return await _IEvolucionCitaMensualDom.Insertar(fecha);
        }
        public async Task<EvolucionCitaMensualDTO> Obtener(DateTime fecha, int idSede)
        {
            return await _IEvolucionCitaMensualDom.Obtener(fecha, idSede);
        }
    }
}
