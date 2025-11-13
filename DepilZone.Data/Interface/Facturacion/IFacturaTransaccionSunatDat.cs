using DepilZone.Entidad.DTO.Facturacion;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace DepilZone.Data.Interface.Facturacion
{
	public interface IFacturaTransaccionSunatDat
	{
		Task<List<FacturaTransaccionSunatDTO>> Listar(int idUsuario);
		Task<List<FacturaTransaccionSunatDTO>> Listar2(int idUsuario);
        Task<FacturaTransaccionSunatDTO> Buscar(int Id, int IdUsuario);
        Task<bool> Registrar(FacturaTransaccionSunatDTO model);
		Task<bool> Modificar(int id, FacturaTransaccionSunatDTO model);
	}
}
