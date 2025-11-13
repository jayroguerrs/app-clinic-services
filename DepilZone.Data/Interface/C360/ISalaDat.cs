using DepilZone.Entidad.DTO.C360;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace DepilZone.Data.Interface.C360
{
	public interface ISalaDat
	{
		Task<List<SalaDTO>> Listar();
		Task<List<SalaDTO>> ListarByEstado(int idEstado);
		Task<bool> Registrar(SalaDTO model);
		Task<bool> Modificar(int id, SalaDTO model);
	}
}
