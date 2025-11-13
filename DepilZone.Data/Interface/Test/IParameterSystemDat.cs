using DepilZone.Domain.Interface.Test;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO.Test;
using System.Threading.Tasks;

namespace DepilZone.Data.Interface.Test
{
    public interface IParameterSystemDat
    {
        Task<ParameterSystemResponseDTO> Create(ParameterSystemDTO model);
    }
}
