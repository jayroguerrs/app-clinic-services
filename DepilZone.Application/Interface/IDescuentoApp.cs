using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace DepilZone.Application.Interface
{
    public interface IDescuentoApp
	{
		Task<List<DescuentoDTO>> ObtenerListado();
	}
}
