using DepilZone.Entidad.DTO.C360;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace DepilZone.Data.Interface.C360
{
	public interface ICasoDat
	{
		Task<List<CasoDTO>> Listar();
		Task<List<CasoDTO>> ListarByEstado(int idEstado);
		Task<bool> Registrar(CasoDTO model);
		Task<bool> Modificar(int id, CasoDTO model);
	}
}
