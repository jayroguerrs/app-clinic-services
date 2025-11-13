using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace DepilZone.Data.Interface
{
	public interface ICajaDat
	{
		Task<IEnumerable<CajaEnt>> Obtener();
		Task<IEnumerable<CajaEnt>> ObtenerByLikeNombre(string Nombre);

		Task<Respuesta<CajaEnt>> Insertar(CajaEnt model);
		Task<Respuesta<CajaEnt>> Modificar(CajaEnt model);
		Task<Respuesta<CajaEnt>> AbrirCerrar(CajaEnt model);
		Task<CajaEnt> ObtenerById(int Id);
		Task<CajaValidacionDTO> ConsultarAperturaCaja(int idsede);
		Task<CajaCuadreDTO> CuadreDeCaja(DateTime fecha, int idCaja, int idUsuario);
		Task<int> VerificaEstadoCaja(DateTime fecha, int idCaja);
        Task<CajaSeguimientoDiarioDTO> SeguimientoDiario(DateTime fecha, int idUsuario);
    }
}
