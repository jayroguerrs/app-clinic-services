using DepilZone.Data.Interface;
using DepilZone.Data.Interface.Test;
using DepilZone.Domain.Interface.Test;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO.Test;
using System;
using System.Threading.Tasks;

namespace DepilZone.Domain.Implement.Test
{
    public class ParameterSystemDom : IParameterSystemDom
    {
        private readonly IParameterSystemDat _IParametroSistemDat;

        public ParameterSystemDom(IParameterSystemDat IParameterSystemDat)
        {
            this._IParametroSistemDat = IParameterSystemDat;
        }

        public async Task<ParameterSystemResponseDTO> Create(ParameterSystemDTO model)
        {
            return await _IParametroSistemDat.Create(model);
        }
    }
}
