using DepilZone.Application.Interface;
using DepilZone.Domain.Interface;
using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement
{
    public class PreferenteAtencionOpcionApp: IPreferenteAtencionOpcionApp
    {

        private readonly IPreferenteAtencionOpcionDom _IPreferenteAtencionOpcionDom;
        public PreferenteAtencionOpcionApp(IPreferenteAtencionOpcionDom IPreferenteAtencionOpcionDom)
        {
            _IPreferenteAtencionOpcionDom = IPreferenteAtencionOpcionDom;
        }

      

        public async Task<List<PreferenteAtencionOpcionDTO>> ListarByCategoria(int idCategoria)
        {
            return await _IPreferenteAtencionOpcionDom.ListarByCategoria(idCategoria);
        }
        

    }
}
