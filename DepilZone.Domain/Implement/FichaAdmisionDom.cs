using DepilZone.Data.Interface;
using DepilZone.Domain.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Domain.Implement
{
    public class FichaAdmisionDom : IFichaAdmisionDom
    {
        private readonly IFichaAdmisionDat _IFichaAdmisionDat;
        public FichaAdmisionDom(IFichaAdmisionDat IFichaAdmisionDat)
        {
            this._IFichaAdmisionDat = IFichaAdmisionDat;
        }

        public async Task<FichaAdmisionDTO> ObtenerFichaById(int IdFichaAdmision)
        {
            return await _IFichaAdmisionDat.ObtenerFichaById(IdFichaAdmision);
        }

        public async Task<bool> EditarFichaAdmision(FichaAdmisionDTO model)
        {
            return await _IFichaAdmisionDat.EditarFichaAdmision(model);
        }
    }
}
