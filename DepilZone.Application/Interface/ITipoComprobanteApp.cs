using DepilZone.Entidad;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Interface
{
    public interface ITipoComprobanteApp
    {
        Task<IEnumerable<TipoComprobanteEnt>> Obtener();
        Task<TipoComprobanteEnt> ObtenerById(int id);
        Task<Respuesta<TipoComprobanteEnt>> Insertar(TipoComprobanteEnt model);
        Task<Respuesta<TipoComprobanteEnt>> Modificar(TipoComprobanteEnt model);
        Task<List<TipoComprobanteEnt>> ObtenerToPuntoVenta(int idUsuario);

    }
}
