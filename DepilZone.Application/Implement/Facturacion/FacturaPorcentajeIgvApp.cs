
using DepilZone.Application.Interface.Facturacion;
using DepilZone.Data.Interface.Facturacion;
using DepilZone.Entidad.DTO.Facturacion;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement.Facturacion
{
	public class FacturaPorcentajeIgvApp : IFacturaPorcentajeIgvApp
	{
		private readonly IFacturaPorcentajeIgvDom _IFacturaPorcentajeIgvDom;
        public FacturaPorcentajeIgvApp(IFacturaPorcentajeIgvDom IFacturaPorcentajeIgvDom)
        {
            this._IFacturaPorcentajeIgvDom = IFacturaPorcentajeIgvDom;
        }

        public async Task<List<FacturaPorcentajeIgvDTO>> Listar(int IdUsuario)
        {
            return await _IFacturaPorcentajeIgvDom.Listar(IdUsuario);
        }

        public async Task<List<FacturaPorcentajeIgvDTO>> Listar2(int IdUsuario)
        {
            return await _IFacturaPorcentajeIgvDom.Listar2(IdUsuario);
        }

        public async Task<FacturaPorcentajeIgvDTO> Buscar(int Id, int IdUsuario)
        {
            return await _IFacturaPorcentajeIgvDom.Buscar(Id, IdUsuario);
        }

        public async Task<bool> Registrar(FacturaPorcentajeIgvDTO model)
        {
            return await _IFacturaPorcentajeIgvDom.Registrar(model);
        }
        public async Task<bool> Modificar(int id, FacturaPorcentajeIgvDTO model)
        {
            return await _IFacturaPorcentajeIgvDom.Modificar(id, model);
        }
        
    }
}
