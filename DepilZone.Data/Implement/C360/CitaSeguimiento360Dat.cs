using DepilZone.Data.Interface.C360;
using DepilZone.Entidad.DTO.C360;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Threading.Tasks;


namespace DepilZone.Data.Implement.C360
{
    public class CitaSeguimiento360Dat : ICitaSeguimiento360Dat
    {

        private readonly string _connectionString;

        public CitaSeguimiento360Dat(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
        public async Task<List<Cita360SeguimientoDTO>> BuscarByCita(int idCita)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_CitaSeguimiento360_ListarByCita", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdCita", idCita);

                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadBuscarByCita(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }


        //****************************************************************** READERS


        static async Task<List<Cita360SeguimientoDTO>> ReadBuscarByCita(DbDataReader reader)
        {
            try
            {
                List<Cita360SeguimientoDTO> collection = new List<Cita360SeguimientoDTO>();
                while (await reader.ReadAsync())
                {
                    Cita360SeguimientoDTO obj = new Cita360SeguimientoDTO();
                    obj.Id = Convert.ToInt32(reader["Id"]);
                    obj.IdCita = Convert.ToInt32(reader["IdCita"]);
                    obj.IdCitaSeguimientoConcepto = Convert.ToInt32(reader["IdCitaSeguimientoConcepto"]);
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