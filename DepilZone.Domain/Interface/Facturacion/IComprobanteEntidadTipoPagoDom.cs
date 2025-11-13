using DepilZone.Entidad.DTO.Facturacion;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Data.Interface.Facturacion
{
	public interface IComprobanteEntidadTipoPagoDom
	{
        Task<List<ComprobanteEntidadTipoPagoDTO>> Listar(int IdUsuario);
    }
}
