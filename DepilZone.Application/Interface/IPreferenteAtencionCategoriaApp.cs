using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Interface
{
    public interface IPreferenteAtencionCategoriaApp
    {
        Task<List<PreferenteAtencionCategoriaDTO>> Listar();
        

    }
}
