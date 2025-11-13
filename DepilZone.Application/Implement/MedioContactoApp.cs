using DepilZone.Data.Interface;
using DepilZone.Domain.Interface;
using DepilZone.Entidad;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement
{
    public class MedioContactoApp: IMedioContactoApp
    {
        private readonly IMedioContactoDom _IMedioContactoDom;
        public MedioContactoApp(IMedioContactoDom IMedioContactoDom)
        {
            this._IMedioContactoDom = IMedioContactoDom;
        }

        public async Task<IEnumerable<MedioContactoEnt>> Obtener()
        {
            return await this._IMedioContactoDom.Obtener();
        }
    }
}
