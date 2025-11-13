using DepilZone.Data.Interface;
using DepilZone.Domain.Interface;
using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Domain.Implement
{
    public class PreferenteAtencionCategoriaDom: IPreferenteAtencionCategoriaDom
    {

        private readonly IPreferenteAtencionCategoriaDat _IPreferenteAtencionCategoriaDat;
        public PreferenteAtencionCategoriaDom(IPreferenteAtencionCategoriaDat IPreferenteAtencionCategoriaDat)
        {
            this._IPreferenteAtencionCategoriaDat = IPreferenteAtencionCategoriaDat;
        }

        public async Task<List<PreferenteAtencionCategoriaDTO>> Listar()
        {
            return await _IPreferenteAtencionCategoriaDat.Listar();
        }

    }
}
