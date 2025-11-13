using DepilZone.Entidad;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Application.Interface
{
   public interface ISedeApp
    {
        Task<IEnumerable<SedeEnt>> Obtener();
        Task<IEnumerable<SedeEnt>> ObtenerByLikeNombre(string Nombre);
        Task<Respuesta<SedeEnt>> Insertar(SedeEnt model);
        Task<SedeEnt> ObtenerById(int IdSede);
        Task<Respuesta<SedeEnt>> Modificar(SedeEnt model);

    }
}
