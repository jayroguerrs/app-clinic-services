using DepilZone.Entidad;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Data.Interface
{
    public interface IConfiguracionDom
    {
        Task<IEnumerable<ConfiguracionEnt>> Obtener();
        Task<ConfiguracionEnt> ObtenerByIdConfiguracion(int IdConfiguracion);
        Task<Respuesta<ConfiguracionEnt>> Insertar(ConfiguracionEnt model);
        Task<Respuesta<ConfiguracionEnt>> Modificar(ConfiguracionEnt model);
        Task<IEnumerable<ConfiguracionEnt>> ObtenerByLikeNombre(string Nombre);

    }
}
