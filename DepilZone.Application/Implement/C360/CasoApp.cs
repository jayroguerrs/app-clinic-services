
using DepilZone.Application.Interface.C360;
using DepilZone.Data.Interface.C360;
using DepilZone.Entidad.DTO.C360;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement.C360
{
	public class CasoApp : ICasoApp
	{
		private readonly ICasoDom _ICasoDom;
        public CasoApp(ICasoDom ICasoDom)
        {
            this._ICasoDom = ICasoDom;
        }

        public async Task<List<CasoDTO>> Listar()
        {
            return await _ICasoDom.Listar();
        }

        public async Task<List<CasoDTO>> ListarByEstado(int idEstado)
        {
            return await _ICasoDom.ListarByEstado(idEstado);
        }

        public async Task<bool> Registrar(CasoDTO model)
        {
            return await _ICasoDom.Registrar(model);
        }
        public async Task<bool> Modificar(int id, CasoDTO model)
        {
            return await _ICasoDom.Modificar(id, model);
        }
        
    }
}
