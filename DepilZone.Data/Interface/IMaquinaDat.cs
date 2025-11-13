using DepilZone.Entidad;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Data.Interface
{
    public interface IMaquinaDat
    {
        Task<IEnumerable<MaquinaEnt>> Obtener();
        Task<Respuesta<MaquinaEnt>> Insertar(MaquinaEnt model);
        Task<Respuesta<MaquinaEnt>> Modificar(MaquinaEnt model);
        Task<MaquinaEnt> ObtenerById(int Id);
        Task<IEnumerable<MaquinaEnt>> ObtenerByLikeNombre(string Nombre);

        Task<List<MaquinaMinutosEnt>> ObtenerMinutos(DateTime fechaCita, int idSede);

    }
}
