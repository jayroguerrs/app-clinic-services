using DepilZone.Application.Interface;
using DepilZone.Domain.Interface;
using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement
{
    public class PreferenteHistorialApp: IPreferenteHistorialApp
    {

        private readonly IPreferenteHistorialDom _IPreferenteHistorialDom;
        public PreferenteHistorialApp(IPreferenteHistorialDom IPreferenteHistorialDom)
        {
            _IPreferenteHistorialDom = IPreferenteHistorialDom;
        }

      

        public async Task<List<PreferenteHistorialDTO>> Obtener(int idPreferente)
        {
            return await _IPreferenteHistorialDom.Obtener(idPreferente);
        }
    }
}
