using DepilZone.Application.Interface;
using DepilZone.Domain.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement
{
    public class PerfilApp: IPerfilApp
    {
        private readonly IPerfilDom _IPerfilDom;
        public PerfilApp(IPerfilDom IPerfilDom)
        {
            this._IPerfilDom = IPerfilDom;
        }

        public async Task<Respuesta<PerfilEnt>> Insertar(PerfilDTO perfil)
        {
            return await _IPerfilDom.Insertar(perfil);
        }
        public async Task<Respuesta<PerfilEnt>> Modificar(PerfilDTO perfil)
        {
            return await _IPerfilDom.Modificar(perfil);
        }

        public async Task<IEnumerable<PerfilEnt>> Obtener()
        {
            return await _IPerfilDom.Obtener();
        }

        public async Task<PerfilConfiguracionDTO> ObtenerById(int idPerfil)
        {
            return await _IPerfilDom.ObtenerById(idPerfil);
        }
    }
}
