using DepilZone.Data.Interface;
using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Domain.Implement
{
    public class MaquinaMarcaDom: IMaquinaMarcaDom
	{
		private readonly IMaquinaMarcaDat _IMaquinaMarcaDat;
		public MaquinaMarcaDom(IMaquinaMarcaDat IMaquinaMarcaDat)
		{
			this._IMaquinaMarcaDat = IMaquinaMarcaDat;
		}
		public async Task<List<MaquinaMarcaSDTO>> Listar()
		{
			return await _IMaquinaMarcaDat.Listar();
		}
        public async Task<List<MaquinaMarcaSDTO>> ListarByServicio(int idServicio)
        {
            return await _IMaquinaMarcaDat.ListarByServicio(idServicio);
        }
        public async Task<List<MaquinaMarcaDTO>> Obtener()
		{
			return await _IMaquinaMarcaDat.Obtener();
		}
		public async Task<bool> Registrar(MaquinaMarcaDTO model)
        {
            return await _IMaquinaMarcaDat.Registrar(model);
        }
        public async Task<bool> Modificar(int id, MaquinaMarcaDTO model)
        {
            return await _IMaquinaMarcaDat.Modificar(id, model);
        }
        
    }
}
