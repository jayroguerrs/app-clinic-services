using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Data.Interface
{
	public interface IServicioDom
	{
        Task<List<ServicioDTO>> Listar();
        Task<List<ServicioDTO>> ListarByEstado(int idEstado);
        Task<bool> Registrar(ServicioDTO model);
        Task<bool> Modificar(int id, ServicioDTO model);
    }
}
