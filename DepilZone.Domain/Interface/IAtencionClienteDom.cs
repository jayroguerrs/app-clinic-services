using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System.Threading.Tasks;

namespace DepilZone.Domain.Interface
{
    public interface IAtencionClienteDom
    {
        Task<bool> Insertar(AtencionClienteRegistrarDTO model);
    }
}
