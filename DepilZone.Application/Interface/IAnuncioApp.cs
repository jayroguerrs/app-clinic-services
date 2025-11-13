using DepilZone.Entidad;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Interface
{
    public interface IAnuncioApp
    {
        Task<Respuesta<AnuncioEnt>> Insertar(AnuncioEnt model);
        Task<AnuncioEnt> ObtenerById(int id);
        Task<Respuesta<AnuncioEnt>> Modificar(AnuncioEnt model);
        Task<IEnumerable<AnuncioEnt>> Obtener();
    }
}
