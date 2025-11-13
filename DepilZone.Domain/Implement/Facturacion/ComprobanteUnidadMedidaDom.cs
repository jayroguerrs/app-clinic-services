
using DepilZone.Data.Interface.Facturacion;
using DepilZone.Entidad.DTO.Facturacion;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Domain.Implement
{
    public class ComprobanteUnidadMedidaDom: IComprobanteUnidadMedidaDom
	{
		private readonly IComprobanteUnidadMedidaDat _IComprobanteUnidadMedidaDat;
		public ComprobanteUnidadMedidaDom(IComprobanteUnidadMedidaDat IComprobanteUnidadMedidaDat)
		{
			this._IComprobanteUnidadMedidaDat = IComprobanteUnidadMedidaDat;
		}
		public async Task<List<ComprobanteUnidadMedidaDTO>> Listar(int IdUsuario)
		{
			return await _IComprobanteUnidadMedidaDat.Listar(IdUsuario);
		}
        public async Task<List<ComprobanteUnidadMedidaDTO>> Listar2(int IdUsuario)
        {
            return await _IComprobanteUnidadMedidaDat.Listar2(IdUsuario);
        }
        public async Task<bool> Registrar(ComprobanteUnidadMedidaDTO model)
        {
            return await _IComprobanteUnidadMedidaDat.Registrar(model);
        }
        public async Task<bool> Modificar(int id, ComprobanteUnidadMedidaDTO model)
        {
            return await _IComprobanteUnidadMedidaDat.Modificar(id, model);
        }

        public async Task<ComprobanteUnidadMedidaDTO> Buscar(int Id, int IdUsuario)
        {
            return await _IComprobanteUnidadMedidaDat.Buscar(Id, IdUsuario);
        }

    }
}
