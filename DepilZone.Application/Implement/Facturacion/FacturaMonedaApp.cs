
using DepilZone.Application.Interface.Facturacion;
using DepilZone.Data.Interface.Facturacion;
using DepilZone.Entidad.DTO.Facturacion;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement.Facturacion
{
	public class FacturaMonedaApp : IFacturaMonedaApp
	{
		private readonly IFacturaMonedaDom _IFacturaMonedaDom;
        public FacturaMonedaApp(IFacturaMonedaDom IFacturaMonedaDom)
        {
            this._IFacturaMonedaDom = IFacturaMonedaDom;
        }

        public async Task<List<FacturaMonedaDTO>> Listar(int IdUsuario)
        {
            return await _IFacturaMonedaDom.Listar(IdUsuario);
        }

        public async Task<List<FacturaMonedaDTO>> Listar2(int IdUsuario)
        {
            return await _IFacturaMonedaDom.Listar2(IdUsuario);
        }

        public async Task<FacturaMonedaDTO> Buscar(int Id, int IdUsuario)
        {
            return await _IFacturaMonedaDom.Buscar(Id, IdUsuario);
        }

        public async Task<bool> Registrar(FacturaMonedaDTO model)
        {
            return await _IFacturaMonedaDom.Registrar(model);
        }
        public async Task<bool> Modificar(int id, FacturaMonedaDTO model)
        {
            return await _IFacturaMonedaDom.Modificar(id, model);
        }
        
    }
}
