
using DepilZone.Application.Interface.Facturacion;
using DepilZone.Data.Interface.Facturacion;
using DepilZone.Entidad.DTO.Facturacion;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement.Facturacion
{
	public class FacturaTipoIgvApp : IFacturaTipoIgvApp
	{
		private readonly IFacturaTipoIgvDom _IFacturaTipoIgvDom;
        public FacturaTipoIgvApp(IFacturaTipoIgvDom IFacturaTipoIgvDom)
        {
            this._IFacturaTipoIgvDom = IFacturaTipoIgvDom;
        }

        public async Task<List<FacturaTipoIgvDTO>> Listar(int IdUsuario)
        {
            return await _IFacturaTipoIgvDom.Listar(IdUsuario);
        }

        public async Task<List<FacturaTipoIgvDTO>> Listar2(int IdUsuario)
        {
            return await _IFacturaTipoIgvDom.Listar2(IdUsuario);
        }

        public async Task<FacturaTipoIgvDTO> Buscar(int Id, int IdUsuario)
        {
            return await _IFacturaTipoIgvDom.Buscar(Id, IdUsuario);
        }

        public async Task<bool> Registrar(FacturaTipoIgvDTO model)
        {
            return await _IFacturaTipoIgvDom.Registrar(model);
        }
        public async Task<bool> Modificar(int id, FacturaTipoIgvDTO model)
        {
            return await _IFacturaTipoIgvDom.Modificar(id, model);
        }
        
    }
}
