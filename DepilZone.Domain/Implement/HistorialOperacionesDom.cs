using DepilZone.Data.Interface;
using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Domain.Implement
{
    public class HistorialOperacionesDom: IHistorialOperacionesDom
	{
		private readonly IHistorialOperacionesDat _IHistorialOperacionesDat;
		public HistorialOperacionesDom(IHistorialOperacionesDat IHistorialOperacionesDat)
		{
			this._IHistorialOperacionesDat = IHistorialOperacionesDat;
		}
		public async Task<List<HistorialMensajeMasivoDTO>> ListarHistorialEnvioMasivoMensaje()
        {
			return await _IHistorialOperacionesDat.ListarHistorialEnvioMasivoMensaje();
		}
        
    }
}
