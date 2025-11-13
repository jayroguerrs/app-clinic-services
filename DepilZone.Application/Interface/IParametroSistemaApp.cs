using DepilZone.Entidad;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Interface
{
    public interface IParametroSistemaApp
    {
        Task<Respuesta<ParametroSistemaEnt>> ObtenerById(int Id);
        Task<List<ParametroSistemaEnt>> ObtenerParametros();
        Task<string> ObtenerValorByParametro(string Parametro);
        Task<Respuesta<string>> ObtenerLinkQA();
    }
}
