
using DepilZone.Application.Interface.Test;
using DepilZone.Domain.Interface.Test;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO.Test;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement.Test
{
    public class ParameterSystemApp : IParameterSystemApp
    {
        private readonly IParameterSystemDom _IParameterSystemDom;

        public ParameterSystemApp(IParameterSystemDom IParameterSystemDom)
        {
            this._IParameterSystemDom = IParameterSystemDom;

        }

        public async Task<ParameterSystemResponseDTO> Create(ParameterSystemDTO model)
        {
            return await _IParameterSystemDom.Create(model);
        }

    }
}
