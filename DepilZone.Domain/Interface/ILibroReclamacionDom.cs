using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System.Threading.Tasks;
namespace DepilZone.Domain.Interface
{
    public interface ILibroReclamacionDom
    {
        Task<Respuesta<LibroReclamacionDTO>> Insertar(LibroReclamacionEnt model);
        Task<Respuesta<string>> ObtenerPlantilla(int idTabla);
    }
}