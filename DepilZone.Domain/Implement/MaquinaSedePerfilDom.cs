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
    public class MaquinaSedePerfilDom : IMaquinaSedePerfilDom
    {

        private readonly IMaquinaSedePerfilDat _IMaquinaSedePerfilDat;
        public MaquinaSedePerfilDom(IMaquinaSedePerfilDat IMaquinaSedePerfilDat)
        {
            this._IMaquinaSedePerfilDat = IMaquinaSedePerfilDat;
        }
        public async Task<bool> Insertar(MaquinaSedePerfilDTO model)
        {
            return await _IMaquinaSedePerfilDat.Insertar(model);
        }
        public async Task<List<MaquinaSedePerfilDTO>> ObtenerByMaquinaSede(int idUsuario, int idMaquinaSede)
        {
            return await _IMaquinaSedePerfilDat.ObtenerByMaquinaSede(idUsuario, idMaquinaSede);
        }

    }
}