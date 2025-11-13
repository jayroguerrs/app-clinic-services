using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Data.Interface
{
	public interface IRolesDom
	{
		Task<Respuesta<RolesEnt>> Insertar(RolesEnt model);
		Task<IEnumerable<RolesMenuEnt>> ObtenerById(int IdUsuario,int idModulo);
		Task<IEnumerable<RolesUsuarioEnt>> ObtenerRoles(int IdUsuario);
		Task<IEnumerable<RolesUsuarioEnt>> ObtenerRolesMenu(int IdUsuario, int IdModulo);
		Task<Respuesta<RolesEnt>> Modificar(RolesEnt model);
	}
}
