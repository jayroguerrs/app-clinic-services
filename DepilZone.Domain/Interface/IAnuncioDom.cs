using DepilZone.Entidad;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Domain.Interface
{
    public interface IAnuncioDom
    {
        Task<Respuesta<AnuncioEnt>> Insertar(AnuncioEnt model);
        Task<AnuncioEnt> ObtenerById(int id);
        Task<Respuesta<AnuncioEnt>> Modificar(AnuncioEnt model);
        Task<IEnumerable<AnuncioEnt>> Obtener();
    }
}
