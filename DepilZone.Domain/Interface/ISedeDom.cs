using DepilZone.Entidad;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Domain.Interface
{
    public interface ISedeDom
    {
        Task<IEnumerable<SedeEnt>> Obtener();
        Task<IEnumerable<SedeEnt>> ObtenerByLikeNombre(string Nombre);
        Task<Respuesta<SedeEnt>> Insertar(SedeEnt model);
        Task<Respuesta<SedeEnt>> Modificar(SedeEnt model);
        Task<SedeEnt> ObtenerById(int idsede);

    }
}
