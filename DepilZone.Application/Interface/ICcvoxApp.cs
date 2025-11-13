using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DepilZone.Entidad;
using DepilZone.Entidad.DTO;


namespace DepilZone.Application.Interface
{
    public interface ICcvoxApp
    {
        Task<ResponseRedirect> EsCliente2(string numero);
    }
}
