using DepilZone.Entidad;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Data.Interface
{
    public interface ICitaTipoDom 
    {
        Task<IEnumerable<CitaTipoEnt>> Obtener();
        Task<CitaTipoEnt> ObtenerById(int id);
        Task<Respuesta<CitaTipoEnt>> Insertar(CitaTipoEnt model);
        Task<Respuesta<CitaTipoEnt>> Modificar(CitaTipoEnt model);
        Task<IEnumerable<CitaTipoEnt>> ObtenerByLikeNombre(string Descripcion);

    }
}
