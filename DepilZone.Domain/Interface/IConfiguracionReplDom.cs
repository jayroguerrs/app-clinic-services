using DepilZone.Entidad;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Data.Interface
{
    public interface IConfiguracionReplDom
    {
        Task<Respuesta<ConfiguracionReplEnt>> Modificar(ConfiguracionReplEnt model);
        Task<IEnumerable<ConfiguracionReplEnt>> Obtener();
        Task<ConfiguracionReplEnt> ObtenerByIdConfiguracion(int IdConfiguracion);
        Task<ConfiguracionReplEnt> ObtenerByIdConfiguracionDNI(string DNI , string IdConfiguracion);
    }
}
