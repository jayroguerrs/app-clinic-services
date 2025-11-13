using DepilZone.Entidad.DTO.C360;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace DepilZone.Data.Interface.C360
{
	public interface IZonaDat
	{
		Task<List<ZonaDTO>> Listar();
		Task<List<ZonaDTO>> ListarByEstado(int idEstado);
		Task<bool> Registrar(ZonaDTO model);
		Task<bool> Modificar(int id, ZonaDTO model);
	}
}
