using System.Collections.Generic;
using System.Threading.Tasks;
using DepilZone.Api.CustomFilter;
using DepilZone.Application.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace DepilZone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class DocumentoPlantillaController : ControllerBase
    {
        private readonly IDocumentoPlantillaApp _documentoPlantilla;
        public DocumentoPlantillaController(IDocumentoPlantillaApp DocumentoPlantillaApp)
        {
            _documentoPlantilla = DocumentoPlantillaApp;
        }

        [HttpGet]
        [CustomFilter("000361")]
        public async Task<IEnumerable<DocumentoPlantillaDTO>> ObtenerListado()
        {
            return await _documentoPlantilla.ObtenerListado();
        }
        [HttpGet("{id}")]
        [CustomFilter("000362")]
        public async Task<Respuesta<DocumentoPlantillaEnt>> Find(int id)
        {
            return await _documentoPlantilla.ObtenerById(id);
        }
        [HttpPost]
        [CustomFilter("000363")]
        public async Task<Respuesta<DocumentoPlantillaEnt>> Create(DocumentoPlantillaDTO model)
        {
            return await _documentoPlantilla.Insertar(model);
        }
        [HttpPut]
        [CustomFilter("000364")]
        public async Task<Respuesta<DocumentoPlantillaEnt>> Update(DocumentoPlantillaDTO model)
        {
            return await _documentoPlantilla.Modificar(model);
        }
    }
}