using DepilZone.Data.Interface;
using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Domain.Implement
{
    public class PlantillaDom: IPlantillaDom
	{
		private readonly IPlantillaDat _IPlantillaDat;
		public PlantillaDom(IPlantillaDat IPlantillaDat)
		{
			this._IPlantillaDat = IPlantillaDat;
		}
		public async Task<List<PlantillaDTO>> Listar()
		{
			return await _IPlantillaDat.Listar();
		}
        public async Task<List<PlantillaDTO>> ListarActivos()
        {
            return await _IPlantillaDat.ListarActivos();
        }
        public async Task<List<PlantillaDTO>> ListarByEstado(int idEstado)
		{
			return await _IPlantillaDat.ListarByEstado(idEstado);
		}
		public async Task<bool> Registrar(PlantillaDTO model)
        {
            return await _IPlantillaDat.Registrar(model);
        }
        public async Task<bool> Modificar(int id, PlantillaDTO model)
        {
            return await _IPlantillaDat.Modificar(id, model);
        }
        
    }
}
