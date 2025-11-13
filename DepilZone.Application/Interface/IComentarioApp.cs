using DepilZone.Entidad;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Application.Interface
{
    public interface IComentarioApp
    {
        Task<IEnumerable<ComentarioEnt>> Obtener();
    }
}
