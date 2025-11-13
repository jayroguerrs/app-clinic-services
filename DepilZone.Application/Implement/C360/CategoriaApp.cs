
using DepilZone.Application.Interface.C360;
using DepilZone.Data.Interface.C360;
using DepilZone.Entidad.DTO.C360;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement.C360
{
	public class CategoriaApp : ICategoriaApp
	{
		private readonly ICategoriaDom _ICategoriaDom;
        public CategoriaApp(ICategoriaDom ICategoriaDom)
        {
            this._ICategoriaDom = ICategoriaDom;
        }

        public async Task<List<CategoriaDTO>> Listar()
        {
            return await _ICategoriaDom.Listar();
        }

        public async Task<List<CategoriaDTO>> ListarByEstado(int idEstado)
        {
            return await _ICategoriaDom.ListarByEstado(idEstado);
        }

        public async Task<bool> Registrar(CategoriaDTO model)
        {
            return await _ICategoriaDom.Registrar(model);
        }
        public async Task<bool> Modificar(int id, CategoriaDTO model)
        {
            return await _ICategoriaDom.Modificar(id, model);
        }
        
    }
}
