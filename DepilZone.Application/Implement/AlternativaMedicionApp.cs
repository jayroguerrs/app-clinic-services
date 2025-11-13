using DepilZone.Application.Interface;
using DepilZone.Domain.Interface;
using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement
{
    public class AlternativaMedicionApp: IAlternativaMedicionApp
    {
        private readonly IAlternativaMedicionDom _IAlternativaMedicionDom;
        public AlternativaMedicionApp(IAlternativaMedicionDom IAlternativaMedicionDom)
        {
            this._IAlternativaMedicionDom = IAlternativaMedicionDom;
        }

        public async Task<List<AlternativaMedicionDTO>> ListarByTipo(int tipo)
        {
            return await _IAlternativaMedicionDom.ListarByTipo(tipo);
        }
    }
}
