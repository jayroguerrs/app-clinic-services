using DepilZone.Entidad;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Data.Interface
{
    public interface IMedioContactoApp
    {
        Task<IEnumerable<MedioContactoEnt>> Obtener();
    }
}
