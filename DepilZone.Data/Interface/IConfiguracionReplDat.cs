using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Data.Interface
{
    public interface IConfiguracionReplDat
    {
        Task<IEnumerable<ConfiguracionReplEnt>> Obtener();
        Task<Respuesta<ConfiguracionReplEnt>> Modificar(ConfiguracionReplEnt model);
        Task<ConfiguracionReplEnt> ObtenerByIdConfiguracion(int IdConfiguracion);
        Task<ConfiguracionReplEnt> ObtenerByIdConfiguracionDNI(string DNI, string IdConfiguracion);
    }
}
