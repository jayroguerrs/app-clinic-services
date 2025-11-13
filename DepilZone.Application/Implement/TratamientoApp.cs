
using DepilZone.Application.Interface;
using DepilZone.Data.Interface;
using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement
{
	public class TratamientoApp : ITratamientoApp
	{
		private readonly ITratamientoDom _ITratamientoDom;
        public TratamientoApp(ITratamientoDom ITratamientoDom)
        {
            this._ITratamientoDom = ITratamientoDom;
        }

        public async Task<List<TratamientoDTO>> Listar()
        {
            return await _ITratamientoDom.Listar();
        }

        public async Task<List<TratamientoSDTO>> ListarToSelect()
        {
            return await _ITratamientoDom.ListarToSelect();
        }

        public async Task<List<TratamientoSDTO>> ListarByServicio(int idServicio)
        {
            return await _ITratamientoDom.ListarByServicio(idServicio);
        }

        public async Task<bool> Registrar(TratamientoDTO model)
        {
            return await _ITratamientoDom.Registrar(model);
        }
        public async Task<bool> Modificar(int id, TratamientoDTO model)
        {
            return await _ITratamientoDom.Modificar(id, model);
        }
        
    }
}
