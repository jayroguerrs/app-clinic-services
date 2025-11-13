using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Domain.Interface
{
    public interface ICitaMotivoDom
    {
        Task<List<CitaMotivoEnt>> ListarByCitaEstado( int IdCitaEstado );
        Task<List<CitaMotivoEnt>> Listar();
    }
}
