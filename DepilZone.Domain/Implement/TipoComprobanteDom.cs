using DepilZone.Data.Interface;
using DepilZone.Domain.Interface;
using DepilZone.Entidad;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Domain.Implement
{
    public class TipoComprobanteDom : ITipoComprobanteDom
    {
        private readonly ITipoComprobanteDat _iTipoComprobanteDat;
        public TipoComprobanteDom(ITipoComprobanteDat iTipoComprobanteDat)
        {
            this._iTipoComprobanteDat = iTipoComprobanteDat;
        }

        public async Task<Respuesta<TipoComprobanteEnt>> Insertar(TipoComprobanteEnt model)
        {
            return await _iTipoComprobanteDat.Insertar(model);
        }

        public async Task<Respuesta<TipoComprobanteEnt>> Modificar(TipoComprobanteEnt model)
        {
            return await _iTipoComprobanteDat.Modificar(model);
        }

        public async Task<IEnumerable<TipoComprobanteEnt>> Obtener()
        {
            return await this._iTipoComprobanteDat.Obtener();
        }

        public async Task<TipoComprobanteEnt> ObtenerById(int id)
        {
            return await _iTipoComprobanteDat.ObtenerById(id);
        }

        public async Task<List<TipoComprobanteEnt>> ObtenerToPuntoVenta(int idUsuario)
        {
            return await _iTipoComprobanteDat.ObtenerToPuntoVenta(idUsuario);
        }
    }
}
