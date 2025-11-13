using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace DepilZone.Data.Interface
{
	public interface IHistorialOperacionesDat
	{
		Task<List<HistorialMensajeMasivoDTO>> ListarHistorialEnvioMasivoMensaje();
	}
}
