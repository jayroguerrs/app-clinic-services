using DepilZone.Entidad.DTO.C360;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace DepilZone.Application.Interface.C360
{
    public interface ITipoCitaApp
	{
		Task<List<TipoCitaDTO>> Listar();
		Task<List<TipoCitaDTO>> ListarByEstado(int idEstado);
		Task<bool> Registrar(TipoCitaDTO model);
		Task<bool> Modificar(int id, TipoCitaDTO model);
	}
}
