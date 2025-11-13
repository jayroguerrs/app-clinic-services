using DepilZone.Entidad;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Domain.Interface
{
    public interface IParametroSistemaDom
    {
        Task<Respuesta<ParametroSistemaEnt>> ObtenerById(int Id);
        Task<IEnumerable<ParametroSistemaEnt>> ObtenerConfgCorreo();
        Task<List<ParametroSistemaEnt>> ObtenerParametros();
        Task<string> ObtenerValorByParametro(string Parametro);
        Task<Respuesta<string>> ObtenerLinkQA();
    }
}
