
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
	public class ComprobanteEntidadTipoPagoDat : IComprobanteEntidadTipoPagoDat
	{
        private readonly string _connectionString;

        public ComprobanteEntidadTipoPagoDat(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
        public async Task<List<ComprobanteEntidadTipoPagoDTO>> Listar(int idUsuario)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_ComprobanteEntidadTipoPago_Listar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdUsuario", idUsuario);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadListar(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        
        // READERS

        static async Task<List<ComprobanteEntidadTipoPagoDTO>> ReadListar(DbDataReader reader)
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


                List<ComprobanteEntidadTipoPagoDTO> collection = new List<ComprobanteEntidadTipoPagoDTO>();
                if (reader.NextResult())
                {
                    while (await reader.ReadAsync())
                    {
                        ComprobanteEntidadTipoPagoDTO obj = new ComprobanteEntidadTipoPagoDTO();
                        obj.Id = Convert.ToInt32(reader["Id"]);
                        obj.Nombre = Convert.ToString(reader["Nombre"]);
                        obj.Valor = DBNull.Value == reader["Valor"] ? null : Convert.ToString(reader["Valor"]);
                        obj.IdEstado = Convert.ToInt32(reader["IdEstado"]);
                        collection.Add(obj);
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
