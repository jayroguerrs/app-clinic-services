using DepilZone.Application.Interface;
using DepilZone.Domain.Interface;
using DepilZone.Entidad;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement
{
    public class ParametroSistemaApp: IParametroSistemaApp
    {
        private readonly IParametroSistemaDom _IParametroSistemaDom;
        public ParametroSistemaApp(IParametroSistemaDom IParametroSistemaDom)
        {
            this._IParametroSistemaDom = IParametroSistemaDom;
        }

        public async Task<Respuesta<ParametroSistemaEnt>> ObtenerById(int Id)
        {
            return await _IParametroSistemaDom.ObtenerById(Id);
        }

        public async Task<List<ParametroSistemaEnt>> ObtenerParametros()
        {
            return await _IParametroSistemaDom.ObtenerParametros();
        }

        public async Task<string> ObtenerValorByParametro(string Parametro)
        {
            return await _IParametroSistemaDom.ObtenerValorByParametro( Parametro);
        }
        public async Task<Respuesta<string>> ObtenerLinkQA()
        {
            return await _IParametroSistemaDom.ObtenerLinkQA();
        }
    }
}
