using DepilZone.Entidad.DTO.Facturacion;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Data.Interface.Facturacion
{
	public interface IFacturaTransaccionSunatDom
	{
        Task<List<FacturaTransaccionSunatDTO>> Listar(int IdUsuario);
        Task<List<FacturaTransaccionSunatDTO>> Listar2(int IdUsuario);
        Task<FacturaTransaccionSunatDTO> Buscar(int Id, int IdUsuario);
        Task<bool> Registrar(FacturaTransaccionSunatDTO model);
        Task<bool> Modificar(int id, FacturaTransaccionSunatDTO model);
    }
}
