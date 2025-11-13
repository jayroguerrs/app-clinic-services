using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace DepilZone.Data.Interface
{
	public interface IMaquinaMarcaDat
	{
		Task<List<MaquinaMarcaDTO>> Obtener();
		Task<List<MaquinaMarcaSDTO>> Listar();
		Task<List<MaquinaMarcaSDTO>> ListarByServicio(int idServicio);
        Task<bool> Registrar(MaquinaMarcaDTO model);
		Task<bool> Modificar(int id, MaquinaMarcaDTO model);
	}
}
