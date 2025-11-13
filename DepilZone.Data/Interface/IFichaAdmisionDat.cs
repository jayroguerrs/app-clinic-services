using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Data.Interface
{
    public interface IFichaAdmisionDat
    {
        //Task<Respuesta<FichaAdmisionEnt>> Insertar(FichaAdmisionEnt model);
        Task<FichaAdmisionDTO> ObtenerFichaById(int IdFichaAdmision);

        Task<bool> EditarFichaAdmision(FichaAdmisionDTO model);
    }
}
