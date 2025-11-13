using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace DepilZone.Data.Interface
{
	public interface IFacturaSerieDat
	{
		Task<List<FacturaSerieDTO>> Listar();
		Task<List<FacturaSerieDTO>> ListarByEstado(int idEstado);
		Task<bool> Registrar(FacturaSerieDTO model);
		Task<bool> Modificar(int id, FacturaSerieDTO model);
	}
}
