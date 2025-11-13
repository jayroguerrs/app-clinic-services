
using DepilZone.Application.Interface;
using DepilZone.Data.Interface;
using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement
{
	public class PlantillaApp : IPlantillaApp
	{
		private readonly IPlantillaDom _IPlantillaDom;
        public PlantillaApp(IPlantillaDom IPlantillaDom)
        {
            this._IPlantillaDom = IPlantillaDom;
        }

        public async Task<List<PlantillaDTO>> Listar()
        {
            return await _IPlantillaDom.Listar();
        }

        public async Task<List<PlantillaDTO>> ListarActivos()
        {
            return await _IPlantillaDom.ListarActivos();
        }

        public async Task<List<PlantillaDTO>> ListarByEstado(int idEstado)
        {
            return await _IPlantillaDom.ListarByEstado(idEstado);
        }

        public async Task<bool> Registrar(PlantillaDTO model)
        {
            return await _IPlantillaDom.Registrar(model);
        }
        public async Task<bool> Modificar(int id, PlantillaDTO model)
        {
            return await _IPlantillaDom.Modificar(id, model);
        }
        
    }
}
