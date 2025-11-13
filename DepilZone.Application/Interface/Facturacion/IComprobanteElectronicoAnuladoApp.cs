
using DepilZone.Entidad.DTO.Facturacion;
using System.Threading.Tasks;


namespace DepilZone.Application.Interface.Facturacion
{
    public interface IComprobanteElectronicoAnuladoApp
	{
        Task<ComprobanteElectronicoMotivoAnuladoDTO> BuscarPorComprobante(int IdVenta, int IdUsuario);
    }
}
