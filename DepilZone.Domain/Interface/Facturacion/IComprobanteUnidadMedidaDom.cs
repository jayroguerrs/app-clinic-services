using DepilZone.Entidad.DTO.Facturacion;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Data.Interface.Facturacion
{
	public interface IComprobanteUnidadMedidaDom
	{
        Task<List<ComprobanteUnidadMedidaDTO>> Listar(int IdUsuario);
        Task<List<ComprobanteUnidadMedidaDTO>> Listar2(int IdUsuario);
        Task<ComprobanteUnidadMedidaDTO> Buscar(int Id, int IdUsuario);
        Task<bool> Registrar(ComprobanteUnidadMedidaDTO model);
        Task<bool> Modificar(int id, ComprobanteUnidadMedidaDTO model);
    }
}
