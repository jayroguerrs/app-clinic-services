using DepilZone.Application.Interface;
using DepilZone.Data.Interface;
using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement
{
    public class MaquinaSedePerfilApp : IMaquinaSedePerfilApp
    {

        private readonly IMaquinaSedePerfilDom _IMaquinaSedePerfilDom;
        public MaquinaSedePerfilApp(IMaquinaSedePerfilDom IMaquinaSedePerfilDom)
        {
            this._IMaquinaSedePerfilDom = IMaquinaSedePerfilDom;
        }

        public async Task<bool> Insertar(MaquinaSedePerfilDTO model)
        {
            return await _IMaquinaSedePerfilDom.Insertar(model);
        }
        public async Task<List<MaquinaSedePerfilDTO>> ObtenerByMaquinaSede(int idUsuario, int idMaquinaSede)
        {
            return await _IMaquinaSedePerfilDom.ObtenerByMaquinaSede(idUsuario, idMaquinaSede);
        }

    }
}
