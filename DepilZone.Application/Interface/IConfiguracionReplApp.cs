using DepilZone.Data.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Application.Interface
{
    public interface IConfiguracionReplApp
    {
        Task<Respuesta<ConfiguracionReplEnt>> Modificar(ConfiguracionReplEnt model);
        Task<IEnumerable<ConfiguracionReplEnt>> Obtener();
        Task<ConfiguracionReplEnt> ObtenerByIdConfiguracion(int IdConfiguracion);
        Task<ConfiguracionReplEnt> ObtenerByIdConfiguracionDNI(string DNI , string IdConfiguracion);
    }
}
