using DepilZone.Data.Interface;
using DepilZone.Domain.Interface;
using DepilZone.Entidad;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Domain.Implement
{
    public class MedioContactoDom : IMedioContactoDom
    {
        private readonly IMedioContactoDat _IMedioContactoDat;
        public MedioContactoDom(IMedioContactoDat MedioContactoDat)
        {
            this._IMedioContactoDat = MedioContactoDat;
        }

        public async Task<IEnumerable<MedioContactoEnt>> Obtener()
        {
            return await this._IMedioContactoDat.Obtener();
        }
    }
}
