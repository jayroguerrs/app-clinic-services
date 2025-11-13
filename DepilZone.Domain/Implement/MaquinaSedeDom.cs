using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DepilZone.Data;
using DepilZone.Data.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;


namespace DepilZone.Domain
{
    public class MaquinaSedeDom : IMaquinaSedeDom
    {

        private readonly IMaquinaSedeDat _IMaquinaSedeDat;
        public MaquinaSedeDom(IMaquinaSedeDat IMaquinaSedeDat)
        {
            this._IMaquinaSedeDat = IMaquinaSedeDat;
        }
        public async Task<IEnumerable<MaquinaSedeGridDTO>> Obtener(int idEstado)
        {
            return await _IMaquinaSedeDat.Obtener(idEstado);
        }
        public async Task<IEnumerable<MaquinaSedeGridDTO>> ObtenerByNombre(string Nombre)
        {
            return await _IMaquinaSedeDat.ObtenerByNombre(Nombre);
        }
        public async Task<IEnumerable<MaquinaSedeGridDTO>> ObtenerBySede(int IdSede)
        {
            return await _IMaquinaSedeDat.ObtenerBySede(IdSede);
        }
        public async Task<IEnumerable<MaquinaSedeGridDTO>> ObtenerByFiltros(string Nombre, int IdSede)
        {
            return await _IMaquinaSedeDat.ObtenerByFiltros(Nombre, IdSede);
        }


        public async Task<Respuesta<MaquinaSedeEnt>> Insertar(MaquinaSedeEnt model)
        {
            return await _IMaquinaSedeDat.Insertar(model);
        }
        public async Task<Respuesta<MaquinaSedeEnt>> Modificar(MaquinaSedeEnt model)
        {
            return await _IMaquinaSedeDat.Modificar(model);
        }
        public async Task<MaquinaSedeEnt> ObtenerById(int Id)
        {
            return await _IMaquinaSedeDat.ObtenerById(Id);
        }

        public async Task<List<MaquinaSedeGridDTO>> BuscarPorSedeyServicio(int idUsuario, int idSede, int idServicio)
        {
            return await _IMaquinaSedeDat.BuscarPorSedeyServicio(idUsuario, idSede, idServicio);
        }

        public async Task<List<MaquinaSedeGridDTO>> BuscarFicticios(int idUsuario, int idSede, int idServicio)
        {
            return await _IMaquinaSedeDat.BuscarFicticios(idUsuario, idSede, idServicio);
        }

    }
}