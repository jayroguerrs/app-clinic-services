
using DepilZone.Data.Interface.Facturacion;
using DepilZone.Entidad.DTO.Facturacion;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Domain.Implement
{
    public class ComprobanteEntidadTipoPagoDom: IComprobanteEntidadTipoPagoDom
	{
		private readonly IComprobanteEntidadTipoPagoDat _IComprobanteEntidadTipoPagoDat;
		public ComprobanteEntidadTipoPagoDom(IComprobanteEntidadTipoPagoDat IComprobanteEntidadTipoPagoDat)
		{
			this._IComprobanteEntidadTipoPagoDat = IComprobanteEntidadTipoPagoDat;
		}
        public async Task<List<ComprobanteEntidadTipoPagoDTO>> Listar(int IdUsuario)
        {
            return await _IComprobanteEntidadTipoPagoDat.Listar(IdUsuario);
        }

    }
}
