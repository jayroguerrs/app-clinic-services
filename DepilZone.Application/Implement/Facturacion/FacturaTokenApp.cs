
using DepilZone.Application.Interface.Facturacion;
using DepilZone.Data.Interface.Facturacion;
using DepilZone.Entidad.DTO.Facturacion;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement.Facturacion
{
	public class FacturaTokenApp : IFacturaTokenApp
	{
		private readonly IFacturaTokenDom _IFacturaTokenDom;
        public FacturaTokenApp(IFacturaTokenDom IFacturaTokenDom)
        {
            this._IFacturaTokenDom = IFacturaTokenDom;
        }

        public async Task<List<FacturaTokenDTO>> Listar(int IdUsuario)
        {
            return await _IFacturaTokenDom.Listar(IdUsuario);
        }

        public async Task<FacturaTokenDTO> BuscarPorSede(int IdUsuario, int IdSede)
        {
            return await _IFacturaTokenDom.BuscarPorSede(IdUsuario, IdSede);
        }

        public async Task<FacturaTokenDTO> Buscar(int Id, int IdUsuario)
        {
            return await _IFacturaTokenDom.Buscar(Id, IdUsuario);
        }

        public async Task<bool> Registrar(FacturaTokenDTO model)
        {
            return await _IFacturaTokenDom.Registrar(model);
        }
        public async Task<bool> Modificar(int id, FacturaTokenDTO model)
        {
            return await _IFacturaTokenDom.Modificar(id, model);
        }
        
    }
}
