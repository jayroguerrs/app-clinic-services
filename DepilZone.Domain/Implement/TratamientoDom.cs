using DepilZone.Data.Interface;
using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Domain.Implement
{
    public class TratamientoDom: ITratamientoDom
	{
		private readonly ITratamientoDat _ITratamientoDat;
		public TratamientoDom(ITratamientoDat ITratamientoDat)
		{
			this._ITratamientoDat = ITratamientoDat;
		}
		public async Task<List<TratamientoDTO>> Listar()
		{
			return await _ITratamientoDat.Listar();
		}
		public async Task<List<TratamientoSDTO>> ListarToSelect()
		{
			return await _ITratamientoDat.ListarToSelect();
		}
		public async Task<List<TratamientoSDTO>> ListarByServicio(int idServicio)
		{
			return await _ITratamientoDat.ListarByServicio(idServicio);
		}
		public async Task<bool> Registrar(TratamientoDTO model)
        {
            return await _ITratamientoDat.Registrar(model);
        }
        public async Task<bool> Modificar(int id, TratamientoDTO model)
        {
            return await _ITratamientoDat.Modificar(id, model);
        }
        
    }
}
