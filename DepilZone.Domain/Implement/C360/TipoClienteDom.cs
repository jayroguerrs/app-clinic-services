using DepilZone.Data.Interface.C360;
using DepilZone.Entidad.DTO.C360;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Domain.Implement.C360
{
    public class TipoClienteDom: ITipoClienteDom
	{
		private readonly ITipoClienteDat _ITipoClienteDat;
		public TipoClienteDom(ITipoClienteDat ITipoClienteDat)
		{
			this._ITipoClienteDat = ITipoClienteDat;
		}
		public async Task<List<TipoCliente360DTO>> Listar()
		{
			return await _ITipoClienteDat.Listar();
		}
		public async Task<List<TipoCliente360DTO>> ListarByEstado(int idEstado)
		{
			return await _ITipoClienteDat.ListarByEstado(idEstado);
		}
		public async Task<bool> Registrar(TipoCliente360DTO model)
        {
            return await _ITipoClienteDat.Registrar(model);
        }
        public async Task<bool> Modificar(int id, TipoCliente360DTO model)
        {
            return await _ITipoClienteDat.Modificar(id, model);
        }
        
    }
}
