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
    public class MaquinaApp : IMaquinaApp
    {

        private readonly IMaquinaDom _IMaquinaDom;
        public MaquinaApp(IMaquinaDom IMaquinaDom)
        {
            this._IMaquinaDom = IMaquinaDom;
        }

        public async Task<IEnumerable<MaquinaEnt>> Obtener()
        {
            return await _IMaquinaDom.Obtener();
        }

        public async Task<Respuesta<MaquinaEnt>> Insertar(MaquinaEnt model)
        {
            return await _IMaquinaDom.Insertar(model);
        }
        public async Task<Respuesta<MaquinaEnt>> Modificar(MaquinaEnt model)
        {
            return await _IMaquinaDom.Modificar(model);
        }
        public async Task<MaquinaEnt> ObtenerById(int Id)
        {
            return await _IMaquinaDom.ObtenerById(Id);
        }

        public async Task<IEnumerable<MaquinaEnt>> ObtenerByLikeNombre(string Nombre)
        {
            return await _IMaquinaDom.ObtenerByLikeNombre(Nombre);
        }

        public async Task<List<MaquinaMinutosEnt>> ObtenerMinutos(DateTime fechaCita, int idSede)
        {
            return await _IMaquinaDom.ObtenerMinutos(fechaCita, idSede);
        }
    }
}
