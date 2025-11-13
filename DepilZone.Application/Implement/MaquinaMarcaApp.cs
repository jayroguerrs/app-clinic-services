
using DepilZone.Application.Interface;
using DepilZone.Data.Interface;
using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement
{
	public class MaquinaMarcaApp : IMaquinaMarcaApp
	{
		private readonly IMaquinaMarcaDom _IMaquinaMarcaDom;
        public MaquinaMarcaApp(IMaquinaMarcaDom IMaquinaMarcaDom)
        {
            this._IMaquinaMarcaDom = IMaquinaMarcaDom;
        }

        public async Task<List<MaquinaMarcaDTO>> Obtener()
        {
            return await _IMaquinaMarcaDom.Obtener();
        }

        public async Task<List<MaquinaMarcaSDTO>> Listar()
        {
            return await _IMaquinaMarcaDom.Listar();
        }

        public async Task<List<MaquinaMarcaSDTO>> ListarByServicio(int idServicio)
        {
            return await _IMaquinaMarcaDom.ListarByServicio(idServicio);
        }

        public async Task<bool> Registrar(MaquinaMarcaDTO model)
        {
            return await _IMaquinaMarcaDom.Registrar(model);
        }
        public async Task<bool> Modificar(int id, MaquinaMarcaDTO model)
        {
            return await _IMaquinaMarcaDom.Modificar(id, model);
        }
        
    }
}
