using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Data.Interface
{
	public interface ICajaDom
	{
        Task<IEnumerable<CajaEnt>> Obtener();
        Task<CajaValidacionDTO> ConsultarAperturaCaja(int idsede);
        Task<IEnumerable<CajaEnt>> ObtenerByLikeNombre(string Nombre);
        Task<CajaEnt> ObtenerById(int Id);
        Task<Respuesta<CajaEnt>> Insertar(CajaEnt model);
        Task<Respuesta<CajaEnt>> Modificar(CajaEnt model);
        Task<Respuesta<CajaEnt>> AbrirCerrar(CajaEnt model);
        Task<CajaCuadreDTO> CuadreDeCaja(DateTime fecha, int idCaja, int idUsuario);
        Task<int> VerificaEstadoCaja(DateTime fecha, int idCaja);
        Task<CajaSeguimientoDiarioDTO> SeguimientoDiario(DateTime fecha, int idUsuario);
    }
}
