using DepilZone.Application.Interface;
using DepilZone.Domain.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement
{
    public class CitaMotivoApp : ICitaMotivoApp
    {
        private readonly ICitaMotivoDom _ICitaMotivoDom;
        public CitaMotivoApp(ICitaMotivoDom ICitaMotivoDom)
        {
            _ICitaMotivoDom = ICitaMotivoDom;
        }
        public async Task<List<CitaMotivoEnt>> ListarByCitaEstado( int idCitaEstado )
        {
            return await _ICitaMotivoDom.ListarByCitaEstado(idCitaEstado);
        }

        public async Task<List<CitaMotivoEnt>> Listar()
        {
            return await _ICitaMotivoDom.Listar();
        }
    }
}
