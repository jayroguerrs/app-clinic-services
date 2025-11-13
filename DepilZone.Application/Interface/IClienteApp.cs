using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Interface
{
    public interface IClienteApp
    {
        Task<IEnumerable<ClienteGridDTO>> Obtener(int topMax);
        Task<IEnumerable<ClienteGridDTO>> ObtenerByLikeNombre(string Nombre);
        Task<IEnumerable<ClienteGridDTO>> ObtenerPorPreferente(string Nombres, string Apellidos, string Numeros, string Email);

        Task<ClienteEnt> ObtenerFirmaById(int Id);

        Task<Respuesta<ClienteEnt>> Insertar(ClienteEnt model);
        Task<ClienteDTO> ObtenerById(int Id);
        Task<ClienteDTO> ObtenerPerfilById(int Id);
        Task<IEnumerable<ClienteZonaCorporalHistoricoDTO>> ObtenerTodasLasZonasCorporales(int Id);
        Task<IEnumerable<ClienteZonaCorporalHistoricoDTO>> ObtenerTodasLasZonasCorporalesPorServicio(int Id, int IdServicio);


        Task<Respuesta<ClienteEnt>> Modificar(ClienteEnt model);
        Task<Respuesta<ClienteEnt>> ModificarFirma(ClienteEnt model);
        Task<ClienteDatosMaestrosDTO> ObtenerDatosMaestros();

        Task<Respuesta<int>> ValidarNumeroCelular(int idCliente, string numeroCelular1, string numeroCelular2);
        Task<Respuesta<FichaAdmisionDTO>> ObtenerFichaAdmisionByIdCliente(int idCliente);
        Task<IEnumerable<ClienteGridDTO>> ObtenerByNumeroCelular(string numero1Pais, string numero1, string numero2Pais, string numero2);
        Task<ClienteConsultaDniDTO> BuscarPorDNIOnline(string dni);
        Task<Respuesta<ClienteEnt>> ActualizarFicha(FichaAdmisionEnt model);

        Task<List<ClienteDTO>> BuscarParametros(string p);

        Task<List<CitaDTO>> BuscarCitasAtendidas(int idCliente);

        Task<bool> VerificarClientePorDni(string documento);

        Task<bool> ActualizarDocumentoIdentidad(int idCliente, ClienteDTO model);

        Task<List<ClienteNuevoDTO>> ObtenerReporteDeNuevosClientes(DateTime fechaDesde, DateTime fechaHasta);
        Task<ClienteRucDTO> ObtenerRazonSocialClientebyRuc(string ruc);
        Task<ClienteDniDTO> ObtenerDatosClientebyDNI(string dni);
    }
}
