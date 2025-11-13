using DepilZone.Application.Interface;
using DepilZone.Domain.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement
{
    public class FichaAdmisionApp : IFichaAdmisionApp
    {
        private readonly IFichaAdmisionDom _IFichaAdmisionDom;
        public FichaAdmisionApp(IFichaAdmisionDom IFichaAdmisionDom)
        {
            this._IFichaAdmisionDom = IFichaAdmisionDom;
        }

        public async Task<FichaAdmisionDTO> ObtenerFichaById(int IdFichaAdmision)
        {
            return await _IFichaAdmisionDom.ObtenerFichaById(IdFichaAdmision);
        }

        public async Task<bool> EditarFichaAdmision(FichaAdmisionDTO model)
        {
            return await _IFichaAdmisionDom.EditarFichaAdmision(model);
        }
    }
}
