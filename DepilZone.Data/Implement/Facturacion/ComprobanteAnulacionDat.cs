
using DepilZone.Data.Interface.Facturacion;
using DepilZone.Entidad.DTO.Facturacion;
using DepilZone.Entidad.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DepilZone.Data.Implement.Facturacion
{
    public class ComprobanteAnulacionDat : IComprobanteAnulacionDat
    {
        private readonly string _connectionString;

        public ComprobanteAnulacionDat(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
        public async Task<List<ComprobanteElectronicoAnulacionDTO>> Obtener(DateTime fechaDesde, DateTime fechaHasta, int idTipoComprobante, int idSede, int idUsuario)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_ComprobanteAnulacion_Obtener", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pFechaDesde", fechaDesde);
                cmd.Parameters.AddWithValue("pFechaHasta", fechaHasta);
                cmd.Parameters.AddWithValue("pIdTipoComprobante", idTipoComprobante);
                cmd.Parameters.AddWithValue("pIdSede", idSede);
                cmd.Parameters.AddWithValue("pIdUsuario", idUsuario);


                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadObtener(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }


        // READERS

        static async Task<List<ComprobanteElectronicoAnulacionDTO>> ReadObtener(DbDataReader reader)
        {
            try
            {
                bool err = true;
                string mensaje = "";
                string detalle = "";
                int codigoError = 0;

                while (await reader.ReadAsync())
                {
                    err = Convert.ToBoolean(reader["Error"]);
                    if (err)
                    {
                        mensaje = Convert.ToString(reader["Mensaje"]);
                        //codigoError = Convert.ToInt32(reader["ErrorNumero"]);
                        detalle = Convert.ToString(reader["Detalle"]);
                        throw new AlertException(mensaje);
                    }
                }


                List<ComprobanteElectronicoAnulacionDTO> collection = new List<ComprobanteElectronicoAnulacionDTO>();
                if (reader.NextResult())
                {
                    while (await reader.ReadAsync())
                    {
                        ComprobanteElectronicoAnulacionDTO model = new ComprobanteElectronicoAnulacionDTO();

                        model.Id = Convert.ToInt32(reader["Id"]);
                        model.Motivo = Convert.ToString(reader["Motivo"]);

                        model.IdTipoComprobante = Convert.ToInt32(reader["IdTipoComprobante"]);
                        model.TipoComprobante = Convert.ToString(reader["TipoComprobante"]);


                        model.IdSede = Convert.ToInt32(reader["IdSede"]);
                        model.Sede = Convert.ToString(reader["Sede"]);

                        model.Serie = Convert.ToString(reader["Serie"]);
                        model.Numero = Convert.ToInt32(reader["Numero"]);

                        model.Codigo = Convert.ToInt32(reader["Codigo"]);

                        model.IdEstadoSunat = Convert.ToInt32(reader["IdEstadoSunat"]);
                        model.EstadoSunat = Convert.ToString(reader["EstadoSunat"]);
                        model.EstadoSunatColor = Convert.ToString(reader["EstadoSunatColor"]);


                        model.SunatAcepto = Convert.ToBoolean(reader["SunatAcepto"]);
                        model.SunatTicketNumero = DBNull.Value == reader["SunatTicketNumero"] ? null :Convert.ToString(reader["SunatTicketNumero"]);

                        model.SunatDescripcion = DBNull.Value == reader["SunatDescripcion"] ? null : Convert.ToString(reader["SunatDescripcion"]);
                        model.SunatNota = DBNull.Value == reader["SunatNota"] ? null : Convert.ToString(reader["SunatNota"]);
                        model.SunatCodigoRespuesta = DBNull.Value == reader["SunatCodigoRespuesta"] ? null : Convert.ToString(reader["SunatCodigoRespuesta"]);
                        model.SunatSoapError = DBNull.Value == reader["SunatSoapError"] ? null : Convert.ToString(reader["SunatSoapError"]);

                        model.SunatUrlPdf = DBNull.Value == reader["SunatUrlPdf"] ? null : Convert.ToString(reader["SunatUrlPdf"]);
                        model.SunatUrlXml = DBNull.Value == reader["SunatUrlXml"] ? null : Convert.ToString(reader["SunatUrlXml"]);
                        model.SunatUrlCdr = DBNull.Value == reader["SunatUrlCdr"] ? null : Convert.ToString(reader["SunatUrlCdr"]);

                        model.IdUsuarioRegistro = Convert.ToInt32(reader["IdUsuarioRegistro"]);
                        model.IdUsuarioModifico = DBNull.Value == reader["IdUsuarioModifico"] ? (int?)null : Convert.ToInt32(reader["IdUsuarioModifico"]);

                        model.FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"]);
                        model.FechaModifico = DBNull.Value == reader["FechaModifico"] ? (DateTime?)null : Convert.ToDateTime(reader["FechaModifico"]);

                        // Secundario
                        model.UsuarioRegistro = Convert.ToString(reader["UsuarioRegistro"]);
                        model.UsuarioModifico = DBNull.Value == reader["UsuarioModifico"] ? null : Convert.ToString(reader["UsuarioModifico"]);

                        collection.Add(model);
                    }
                }

                return collection;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

    }
}
