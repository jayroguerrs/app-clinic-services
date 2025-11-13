using DepilZone.Entidad.DTO.Facturacion;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace DepilZone.Data.Interface.Facturacion
{
	public interface IFacturaPorcentajeIgvDat
	{
		Task<List<FacturaPorcentajeIgvDTO>> Listar(int idUsuario);
		Task<List<FacturaPorcentajeIgvDTO>> Listar2(int idUsuario);
        Task<FacturaPorcentajeIgvDTO> Buscar(int Id, int IdUsuario);
        Task<bool> Registrar(FacturaPorcentajeIgvDTO model);
		Task<bool> Modificar(int id, FacturaPorcentajeIgvDTO model);
	}
}
