using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Data.Interface
{
	public interface IEmpresaDat
	{
		Task<IEnumerable<EmpresaEnt>> Obtener();
		Task<EmpresaEmisionTicketDTO> ObtenerEmpresaEmisionTicketByCita(int idCita);
	}
}
