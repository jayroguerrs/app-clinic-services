using DepilZone.Entidad.DTO.Facturacion;
using System.Threading.Tasks;

namespace DepilZone.Data.Interface.Facturacion
{
	public interface IComprobanteElectronicoAnuladoDom
	{
        Task<ComprobanteElectronicoMotivoAnuladoDTO> BuscarPorComprobante(int IdVenta, int IdUsuario);
    }
}
