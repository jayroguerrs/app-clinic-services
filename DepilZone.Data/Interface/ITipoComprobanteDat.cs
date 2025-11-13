using DepilZone.Entidad;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Data.Interface
{
    public interface ITipoComprobanteDat
    {
        Task<IEnumerable<TipoComprobanteEnt>> Obtener();
        Task<TipoComprobanteEnt> ObtenerById(int id);
        Task<Respuesta<TipoComprobanteEnt>> Insertar(TipoComprobanteEnt model);
        Task<Respuesta<TipoComprobanteEnt>> Modificar(TipoComprobanteEnt model);
        Task<List<TipoComprobanteEnt>> ObtenerToPuntoVenta(int idUsuario);


    }
}
