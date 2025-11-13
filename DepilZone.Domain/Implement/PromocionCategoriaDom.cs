using DepilZone.Data.Interface;
using DepilZone.Domain.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Domain.Implement
{
    public class PromocionCategoriaDom : IPromocionCategoriaDom
    {
        private readonly IPromocionCategoriaDat _IPromocionCategoriaDat;
        public PromocionCategoriaDom(IPromocionCategoriaDat IPromocionCategoriaDat)
        {
            this._IPromocionCategoriaDat = IPromocionCategoriaDat;
        }


        public async Task<List<PromocionCategoriaDTO>> Listar() 
        {
            return await _IPromocionCategoriaDat.Listar();
        }
        public async Task<bool> Registrar(PromocionCategoriaDTO model)
        {
            return await _IPromocionCategoriaDat.Registrar(model);
        }
        public async Task<bool> Modificar(int id, PromocionCategoriaDTO model)
        {
            return await _IPromocionCategoriaDat.Modificar(id, model);
        }
    }
}
