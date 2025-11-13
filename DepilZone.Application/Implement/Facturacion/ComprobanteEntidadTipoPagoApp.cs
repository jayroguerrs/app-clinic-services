
using DepilZone.Application.Interface.Facturacion;
using DepilZone.Data.Interface.Facturacion;
using DepilZone.Entidad.DTO.Facturacion;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement.Facturacion
{
	public class ComprobanteEntidadTipoPagoApp : IComprobanteEntidadTipoPagoApp
	{
		private readonly IComprobanteEntidadTipoPagoDom _IComprobanteEntidadTipoPagoDom;
        public ComprobanteEntidadTipoPagoApp(IComprobanteEntidadTipoPagoDom IComprobanteEntidadTipoPagoDom)
        {
            this._IComprobanteEntidadTipoPagoDom = IComprobanteEntidadTipoPagoDom;
        }

        public async Task<List<ComprobanteEntidadTipoPagoDTO>> Listar(int IdUsuario)
        {
            return await _IComprobanteEntidadTipoPagoDom.Listar(IdUsuario);
        }

        
    }
}
