using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Data.Interface
{
    public interface IConfiguracionDat
    {
        Task<IEnumerable<ConfiguracionEnt>> Obtener();
        Task<Respuesta<ConfiguracionEnt>> Insertar(ConfiguracionEnt model);
        Task<Respuesta<ConfiguracionEnt>> Modificar(ConfiguracionEnt model);
        Task<ConfiguracionEnt> ObtenerByIdConfiguracion(int IdConfiguracion);
        Task<IEnumerable<ConfiguracionEnt>> ObtenerByLikeNombre(string Nombre);
    }
}
