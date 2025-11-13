using DepilZone.Entidad;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Data.Interface
{
    public interface IParametroSistemaDat
    {
        Task<Respuesta<ParametroSistemaEnt>> ObtenerById(int Id);
        Task<IEnumerable<ParametroSistemaEnt>> ObtenerParametrosEmail();
        Task<List<ParametroSistemaEnt>> ObtenerParametros();
        Task<string> ObtenerValorByParametro(string Parametro);
        Task<Respuesta<string>> ObtenerLinkQA();
    }
}
