using DepilZone.Data.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Domain.Implement
{
    public class CajaDom: ICajaDom
	{
		private readonly ICajaDat _ICajaDat;
		public CajaDom(ICajaDat ICajaDat)
		{
			this._ICajaDat = ICajaDat;
		}
		public async Task<IEnumerable<CajaEnt>> Obtener()
		{
			return await _ICajaDat.Obtener();
		}
        public async Task<Respuesta<CajaEnt>> Insertar(CajaEnt model)
        {
            return await _ICajaDat.Insertar(model);
        }
        public async Task<Respuesta<CajaEnt>> Modificar(CajaEnt model)
        {
            return await _ICajaDat.Modificar(model);
        }
        public async Task<CajaEnt> ObtenerById(int Id)
        {
            return await _ICajaDat.ObtenerById(Id);
        }
        public async Task<IEnumerable<CajaEnt>> ObtenerByLikeNombre(string Nombre)
        {
            return await _ICajaDat.ObtenerByLikeNombre(Nombre);
        }
        public async Task<CajaValidacionDTO> ConsultarAperturaCaja(int idsede)
        {
            return await _ICajaDat.ConsultarAperturaCaja(idsede);
        }
        public async Task<Respuesta<CajaEnt>> AbrirCerrar(CajaEnt model)
        {
            return await _ICajaDat.AbrirCerrar(model);
        }
        public async Task<CajaCuadreDTO> CuadreDeCaja(DateTime fecha, int idCaja, int idUsuario)
        {
            return await _ICajaDat.CuadreDeCaja(fecha, idCaja, idUsuario);
        }
        public async Task<int> VerificaEstadoCaja(DateTime fecha, int idCaja)
        {
            return await _ICajaDat.VerificaEstadoCaja(fecha, idCaja);
        }
        public async Task<CajaSeguimientoDiarioDTO> SeguimientoDiario(DateTime fecha, int idUsuario)
        {
            return await _ICajaDat.SeguimientoDiario(fecha, idUsuario);
        }
    }
}
