using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DepilZone.Api.CustomFilter;
using DepilZone.Application.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace DepilZone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class DocumentoController : ControllerBase
    {
        private readonly IDocumentoApp _documento;
        public DocumentoController(IDocumentoApp DocumentoApp)
        {
            _documento = DocumentoApp;
        }
        [HttpGet("tipoDocumento")]
        [CustomFilter("000353")]
        public async Task<IEnumerable<DocumentoTipoEnt>> ObtenerTipoDocumento()
        {
            try
            {
                return await _documento.ObtenerTipoDocumento();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet("tipoDocumento/perfil/{idPerfil}")]
        [CustomFilter("000354")]
        public async Task<IEnumerable<DocumentoTipoEnt>> ObtenerTipoDocumentoByPerfil(int idPerfil)
        {
            try
            {
                return await _documento.ObtenerTipoDocumentoByPerfil(idPerfil);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }        
        [HttpGet("plantilla/{idPlantilla}")]
        [CustomFilter("000355")]
        public async Task<DocumentoPlantillaDTO> ObtenerPlantilla(int idPlantilla)
        {
            try
            {
                return await _documento.ObtenerPlantilla(idPlantilla);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        [CustomFilter("000356")]
        public async Task<Respuesta<DocumentoDTO>> Post(DocumentoEnt model)
        {
            try
            {
                return await _documento.Insertar(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        [HttpGet]
        [CustomFilter("000357")]
        public async Task<IEnumerable<DocumentoDTO>> ObtenerListado()
        {
            try
            {
                return await _documento.ObtenerListado();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet("cliente/{idClient}")]
        [CustomFilter("000358")]
        public async Task<IEnumerable<DocumentoDTO>> CollectionByClientId( int idClient )
        {
            try
            {
                return await _documento.ObtenerListadoByCliente(idClient);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPut("{id}/anular")]
        [CustomFilter("000359")]
        public async Task<Respuesta<DocumentoDTO>> cancelDocument(int id)
        {
            try
            {
                return await _documento.AnularDocumento(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}