using DepilZone.Entidad;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Data.Interface
{
    public interface ISedeDat
    {
        Task<IEnumerable<SedeEnt>> ObtenerByLikeNombre(string Nombre);
        Task<Respuesta<SedeEnt>> Insertar(SedeEnt model);
        Task<SedeEnt> ObtenerById(int IdSede);
        Task<Respuesta<SedeEnt>> Modificar(SedeEnt model);
        Task<IEnumerable<SedeEnt>> Obtener();

    }
}
