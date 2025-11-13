using DepilZone.Data.Interface.C360;
using DepilZone.Entidad.DTO.C360;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Domain.Implement.C360
{
    public class CategoriaDom: ICategoriaDom
	{
		private readonly ICategoriaDat _ICategoriaDat;
		public CategoriaDom(ICategoriaDat ICategoriaDat)
		{
			this._ICategoriaDat = ICategoriaDat;
		}
		public async Task<List<CategoriaDTO>> Listar()
		{
			return await _ICategoriaDat.Listar();
		}
		public async Task<List<CategoriaDTO>> ListarByEstado(int idEstado)
		{
			return await _ICategoriaDat.ListarByEstado(idEstado);
		}
		public async Task<bool> Registrar(CategoriaDTO model)
        {
            return await _ICategoriaDat.Registrar(model);
        }
        public async Task<bool> Modificar(int id, CategoriaDTO model)
        {
            return await _ICategoriaDat.Modificar(id, model);
        }
        
    }
}
