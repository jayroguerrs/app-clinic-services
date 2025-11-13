using DepilZone.Application.Interface;
using DepilZone.Data.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement
{
	public class RolesApp: IRolesApp
	{
		private readonly IRolesDom _IRolesDom;
		public RolesApp(IRolesDom IRolesDom)
		{
			this._IRolesDom = IRolesDom;
		}
		public async Task<Respuesta<RolesEnt>> Insertar(RolesEnt model)
		{
			return await _IRolesDom.Insertar(model);
		}
		public async Task<Respuesta<RolesEnt>> Modificar(RolesEnt model)
		{
			return await _IRolesDom.Modificar(model);
		}
		public async Task<IEnumerable<RolesMenuEnt>> ObtenerById(int IdUsuario, int idModulo)
		{
			return await _IRolesDom.ObtenerById(IdUsuario, idModulo);
		}
		public async Task<IEnumerable<RolesUsuarioEnt>> ObtenerRoles(int IdUsuario)
		{
			return await _IRolesDom.ObtenerRoles(IdUsuario);
		}
		public async Task<IEnumerable<RolesUsuarioEnt>> ObtenerRolesMenu(int IdUsuario, int idModulo)
		{
			return await _IRolesDom.ObtenerRolesMenu(IdUsuario, idModulo);
		}
	}
}
