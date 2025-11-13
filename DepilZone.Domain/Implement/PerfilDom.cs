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
   public class PerfilDom: IPerfilDom
    {
        private readonly IPerfilDat _IPerfilDat;
        public PerfilDom(IPerfilDat IPerfilDat)
        {
            this._IPerfilDat = IPerfilDat;
        }

        public async Task<Respuesta<PerfilEnt>> Insertar(PerfilDTO perfil)
        {
            return await _IPerfilDat.Insertar(perfil);
        }
        public async Task<Respuesta<PerfilEnt>> Modificar(PerfilDTO perfil)
        {
            return await _IPerfilDat.Modificar(perfil);
        }

        public async Task<IEnumerable<PerfilEnt>> Obtener()
        {
            return await _IPerfilDat.Obtener();
        }
        public async Task<PerfilConfiguracionDTO> ObtenerById(int idPerfil)
        {
            return await _IPerfilDat.ObtenerById(idPerfil);
        }

    }
}
