using DepilZone.Entidad.DTO.Facturacion;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace DepilZone.Data.Interface.Facturacion
{
	public interface IFacturaTipoIgvDat
	{
		Task<List<FacturaTipoIgvDTO>> Listar(int idUsuario);
		Task<List<FacturaTipoIgvDTO>> Listar2(int idUsuario);
        Task<FacturaTipoIgvDTO> Buscar(int Id, int IdUsuario);
        Task<bool> Registrar(FacturaTipoIgvDTO model);
		Task<bool> Modificar(int id, FacturaTipoIgvDTO model);
	}
}
