using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Application.Interface
{
    public interface ISegAuditoriaApp
    {
        Task<Boolean> Insertar(SegAuditoriaDTO model);
    }
}
