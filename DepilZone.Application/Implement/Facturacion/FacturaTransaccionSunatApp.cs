
using DepilZone.Application.Interface.Facturacion;
using DepilZone.Data.Interface.Facturacion;
using DepilZone.Entidad.DTO.Facturacion;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement.Facturacion
{
	public class FacturaTransaccionSunatApp : IFacturaTransaccionSunatApp
	{
		private readonly IFacturaTransaccionSunatDom _IFacturaTransaccionSunatDom;
        public FacturaTransaccionSunatApp(IFacturaTransaccionSunatDom IFacturaTransaccionSunatDom)
        {
            this._IFacturaTransaccionSunatDom = IFacturaTransaccionSunatDom;
        }

        public async Task<List<FacturaTransaccionSunatDTO>> Listar(int IdUsuario)
        {
            return await _IFacturaTransaccionSunatDom.Listar(IdUsuario);
        }

        public async Task<List<FacturaTransaccionSunatDTO>> Listar2(int IdUsuario)
        {
            return await _IFacturaTransaccionSunatDom.Listar2(IdUsuario);
        }

        public async Task<FacturaTransaccionSunatDTO> Buscar(int Id, int IdUsuario)
        {
            return await _IFacturaTransaccionSunatDom.Buscar(Id, IdUsuario);
        }

        public async Task<bool> Registrar(FacturaTransaccionSunatDTO model)
        {
            return await _IFacturaTransaccionSunatDom.Registrar(model);
        }
        public async Task<bool> Modificar(int id, FacturaTransaccionSunatDTO model)
        {
            return await _IFacturaTransaccionSunatDom.Modificar(id, model);
        }
        
    }
}
