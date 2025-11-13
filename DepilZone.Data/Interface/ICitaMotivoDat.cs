using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Data.Interface
{
    public interface ICitaMotivoDat
    {
        Task<List<CitaMotivoEnt>> ListarByCitaEstado( int idCitaEstado );
        Task<List<CitaMotivoEnt>> Listar();
    }
}
