using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Domain.Interface
{
    public interface IPreferenteAtencionCategoriaDom
    {
        Task<List<PreferenteAtencionCategoriaDTO>> Listar();
    }
}
