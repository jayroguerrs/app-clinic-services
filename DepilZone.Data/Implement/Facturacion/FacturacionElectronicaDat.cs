
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
	public class FacturacionElectronicaDat : IFacturacionElectronicaDat
	{
        private readonly string _connectionString;

        public FacturacionElectronicaDat(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
        public async Task<CitaDatosComprobanteDTO> ObtenerDatosComprobanteCita(int IdCita, int IdUsuario)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_ObtenerDatosParaComprobanteByCita", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdUsuario", IdUsuario);
                cmd.Parameters.AddWithValue("pIdCita", IdCita);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadObtenerDatosComprobanteCita(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }


        public async Task<List<CitaDetalleDatosComprobanteDTO>> ObtenerCitaDetalleComprobanteCita(int IdCita, int IdUsuario)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_ObtenerCitaDetalleParaComprobanteByCita", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdUsuario", IdUsuario);
                cmd.Parameters.AddWithValue("pIdCita", IdCita);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadObtenerCitaDetalleComprobanteCita(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }


        // READERS

        static async Task<CitaDatosComprobanteDTO> ReadObtenerDatosComprobanteCita(DbDataReader reader)
        {
            try
            {

                bool exito = true;
                string mensaje = "";
                string detalle = "";
                int codigoError = 0;

                while (await reader.ReadAsync())
                {
                    exito = Convert.ToBoolean(reader["Exito"]);
                    if (!exito)
                    {
                        mensaje = Convert.ToString(reader["Mensaje"]);
                        codigoError = Convert.ToInt32(reader["ErrorNumero"]);
                        detalle = Convert.ToString(reader["ErrorDetalle"]);
                        throw new AlertException(mensaje);
                    }
                }

                CitaDatosComprobanteDTO data = new CitaDatosComprobanteDTO();
                if (reader.NextResult())
                {
                    while (await reader.ReadAsync())
                    {
                        data.IdCita = Convert.ToInt32(reader["IdCita"]);
                        data.IdSede = Convert.ToInt32(reader["IdSede"]);
                        data.IdServicio = Convert.ToInt32(reader["IdServicio"]);
                        data.FechaCita = Convert.ToDateTime(reader["FechaCita"]);
                        data.NumeroBox = Convert.ToInt32(reader["NumeroBox"]);

                        data.IdMaquinaMarca = DBNull.Value != reader["IdMaquinaMarca"] ? Convert.ToInt32(reader["IdMaquinaMarca"]) : (int?)null;
                        data.MaquinaMarca = DBNull.Value != reader["MaquinaMarca"] ? Convert.ToString(reader["MaquinaMarca"]) : null;

                        data.IdAtendidoPor = DBNull.Value != reader["IdAtendidoPor"] ? Convert.ToInt32(reader["IdAtendidoPor"]) : (int?)null;
                        data.AtendidoPor = DBNull.Value != reader["AtendidoPor"] ? Convert.ToString(reader["AtendidoPor"]) : null;

                        data.IdCliente = Convert.ToInt32(reader["IdCliente"]);
                        data.NombreCliente = Convert.ToString(reader["NombreCliente"]);

                        data.IdTipoDocumentoCliente = DBNull.Value != reader["IdTipoDocumentoCliente"] ? Convert.ToInt32(reader["IdTipoDocumentoCliente"]) : (int?)null;
                        data.TipoDocumentoCliente = DBNull.Value != reader["TipoDocumentoCliente"] ? Convert.ToString(reader["TipoDocumentoCliente"]) : null;
                        data.DocumentoCliente = DBNull.Value != reader["DocumentoCliente"] ? Convert.ToString(reader["DocumentoCliente"]) : null;
                    }
                }

                return data;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        static async Task<List<CitaDetalleDatosComprobanteDTO>> ReadObtenerCitaDetalleComprobanteCita(DbDataReader reader)
        {
            try
            {

                bool exito = true;
                string mensaje = "";
                string detalle = "";
                int codigoError = 0;

                while (await reader.ReadAsync())
                {
                    exito = Convert.ToBoolean(reader["Exito"]);
                    if (!exito)
                    {
                        mensaje = Convert.ToString(reader["Mensaje"]);
                        codigoError = Convert.ToInt32(reader["ErrorNumero"]);
                        detalle = Convert.ToString(reader["ErrorDetalle"]);
                        throw new AlertException(mensaje);
                    }
                }

                List<CitaDetalleDatosComprobanteDTO> collection = new List<CitaDetalleDatosComprobanteDTO>();
                if (reader.NextResult())
                {
                    while (await reader.ReadAsync())
                    {
                        CitaDetalleDatosComprobanteDTO data = new CitaDetalleDatosComprobanteDTO();

                        data.Id = Convert.ToInt32(reader["Id"]);

                        data.IdCita = Convert.ToInt32(reader["IdCita"]);
                        data.Precio = Convert.ToDecimal(reader["Precio"]);
                        data.Sesion = Convert.ToInt32(reader["Sesion"]);

                        data.IdUnidadMedida = DBNull.Value != reader["IdUnidadMedida"] ? Convert.ToInt32(reader["IdUnidadMedida"]) : (int?)null;
                        data.UnidadMedida = DBNull.Value != reader["UnidadMedida"] ? Convert.ToString(reader["UnidadMedida"]) : null;
                        data.UnidadMedidaValor = DBNull.Value != reader["UnidadMedidaValor"] ? Convert.ToString(reader["UnidadMedidaValor"]) : null;
                        data.DescripcionUnidadMedida = DBNull.Value != reader["DescripcionUnidadMedida"] ? Convert.ToString(reader["DescripcionUnidadMedida"]) : null;

                        data.IdZona = Convert.ToInt32(reader["IdZona"]);
                        data.Zona = Convert.ToString(reader["Zona"]);

                        collection.Add(data);
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
