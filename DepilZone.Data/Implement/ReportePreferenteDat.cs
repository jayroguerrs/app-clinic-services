using DepilZone.Data.Interface;
//using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Threading.Tasks;
namespace DepilZone.Data.Implement

{
    public class ReportePreferenteDat : IReportePreferenteDat
    {
        private readonly string _connectionString;
        public ReportePreferenteDat(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
        public async Task<List<PreferenteReporteMedioContactoDTO>> ObtenerReportePorMedioContacto(DateTime fechaDesde, DateTime fechaHasta, int idMedioContacto)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Preferente_ReporteMedioContacto", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.CommandTimeout = 900;
                cmd.Parameters.AddWithValue("pFechaDesde", fechaDesde);
                cmd.Parameters.AddWithValue("pFechaHasta", fechaHasta);
                cmd.Parameters.AddWithValue("pIdMedioContacto", idMedioContacto);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadObtenerReportePorMedioContacto(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public async Task<PreferenteReporteTotalDTO> ObtenerReporteTotal(DateTime fecha)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Preferente_ReporteTotal", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.CommandTimeout = 900;
                cmd.Parameters.AddWithValue("pFecha", fecha);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadObtenerReporteTotal(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        // READERS

        static async Task<List<PreferenteReporteMedioContactoDTO>> ReadObtenerReportePorMedioContacto(DbDataReader reader)
        {
            try
            {
                List<PreferenteReporteMedioContactoDTO> lista = new List<PreferenteReporteMedioContactoDTO>();
                while (await reader.ReadAsync())
                {
                    PreferenteReporteMedioContactoDTO obj = new PreferenteReporteMedioContactoDTO();

                    obj.Fecha = Convert.ToDateTime(reader["Fecha"]);
                    obj.TotalPreferentes = Convert.ToInt32(reader["TotalPreferentes"]);
                    obj.TotalAsignados = Convert.ToInt32(reader["TotalAsignados"]);
                    obj.TotalAgendados = Convert.ToInt32(reader["TotalAgendados"]);
                    obj.TotalEfectivos = Convert.ToInt32(reader["TotalEfectivos"]);
                    obj.TotalEfectivosNuevos = Convert.ToInt32(reader["TotalEfectivosNuevos"]);
                    obj.TotalEfectivosAntiguos = Convert.ToInt32(reader["TotalEfectivosAntiguos"]);
                    obj.IdMedioContacto = DBNull.Value == reader["IdMedioContacto"] ? (int?)null : Convert.ToInt32(reader["IdMedioContacto"]);
                    obj.MedioContacto = DBNull.Value == reader["MedioContacto"] ? null : Convert.ToString(reader["MedioContacto"]);

                    lista.Add(obj);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static async Task<PreferenteReporteTotalDTO> ReadObtenerReporteTotal(DbDataReader reader)
        {
            try
            {
                PreferenteReporteTotalDTO obj = new PreferenteReporteTotalDTO();
                while (await reader.ReadAsync())
                {

                    obj.TotalPreferentes = Convert.ToInt32(reader["TotalPreferentes"]);
                    obj.TotalAsignados = Convert.ToInt32(reader["TotalAsignados"]);
                    obj.TotalAgendados = Convert.ToInt32(reader["TotalAgendados"]);
                    obj.TotalEfectivos = Convert.ToInt32(reader["TotalEfectivos"]);
                    obj.TotalEfectivosNuevos = Convert.ToInt32(reader["TotalEfectivosNuevos"]);
                    obj.TotalEfectivosAntiguos = Convert.ToInt32(reader["TotalEfectivosAntiguos"]);

                }

                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
