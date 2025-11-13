using DepilZone.Application.Interface;
using DepilZone.Data.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement
{
    public class MaquinaSedeApp : IMaquinaSedeApp
    {

        private readonly IMaquinaSedeDom _IMaquinaSedeDom;
        public MaquinaSedeApp(IMaquinaSedeDom IMaquinaSedeDom)
        {
            this._IMaquinaSedeDom = IMaquinaSedeDom;
        }

        public async Task<IEnumerable<MaquinaSedeGridDTO>> Obtener(int idEstado)
        {
            return await _IMaquinaSedeDom.Obtener(idEstado);
        }
        public async Task<IEnumerable<MaquinaSedeGridDTO>> ObtenerBySede(int IdSede)
        {
            return await _IMaquinaSedeDom.ObtenerBySede(IdSede);
        }
        public async Task<IEnumerable<MaquinaSedeGridDTO>> ObtenerByNombre(string Nombre)
        {
            return await _IMaquinaSedeDom.ObtenerByNombre(Nombre);
        }
        public async Task<IEnumerable<MaquinaSedeGridDTO>> ObtenerByFiltros(string Nombre, int IdSede)
        {
            return await _IMaquinaSedeDom.ObtenerByFiltros(Nombre, IdSede);
        }



        public async Task<Respuesta<MaquinaSedeEnt>> Insertar(MaquinaSedeEnt model)
        {
            return await _IMaquinaSedeDom.Insertar(model);
        }
        public async Task<Respuesta<MaquinaSedeEnt>> Modificar(MaquinaSedeEnt model)
        {
            return await _IMaquinaSedeDom.Modificar(model);
        }
        public async Task<MaquinaSedeEnt> ObtenerById(int Id)
        {
            return await _IMaquinaSedeDom.ObtenerById(Id);
        }

        public async Task<List<MaquinaSedeGridDTO>> BuscarPorSedeyServicio(int idUsuario, int idSede, int idServicio)
        {
            return await _IMaquinaSedeDom.BuscarPorSedeyServicio(idUsuario, idSede, idServicio);
        }

        public async Task<List<MaquinaSedeGridDTO>> BuscarFicticios(int idUsuario, int idSede, int idServicio)
        {
            return await _IMaquinaSedeDom.BuscarFicticios(idUsuario, idSede, idServicio);
        }

    }
}
