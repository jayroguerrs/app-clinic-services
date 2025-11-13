using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Interface
{
	public interface IClienteRecurrenteApp
	{
		Task<IEnumerable<ClienteRecurrenteDTO>> Obtener();
		Task<IEnumerable<ClienteRecurrenteDTO>> Obtenercitafecha(DateTime fechaInicio, DateTime fechaTermino);
	}
}
