using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace DepilZone.Data.Interface
{
	public interface ITecnologiaDat
	{
		Task<List<TecnologiaDTO>> Listar();
		Task<List<TecnologiaDTO>> ListarByEstado(int idEstado);
		Task<List<TecnologiaDTO>> ListarByServicio(int idServicio);
		Task<bool> Registrar(TecnologiaDTO model);
		Task<bool> Modificar(int id, TecnologiaDTO model);
	}
}
