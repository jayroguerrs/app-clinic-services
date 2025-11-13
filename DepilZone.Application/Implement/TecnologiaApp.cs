
using DepilZone.Application.Interface;
using DepilZone.Data.Interface;
using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement
{
	public class TecnologiaApp : ITecnologiaApp
	{
		private readonly ITecnologiaDom _ITecnologiaDom;
        public TecnologiaApp(ITecnologiaDom ITecnologiaDom)
        {
            this._ITecnologiaDom = ITecnologiaDom;
        }

        public async Task<List<TecnologiaDTO>> Listar()
        {
            return await _ITecnologiaDom.Listar();
        }

        public async Task<List<TecnologiaDTO>> ListarByEstado(int idEstado)
        {
            return await _ITecnologiaDom.ListarByEstado(idEstado);
        }

        public async Task<List<TecnologiaDTO>> ListarByServicio(int idServicio)
        {
            return await _ITecnologiaDom.ListarByServicio(idServicio);
        }

        public async Task<bool> Registrar(TecnologiaDTO model)
        {
            return await _ITecnologiaDom.Registrar(model);
        }
        public async Task<bool> Modificar(int id, TecnologiaDTO model)
        {
            return await _ITecnologiaDom.Modificar(id, model);
        }
        
    }
}
