using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Data.Interface
{
	public interface ITratamientoDom
	{
        Task<List<TratamientoDTO>> Listar();
        Task<List<TratamientoSDTO>> ListarToSelect();
        Task<List<TratamientoSDTO>> ListarByServicio(int idServicio);
        Task<bool> Registrar(TratamientoDTO model);
        Task<bool> Modificar(int id, TratamientoDTO model);
    }
}
