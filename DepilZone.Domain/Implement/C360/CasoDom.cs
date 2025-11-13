using DepilZone.Data.Interface.C360;
using DepilZone.Entidad.DTO.C360;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Domain.Implement.C360
{
    public class CasoDom: ICasoDom
	{
		private readonly ICasoDat _ICasoDat;
		public CasoDom(ICasoDat ICasoDat)
		{
			this._ICasoDat = ICasoDat;
		}
		public async Task<List<CasoDTO>> Listar()
		{
			return await _ICasoDat.Listar();
		}
		public async Task<List<CasoDTO>> ListarByEstado(int idEstado)
		{
			return await _ICasoDat.ListarByEstado(idEstado);
		}
		public async Task<bool> Registrar(CasoDTO model)
        {
            return await _ICasoDat.Registrar(model);
        }
        public async Task<bool> Modificar(int id, CasoDTO model)
        {
            return await _ICasoDat.Modificar(id, model);
        }
        
    }
}
