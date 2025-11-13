
using DepilZone.Data.Interface.Facturacion;
using DepilZone.Entidad.DTO.Facturacion;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Domain.Implement
{
    public class FacturaPorcentajeIgvDom: IFacturaPorcentajeIgvDom
	{
		private readonly IFacturaPorcentajeIgvDat _IFacturaPorcentajeIgvDat;
		public FacturaPorcentajeIgvDom(IFacturaPorcentajeIgvDat IFacturaPorcentajeIgvDat)
		{
			this._IFacturaPorcentajeIgvDat = IFacturaPorcentajeIgvDat;
		}
		public async Task<List<FacturaPorcentajeIgvDTO>> Listar(int IdUsuario)
		{
			return await _IFacturaPorcentajeIgvDat.Listar(IdUsuario);
		}
        public async Task<List<FacturaPorcentajeIgvDTO>> Listar2(int IdUsuario)
        {
            return await _IFacturaPorcentajeIgvDat.Listar2(IdUsuario);
        }
        public async Task<bool> Registrar(FacturaPorcentajeIgvDTO model)
        {
            return await _IFacturaPorcentajeIgvDat.Registrar(model);
        }
        public async Task<bool> Modificar(int id, FacturaPorcentajeIgvDTO model)
        {
            return await _IFacturaPorcentajeIgvDat.Modificar(id, model);
        }

        public async Task<FacturaPorcentajeIgvDTO> Buscar(int Id, int IdUsuario)
        {
            return await _IFacturaPorcentajeIgvDat.Buscar(Id, IdUsuario);
        }

    }
}
