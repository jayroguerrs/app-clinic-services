
using DepilZone.Entidad;
using DepilZone.Entidad.DTO.Test;
using System.Threading.Tasks;

namespace DepilZone.Domain.Interface.Test
{
    public interface IParameterSystemDom
    {
        Task<ParameterSystemResponseDTO> Create(ParameterSystemDTO model);

    }
}
