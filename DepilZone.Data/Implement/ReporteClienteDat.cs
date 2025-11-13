using DepilZone.Data.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Threading.Tasks;
namespace DepilZone.Data.Implement

{
    public class ReporteClienteDat : IReporteClienteDat
    {
        private readonly string _connectionString;
        public ReporteClienteDat(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
        public async Task<List<ClienteCumpleaniosDTO>> ObtenerCumpleanios(DateTime fechaDesde, DateTime fechaHasta, int idEstadoAtendido)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_ReporteClientes_Cumpleanios", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pFechaDesde", fechaDesde);
                cmd.Parameters.AddWithValue("pFechaHasta", fechaHasta);
                cmd.Parameters.AddWithValue("pIdEstadoAtendido", idEstadoAtendido);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadObtenerCumpleanios(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // READERS

        static async Task<List<ClienteCumpleaniosDTO>> ReadObtenerCumpleanios(DbDataReader reader)
        {
            try
            {
                List<ClienteCumpleaniosDTO> lista = new List<ClienteCumpleaniosDTO>();
                while (await reader.ReadAsync())
                {
                    ClienteCumpleaniosDTO obj = new ClienteCumpleaniosDTO
                    {

                        IdCliente = Convert.ToInt32(reader["IdCliente"]),
                        Nombre = Convert.ToString(reader["Nombre"]),
                        Edad = Convert.ToInt32(reader["Edad"]),
                        UltimaCita = DBNull.Value == reader["UltimaCita"] ? (DateTime?) null : Convert.ToDateTime(reader["UltimaCita"]),
                        UltimaCitaColor = DBNull.Value == reader["UltimaCitaColor"] ? null : Convert.ToString(reader["UltimaCitaColor"]),
                        IdUltimaCita = DBNull.Value == reader["IdUltimaCita"] ? (int?) null : Convert.ToInt32(reader["IdUltimaCita"]),
                        ProximaCita = DBNull.Value == reader["ProximaCita"] ? (DateTime?)null : Convert.ToDateTime(reader["ProximaCita"]),
                        ProximaCitaColor = DBNull.Value == reader["ProximaCitaColor"] ? null : Convert.ToString(reader["ProximaCitaColor"]),
                        IdProximaCita = DBNull.Value == reader["IdProximaCita"] ? (int?)null : Convert.ToInt32(reader["IdProximaCita"]),
                    };
                    lista.Add(obj);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
