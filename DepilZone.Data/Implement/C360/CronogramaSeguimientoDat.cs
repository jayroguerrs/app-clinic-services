using DepilZone.Data.Interface.C360;
using DepilZone.Entidad.DTO;
using DepilZone.Entidad.DTO.C360;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Threading.Tasks;


namespace DepilZone.Data.Implement.C360
{
    public class CronogramaSeguimientoDat : ICronogramaSeguimientoDat
    {
        private readonly string _connectionString;

        public CronogramaSeguimientoDat(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public async Task<List<CronogramaSeguimientoDTO>> ObtenerByCronograma(int idCronograma)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_CronogramaSeguimiento_ObtenerByCronograma", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdCronograma", idCronograma);

                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadObtenerByCronograma(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }


        //****************************************************************** READERS


        static async Task<List<CronogramaSeguimientoDTO>> ReadObtenerByCronograma(DbDataReader reader)
        {
            try
            {
                List<CronogramaSeguimientoDTO> collection = new List<CronogramaSeguimientoDTO>();
                while (await reader.ReadAsync())
                {
                    CronogramaSeguimientoDTO obj = new CronogramaSeguimientoDTO();
                    obj.Id = Convert.ToInt32(reader["Id"]);
                    obj.IdCronograma = Convert.ToInt32(reader["IdCronograma"]);
                    obj.IdCronogramaSeguimientoConcepto = Convert.ToInt32(reader["IdCronogramaSeguimientoConcepto"]);
                    obj.Descripcion = Convert.ToString(reader["Descripcion"]);
                    obj.IdUsuarioRegistro = Convert.ToInt32(reader["IdUsuarioRegistro"]);
                    obj.FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"]);

                    // secondary
                    obj.Detalle = Convert.ToString(reader["Detalle"]);
                    obj.UsuarioRegistro = Convert.ToString(reader["UsuarioRegistro"]);
                    collection.Add(obj);
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