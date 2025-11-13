using DepilZone.Entidad.DTO.C360;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace DepilZone.Application.Interface.C360
{
    public interface ISalaApp
	{
		Task<List<SalaDTO>> Listar();
		Task<List<SalaDTO>> ListarByEstado(int idEstado);
		Task<bool> Registrar(SalaDTO model);
		Task<bool> Modificar(int id, SalaDTO model);
	}
}
