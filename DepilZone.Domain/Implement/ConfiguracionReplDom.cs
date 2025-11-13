using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DepilZone.Data;
using DepilZone.Data.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;

namespace DepilZone.Domain
{
    public class ConfiguracionReplDom : IConfiguracionReplDom
    {
        private readonly IConfiguracionReplDat _IConfiguracionRplDat;
        public ConfiguracionReplDom(IConfiguracionReplDat IConfiguracionReplDat)
        {
            this._IConfiguracionRplDat = IConfiguracionReplDat;
        }
        public async Task<IEnumerable<ConfiguracionReplEnt>> Obtener()
        {
            return await _IConfiguracionRplDat.Obtener();
        }
        public async Task<ConfiguracionReplEnt> ObtenerByIdConfiguracion(int IdConfiguracion)
        {
            return await _IConfiguracionRplDat.ObtenerByIdConfiguracion(IdConfiguracion);
        }
        public async Task<ConfiguracionReplEnt> ObtenerByIdConfiguracionDNI(string DNI, string IdConfiguracion)
        {
            return await _IConfiguracionRplDat.ObtenerByIdConfiguracionDNI(DNI , IdConfiguracion);
        }
        public async Task<Respuesta<ConfiguracionReplEnt>> Modificar(ConfiguracionReplEnt model)
        {
            return await _IConfiguracionRplDat.Modificar(model);
        }
    }
   
}
