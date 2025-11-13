using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace DepilZone.Data.Interface
{
	public interface IPlantillaDat
	{
		Task<List<PlantillaDTO>> Listar();
		Task<List<PlantillaDTO>> ListarActivos();
        Task<List<PlantillaDTO>> ListarByEstado(int idEstado);
		Task<bool> Registrar(PlantillaDTO model);
		Task<bool> Modificar(int id, PlantillaDTO model);
	}
}
