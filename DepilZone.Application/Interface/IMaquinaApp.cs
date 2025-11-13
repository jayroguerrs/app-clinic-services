using DepilZone.Data.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Application.Interface
{
    public interface IMaquinaApp
    {
        Task<IEnumerable<MaquinaEnt>> Obtener();
        Task<Respuesta<MaquinaEnt>> Insertar(MaquinaEnt model);
        Task<Respuesta<MaquinaEnt>> Modificar(MaquinaEnt model);
        Task<MaquinaEnt> ObtenerById(int Id);
        Task<IEnumerable<MaquinaEnt>> ObtenerByLikeNombre(string Nombre);

        Task<List<MaquinaMinutosEnt>> ObtenerMinutos(DateTime fechaCita, int idSede);
    }
}
