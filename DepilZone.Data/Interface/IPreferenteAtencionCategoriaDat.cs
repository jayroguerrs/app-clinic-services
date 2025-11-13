using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Data.Interface
{
    public interface IPreferenteAtencionCategoriaDat
    {
        Task<List<PreferenteAtencionCategoriaDTO>> Listar();
       

    }
}
