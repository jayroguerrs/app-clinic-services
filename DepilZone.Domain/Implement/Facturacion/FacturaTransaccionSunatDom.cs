
using DepilZone.Data.Interface.Facturacion;
using DepilZone.Entidad.DTO.Facturacion;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Domain.Implement
{
    public class FacturaTransaccionSunatDom: IFacturaTransaccionSunatDom
	{
		private readonly IFacturaTransaccionSunatDat _IFacturaTransaccionSunatDat;
		public FacturaTransaccionSunatDom(IFacturaTransaccionSunatDat IFacturaTransaccionSunatDat)
		{
			this._IFacturaTransaccionSunatDat = IFacturaTransaccionSunatDat;
		}
		public async Task<List<FacturaTransaccionSunatDTO>> Listar(int IdUsuario)
		{
			return await _IFacturaTransaccionSunatDat.Listar(IdUsuario);
		}
        public async Task<List<FacturaTransaccionSunatDTO>> Listar2(int IdUsuario)
        {
            return await _IFacturaTransaccionSunatDat.Listar2(IdUsuario);
        }
        public async Task<bool> Registrar(FacturaTransaccionSunatDTO model)
        {
            return await _IFacturaTransaccionSunatDat.Registrar(model);
        }
        public async Task<bool> Modificar(int id, FacturaTransaccionSunatDTO model)
        {
            return await _IFacturaTransaccionSunatDat.Modificar(id, model);
        }

        public async Task<FacturaTransaccionSunatDTO> Buscar(int Id, int IdUsuario)
        {
            return await _IFacturaTransaccionSunatDat.Buscar(Id, IdUsuario);
        }

    }
}
