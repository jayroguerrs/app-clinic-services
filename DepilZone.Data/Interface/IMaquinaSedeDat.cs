using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Data.Interface
{
    public interface IMaquinaSedeDat
    {
        Task<IEnumerable<MaquinaSedeGridDTO>> Obtener(int idEstado);
        Task<IEnumerable<MaquinaSedeGridDTO>> ObtenerBySede(int IdSede);
        Task<IEnumerable<MaquinaSedeGridDTO>> ObtenerByNombre(string Nombre);
        Task<IEnumerable<MaquinaSedeGridDTO>> ObtenerByFiltros(string Nombre, int IdSede);

        Task<Respuesta<MaquinaSedeEnt>> Insertar(MaquinaSedeEnt model);
        Task<Respuesta<MaquinaSedeEnt>> Modificar(MaquinaSedeEnt model);
        Task<MaquinaSedeEnt> ObtenerById(int Id);

        Task<List<MaquinaSedeGridDTO>> BuscarPorSedeyServicio(int idUsuario, int idSede, int idServicio);
        Task<List<MaquinaSedeGridDTO>> BuscarFicticios(int idUsuario, int idSede, int idServicio);
    }
}
