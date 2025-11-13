using DepilZone.Entidad.DTO.C360;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace DepilZone.Application.Interface.C360
{
    public interface ICategoriaApp
	{
		Task<List<CategoriaDTO>> Listar();
		Task<List<CategoriaDTO>> ListarByEstado(int idEstado);
		Task<bool> Registrar(CategoriaDTO model);
		Task<bool> Modificar(int id, CategoriaDTO model);
	}
}
