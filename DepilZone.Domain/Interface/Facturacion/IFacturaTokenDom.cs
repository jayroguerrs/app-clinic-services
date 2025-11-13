using DepilZone.Entidad.DTO.Facturacion;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Data.Interface.Facturacion
{
	public interface IFacturaTokenDom
	{
        Task<List<FacturaTokenDTO>> Listar(int IdUsuario);
        Task<FacturaTokenDTO> BuscarPorSede(int IdUsuario, int IdSede);
        Task<FacturaTokenDTO> Buscar(int Id, int IdUsuario);
        Task<bool> Registrar(FacturaTokenDTO model);
        Task<bool> Modificar(int id, FacturaTokenDTO model);
    }
}
