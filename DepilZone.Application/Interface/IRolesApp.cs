using DepilZone.Entidad;
using System.Collections.Generic;
using System.Threading.Tasks;
using DepilZone.Entidad.DTO;


namespace DepilZone.Application.Interface
{
	public interface IRolesApp
	{
		Task<Respuesta<RolesEnt>> Insertar(RolesEnt model);
		Task<IEnumerable<RolesMenuEnt>> ObtenerById(int IdUsuario, int idModulo);
		Task<IEnumerable<RolesUsuarioEnt>> ObtenerRoles(int IdUsuario);
		Task<IEnumerable<RolesUsuarioEnt>> ObtenerRolesMenu(int IdUsuario, int IdModulo);
		Task<Respuesta<RolesEnt>> Modificar(RolesEnt model);
	}
}
