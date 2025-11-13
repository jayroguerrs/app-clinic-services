
using DepilZone.Application.Interface.C360;
using DepilZone.Data.Interface.C360;
using DepilZone.Entidad.DTO.C360;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement.C360
{
	public class TipoClienteApp : ITipoClienteApp
	{
		private readonly ITipoClienteDom _ITipoClienteDom;
        public TipoClienteApp(ITipoClienteDom ITipoClienteDom)
        {
            this._ITipoClienteDom = ITipoClienteDom;
        }

        public async Task<List<TipoCliente360DTO>> Listar()
        {
            return await _ITipoClienteDom.Listar();
        }

        public async Task<List<TipoCliente360DTO>> ListarByEstado(int idEstado)
        {
            return await _ITipoClienteDom.ListarByEstado(idEstado);
        }

        public async Task<bool> Registrar(TipoCliente360DTO model)
        {
            return await _ITipoClienteDom.Registrar(model);
        }
        public async Task<bool> Modificar(int id, TipoCliente360DTO model)
        {
            return await _ITipoClienteDom.Modificar(id, model);
        }
        
    }
}
