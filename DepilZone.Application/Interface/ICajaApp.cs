using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace DepilZone.Application.Interface
{
    public interface ICajaApp
	{
		Task<IEnumerable<CajaEnt>> Obtener();
		Task<Respuesta<CajaEnt>> Insertar(CajaEnt model);
		Task<Respuesta<CajaEnt>> Modificar(CajaEnt model);
		Task<Respuesta<CajaEnt>> AbrirCerrar(CajaEnt model);
		Task<CajaEnt> ObtenerById(int Id);
		Task<IEnumerable<CajaEnt>> ObtenerByLikeNombre(string Nombre);
		Task<CajaValidacionDTO> ConsultarAperturaCaja(int idsede);
		Task<CajaCuadreDTO> CuadreDeCaja(DateTime fecha, int idCaja, int idUsuario);
		Task<int> VerificaEstadoCaja(DateTime fecha, int idCaja);
        Task<CajaSeguimientoDiarioDTO> SeguimientoDiario(DateTime fecha, int idUsuario);
        Task<Boolean> InsSale(PosSale model);
        Task<Boolean> InsIzip(PosIzip model);
    }
}
