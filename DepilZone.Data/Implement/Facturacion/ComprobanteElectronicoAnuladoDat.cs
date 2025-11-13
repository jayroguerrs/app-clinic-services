
using DepilZone.Data.Interface.Facturacion;
using DepilZone.Entidad.DTO.C360;
using DepilZone.Entidad.DTO.Facturacion;
using DepilZone.Entidad.Exceptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Reflection;
using System.Reflection.PortableExecutable;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DepilZone.Data.Implement.Facturacion
{
    public class ComprobanteElectronicoAnuladoDat : IComprobanteElectronicoAnuladoDat
    {
        private readonly string _connectionString;

        public ComprobanteElectronicoAnuladoDat(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
        public async Task<ComprobanteElectronicoMotivoAnuladoDTO> BuscarPorComprobante(int IdVenta, int IdUsuario)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_ComprobanteElectronicoAnulado_BuscarPorVenta", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdVenta", IdVenta);
                cmd.Parameters.AddWithValue("pIdUsuario", IdUsuario);


                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadBuscarPorComprobante(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }


        // READERS

        static async Task<ComprobanteElectronicoMotivoAnuladoDTO> ReadBuscarPorComprobante(DbDataReader reader)
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


                ComprobanteElectronicoMotivoAnuladoDTO model = new ComprobanteElectronicoMotivoAnuladoDTO();
                if (reader.NextResult())
                {
                    while (await reader.ReadAsync())
                    {
                        model.Id = Convert.ToInt32(reader["Id"]);
                        model.IdVenta = Convert.ToInt32(reader["IdVenta"]);
                        model.Motivo = Convert.ToString(reader["Motivo"]);
                        model.FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"]);
                        model.IdUsuarioRegistro = Convert.ToInt32(reader["IdUsuarioRegistro"]);
                        model.UsuarioRegistro = Convert.ToString(reader["UsuarioRegistro"]);
                    }
                }

                return model;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

    }
}
