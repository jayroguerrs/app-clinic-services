using DepilZone.Data.Interface;
using DepilZone.Domain.Interface;
using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Domain.Implement
{
    public class PreferenteAtencionOpcionDom: IPreferenteAtencionOpcionDom
    {

        private readonly IPreferenteAtencionOpcionDat _IPreferenteAtencionOpcionDat;
        public PreferenteAtencionOpcionDom(IPreferenteAtencionOpcionDat IPreferenteAtencionOpcionDat)
        {
            this._IPreferenteAtencionOpcionDat = IPreferenteAtencionOpcionDat;
        }

        public async Task<List<PreferenteAtencionOpcionDTO>> ListarByCategoria(int idCategoria)
        {
            return await _IPreferenteAtencionOpcionDat.ListarByCategoria(idCategoria);
        }

    }
}
