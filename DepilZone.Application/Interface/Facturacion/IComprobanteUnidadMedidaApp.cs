
using DepilZone.Entidad.DTO.Facturacion;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace DepilZone.Application.Interface.Facturacion
{
    public interface IComprobanteUnidadMedidaApp
	{
		Task<List<ComprobanteUnidadMedidaDTO>> Listar(int idUsuario);
		Task<List<ComprobanteUnidadMedidaDTO>> Listar2(int idUsuario);
        Task<ComprobanteUnidadMedidaDTO> Buscar(int Id, int IdUsuario);
        Task<bool> Registrar(ComprobanteUnidadMedidaDTO model);
		Task<bool> Modificar(int id, ComprobanteUnidadMedidaDTO model);
	}
}
