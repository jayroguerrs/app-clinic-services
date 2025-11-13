using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Data.Response
{
    public class RClienteContrato
    {
        
        public Object VerContrato(ClienteContratoDTO model)
        {
            try
            {
                var response = new
                {
                    Id = model.Id,
                    NombreCliente = model.NombreCliente,
                    TipoDocumentoIdentidad = model.TipoDocumentoIdentidad,
                    DocumentoIdentidad = model.DocumentoIdentidad,
                    FechaRegistro = model.FechaRegistro,
                    Documentos = model.Documentos,
                    IdEstado = model.IdEstado,
                    Observacion = model.Observacion
                };

                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

    }
}
