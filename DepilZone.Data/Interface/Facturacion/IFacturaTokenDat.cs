using DepilZone.Entidad.DTO.Facturacion;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace DepilZone.Data.Interface.Facturacion
{
	public interface IFacturaTokenDat
	{
		Task<List<FacturaTokenDTO>> Listar(int idUsuario);
		Task<FacturaTokenDTO> BuscarPorSede(int idUsuario, int idSede);
        Task<FacturaTokenDTO> Buscar(int Id, int IdUsuario);
        Task<bool> Registrar(FacturaTokenDTO model);
		Task<bool> Modificar(int id, FacturaTokenDTO model);
	}
}
