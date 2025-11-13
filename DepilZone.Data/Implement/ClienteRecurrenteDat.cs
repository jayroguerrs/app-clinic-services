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
	public class ClienteRecurrenteDat : IClienteRecurrenteDat
	{
        private readonly string _connectionString;

        public ClienteRecurrenteDat(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
        public async Task<IEnumerable<ClienteRecurrenteDTO>> Obtener()
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_ClienteRecurrente_Obtener", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItems(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<IEnumerable<ClienteRecurrenteDTO>> Obtenercitafecha(DateTime fechaInicio, DateTime fechaTermino)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_ClienteRecurrente_Obtener_fecha", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pFechaInicio", fechaInicio);
                cmd.Parameters.AddWithValue("pFechaTermino", fechaTermino);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItems(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static async Task<IEnumerable<ClienteRecurrenteDTO>> ReadItems(DbDataReader reader)
        {
            try
            {
                IList<ClienteRecurrenteDTO> lista = new List<ClienteRecurrenteDTO>();
                while (await reader.ReadAsync())
                {
                    ClienteRecurrenteDTO obj = new ClienteRecurrenteDTO
                    {
                        id = Convert.ToInt32(reader["id"]),
                        //id = Convert.ToString(reader["id"]),
                        Nombres = Convert.ToString(reader["Nombres"]),
                        Cliente = Convert.ToString(reader["Cliente"]),
                        CantidadCitas = Convert.ToInt32(reader["CantidadCitas"]),
                        CantidadZonas = Convert.ToInt32(reader["CantidadZonas"]),
                        Celular = Convert.ToString(reader["Celular"]),
                        Documento = Convert.ToString(reader["Documento"]),

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
