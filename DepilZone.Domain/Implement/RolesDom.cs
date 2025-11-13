using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DepilZone.Data;
using DepilZone.Data.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
namespace DepilZone.Domain.Implement
{
	public class RolesDom : IRolesDom
	{
		private readonly IRolesDat _IRolesDat;
		public RolesDom(IRolesDat IRolesDat)
		{
			this._IRolesDat = IRolesDat;
		}
		public async Task<Respuesta<RolesEnt>> Insertar(RolesEnt model)
		{
			return await _IRolesDat.Insertar(model);
		}
		public async Task<IEnumerable<RolesMenuEnt>> ObtenerById(int IdUsuario, int idModulo)
		{
			return await _IRolesDat.ObtenerById(IdUsuario, idModulo);
		}
		public async Task<IEnumerable<RolesUsuarioEnt>> ObtenerRoles(int IdUsuario)
		{
			return await _IRolesDat.ObtenerRoles(IdUsuario);
		}
		public async Task<IEnumerable<RolesUsuarioEnt>> ObtenerRolesMenu(int IdUsuario, int IdModulo)
		{
			return await _IRolesDat.ObtenerRolesMenu(IdUsuario, IdModulo);
		}
		public async Task<Respuesta<RolesEnt>> Modificar(RolesEnt model)
		{
			return await _IRolesDat.Modificar(model);
		}
	}
}
