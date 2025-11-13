using DepilZone.Entidad.DTO.C360;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace DepilZone.Data.Interface.C360
{
	public interface ITipoCitaDat
	{
		Task<List<TipoCitaDTO>> Listar();
		Task<List<TipoCitaDTO>> ListarByEstado(int idEstado);
		Task<bool> Registrar(TipoCitaDTO model);
		Task<bool> Modificar(int id, TipoCitaDTO model);
	}
}
