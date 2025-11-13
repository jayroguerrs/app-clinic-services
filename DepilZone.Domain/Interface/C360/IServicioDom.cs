using DepilZone.Entidad.DTO.C360;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Data.Interface.C360
{
	public interface IServicioDom
	{
        Task<List<Servicio360DTO>> Listar();
        Task<List<Servicio360DTO>> ListarByEstado(int idEstado);
        Task<bool> Registrar(Servicio360DTO model);
        Task<bool> Modificar(int id, Servicio360DTO model);
        Task<Servicios360DTO> BuscarById(int id);
    }
}
