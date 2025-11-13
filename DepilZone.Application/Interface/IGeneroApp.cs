using DepilZone.Entidad;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Application.Interface
{
    public interface IGeneroApp
    {
        Task<IEnumerable<GeneroEnt>> Obtener();
    }
}
