using DepilZone.Application.Interface;
using DepilZone.Data.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace DepilZone.Application.Implement
{
    public class ConfiguracionReplApp : IConfiguracionReplApp
    {
        private readonly IConfiguracionReplDom _IConfiguracionReplDom;
        public ConfiguracionReplApp(IConfiguracionReplDom IConfiguracionReplDom)
        {
            this._IConfiguracionReplDom = IConfiguracionReplDom;
        }
        public async Task<IEnumerable<ConfiguracionReplEnt>> Obtener()
        {
            return await _IConfiguracionReplDom.Obtener();
        }
        public async Task<Respuesta<ConfiguracionReplEnt>> Modificar(ConfiguracionReplEnt model)
        {
            return await _IConfiguracionReplDom.Modificar(model);
        }
        public async Task<ConfiguracionReplEnt> ObtenerByIdConfiguracion(int IdConfiguracion)
        {
            return await _IConfiguracionReplDom.ObtenerByIdConfiguracion(IdConfiguracion);
        }
        public async Task<ConfiguracionReplEnt> ObtenerByIdConfiguracionDNI(string DNI, string IdConfiguracion)
        {
            return await _IConfiguracionReplDom.ObtenerByIdConfiguracionDNI(DNI, IdConfiguracion);
        }
    }
}
