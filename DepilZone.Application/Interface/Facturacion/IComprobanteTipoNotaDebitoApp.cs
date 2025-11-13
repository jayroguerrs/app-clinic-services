
using DepilZone.Entidad.DTO.Facturacion;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace DepilZone.Application.Interface.Facturacion
{
    public interface IComprobanteTipoNotaDebitoApp
	{
		Task<List<ComprobanteTipoNotaDebitoDTO>> Listar(int idUsuario);
		Task<List<ComprobanteTipoNotaDebitoDTO>> Listar2(int idUsuario);
        Task<ComprobanteTipoNotaDebitoDTO> Buscar(int Id, int IdUsuario);
        Task<bool> Registrar(ComprobanteTipoNotaDebitoDTO model);
		Task<bool> Modificar(int id, ComprobanteTipoNotaDebitoDTO model);
	}
}
