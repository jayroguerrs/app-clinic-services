using DepilZone.Entidad.DTO.C360;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace DepilZone.Application.Interface.C360
{
    public interface ITipoClienteApp
	{
		Task<List<TipoCliente360DTO>> Listar();
		Task<List<TipoCliente360DTO>> ListarByEstado(int idEstado);
		Task<bool> Registrar(TipoCliente360DTO model);
		Task<bool> Modificar(int id, TipoCliente360DTO model);
	}
}
