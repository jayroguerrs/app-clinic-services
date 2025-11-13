
using DepilZone.Application.Interface;
using DepilZone.Data.Interface;
using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement
{
	public class FacturaSerieApp : IFacturaSerieApp
	{
		private readonly IFacturaSerieDom _IFacturaSerieDom;
        public FacturaSerieApp(IFacturaSerieDom IFacturaSerieDom)
        {
            this._IFacturaSerieDom = IFacturaSerieDom;
        }

        public async Task<List<FacturaSerieDTO>> Listar()
        {
            return await _IFacturaSerieDom.Listar();
        }

        public async Task<List<FacturaSerieDTO>> ListarByEstado(int idEstado)
        {
            return await _IFacturaSerieDom.ListarByEstado(idEstado);
        }

        public async Task<bool> Registrar(FacturaSerieDTO model)
        {
            return await _IFacturaSerieDom.Registrar(model);
        }
        public async Task<bool> Modificar(int id, FacturaSerieDTO model)
        {
            return await _IFacturaSerieDom.Modificar(id, model);
        }
        
    }
}
