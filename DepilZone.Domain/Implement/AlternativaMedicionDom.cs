using DepilZone.Data.Interface;
using DepilZone.Domain.Interface;
using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Domain.Implement
{
    public class AlternativaMedicionDom : IAlternativaMedicionDom
    {
        private readonly IAlternativaMedicionDat _IAlternativaMedicionDat;
        public AlternativaMedicionDom(IAlternativaMedicionDat IAlternativaMedicionDat)
        {
            this._IAlternativaMedicionDat = IAlternativaMedicionDat;
        }
        public async Task<List<AlternativaMedicionDTO>> ListarByTipo(int tipo)
        {
            return await _IAlternativaMedicionDat.ListarByTipo(tipo);
        }
    }
}
