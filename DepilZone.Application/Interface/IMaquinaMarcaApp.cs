using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace DepilZone.Application.Interface
{
    public interface IMaquinaMarcaApp
	{
		Task<List<MaquinaMarcaDTO>> Obtener();
		Task<List<MaquinaMarcaSDTO>> Listar();
		Task<List<MaquinaMarcaSDTO>> ListarByServicio(int idServicio);
        Task<bool> Registrar(MaquinaMarcaDTO model);
		Task<bool> Modificar(int id, MaquinaMarcaDTO model);
	}
}
