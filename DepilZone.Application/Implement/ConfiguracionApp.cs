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
    public class ConfiguracionApp:IConfiguracionApp
    {
        private readonly IConfiguracionDom _IConfiguracionDom;
        public ConfiguracionApp(IConfiguracionDom IConfiguracionDom)
        {
            this._IConfiguracionDom = IConfiguracionDom;
        }
        public async Task<IEnumerable<ConfiguracionEnt>> Obtener()
        {
            return await _IConfiguracionDom.Obtener();
        }

        public async Task<Respuesta<ConfiguracionEnt>> Insertar(ConfiguracionEnt model)
        {
            return await _IConfiguracionDom.Insertar(model);
        }
        public async Task<Respuesta<ConfiguracionEnt>> Modificar(ConfiguracionEnt model)
        {
            return await _IConfiguracionDom.Modificar(model);
        }

        public async Task<ConfiguracionEnt> ObtenerByIdConfiguracion(int IdConfiguracion)
        {
            return await _IConfiguracionDom.ObtenerByIdConfiguracion(IdConfiguracion);
        }
        public async Task<IEnumerable<ConfiguracionEnt>> ObtenerByLikeNombre(string Nombre)
        {
            return await _IConfiguracionDom.ObtenerByLikeNombre(Nombre);
        }
    }
}
