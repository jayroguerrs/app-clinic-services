using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Interface
{
    public interface ICitaMotivoApp
    {
        Task<List<CitaMotivoEnt>> ListarByCitaEstado( int idCitaEstado );
        Task<List<CitaMotivoEnt>> Listar();
    }
}
