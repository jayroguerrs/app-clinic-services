using DepilZone.Entidad.DTO.Facturacion;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Data.Interface.Facturacion
{
	public interface IFacturaPorcentajeIgvDom
	{
        Task<List<FacturaPorcentajeIgvDTO>> Listar(int IdUsuario);
        Task<List<FacturaPorcentajeIgvDTO>> Listar2(int IdUsuario);
        Task<FacturaPorcentajeIgvDTO> Buscar(int Id, int IdUsuario);
        Task<bool> Registrar(FacturaPorcentajeIgvDTO model);
        Task<bool> Modificar(int id, FacturaPorcentajeIgvDTO model);
    }
}
