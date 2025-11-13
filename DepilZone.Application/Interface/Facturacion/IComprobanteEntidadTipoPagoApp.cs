
using DepilZone.Entidad.DTO.Facturacion;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace DepilZone.Application.Interface.Facturacion
{
    public interface IComprobanteEntidadTipoPagoApp
	{
		Task<List<ComprobanteEntidadTipoPagoDTO>> Listar(int idUsuario);
	}
}
