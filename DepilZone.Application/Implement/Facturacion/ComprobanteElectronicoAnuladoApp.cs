
using DepilZone.Application.Interface.Facturacion;
using DepilZone.Data.Interface.Facturacion;
using DepilZone.Entidad.DTO.Facturacion;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement.Facturacion
{
	public class ComprobanteElectronicoAnuladoApp : IComprobanteElectronicoAnuladoApp
	{

		private readonly IComprobanteElectronicoAnuladoDom _IComprobanteElectronicoAnuladoDom;
        public ComprobanteElectronicoAnuladoApp(IComprobanteElectronicoAnuladoDom IComprobanteElectronicoAnuladoDom)
        {
            this._IComprobanteElectronicoAnuladoDom = IComprobanteElectronicoAnuladoDom;
        }

        public async Task<ComprobanteElectronicoMotivoAnuladoDTO> BuscarPorComprobante(int IdVenta, int IdUsuario)
        {
            return await _IComprobanteElectronicoAnuladoDom.BuscarPorComprobante(IdVenta, IdUsuario);
        }

    }
}
