using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Data.Interface
{
    public interface IMaquinaSedeDom
    {
        Task<IEnumerable<MaquinaSedeGridDTO>> Obtener(int idEstado);
        Task<IEnumerable<MaquinaSedeGridDTO>> ObtenerBySede(int IdSede);
        Task<IEnumerable<MaquinaSedeGridDTO>> ObtenerByNombre(string Nombre);
        Task<IEnumerable<MaquinaSedeGridDTO>> ObtenerByFiltros(string Nombre, int IdSede);

        Task<MaquinaSedeEnt> ObtenerById(int Id);
        Task<Respuesta<MaquinaSedeEnt>> Insertar(MaquinaSedeEnt model);
        Task<Respuesta<MaquinaSedeEnt>> Modificar(MaquinaSedeEnt model);

        Task<List<MaquinaSedeGridDTO>> BuscarPorSedeyServicio(int idUsuario, int idSede, int idServicio);
        Task<List<MaquinaSedeGridDTO>> BuscarFicticios(int idUsuario, int idSede, int idServicio);
    }
}
