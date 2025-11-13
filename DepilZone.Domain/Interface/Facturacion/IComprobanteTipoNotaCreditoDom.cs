using DepilZone.Entidad.DTO.Facturacion;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Data.Interface.Facturacion
{
	public interface IComprobanteTipoNotaCreditoDom
	{
        Task<List<ComprobanteTipoNotaCreditoDTO>> Listar(int IdUsuario);
        Task<List<ComprobanteTipoNotaCreditoDTO>> Listar2(int IdUsuario);
        Task<ComprobanteTipoNotaCreditoDTO> Buscar(int Id, int IdUsuario);
        Task<bool> Registrar(ComprobanteTipoNotaCreditoDTO model);
        Task<bool> Modificar(int id, ComprobanteTipoNotaCreditoDTO model);
    }
}
