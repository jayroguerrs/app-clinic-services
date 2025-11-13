using DepilZone.Data.Interface;
using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Domain.Implement
{
    public class FacturaSerieDom: IFacturaSerieDom
	{
		private readonly IFacturaSerieDat _IFacturaSerieDat;
		public FacturaSerieDom(IFacturaSerieDat IFacturaSerieDat)
		{
			this._IFacturaSerieDat = IFacturaSerieDat;
		}
		public async Task<List<FacturaSerieDTO>> Listar()
		{
			return await _IFacturaSerieDat.Listar();
		}
		public async Task<List<FacturaSerieDTO>> ListarByEstado(int idEstado)
		{
			return await _IFacturaSerieDat.ListarByEstado(idEstado);
		}
		public async Task<bool> Registrar(FacturaSerieDTO model)
        {
            return await _IFacturaSerieDat.Registrar(model);
        }
        public async Task<bool> Modificar(int id, FacturaSerieDTO model)
        {
            return await _IFacturaSerieDat.Modificar(id, model);
        }
        
    }
}
