using DepilZone.Entidad;
using System.Collections.Generic;
using System.Threading.Tasks;
using DepilZone.Entidad.DTO;

namespace DepilZone.Application.Interface
{
	public interface IEmpresaApp
	{
		Task<IEnumerable<EmpresaEnt>> Obtener();
		Task<EmpresaEmisionTicketDTO> ObtenerEmpresaEmisionTicketByCita(int idCita);
	}
}
