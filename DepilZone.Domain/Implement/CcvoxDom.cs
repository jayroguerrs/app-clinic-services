using DepilZone.Data.Interface;
using DepilZone.Domain.Interface;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Domain.Implement
{
    public class CcvoxDom : ICcvoxDom
    {
        private readonly ICcvoxDat _CcvoxDat;
        public CcvoxDom(ICcvoxDat ICcvox)
        {
            this._CcvoxDat = ICcvox;
        }

        public async Task<ResponseRedirect> EsCliente2(string numero)
        {
            return await _CcvoxDat.EsCliente2(numero);
        }

    }
}
