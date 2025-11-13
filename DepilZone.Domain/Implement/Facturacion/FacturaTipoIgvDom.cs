
using DepilZone.Data.Interface.Facturacion;
using DepilZone.Entidad.DTO.Facturacion;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Domain.Implement
{
    public class FacturaTipoIgvDom: IFacturaTipoIgvDom
	{
		private readonly IFacturaTipoIgvDat _IFacturaTipoIgvDat;
		public FacturaTipoIgvDom(IFacturaTipoIgvDat IFacturaTipoIgvDat)
		{
			this._IFacturaTipoIgvDat = IFacturaTipoIgvDat;
		}
		public async Task<List<FacturaTipoIgvDTO>> Listar(int IdUsuario)
		{
			return await _IFacturaTipoIgvDat.Listar(IdUsuario);
		}
        public async Task<List<FacturaTipoIgvDTO>> Listar2(int IdUsuario)
        {
            return await _IFacturaTipoIgvDat.Listar2(IdUsuario);
        }
        public async Task<bool> Registrar(FacturaTipoIgvDTO model)
        {
            return await _IFacturaTipoIgvDat.Registrar(model);
        }
        public async Task<bool> Modificar(int id, FacturaTipoIgvDTO model)
        {
            return await _IFacturaTipoIgvDat.Modificar(id, model);
        }

        public async Task<FacturaTipoIgvDTO> Buscar(int Id, int IdUsuario)
        {
            return await _IFacturaTipoIgvDat.Buscar(Id, IdUsuario);
        }

    }
}
