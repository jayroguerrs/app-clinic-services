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
    public class MaquinaDom : IMaquinaDom
    {

        private readonly IMaquinaDat _IMaquinaDat;
        public MaquinaDom(IMaquinaDat IMaquinaDat)
        {
            this._IMaquinaDat = IMaquinaDat;
        }
        public async Task<IEnumerable<MaquinaEnt>> Obtener()
        {
            return await _IMaquinaDat.Obtener();
        }
        public async Task<Respuesta<MaquinaEnt>> Insertar(MaquinaEnt model)
        {
            return await _IMaquinaDat.Insertar(model);
        }
        public async Task<Respuesta<MaquinaEnt>> Modificar(MaquinaEnt model)
        {
            return await _IMaquinaDat.Modificar(model);
        }
        public async Task<MaquinaEnt> ObtenerById(int Id)
        {
            return await _IMaquinaDat.ObtenerById(Id);
        }
        public async Task<IEnumerable<MaquinaEnt>> ObtenerByLikeNombre(string Nombre)
        {
            return await _IMaquinaDat.ObtenerByLikeNombre(Nombre);
        }
        //public async Task<IEnumerable<MaquinaSedeEnt>> ObtenerByIdSede(int IdSede)
        //{
        //    return await _IMaquinaDat.ObtenerByIdSede(IdSede);
        //}

        public async Task<List<MaquinaMinutosEnt>> ObtenerMinutos(DateTime fechaCita, int idSede)
        {
            return await _IMaquinaDat.ObtenerMinutos(fechaCita, idSede);
        }
    }
}