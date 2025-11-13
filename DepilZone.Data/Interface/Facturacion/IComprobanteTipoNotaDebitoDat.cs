using DepilZone.Entidad.DTO.Facturacion;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace DepilZone.Data.Interface.Facturacion
{
	public interface IComprobanteTipoNotaDebitoDat
	{
		Task<List<ComprobanteTipoNotaDebitoDTO>> Listar(int idUsuario);
		Task<List<ComprobanteTipoNotaDebitoDTO>> Listar2(int idUsuario);
        Task<ComprobanteTipoNotaDebitoDTO> Buscar(int Id, int IdUsuario);
        Task<bool> Registrar(ComprobanteTipoNotaDebitoDTO model);
		Task<bool> Modificar(int id, ComprobanteTipoNotaDebitoDTO model);
	}
}
