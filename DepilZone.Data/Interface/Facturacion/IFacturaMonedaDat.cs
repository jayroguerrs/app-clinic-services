using DepilZone.Entidad.DTO.Facturacion;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace DepilZone.Data.Interface.Facturacion
{
	public interface IFacturaMonedaDat
	{
		Task<List<FacturaMonedaDTO>> Listar(int idUsuario);
		Task<List<FacturaMonedaDTO>> Listar2(int idUsuario);
        Task<FacturaMonedaDTO> Buscar(int Id, int IdUsuario);
        Task<bool> Registrar(FacturaMonedaDTO model);
		Task<bool> Modificar(int id, FacturaMonedaDTO model);
	}
}
