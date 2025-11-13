using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Data.Interface
{
    public interface ICcvoxDat
    {
        Task<ResponseRedirect> EsCliente2(string numero);
    }
}
