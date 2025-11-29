using DepilZone.Data.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Application.Interface
{
    public interface IUsuarioApp
    {
        Task<IEnumerable<UsuarioGridDTO>> Obtener(bool idEstado);
        Task<IEnumerable<UsuarioGridDTO>> ObtenerListadoGrilla();
        Task<UsuarioEnt> ObtenerByIdUsuario(int IdUsuario);
        Task<IEnumerable<UsuarioGridDTO>> ObtenerByIdPerfil(string idPerfil, int idSede);
        Task<IEnumerable<UsuarioGridDTO>> ObtenerByIdPerfilUsuario(int idUsuario);
        Task<IEnumerable<UsuarioGridDTO>> ObtenerResponsableCaja();

        Task<IEnumerable<UsuarioGridDTO>>  ObtenerByLikeNombre(string Nombre);
        Task<Respuesta<UsuarioEnt>> Insertar(UsuarioEnt model);
        Task<Respuesta<UsuarioEnt>> Modificar(UsuarioEnt model);
        Task<Respuesta<LoginDTO>> Login(LoginDTO model);
        Task<List<MenuRutaDetDTO>> MenuUsuario(LoginDTO model);
        Task<Respuesta<UsuarioCambiarClaveDTO>> CambiarClave(UsuarioCambiarClaveDTO model);
        Task<List<UsuarioGridDTO>> ListarParaPreferentes();
        Task<List<EmpleadoDTO>> ListarParaPreferentesPorUsuario(int idPerfil);

        Task<List<MenuDTO>> ObtenerMenuByPerfil(int idPerfil);

        Task<List<ShortUser>> CollectionByEstado(int idEstado);

        Task<string> ObtenerClave(int idUsuario);

        Task<bool> CambiarClave(int idUsuario, string clave);

        Task<IEnumerable<UsuarioGridDTO>> ObtenerParaCita();
        Task<string> ObtenerClaveUsuario(int id);
        Task<UsuarioActualizarDatosDTO> ActualizarDatos(UsuarioActualizarDatosDTO model);
        Task<PersonalizarClinicDTO> PerzonalizarClinic(PersonalizarClinicDTO model);
        Task<IEnumerable<UsuarioGridDTO>> ObtenerListadoGrillaBySupervisor(int idSupervisor);
        Task<GeneralResponse<RespuestaConfirmarSupervisorDTO>> ConfirmarSupervisor(int idUsuario, string usuarioSupervisor);
        Task<GeneralResponse<bool>> CambiarEstadoAprobacion(int IdUsuario, byte EstadoUsuario);
        Task<byte> ObtenerEstadoAprobacionUsuario(int IdUsuario);
        Task<AccesoUsuarioDTO> ObtenerEstadoPrivilegioUsuario(int IdUsuario);
        Task<IEnumerable<SupervisorDTO>> ObtenerListadoSupervisores();
        Task<GeneralResponse<ClaveGenericaResult>> GenerarClaveGenerica(int idUsuario);
        Task<bool> CambiarClaveGenerica(int idUsuario, string clave);
    }
}
