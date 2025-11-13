using DepilZone.Entidad;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Application.Interface
{
    public interface IPatologiaApp
    {
        Task<IEnumerable<PatologiaEnt>> ObtenerListado();
    }
}
