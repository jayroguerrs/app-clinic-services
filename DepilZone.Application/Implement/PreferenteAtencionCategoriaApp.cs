using DepilZone.Application.Interface;
using DepilZone.Domain.Interface;
using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement
{
    public class PreferenteAtencionCategoriaApp: IPreferenteAtencionCategoriaApp
    {

        private readonly IPreferenteAtencionCategoriaDom _IPreferenteAtencionCategoriaDom;
        public PreferenteAtencionCategoriaApp(IPreferenteAtencionCategoriaDom IPreferenteAtencionCategoriaDom)
        {
            _IPreferenteAtencionCategoriaDom = IPreferenteAtencionCategoriaDom;
        }

      

        public async Task<List<PreferenteAtencionCategoriaDTO>> Listar()
        {
            return await _IPreferenteAtencionCategoriaDom.Listar();
        }
        

    }
}
