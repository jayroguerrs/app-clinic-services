using DepilZone.Data.Interface;
using DepilZone.Domain.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Domain.Implement
{
    public class PreferenteHistorialDom: IPreferenteHistorialDom
    {

        private readonly IPreferenteHistorialDat _IPreferenteHistorialDat;
        public PreferenteHistorialDom(IPreferenteHistorialDat IPreferenteHistorialDat)
        {
            this._IPreferenteHistorialDat = IPreferenteHistorialDat;
        }

        public async Task<List<PreferenteHistorialDTO>> Obtener(int idPreferente)
        {
            return await _IPreferenteHistorialDat.Obtener(idPreferente);
        }

    }
}
