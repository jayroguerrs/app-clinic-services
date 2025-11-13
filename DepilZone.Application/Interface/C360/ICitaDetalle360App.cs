using DepilZone.Entidad.DTO.C360;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Interface.C360
{
    public interface ICitaDetalle360App
    {
        Task<List<Cita360DetallesDTO>> BuscarByCita(int idCita);

    }
}
