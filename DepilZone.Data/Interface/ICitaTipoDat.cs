using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Data.Interface
{
    public interface ICitaTipoDat
    {
        Task<IEnumerable<CitaTipoEnt>> ObtenerByLikeNombre(string Descripcion);
        Task<Respuesta<CitaTipoEnt>> Insertar(CitaTipoEnt model);
        Task<CitaTipoEnt> ObtenerById(int IdTipoCita);
        Task<Respuesta<CitaTipoEnt>> Modificar(CitaTipoEnt model);
        Task<IEnumerable<CitaTipoEnt>> Obtener();
    }
}
