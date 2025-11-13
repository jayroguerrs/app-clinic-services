
using DepilZone.Entidad.DTO.Facturacion;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace DepilZone.Application.Interface.Facturacion
{
    public interface IComprobanteTipoNotaCreditoApp
	{
		Task<List<ComprobanteTipoNotaCreditoDTO>> Listar(int idUsuario);
		Task<List<ComprobanteTipoNotaCreditoDTO>> Listar2(int idUsuario);
        Task<ComprobanteTipoNotaCreditoDTO> Buscar(int Id, int IdUsuario);
        Task<bool> Registrar(ComprobanteTipoNotaCreditoDTO model);
		Task<bool> Modificar(int id, ComprobanteTipoNotaCreditoDTO model);
	}
}
