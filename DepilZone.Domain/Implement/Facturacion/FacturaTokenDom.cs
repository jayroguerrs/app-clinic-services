
using DepilZone.Data.Interface.Facturacion;
using DepilZone.Entidad.DTO.Facturacion;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Domain.Implement
{
    public class FacturaTokenDom: IFacturaTokenDom
	{
		private readonly IFacturaTokenDat _IFacturaTokenDat;
		public FacturaTokenDom(IFacturaTokenDat IFacturaTokenDat)
		{
			this._IFacturaTokenDat = IFacturaTokenDat;
		}
		public async Task<List<FacturaTokenDTO>> Listar(int IdUsuario)
		{
			return await _IFacturaTokenDat.Listar(IdUsuario);
		}
		public async Task<FacturaTokenDTO> BuscarPorSede(int IdUsuario, int IdSede)
        {
			return await _IFacturaTokenDat.BuscarPorSede(IdUsuario, IdSede);
		}
		public async Task<bool> Registrar(FacturaTokenDTO model)
        {
            return await _IFacturaTokenDat.Registrar(model);
        }
        public async Task<bool> Modificar(int id, FacturaTokenDTO model)
        {
            return await _IFacturaTokenDat.Modificar(id, model);
        }

        public async Task<FacturaTokenDTO> Buscar(int Id, int IdUsuario)
        {
            return await _IFacturaTokenDat.Buscar(Id, IdUsuario);
        }

    }
}
