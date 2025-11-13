
using DepilZone.Data.Interface.Facturacion;
using DepilZone.Entidad.DTO.Facturacion;
using System.Threading.Tasks;

namespace DepilZone.Domain.Implement
{
    public class ComprobanteElectronicoAnuladoDom: IComprobanteElectronicoAnuladoDom
	{
		private readonly IComprobanteElectronicoAnuladoDat _IComprobanteElectronicoAnuladoDat;
		public ComprobanteElectronicoAnuladoDom(IComprobanteElectronicoAnuladoDat IComprobanteElectronicoAnuladoDat)
		{
			this._IComprobanteElectronicoAnuladoDat = IComprobanteElectronicoAnuladoDat;
		}
        public async Task<ComprobanteElectronicoMotivoAnuladoDTO> BuscarPorComprobante(int IdVenta, int IdUsuario)
		{ 
            return await _IComprobanteElectronicoAnuladoDat.BuscarPorComprobante(IdVenta, IdUsuario);
        }
      

    }
}
