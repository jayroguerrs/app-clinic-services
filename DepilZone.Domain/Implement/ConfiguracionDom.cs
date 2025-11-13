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
    public class ConfiguracionDom : IConfiguracionDom
    {
        private readonly IConfiguracionDat _IConfiguracionDat;
        public ConfiguracionDom(IConfiguracionDat IConfiguracionDat)
        {
            this._IConfiguracionDat = IConfiguracionDat;
        }
        public async Task<IEnumerable<ConfiguracionEnt>> Obtener()
        {
            return await _IConfiguracionDat.Obtener();
        }
        public async Task<Respuesta<ConfiguracionEnt>> Insertar(ConfiguracionEnt model)
        {
            return await _IConfiguracionDat.Insertar(model);
        }
        public async Task<Respuesta<ConfiguracionEnt>> Modificar(ConfiguracionEnt model)
        {
            return await _IConfiguracionDat.Modificar(model);
        }
        public async Task<ConfiguracionEnt> ObtenerByIdConfiguracion(int IdConfiguracion)
        {
            return await _IConfiguracionDat.ObtenerByIdConfiguracion(IdConfiguracion);
        }
        public async Task<IEnumerable<ConfiguracionEnt>> ObtenerByLikeNombre(string Nombre)
        {
            return await _IConfiguracionDat.ObtenerByLikeNombre(Nombre);
        }
    }
}
