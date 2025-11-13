using DepilZone.Domain.Interface.Test;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO.Test;

using System.Threading.Tasks;

namespace DepilZone.Application.Interface.Test
{
    public interface IParameterSystemApp
    {
        Task<ParameterSystemResponseDTO> Create(ParameterSystemDTO model);
    }
}
