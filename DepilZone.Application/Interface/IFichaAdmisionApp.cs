using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Interface
{
    public interface IFichaAdmisionApp
    {
        //Task<Respuesta<FichaAdmisionEnt>> Insertar(FichaAdmisionEnt model);

        Task<FichaAdmisionDTO> ObtenerFichaById(int IdFichaAdmision);

        Task<bool> EditarFichaAdmision(FichaAdmisionDTO model);
    }
}
