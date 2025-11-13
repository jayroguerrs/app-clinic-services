using DepilZone.Application.Interface;
using DepilZone.Data.Interface;
using DepilZone.Domain.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement
{
	public class CajaApp : ICajaApp
	{
		private readonly ICajaDom _ICajaDom;
        private readonly IPosDom _IPosDom;
        public CajaApp(ICajaDom ICajaDom, IPosDom IPosDom)
        {
            this._ICajaDom = ICajaDom;
            this._IPosDom = IPosDom;
        }

        public async Task<IEnumerable<CajaEnt>> Obtener()
        {
            return await _ICajaDom.Obtener();
        }

        public async Task<Respuesta<CajaEnt>> Insertar(CajaEnt model)
        {
            return await _ICajaDom.Insertar(model);
        }
        public async Task<Respuesta<CajaEnt>> Modificar(CajaEnt model)
        {
            return await _ICajaDom.Modificar(model);
        }
        public async Task<Respuesta<CajaEnt>> AbrirCerrar(CajaEnt model)
        {
            return await _ICajaDom.AbrirCerrar(model);
        }
        public async Task<CajaEnt> ObtenerById(int Id)
        {
            return await _ICajaDom.ObtenerById(Id);
        }

        public async Task<IEnumerable<CajaEnt>> ObtenerByLikeNombre(string Nombre)
        {
            return await _ICajaDom.ObtenerByLikeNombre(Nombre);
        }
        public async Task<CajaValidacionDTO> ConsultarAperturaCaja(int idsede)
        {
            return await _ICajaDom.ConsultarAperturaCaja(idsede);
        }

        public async Task<CajaCuadreDTO> CuadreDeCaja(DateTime fecha, int idCaja, int idUsuario)
        {
            return await _ICajaDom.CuadreDeCaja(fecha, idCaja, idUsuario);
        }
        public async Task<int> VerificaEstadoCaja(DateTime fecha, int idCaja)
        {
            return await _ICajaDom.VerificaEstadoCaja(fecha, idCaja);
        }

        public async Task<CajaSeguimientoDiarioDTO> SeguimientoDiario(DateTime fecha,  int idUsuario)
        {
            return await _ICajaDom.SeguimientoDiario(fecha, idUsuario);
        }

        public async Task<bool> InsSale(PosSale model)
        {
            return await _IPosDom.insSale(model);
        }
        public async Task<bool> InsIzip(PosIzip model)
        {
            return await _IPosDom.insIzip(model);
        }
    }
}
