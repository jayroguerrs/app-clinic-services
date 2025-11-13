using DepilZone.Application.Interface;
using DepilZone.Domain.Interface;
using DepilZone.Entidad;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement
{
    public class TipoComprobanteApp : ITipoComprobanteApp
    {
        private readonly ITipoComprobanteDom _ITipoComprobanteDom;

        public TipoComprobanteApp(ITipoComprobanteDom iTipoComprobanteDom)
        {
            this._ITipoComprobanteDom = iTipoComprobanteDom;
        }

        public async Task<Respuesta<TipoComprobanteEnt>> Insertar(TipoComprobanteEnt model)
        {
            return await _ITipoComprobanteDom.Insertar(model);
        }

        public async Task<Respuesta<TipoComprobanteEnt>> Modificar(TipoComprobanteEnt model)
        {
            return await _ITipoComprobanteDom.Modificar(model);
        }

        public async Task<IEnumerable<TipoComprobanteEnt>> Obtener()
        {
            return await _ITipoComprobanteDom.Obtener();
        }

        public async Task<TipoComprobanteEnt> ObtenerById(int id)
        {
            return await _ITipoComprobanteDom.ObtenerById(id);
        }

        public async Task<List<TipoComprobanteEnt>> ObtenerToPuntoVenta(int idUsuario)
        {
            return await _ITipoComprobanteDom.ObtenerToPuntoVenta(idUsuario);
        }
    }
}
