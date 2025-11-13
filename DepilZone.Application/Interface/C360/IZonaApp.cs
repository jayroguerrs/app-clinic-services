using DepilZone.Entidad.DTO.C360;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace DepilZone.Application.Interface.C360
{
    public interface IZonaApp
	{
		Task<List<ZonaDTO>> Listar();
		Task<List<ZonaDTO>> ListarByEstado(int idEstado);
		Task<bool> Registrar(ZonaDTO model);
		Task<bool> Modificar(int id, ZonaDTO model);
	}
}
