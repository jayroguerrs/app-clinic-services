using DepilZone.Data.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace DepilZone.Domain.Implement

{
    public class EmpresaDom : IEmpresaDom
	{
		private readonly IEmpresaDat _IEmpresaDat;
		public EmpresaDom(IEmpresaDat IEmpresaDat)
		{
			this._IEmpresaDat = IEmpresaDat;
		}
		public async Task<IEnumerable<EmpresaEnt>> Obtener()
		{
			return await _IEmpresaDat.Obtener();
		}
		public async Task<EmpresaEmisionTicketDTO> ObtenerEmpresaEmisionTicketByCita(int idCita)
		{
			return await _IEmpresaDat.ObtenerEmpresaEmisionTicketByCita(idCita);
		}
	}
}
