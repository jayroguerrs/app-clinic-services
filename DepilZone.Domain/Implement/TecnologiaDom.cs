using DepilZone.Data.Interface;
using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Domain.Implement
{
    public class TecnologiaDom: ITecnologiaDom
	{
		private readonly ITecnologiaDat _ITecnologiaDat;
		public TecnologiaDom(ITecnologiaDat ITecnologiaDat)
		{
			this._ITecnologiaDat = ITecnologiaDat;
		}
		public async Task<List<TecnologiaDTO>> Listar()
		{
			return await _ITecnologiaDat.Listar();
		}
		public async Task<List<TecnologiaDTO>> ListarByEstado(int idEstado)
		{
			return await _ITecnologiaDat.ListarByEstado(idEstado);
		}
		public async Task<List<TecnologiaDTO>> ListarByServicio(int idServicio)
		{
			return await _ITecnologiaDat.ListarByServicio(idServicio);
		}
		public async Task<bool> Registrar(TecnologiaDTO model)
        {
            return await _ITecnologiaDat.Registrar(model);
        }
        public async Task<bool> Modificar(int id, TecnologiaDTO model)
        {
            return await _ITecnologiaDat.Modificar(id, model);
        }
        
    }
}
