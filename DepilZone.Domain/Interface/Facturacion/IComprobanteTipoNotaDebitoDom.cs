using DepilZone.Entidad.DTO.Facturacion;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Data.Interface.Facturacion
{
	public interface IComprobanteTipoNotaDebitoDom
	{
        Task<List<ComprobanteTipoNotaDebitoDTO>> Listar(int IdUsuario);
        Task<List<ComprobanteTipoNotaDebitoDTO>> Listar2(int IdUsuario);
        Task<ComprobanteTipoNotaDebitoDTO> Buscar(int Id, int IdUsuario);
        Task<bool> Registrar(ComprobanteTipoNotaDebitoDTO model);
        Task<bool> Modificar(int id, ComprobanteTipoNotaDebitoDTO model);
    }
}
