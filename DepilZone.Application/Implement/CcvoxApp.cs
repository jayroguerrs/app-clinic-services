using DepilZone.Application.Interface;
using DepilZone.Domain.Implement;
using DepilZone.Domain.Interface;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement
{
    public class CcvoxApp : ICcvoxApp
    {
        private readonly ICcvoxDom _CcvoxDom;
        public CcvoxApp(ICcvoxDom ICcvoxDom)
        {
            this._CcvoxDom = ICcvoxDom;
        }

        public async Task<ResponseRedirect> EsCliente2(string numero)
        {
            return await _CcvoxDom.EsCliente2(numero);
        }
    }
}
