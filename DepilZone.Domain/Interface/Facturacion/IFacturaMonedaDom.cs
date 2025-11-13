using DepilZone.Entidad.DTO.Facturacion;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Data.Interface.Facturacion
{
	public interface IFacturaMonedaDom
	{
        Task<List<FacturaMonedaDTO>> Listar(int IdUsuario);
        Task<List<FacturaMonedaDTO>> Listar2(int IdUsuario);
        Task<bool> Registrar(FacturaMonedaDTO model);
        Task<bool> Modificar(int id, FacturaMonedaDTO model);
        Task<FacturaMonedaDTO> Buscar(int Id, int IdUsuario);
    }
}
