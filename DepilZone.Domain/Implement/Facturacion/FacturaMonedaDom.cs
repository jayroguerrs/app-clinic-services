
using DepilZone.Data.Interface.Facturacion;
using DepilZone.Entidad.DTO.Facturacion;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Domain.Implement
{
    public class FacturaMonedaDom: IFacturaMonedaDom
	{
		private readonly IFacturaMonedaDat _IFacturaMonedaDat;
		public FacturaMonedaDom(IFacturaMonedaDat IFacturaMonedaDat)
		{
			this._IFacturaMonedaDat = IFacturaMonedaDat;
		}
		public async Task<List<FacturaMonedaDTO>> Listar(int IdUsuario)
		{
			return await _IFacturaMonedaDat.Listar(IdUsuario);
		}
        public async Task<List<FacturaMonedaDTO>> Listar2(int IdUsuario)
        {
            return await _IFacturaMonedaDat.Listar2(IdUsuario);
        }
        public async Task<bool> Registrar(FacturaMonedaDTO model)
        {
            return await _IFacturaMonedaDat.Registrar(model);
        }
        public async Task<bool> Modificar(int id, FacturaMonedaDTO model)
        {
            return await _IFacturaMonedaDat.Modificar(id, model);
        }

        public async Task<FacturaMonedaDTO> Buscar(int Id, int IdUsuario)
        {
            return await _IFacturaMonedaDat.Buscar(Id, IdUsuario);
        }

    }
}
