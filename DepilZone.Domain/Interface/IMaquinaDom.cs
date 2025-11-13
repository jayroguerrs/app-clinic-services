using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Data.Interface
{
    public interface IMaquinaDom
    {
        Task<IEnumerable<MaquinaEnt>> Obtener();
        Task<MaquinaEnt> ObtenerById(int Id);
        Task<Respuesta<MaquinaEnt>> Insertar(MaquinaEnt model);
        Task<Respuesta<MaquinaEnt>> Modificar(MaquinaEnt model);
        //Task<IEnumerable<MaquinaSedeEnt>> ObtenerByIdSede(int IdSede);
        Task<IEnumerable<MaquinaEnt>> ObtenerByLikeNombre(string Nombre);

        Task<List<MaquinaMinutosEnt>> ObtenerMinutos(DateTime fechaCita, int idSede);
    }
}
