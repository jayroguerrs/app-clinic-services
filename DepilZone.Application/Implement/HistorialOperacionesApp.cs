
using DepilZone.Application.Interface;
using DepilZone.Data.Interface;
using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement
{
	public class HistorialOperacionesApp : IHistorialOperacionesApp
	{
		private readonly IHistorialOperacionesDom _IHistorialOperacionesDom;
        public HistorialOperacionesApp(IHistorialOperacionesDom IHistorialOperacionesDom)
        {
            this._IHistorialOperacionesDom = IHistorialOperacionesDom;
        }

        public async Task<List<HistorialMensajeMasivoDTO>> ListarHistorialEnvioMasivoMensaje()
        {
            return await _IHistorialOperacionesDom.ListarHistorialEnvioMasivoMensaje();
        }

        
    }
}
