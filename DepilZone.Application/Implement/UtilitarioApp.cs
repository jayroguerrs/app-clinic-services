using DepilZone.Application.Interface;
using DepilZone.Data;
using DepilZone.Data.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement
{
    public class UtilitarioApp: IUtilitarioApp
    {

        private readonly IUtilitarioDom _IUtilitarioDom;
        public UtilitarioApp(IUtilitarioDom IUtilitarioDom)
        {
            this._IUtilitarioDom = IUtilitarioDom;
        }

        public async Task<string> Encriptar(string text)
        {
            return await _IUtilitarioDom.Encriptar(text);
        }

        public async Task<string> Desencriptar(string text)
        {
            return await _IUtilitarioDom.Desencriptar(text);
        }


    }
}
